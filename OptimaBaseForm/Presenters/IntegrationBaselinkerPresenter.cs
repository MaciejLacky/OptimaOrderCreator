using OptimaBaseForm.Properties;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Presenters
{
   
    public class IntegrationBaselinkerPresenter
    {
         private IIntegrationBaselinkerView view;
         private IMainView mainView;

        public IntegrationBaselinkerPresenter(IIntegrationBaselinkerView view, IMainView mainView)
        {
            this.view = view;
            this.mainView = mainView;
            this.view.Show();
            this.view.SaveEvent += SaveConfig;
            this.view.CancelEvent += CancelView;
            this.view.LoadEvent += LoadConfig;
            this.view.DeleteProductsFromBaselinkerEvent += DeleteBlProductsByAtr;
        }

        private void DeleteBlProductsByAtr(object? sender, EventArgs e) => DeleteBlProductsByAtr();

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
            //LoadDataGridViews();
            //view.FilePath = Settings.Default.FilePathSFF;
            //view.SpecialOfferName = Settings.Default.SpecialOfferNameSFF;
            //view.SpecialOfferPriceType = Settings.Default.SpecialOfferPriceTypeIdSFF;
            //view.UpdAtrSaleId = Settings.Default.UpdAtrSaleIdSFF;
            //view.UpdAtrSaleValue = Settings.Default.UpdAtrSaleValueSFF;
            //view.SpecialOfferFrom = Settings.Default.SpecialOfferFrom;
            //view.SpecialOfferTo = Settings.Default.SpecialOfferTo;

        }

        private void LoadComboboxes()
        {
            // Get values from model
            //Dictionary<int, string> valuesPrice = Config.GetPricesFromOPT();
            //Dictionary<int, string> valuesAtr = Config.GetAtrValueToUpdPricesFromOPT();

            //if (valuesPrice != null && valuesPrice.Count > 0)
            //    view.LoadCombobox(valuesPrice, "typePrice");

            //if (valuesAtr != null && valuesAtr.Count > 0)
            //    view.LoadCombobox(valuesAtr, "atr");
        }

        private void SaveConfig()
        {
            //Settings.Default.FilePathSFF = view.FilePath;
            //Settings.Default.SpecialOfferNameSFF = view.SpecialOfferName;
            //Settings.Default.SpecialOfferPriceTypeIdSFF = view.SpecialOfferPriceType;
            //Settings.Default.UpdAtrSaleIdSFF = view.UpdAtrSaleId;
            //Settings.Default.UpdAtrSaleValueSFF = view.UpdAtrSaleValue;
            //Settings.Default.SpecialOfferFrom = view.SpecialOfferFrom;
            //Settings.Default.SpecialOfferTo = view.SpecialOfferTo;

            Settings.Default.Save();
        }

        private void DeleteBlProductsByAtr()
        {
            //throw new NotImplementedException();
        }

    }
}
