using OptimaBaseForm.Presenters;
using OptimaBaseForm.Presenters.Common;
using OptimaBaseForm.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OptimaBaseForm.Views
{
    public partial class DataBaseConfigView : Form, IDataBaseConfigView
    {
        public string LogPath { get => tbLogPath.Text; set => tbLogPath.Text = value; }
        public decimal DeleteOldLogsDays { get => nudDeleteOldLogsDays.Value; set => nudDeleteOldLogsDays.Value = value; }
        public string CompanyGID { get => tbCompanyGID.Text; set => tbCompanyGID.Text = value; }
        public string Log { get => tbLog.Text; set => tbLog.Text = value; }
        public bool DeleteOldLogs { get => cbDeleteOldLogs.Checked; set => cbDeleteOldLogs.Checked = value; }
        public int OptIdAtrStatusZamOpt { get => Convert.ToInt16(cbOptIdAtrStatusZamOpt.SelectedValue); set => cbOptIdAtrStatusZamOpt.SelectedValue = value; }

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadEvent;
        public event EventHandler SqlPrepareTables;
        public event EventHandler SqlPrepareMethods;
        public event EventHandler SqlUpdateBlAllproductsQuantity;
        public event EventHandler SqlUpdateBlAllproductsPrices;
        public event EventHandler ShowMappingProducts;
        public event EventHandler DeleteProdsMapping;
        
        

        public DataBaseConfigView()
        {
            InitializeComponent();
            
            btnCloseView.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSaveView.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };           
            btnSqlPrepareTables.Click += delegate { SqlPrepareTables?.Invoke(this, EventArgs.Empty); };
            btnSqlPrepareMethods.Click += delegate { SqlPrepareMethods?.Invoke(this, EventArgs.Empty); };
            btnSqlUpdateBlAllproductsPrices.Click += delegate { SqlUpdateBlAllproductsPrices?.Invoke(this, EventArgs.Empty); };
            btnShowMappingProducts.Click += delegate { ShowMappingProducts?.Invoke(this, EventArgs.Empty); };
            btnDeleteProdsMapping.Click += delegate { DeleteProdsMapping?.Invoke(this, EventArgs.Empty); };
            btnSqlUpdateBlAllproductsQuantity.Click += delegate { SqlUpdateBlAllproductsQuantity?.Invoke(this, EventArgs.Empty); };
            Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };

        }

        public static DataBaseConfigView GetInstance(Form parentContainer)
        {
            return InstanceForm<DataBaseConfigView>.Get(parentContainer);
        }

        public void LoadCombobox(Dictionary<int, string> values, string comboboxName)
        {
            if(comboboxName == "rodzaj1")
            {
                cbOptIdAtrStatusZamOpt.Items.Clear();
                cbOptIdAtrStatusZamOpt.DataSource = new BindingSource(values, null);
                cbOptIdAtrStatusZamOpt.DisplayMember = "Value";
                cbOptIdAtrStatusZamOpt.ValueMember = "Key";
            }

            if (comboboxName == "rodzaj2")
            {
                //add combox
            }
        }

        private void btnPickLogPath_Click(object sender, EventArgs e)
        {
            if (fbdLogPath.ShowDialog() == DialogResult.OK) tbLogPath.Text = fbdLogPath.SelectedPath;
        }
    }
}
