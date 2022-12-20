using OptimaBaseForm.Properties;
using OptimaBaseForm.Views;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;            
            this.mainView.ShowConnectionConfig += ShowConnectionConfig;
            this.mainView.ShowDataBaseConfig += ShowDataBaseConfig;
            this.mainView.ShowMainImportOrders += ShowMainImportOrders;
    }

        private void ShowMainImportOrders(object? sender, EventArgs e)
        {
            var view = StatusesToGetOrdersView.GetInstance((MainView)mainView);

            new StatusesToGetOrdersPresenter(view, mainView);
        }

        private void ShowDataBaseConfig(object? sender, EventArgs e)
        {
            var view = DataBaseConfigView.GetInstance((MainView)mainView);

            new DataBaseConfigPresenter(view, mainView);
        }

        private void ShowConnectionConfig(object? sender, EventArgs e)
        {
            var view = ConnectionConfigView.GetInstance((MainView)mainView);
            
            new ConnectionConfigPresenter(view, mainView);
        }
    }
}
