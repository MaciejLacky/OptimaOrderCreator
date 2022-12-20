using OptimaBaseForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IDataBaseConfigView : IBaseView, IComboboxView
    {
        public string LogPath { get; set; }
        public decimal DeleteOldLogsDays { get; set; }
        public string CompanyGID { get; set; }
        public string Log { get; set; }
        public bool DeleteOldLogs { get; set; }
        public int OptIdAtrStatusZamOpt { get; set; }
        event EventHandler SqlPrepareTables;
        event EventHandler SqlPrepareMethods;
        event EventHandler SqlUpdateBlAllproductsQuantity;
        event EventHandler SqlUpdateBlAllproductsPrices;
        event EventHandler ShowMappingProducts;
        event EventHandler DeleteProdsMapping;
    }
}
