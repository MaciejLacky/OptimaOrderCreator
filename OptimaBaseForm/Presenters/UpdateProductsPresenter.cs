using OptimaBaseForm.BsLogic.CreateOrders;
using OptimaBaseForm.Optima;
using OptimaBaseForm.Properties;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Presenters
{
    public class UpdateProductsPresenter
    {
        private IUpdateProductsView view;
        private IMainView mainView;
        private DataTable dt;




        public UpdateProductsPresenter(IUpdateProductsView view, IMainView mainView)
        {
            this.view = view;
            this.mainView = mainView;
            this.dt = new DataTable();
            this.view.SaveEvent += SaveConfig;
            this.view.CancelEvent += CancelView;
            this.view.LoadEvent += LoadConfig;
            this.view.CreateOrderEvent += CreateOrder;
            this.view.DeleteDataGridEvent += DeleteDataGridEvent;
            this.view.AddDataGridEvent += AddDataGridEvent;
            this.view.Show();
        }

        private void CreateOrder(object? sender, EventArgs e)
        {            
            string productName = this.view.OrderRotaionProductName;
            int idMag = this.view.OrderRotationMag;
            int daysBack = Convert.ToInt32(this.view.OrderRotationDaysBack);
            int idAtrProd = this.view.OrderRotationAtrProductId;
            string atrProdValue = this.view.OrderRotationAtrProductValue;
            string codeKnt = this.view.OrderRotationKnt;
            int addIfZero = Convert.ToInt32(this.view.OrderRotationAddIfZero);
            int defaultMin = Convert.ToInt32(this.view.OrderRotationMinValue);
            int defaultMax = Convert.ToInt32(this.view.OrderRotationMaxValue);

            var data = Config.GetProductSaleByProductName(productName,daysBack,idAtrProd,atrProdValue,idMag);
            var dataDto = ToSupplier.Dto(data);
            this.view.LogInfo($"Pobrano {data.Rows.Count} produktów...",2);
            if (this.view.LastKntByOrder)
                ToSupplier.GetLastKntOnProducts(dataDto);
            if (dataDto.Count == 0) return;
            this.view.LogInfo($"Tworze zamówienia na {data.Rows.Count} produktów...", 2);
            var docNumbers = ToSupplier.Create(dataDto,addIfZero,defaultMin,defaultMax,codeKnt, idMag);
            this.view.LogInfo($" {docNumbers}... zakończono ", 2);
        }

        private void AddDataGridEvent(object? sender, EventArgs e)
        {
            int min = Convert.ToInt32(this.view.UpdProductMIn);
            int max = Convert.ToInt32(this.view.UpdProductMax);
            int amount = Convert.ToInt32(this.view.UpdProductOrderAmount);
            int weight = Convert.ToInt32(this.view.UpdProductWeight);
            string group = this.view.UpdProdGroupsValue;
            int idgroup = this.view.UpdProdGroupsValueId;
            Config.AddMaping(min, group, max, "", amount, "", MappingTypeDB.UpdateProducts);
            LoadDataGridViews();
        }

        private void DeleteDataGridEvent(object? sender, EventArgs e)
        {
            DataGridViewCellCollection cell = (DataGridViewCellCollection)view.SelectedRow;
            Config.DeleteMaping(Convert.ToInt32(cell[0].Value));
            LoadDataGridViews();
        }

        private void LoadConfig(object? sender, EventArgs e)
        {
            LoadComboboxes();
            LoadDataGridViews();
            view.OrderRotationMaxValue = Settings.Default.OrderRotationMaxValue;
            view.OrderRotationMinValue = Settings.Default.OrderRotationMinValue;
            view.OrderRotationMag = Settings.Default.OrderRotationMag;
            view.OrderRotationDaysBack = Settings.Default.OrderRotationDaysBack;
            view.OrderRotaionProductName = Settings.Default.OrderRotaionProductName;
            //view.OrderRotationKnt = Settings.Default.OrderRotationKnt;
            view.OrderRotationKntId = Settings.Default.OrderRotationKntId;
            view.OrderRotationAddIfZero = Settings.Default.OrderRotationAddIfZero;
            view.OrderRotationAtrProductId = Settings.Default.OrderRotationAtrProductId;
            view.OrderRotationAtrProductValue = Settings.Default.OrderRotationAtrProductValue;
            view.LastKntByOrder = Settings.Default.LastKntByOrder;

        }

        private void CancelView(object? sender, EventArgs e)
        {
            this.view.Close();
            this.mainView.ShowMainPanel();
        }

        private void SaveConfig(object? sender, EventArgs e)
        {
            
            Settings.Default.OrderRotationMaxValue = view.OrderRotationMaxValue;
            Settings.Default.OrderRotationMinValue = view.OrderRotationMinValue;
            Settings.Default.OrderRotationMag = view.OrderRotationMag;
            Settings.Default.OrderRotationDaysBack = view.OrderRotationDaysBack;
            Settings.Default.OrderRotaionProductName = view.OrderRotaionProductName;
            Settings.Default.OrderRotationKnt = view.OrderRotationKnt;
            Settings.Default.OrderRotationAddIfZero = view.OrderRotationAddIfZero;
            Settings.Default.OrderRotationAtrProductId = view.OrderRotationAtrProductId;
            Settings.Default.OrderRotationAtrProductValue = view.OrderRotationAtrProductValue;
            Settings.Default.OrderRotationKntId = view.OrderRotationKntId;
            Settings.Default.LastKntByOrder = view.LastKntByOrder;           
            Settings.Default.Save();
        }

        private void LoadDataGridViews()
        {
            view.LoadDataGridView(Config.GetMapping(MappingTypeDB.UpdateProducts), 1);
        }

        public void LoadComboboxes()
        {
            // Get values from model
            Dictionary<int, string> valuesPrice = Config.GetGroupsFromOPT();
            Dictionary<int, string> valuesKnt = Config.GetKntSupplier();
            Dictionary<int, string> valuesAtr = Config.GetAtrProdValue();
            Dictionary<int, string> valuesMag = Config.GetOptIdMag();

            if (valuesPrice != null && valuesPrice.Count > 0)
                view.LoadCombobox(valuesPrice, "optimaGroup");

            if (valuesKnt != null && valuesKnt.Count > 0)
                view.LoadCombobox(valuesKnt, "optimaKnt");

            if (valuesAtr != null && valuesAtr.Count > 0)
                view.LoadCombobox(valuesAtr, "optimaProductAtrId");

            if (valuesMag != null && valuesMag.Count > 0)
                view.LoadCombobox(valuesMag, "optimaMag");

        }
    }
}
