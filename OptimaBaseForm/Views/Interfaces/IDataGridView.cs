using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IDataGridView
    {
        object SelectedRow { get; }
        object SelectedValueCombobox { get; }
        void LoadDataGridView(DataTable values, int mappingType);
        event EventHandler AddDataGridEvent;
        event EventHandler DeleteDataGridEvent;
    }
}
