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
    public partial class UpdateProductsView : Form, IUpdateProductsView
    {
        public UpdateProductsView()
        {
            InitializeComponent();
            btnClose.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSave.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
            btnAddUpdProduct.Click += delegate { AddDataGridEvent?.Invoke(this, EventArgs.Empty); };
            btnDeleteUpdProduct.Click += delegate { DeleteDataGridEvent?.Invoke(this, EventArgs.Empty); };
            btnCreateOrder.Click += delegate { CreateOrderEvent?.Invoke(this, EventArgs.Empty); };
        }

        public object SelectedRow { get => dgvUpdateProduct.Rows[dgvUpdateProduct.CurrentRow.Index].Cells; }

        public object SelectedValueCombobox => throw new NotImplementedException();

        public int UpdProdGroupsValueId { get => Convert.ToInt32(cbUpdProdGroupsValue.SelectedValue); set => cbUpdProdGroupsValue.SelectedValue = value; }
        public string? UpdProdGroupsValue { get => ((KeyValuePair<int, string>)cbUpdProdGroupsValue.SelectedItem).Value; set => cbUpdProdGroupsValue.SelectedItem = value; }
        public decimal UpdProductMIn { get => nudUpdProductMIn.Value; set => nudUpdProductMIn.Value = value; }
        public decimal UpdProductMax { get => nudUpdProductMax.Value; set => nudUpdProductMax.Value = value; }
        public decimal UpdProductOrderAmount { get => nudUpdProductOrderAmount.Value; set => nudUpdProductOrderAmount.Value = value; }
        public decimal UpdProductWeight { get => nudUpdProductWeight.Value; set => nudUpdProductWeight.Value =value; }
        public decimal UpdProductHigh { get => nudUpdProductHigh.Value; set => nudUpdProductHigh.Value = value; }
        public decimal UpdProductWidth { get => nudUpdProductWidth.Value; set => nudUpdProductWidth.Value = value; }
        public decimal UpdProductLength { get => nudUpdProductLength.Value; set => nudUpdProductLength.Value = value; }
        public bool CreateOrderRotation { get => cbCreateOrderRotation.Checked; set => cbCreateOrderRotation.Checked = value; }
        public decimal OrderRotationDaysBack { get => nudOrderRotationDaysBack.Value; set => nudOrderRotationDaysBack.Value = value; }
        public string OrderRotaionProductName { get => tbOrderRotaionProductName.Text; set => tbOrderRotaionProductName.Text = value; }
        public int OrderRotationAtrProductId { get => Convert.ToInt32(cbOrderRotationAtrProductId.SelectedValue); set => cbOrderRotationAtrProductId.SelectedValue = value; }
        public string OrderRotationAtrProductValue { get => tbOrderRotationAtrProductValue.Text; set => tbOrderRotationAtrProductValue.Text = value; }
        public int OrderRotationMag { get => Convert.ToInt32(cbOrderRotationMag.SelectedValue); set => cbOrderRotationMag.SelectedValue = value; }
        public decimal OrderRotationAddIfZero { get => nudOrderRotationAddIfZero.Value; set => nudOrderRotationAddIfZero.Value = value; }
        public decimal OrderRotationMinValue { get => nudOrderRotationMinValue.Value; set => nudOrderRotationMinValue.Value = value; }
        public decimal OrderRotationMaxValue { get => nudOrderRotationMaxValue.Value; set => nudOrderRotationMaxValue.Value = value; }
        public string OrderRotationKnt { get => ((KeyValuePair<int, string>)cbOrderRotationKnt.SelectedItem).Value;}
        public int OrderRotationKntId { get => ((KeyValuePair<int, string>)cbOrderRotationKnt.SelectedItem).Key; set => cbOrderRotationKnt.SelectedValue = value; }
        public bool LastKntByOrder { get => cbLastKntByOrder.Checked; set => cbLastKntByOrder.Checked = value; }
        public ProgressBar ProgressBarCreateOrder { get => prBarCreateOrder; set=> prBarCreateOrder = value; }

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadEvent;
        public event EventHandler AddDataGridEvent;
        public event EventHandler DeleteDataGridEvent;
        public event EventHandler CreateOrderEvent;

        public static UpdateProductsView GetInstance(Form parentContainer)
        {
            return InstanceForm<UpdateProductsView>.Get(parentContainer);
        }

        public void LoadCombobox(Dictionary<int, string> values, string comboboxName)
        {
            if (comboboxName == "optimaGroup")
            {
                cbUpdProdGroupsValue.Items.Clear();
                cbUpdProdGroupsValue.DataSource = new BindingSource(values, null);
                cbUpdProdGroupsValue.DisplayMember = "Value";
                cbUpdProdGroupsValue.ValueMember = "Key";
            }

            if (comboboxName == "optimaMag")
            {
                cbOrderRotationMag.Items.Clear();
                cbOrderRotationMag.DataSource = new BindingSource(values, null);
                cbOrderRotationMag.DisplayMember = "Value";
                cbOrderRotationMag.ValueMember = "Key";
            }

            if (comboboxName == "optimaProductAtrId")
            {
                cbOrderRotationAtrProductId.Items.Clear();
                cbOrderRotationAtrProductId.DataSource = new BindingSource(values, null);
                cbOrderRotationAtrProductId.DisplayMember = "Value";
                cbOrderRotationAtrProductId.ValueMember = "Key";
            }

            if (comboboxName == "optimaKnt")
            {
                cbOrderRotationKnt.Items.Clear();
                cbOrderRotationKnt.DataSource = new BindingSource(values, null);
                cbOrderRotationKnt.DisplayMember = "Value";
                cbOrderRotationKnt.ValueMember = "Key";
            }
        }

        public void LoadDataGridView(DataTable values, int mappingType)
        {
            if (mappingType == 1)
            {
                dgvUpdateProduct.DataSource = values;
                if (dgvUpdateProduct.Rows.Count == 0)
                {
                    dgvUpdateProduct.ColumnHeadersVisible = false;
                    return;
                }
                else
                    dgvUpdateProduct.ColumnHeadersVisible = true;
                dgvUpdateProduct.Columns[0].Visible = false;        
                dgvUpdateProduct.Columns[1].HeaderText = "Grupa ID";
                dgvUpdateProduct.Columns[2].HeaderText = "Grupa";
                dgvUpdateProduct.Columns[3].HeaderText = "Min";
                dgvUpdateProduct.Columns[4].HeaderText = "Max";
                dgvUpdateProduct.Columns[5].HeaderText = "Zam";
                dgvUpdateProduct.Columns[6].HeaderText = "Waga";
            }
        }

        public void LogInfo(string info, int typeTextBox)
        {
            if(typeTextBox == 1)
            {
                tbLog.Text = info;
                tbLog.Refresh();
            }
            if (typeTextBox == 2)
            {
                tbLogOrder.Text = info;
                tbLogOrder.Refresh();
            }

        }
    }
}
