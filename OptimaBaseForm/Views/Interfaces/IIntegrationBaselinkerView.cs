using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IIntegrationBaselinkerView: IBaseView, IComboboxView,IDataGridView, ILogInfoUser
    {
        public int AtrForDeleteProductsBlId { get; set; }
        public string AtrForDeleteProductsBlValue { get; set; }
      
        public event EventHandler DeleteProductsFromBaselinkerEvent;
    }
}
