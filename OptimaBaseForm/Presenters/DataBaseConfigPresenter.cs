using OptimaBaseForm.Properties;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimaBaseForm.Presenters
{
    public class DataBaseConfigPresenter 
    {
        private IDataBaseConfigView view;
        private IMainView mainView;

        public DataBaseConfigPresenter(IDataBaseConfigView view, IMainView mainView)
        {
            this.view = view;
            this.mainView = mainView;
            this.view.SaveEvent += SaveConfig;
            this.view.CancelEvent += CancelView;
            this.view.LoadEvent += LoadConfig;
            this.view.SqlPrepareTables += SqlPrepareTables;
            this.view.SqlPrepareMethods += SqlPrepareMethods;
            this.view.Show();
        }

        private void SqlPrepareTables(object? sender, EventArgs e) => SqlPrepareTables();
        private void SqlPrepareMethods(object? sender, EventArgs e) => SqlPrepareMethods();

        private void LoadConfig(object? sender, EventArgs e) => LoadConfig();
        private void SaveConfig(object? sender, EventArgs e) => SaveConfig();
        private void CancelView(object? sender, EventArgs e)
        {
            this.view.Close();
            this.mainView.ShowMainPanel();
        }

        private void LoadConfig()
        {
            LoadCombobox();

            view.OptIdAtrStatusZamOpt = Settings.Default.OptIdAtrStatusZamOpt;
            view.LogPath = Settings.Default.LogPath;
            view.DeleteOldLogs = Settings.Default.DeleteOldLogs;
            view.DeleteOldLogsDays = Settings.Default.DeleteOldLogsDays;
            view.CompanyGID = Settings.Default.CompanyGID;
        }

        public void LoadCombobox()
        {
            // Get values from model
            Dictionary<int, string> values = new Dictionary<int, string>();
            values.Add(2, "jeden");
            values.Add(1, "dwa");
            //another data for combox
            Dictionary<int, string> values1 = new Dictionary<int, string>();
            values1.Add(2, "trzy");
            values1.Add(5, "cztery");


            // Populate combobox with values
            view.LoadCombobox(values, "rodzaj1");
            view.LoadCombobox(values1, "rodzaj2");
        }

        private void SaveConfig()
        {
            Settings.Default.OptIdAtrStatusZamOpt =  view.OptIdAtrStatusZamOpt;
            Settings.Default.LogPath = view.LogPath;
            Settings.Default.DeleteOldLogs = view.DeleteOldLogs;
            Settings.Default.DeleteOldLogsDays = view.DeleteOldLogsDays;
            Settings.Default.CompanyGID = view.CompanyGID;

            Settings.Default.Save();
        }

        private void SqlPrepareTables()
        {

            try
            {
                string[] procedures = SqlSplitProcedures(0).Split(new string[] { "GO" }, StringSplitOptions.None);

                using (SqlConnection conn = new SqlConnection(Methods.GetSqlConnectionString()))
                {
                    conn.Open();
                    foreach (string procedure in procedures)
                    {
                        if (string.IsNullOrWhiteSpace(procedure)) continue;

                        try { new SqlCommand(procedure, conn).ExecuteNonQuery(); }
                        catch (Exception ex)
                        {
                            if (procedure.Contains("IF EXISTS(SELECT * FROM [ELTES].[Mapping]) AND (SELECT COUNT([Map_OptId]) FROM [ELTES].[BlMapping])=0")) continue;
                            Log.Error("Tworzeniem tabel/pól sql " + ex.Message);
                        }
                    }
                }
                MessageBox.Show("Tabele zostały dostosowane.", "Sukces!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Problem ogólny z tworzeniem tabel/pól sql ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Problem ogólny z tworzeniem tabel/pól sql " + ex.Message);
            }
        }

        public void SqlPrepareMethods()
        {
            try
            {
                string[] procedures = SqlSplitProcedures(1).Split(new string[] { "GO" }, StringSplitOptions.None);
                using (SqlConnection conn = new SqlConnection(Methods.GetSqlConnectionString()))
                {
                    conn.Open();
                    foreach (string procedure in procedures)
                    {
                        if (string.IsNullOrWhiteSpace(procedure)) continue;

                        try { new SqlCommand(procedure, conn).ExecuteNonQuery(); }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Problem z tworzeniem procedur sql ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.Error("Problem z tworzeniem procedur sql " + ex.Message);
                        }
                    }

                }
                MessageBox.Show("Metody zostały dostosowane.", "Sukces!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Problem ogólny  z tworzeniem procedur sql ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Problem ogólny z tworzeniem procedur sql " + ex.Message);
            }
        }

        private string SqlSplitProcedures(int num)
        {
            string procedures;
            string fileName = "\\Procedures.sql";

            try { procedures = File.ReadAllText(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + fileName); }
            catch (Exception)
            {
                Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                procedures = File.ReadAllText(Environment.CurrentDirectory.Replace(@"bin\Debug", "") + fileName);
            }



            string[] splittedProcedures = procedures.Split(new string[] { "--StringSplitter" }, StringSplitOptions.None);
            return splittedProcedures[num];
        }

    }
}
