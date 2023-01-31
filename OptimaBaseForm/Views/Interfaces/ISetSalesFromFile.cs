using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface ISetSalesFromFile : IBaseView, IComboboxView,IDataGridView, ILogInfoUser
    {
        //public string LogInfo { get; set; }
        public string FilePath { get; set; }
        public string SpecialOfferName { get; set; }
        public DateTime SpecialOfferFrom { get; set; }
        public DateTime SpecialOfferTo { get; set; }
        public int UpdAtrSaleId { get; set; }
        public string UpdAtrSaleValue { get; set; }
        public int SpecialOfferPriceType { get; set; }

        public event EventHandler AddSpecialOfferEvent;
        public event EventHandler SpecialOfferDeleteEvent;
        public event EventHandler PickLogPathEvent;
       
       
    }
}
