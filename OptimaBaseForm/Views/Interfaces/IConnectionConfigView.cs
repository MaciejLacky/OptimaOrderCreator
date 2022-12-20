using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IConnectionConfigView : IBaseView
    {
        public string OptPath { get; set; }
        public string OptUser { get; set; }
        public string OptPass { get; set; }
        public string OptCompany { get; set; }
        public string ServerKey { get; set; }
        public bool OptModulyUsera { get; set; }
        public bool OptKBP { get; set; }
        public bool OptHAP { get; set; }


        public string BLToken { get; set; }
        public string NazwaSerweraSql { get; set; }
        public string NazwaBazySql { get; set; }
        public string LoginSql { get; set; }
        public string HasloSql { get; set; }
        public string SqlOptBazaKonfigConnectionStr { get; set; }
        public bool WindowsAuth { get; set; }
        public bool SqlAuth { get; set; }
        public bool SqlConnStringPobierajZOpt { get; set; }

        event EventHandler OptConnectionTest;
        event EventHandler PickOptPath;
        event EventHandler CheckSqlConnection;
    }
}
