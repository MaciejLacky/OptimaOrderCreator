using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IUpdateProductsView : IBaseView, IComboboxView,IDataGridView, ILogInfoUser
    {
        public int UpdProdGroupsValueId { get; set; }
        public string? UpdProdGroupsValue { get; set; }
        public decimal UpdProductMIn { get; set; }
        public decimal UpdProductMax { get; set; }
        public decimal UpdProductOrderAmount { get; set; }
        public decimal UpdProductWeight { get; set; }
        public decimal UpdProductHigh { get; set; }
        public decimal UpdProductWidth { get; set; }
        public decimal UpdProductLength { get; set; }
        public bool CreateOrderRotation { get; set; }
        public decimal OrderRotationDaysBack { get; set; }
        public string OrderRotaionProductName { get; set; }
        public int OrderRotationAtrProductId { get; set; }
        public string OrderRotationAtrProductValue { get; set; }
        public int OrderRotationMag { get; set; }
        public decimal OrderRotationAddIfZero { get; set; }
        public decimal OrderRotationMinValue { get; set; }
        public decimal OrderRotationMaxValue { get; set; }
        public bool LastKntByOrder { get; set; }
        public string OrderRotationKnt { get; }
        public int OrderRotationKntId { get; set; }
        event EventHandler CreateOrderEvent;
        public ProgressBar ProgressBarCreateOrder { get; set; }
        
    }
}
