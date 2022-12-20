using OptimaBaseForm.Properties;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Presenters
{
    public class ConnectionConfigPresenter
    {       
        private IMainView mainView;
        private IConnectionConfigView view;

        public ConnectionConfigPresenter(IConnectionConfigView view, IMainView mainView)
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
            view.OptPath = Settings.Default.OptPath;
            view.OptPass = Settings.Default.OptPass;
            view.OptHAP = Settings.Default.OptHAP;
            view.OptUser = Settings.Default.OptUser;
            view.OptCompany = Settings.Default.OptCompany;
            view.OptKBP = Settings.Default.OptKBP;
            view.OptModulyUsera = Settings.Default.OptModulyUsera;
            view.ServerKey = Settings.Default.ServerKey;
            view.SqlConnStringPobierajZOpt = Settings.Default.SqlConnStringPobierajZOpt;
            view.NazwaSerweraSql = Settings.Default.NazwaSerweraSql;
            view.NazwaBazySql = Settings.Default.NazwaBazySql;
            view.WindowsAuth = Settings.Default.WindowsAuth;
            view.SqlAuth = Settings.Default.SqlAuth;
            view.LoginSql = Settings.Default.LoginSql;
            view.HasloSql = Settings.Default.HasloSql;
            view.SqlOptBazaKonfigConnectionStr = Settings.Default.SqlOptBazaKonfigConnectionStr;
            view.BLToken = Settings.Default.BLToken;
        }
        private void SaveConfig()
        {

            Settings.Default.OptPath = view.OptPath;
            Settings.Default.OptPass = view.OptPass;
            Settings.Default.OptHAP = view.OptHAP;
            Settings.Default.OptUser = view.OptUser;
            Settings.Default.OptCompany = view.OptCompany;
            Settings.Default.OptKBP = view.OptKBP;
            Settings.Default.OptModulyUsera = view.OptModulyUsera;
            Settings.Default.ServerKey = view.ServerKey;
            Settings.Default.SqlConnStringPobierajZOpt = view.SqlConnStringPobierajZOpt;
            Settings.Default.NazwaSerweraSql = view.NazwaSerweraSql;
            Settings.Default.NazwaBazySql = view.NazwaBazySql;
            Settings.Default.WindowsAuth = view.WindowsAuth;
            Settings.Default.SqlAuth = view.SqlAuth;
            Settings.Default.LoginSql = view.LoginSql;
            Settings.Default.HasloSql = view.HasloSql;
            Settings.Default.SqlOptBazaKonfigConnectionStr = view.SqlOptBazaKonfigConnectionStr;
            Settings.Default.BLToken = view.BLToken;


            Settings.Default.Save();
        }


    }
}
