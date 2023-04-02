using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptimaBaseForm.Views.Interfaces;

namespace OptimaBaseForm.Views
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler ShowConnectionConfig;
        public event EventHandler ShowDataBaseConfig;
        public event EventHandler ShowSetSaleFromFile;        
        public event EventHandler ShowIntegrationBaselinker;
        public event EventHandler ShowIntegrationPrestaShop;
        public event EventHandler ShowUpdateProducts;

        public MainView()
        {
            InitializeComponent();
            ButtonsClickEvents();
            
        }

        private void ButtonsClickEvents()
        {
            btnMainConfig.Click += delegate {                
                ShowSubMenu(panelSubmenu1);
                ShowMainPanel();
            };
            btnMainConfigConnections.Click += delegate {
                ShowConnectionConfig?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
                
            };
            btnMainConfigUpdateDb.Click += delegate {
                ShowDataBaseConfig?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
            };
            btnPromoOptima.Click += delegate
            {
                ShowSubMenu(panelSubmenu2);
                ShowMainPanel();
            };
            btnSetSaleFromFile.Click += delegate
            {
                ShowSetSaleFromFile?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
            };
            btnMainIntegrations.Click += delegate
            {               
                ShowSubMenu(panelSubmenu3);
                ShowMainPanel();
            };
            btnIntegrationBaselinker.Click += delegate
            {
                ShowIntegrationBaselinker?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
            };
            btnIntegrationPresta.Click += delegate
            {
                ShowIntegrationPrestaShop?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
            };
             btnUpdateProducts.Click += delegate
            {
                ShowUpdateProducts?.Invoke(this, EventArgs.Empty);
                HideMainPanel();
            };

        }

        public void CustomizeDesign()
        {
            panelSubmenu1.Visible = false;
            panelSubmenu2.Visible = false;
        }

        public void HideSubMenu()
        {
            if (panelSubmenu1.Visible == true)
                panelSubmenu1.Visible = false;
            if (panelSubmenu2.Visible == true)
                panelSubmenu2.Visible = false;
        }

        public void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        public void ShowMainPanel() => panelMainView.Visible = true;
        public void HideMainPanel() => panelMainView.Visible = false;
    }
}
