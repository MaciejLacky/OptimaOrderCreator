using OptimaBaseForm.Properties;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
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
            this.view.Show();
        }

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
    }
}
