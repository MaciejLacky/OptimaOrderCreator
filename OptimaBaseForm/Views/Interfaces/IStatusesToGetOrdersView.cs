using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IStatusesToGetOrdersView : IBaseView ,IComboboxView, IDataGridView
    {
        object SelectedValueCombobox2 { get; }

    }
}
