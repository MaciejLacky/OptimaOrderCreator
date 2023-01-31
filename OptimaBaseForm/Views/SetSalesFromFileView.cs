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
    public partial class SetSalesFromFileView : Form, ISetSalesFromFile
    {
        public SetSalesFromFileView()
        {
            InitializeComponent();

            btnCloseView.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSaveView.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            btnAddSpecialOffer.Click += delegate { AddSpecialOfferEvent?.Invoke(this, EventArgs.Empty); };
            btnSpecialOfferDelete.Click += delegate { SpecialOfferDeleteEvent?.Invoke(this, EventArgs.Empty); };
            btnPickLogPath.Click += delegate { PickLogPathEvent?.Invoke(this, EventArgs.Empty); };          
            Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
        }

        public static SetSalesFromFileView GetInstance(Form parentContainer)
        {
            return InstanceForm<SetSalesFromFileView>.Get(parentContainer);
        }
        public object SelectedRow { get => dgvSpecialPrice.Rows[dgvSpecialPrice.CurrentRow.Index].Cells; }

        public object SelectedValueCombobox => throw new NotImplementedException();

        public string FilePath { get => tbFilePath.Text; set => tbFilePath.Text = value; }
        public string SpecialOfferName { get => tbSpecialOfferName.Text; set => tbSpecialOfferName.Text = value; }
        public DateTime SpecialOfferFrom { get => dtpSpecialOfferFrom.Value; set => dtpSpecialOfferFrom.Value = value; }
        public DateTime SpecialOfferTo { get => dtpSpecialOfferTo.Value; set => dtpSpecialOfferTo.Value = value; }
        public int UpdAtrSaleId { get => Convert.ToInt32(cbUpdAtrSaleId.SelectedValue); set => cbUpdAtrSaleId.SelectedValue = value; }
        public string UpdAtrSaleValue { get => tbUpdAtrSaleValue.Text; set => tbUpdAtrSaleValue.Text = value; }
        public int SpecialOfferPriceType { get => Convert.ToInt32(cbSpecialOfferPriceType.SelectedValue); set => cbSpecialOfferPriceType.SelectedValue = value; }
       // public string LogInfo { get => tbLog.Text; set => tbLog.Text = value; }

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadEvent;
        public event EventHandler AddSpecialOfferEvent;
        public event EventHandler SpecialOfferDeleteEvent;
        public event EventHandler PickLogPathEvent;
        public event EventHandler AddDataGridEvent;
        public event EventHandler DeleteDataGridEvent;
        public event EventHandler TbLog;

        public void LoadCombobox(Dictionary<int, string> values, string comboboxName)
        {
            if (comboboxName == "atr")
            {
                cbUpdAtrSaleId.Items.Clear();
                cbUpdAtrSaleId.DataSource = new BindingSource(values, null);
                cbUpdAtrSaleId.DisplayMember = "Value";
                cbUpdAtrSaleId.ValueMember = "Key";
            }

            if (comboboxName == "typePrice")
            {
                cbSpecialOfferPriceType.Items.Clear();
                cbSpecialOfferPriceType.DataSource = new BindingSource(values, null);
                cbSpecialOfferPriceType.DisplayMember = "Value";
                cbSpecialOfferPriceType.ValueMember = "Key";
            }
        }

        public void LoadDataGridView(DataTable values, int mappingType)
        {
            if (mappingType == 2)
            {
                dgvSpecialPrice.DataSource = values;
                if (dgvSpecialPrice.Rows.Count == 0)
                {
                    dgvSpecialPrice.ColumnHeadersVisible = false;
                    return;
                }
                else
                    dgvSpecialPrice.ColumnHeadersVisible = true;
                dgvSpecialPrice.Columns[0].Visible = false;
                dgvSpecialPrice.Columns[1].Visible = false;
                dgvSpecialPrice.Columns[3].Visible = false;
                dgvSpecialPrice.Columns[5].Visible = false;
                dgvSpecialPrice.Columns[2].HeaderText = "Nazwa promocji";
                dgvSpecialPrice.Columns[4].HeaderText = "Okres od";
                dgvSpecialPrice.Columns[6].HeaderText = "Okres do";
            }
                
        }

        private void btnPickLogPath_Click(object sender, EventArgs e)
        {
            if (ofdFilePath.ShowDialog() == DialogResult.OK) tbFilePath.Text = ofdFilePath.FileName;
        }

        public void LogInfo(string info, int typeTextBox)
        {
            tbLog.Text = info;
            tbLog.Refresh();
        }
    }
}
