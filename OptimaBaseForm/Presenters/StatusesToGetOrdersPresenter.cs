using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Presenters
{
    public class StatusesToGetOrdersPresenter
    {
        private IStatusesToGetOrdersView view;
        private IMainView mainView;
        //test
        DataTable dt;
        public StatusesToGetOrdersPresenter(IStatusesToGetOrdersView view, IMainView mainView)
        {
            this.view = view;
            this.mainView = mainView;
            dt = new DataTable();
            this.view.SaveEvent += SaveConfig;
            this.view.CancelEvent += CancelView;
            this.view.LoadEvent += LoadConfig;
            this.view.DeleteDataGridEvent += DeleteItemDataGrid;
            this.view.AddDataGridEvent += AddItemDataGrid;
            this.view.Show();

        }

        private void AddItemDataGrid(object? sender, EventArgs e) => AddItemDataGrid();
        private void DeleteItemDataGrid(object? sender, EventArgs e) => DeleteItemDataGrid();
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
        }

        private void SaveConfig()
        {

        }

        private void LoadDataGridViews()
        {
           
            DataColumn dc = new DataColumn("col1", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("col2", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("col3", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("col4", typeof(String));
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();

            dr[0] = "coldata1";
            dr[1] = "coldata2";
            dr[2] = "coldata3";
            dr[3] = "coldata4";

            dt.Rows.Add(dr);
            BindingSource bindingSource = new BindingSource();

            view.LoadDataGridView(dt, 1);
        }

        public void LoadComboboxes()
        {
            // Get values from model
            Dictionary<int, string> values = new Dictionary<int, string>();
            values.Add(2, "jeden");
            values.Add(1, "dwa");
            //another data for combox
            Dictionary<int, string> values1 = new Dictionary<int, string>();
            values1.Add(2, "trzy");
            values1.Add(5, "cztery");


            // Populate combobox with values
            view.LoadCombobox(values, "rodzaj1");
            view.LoadCombobox(values1, "rodzaj2");
        }

        private void AddItemDataGrid()
        {
            var x = view.SelectedValueCombobox;
            var y = view.SelectedValueCombobox2;
        }
        private void DeleteItemDataGrid()
        {

            var x = view.SelectedRow;
        }
    }
}
