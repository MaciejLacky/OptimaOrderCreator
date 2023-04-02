using OptimaBaseForm.BsLogic.SaleFromFiles;
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
    public class SetSalesFromFilePresenter
    {
        private ISetSalesFromFile view;
        private IMainView mainView;
        private DataTable dt;
        



        public SetSalesFromFilePresenter(ISetSalesFromFile view, IMainView mainView)
        {
            this.view = view;
            this.mainView = mainView;
            this.dt = new DataTable();
            this.view.SaveEvent += SaveConfig;
            this.view.CancelEvent += CancelView;
            this.view.LoadEvent += LoadConfig;
            this.view.AddSpecialOfferEvent += AddSpecialPrice;
            this.view.SpecialOfferDeleteEvent += DeleteSpecialPrice;
            this.view.Show();
        }

      

       

        private void AddSpecialPrice(object? sender, EventArgs e) => AddSpecialPrice();
        private void DeleteSpecialPrice(object? sender, EventArgs e) => DeleteSpecialPrice();
        private void LoadConfig(object? sender, EventArgs e) => LoadConfig();
        private void SaveConfig(object? sender, EventArgs e) => SaveConfig();
        private void CancelView(object? sender, EventArgs e)
        {
            this.view.Close();
            this.mainView.ShowMainPanel();
        }

        private void LoadConfig()
        {
            LoadComboboxes();
            LoadDataGridViews();
            view.FilePath = Settings.Default.FilePathSFF;
            view.SpecialOfferName = Settings.Default.SpecialOfferNameSFF;
            view.SpecialOfferPriceType = Settings.Default.SpecialOfferPriceTypeIdSFF;
            view.UpdAtrSaleId = Settings.Default.UpdAtrSaleIdSFF;
            view.UpdAtrSaleValue = Settings.Default.UpdAtrSaleValueSFF;
            view.SpecialOfferFrom = Settings.Default.SpecialOfferFrom;
            view.SpecialOfferTo = Settings.Default.SpecialOfferTo;

        }

        private void SaveConfig()
        {
            Settings.Default.FilePathSFF = view.FilePath;
            Settings.Default.SpecialOfferNameSFF = view.SpecialOfferName;
            Settings.Default.SpecialOfferPriceTypeIdSFF = view.SpecialOfferPriceType;
            Settings.Default.UpdAtrSaleIdSFF = view.UpdAtrSaleId;
            Settings.Default.UpdAtrSaleValueSFF = view.UpdAtrSaleValue;
            Settings.Default.SpecialOfferFrom = view.SpecialOfferFrom;
            Settings.Default.SpecialOfferTo = view.SpecialOfferTo;

            Settings.Default.Save();
        }

        private void LoadDataGridViews()
        {
            view.LoadDataGridView(Config.GetMapping(MappingTypeDB.SpecialPrice), 2);
        }

        public void LoadComboboxes()
        {
            // Get values from model
            Dictionary<int, string> valuesPrice = Config.GetPricesFromOPT();
            Dictionary<int, string> valuesAtr = Config.GetAtrProdValue();

            if (valuesPrice != null && valuesPrice.Count>0)
            view.LoadCombobox(valuesPrice, "typePrice");

            if (valuesAtr != null && valuesAtr.Count > 0)
                view.LoadCombobox(valuesAtr, "atr");          
        }

        private void DeleteSpecialPrice()
        {
            DataGridViewCellCollection cell = (DataGridViewCellCollection)view.SelectedRow;
            view.LogInfo($"Usuwam promocje {cell[2].Value.ToString()}...", 1);
            SaleFromFile.Delete(Convert.ToInt32(cell[0].Value), cell[2].Value.ToString());

            LoadDataGridViews();
            view.LogInfo($"Zakończono", 1);
        } 

        private void AddSpecialPrice() 
        {
            view.LogInfo("Dodaje promocje...", 1);
            SaveConfig();
            
            SaleFromFile.Add();
            LoadDataGridViews();

            view.LogInfo($"Zakończono", 1);
        } 
       

    }
}
