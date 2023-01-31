using OptimaBaseForm.Presenters.Common;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimaBaseForm.Views
{
    public partial class ConnectionConfigView : Form, IConnectionConfigView
    {
     

        public ConnectionConfigView()
        {
            InitializeComponent();
            btnCloseView.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSaveView.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            btnOptConnectionTest.Click += delegate { OptConnectionTest?.Invoke(this, EventArgs.Empty); };
            btnCheckSqlConnection.Click += delegate { CheckSqlConnection?.Invoke(this, EventArgs.Empty); };
            btnPickOptPath.Click += delegate { PickOptPath?.Invoke(this, EventArgs.Empty); };           
            Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string OptPath { get => tbOptPath.Text; set => tbOptPath.Text = value; }
        public string OptUser { get => tbOptUser.Text; set => tbOptUser.Text = value; }
        public string OptPass { get => tbOptPass.Text; set => tbOptPass.Text = value; }
        public string OptCompany { get => tbOptCompany.Text; set => tbOptCompany.Text = value; }
        public string ServerKey { get => tbServerKey.Text; set => tbServerKey.Text = value; }
        public bool OptModulyUsera { get => cbOptModulyUsera.Checked; set => cbOptModulyUsera.Checked = value; }
        public bool OptKBP { get => cbOptKBP.Checked; set => cbOptKBP.Checked = value; }
        public bool OptHAP { get => cbOptHAP.Checked; set => cbOptHAP.Checked = value; }
        public string BLToken { get => tbBLToken.Text; set => tbBLToken.Text = value; }
        public string NazwaSerweraSql { get => tbNazwaSerweraSql.Text; set => tbNazwaSerweraSql.Text = value; }
        public string NazwaBazySql { get => tbNazwaBazySql.Text; set => tbNazwaBazySql.Text = value; }
        public string LoginSql { get => tbLoginSql.Text; set => tbLoginSql.Text = value; }
        public string HasloSql { get => tbHasloSql.Text; set => tbHasloSql.Text = value; }
        public string SqlOptBazaKonfigConnectionStr { get => tbSqlOptBazaKonfigConnectionStr.Text; set => tbSqlOptBazaKonfigConnectionStr.Text = value; }
        public bool WindowsAuth { get => rbWindowsAuth.Checked; set => rbWindowsAuth.Checked = value; }
        public bool SqlAuth { get => rbSqlAuth.Checked; set => rbSqlAuth.Checked = value; }
        public bool SqlConnStringPobierajZOpt { get => cbSqlConnStringPobierajZOpt.Checked; set => cbSqlConnStringPobierajZOpt.Checked = value; }
       

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler OptConnectionTest;
        public event EventHandler LoadEvent;
        public event EventHandler PickOptPath;
        public event EventHandler CheckSqlConnection;

        public static ConnectionConfigView GetInstance(Form parentContainer)
        {
            return InstanceForm<ConnectionConfigView>.Get(parentContainer);
        }

        private void btnPickOptPath_Click(object sender, EventArgs e)
        {
            if (fbdOptPath.ShowDialog() == DialogResult.Cancel) return;
            var katalogOpt = fbdOptPath.SelectedPath;

            if (File.Exists(katalogOpt + "\\optima.exe") || File.Exists(katalogOpt + "\\Comarch OPT!MA.exe"))
            {
                tbOptPath.Text = katalogOpt;
                return;
            }
            MessageBox.Show("Katalog nie zawiera pliku optima.exe", "informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbOptModulyUsera_CheckedChanged(object sender, EventArgs e)
        {
            cbOptKBP.Visible = !cbOptModulyUsera.Checked;
            cbOptHAP.Visible = !cbOptModulyUsera.Checked;
        }

        private void cbSqlConnStringPobierajZOpt_CheckedChanged(object sender, EventArgs e) => panelSql.Visible = !cbSqlConnStringPobierajZOpt.Checked;
       
    }
}
