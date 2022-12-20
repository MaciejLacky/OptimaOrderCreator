using OptimaBaseForm.Presenters.Common;
using OptimaBaseForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimaBaseForm.Views
{
    public partial class StatusesToGetOrdersView : Form, IStatusesToGetOrdersView
    {
        public object SelectedRow { get => dgvStatusMapping.Rows[dgvStatusMapping.CurrentRow.Index].Cells[0].Value; }

        public object SelectedValueCombobox2 => cbStatusMappingStart.SelectedItem;

        public object SelectedValueCombobox => cbStatusMappingEnd.SelectedItem;

        public StatusesToGetOrdersView()
        {
            InitializeComponent();

            btnCloseView.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSaveView.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            btnAddStatusMapping.Click += delegate { AddDataGridEvent?.Invoke(this, EventArgs.Empty); };
            btnDeleteStatusMapping.Click += delegate { DeleteDataGridEvent?.Invoke(this, EventArgs.Empty); };           
            Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
        }
        public static StatusesToGetOrdersView GetInstance(Form parentContainer)
        {
            return InstanceForm<StatusesToGetOrdersView>.Get(parentContainer);
        }

        public event EventHandler AddDataGridEvent;
        public event EventHandler DeleteDataGridEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadEvent;

        public void LoadCombobox(Dictionary<int, string> values, string comboboxName)
        {
            if (comboboxName == "rodzaj1")
            {
                cbStatusMappingStart.Items.Clear();
                cbStatusMappingStart.DataSource = new BindingSource(values, null);
                cbStatusMappingStart.DisplayMember = "Value";
                cbStatusMappingStart.ValueMember = "Key";
            }

            if (comboboxName == "rodzaj2")
            {                 
                cbStatusMappingEnd.Items.Clear();
                cbStatusMappingEnd.DataSource = new BindingSource(values, null);
                cbStatusMappingEnd.DisplayMember = "Value";
                cbStatusMappingEnd.ValueMember = "Key";              
            }
        }

        public void LoadDataGridView(DataTable values, int mappingType)
        {
            if(mappingType == 1)
            dgvStatusMapping.DataSource = values;
        }
    }
}
