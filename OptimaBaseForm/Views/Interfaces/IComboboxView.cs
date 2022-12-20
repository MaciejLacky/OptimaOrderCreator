using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IComboboxView
    {
        void LoadCombobox(Dictionary<int, string> values, string comboboxName);
    }
}
