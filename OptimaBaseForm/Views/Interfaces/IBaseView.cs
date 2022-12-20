using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IBaseView
    {
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler LoadEvent;
        void Show();
        void Close();
    }
}
