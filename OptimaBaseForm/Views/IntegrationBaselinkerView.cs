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
    public partial class IntegrationBaselinkerView : Form , IIntegrationBaselinkerView
    {
        public IntegrationBaselinkerView()
        {
            InitializeComponent();

            btnCloseView.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnSaveView.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            
        }

        public static IntegrationBaselinkerView GetInstance(Form parentContainer)
        {
            return InstanceForm<IntegrationBaselinkerView>.Get(parentContainer);
        }

        public int AtrForDeleteProductsBlId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AtrForDeleteProductsBlValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object SelectedRow => throw new NotImplementedException();

        public object SelectedValueCombobox => throw new NotImplementedException();

        public event EventHandler DeleteProductsFromBaselinkerEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadEvent;
        public event EventHandler AddDataGridEvent;
        public event EventHandler DeleteDataGridEvent;

        public void LoadCombobox(Dictionary<int, string> values, string comboboxName)
        {
            throw new NotImplementedException();
        }

        public void LoadDataGridView(DataTable values, int mappingType)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string info, int typeTextBox)
        {
            throw new NotImplementedException();
        }
    }
}
