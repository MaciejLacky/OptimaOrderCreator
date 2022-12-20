﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Views.Interfaces
{
    public interface IMainView
    {
        event EventHandler ShowConnectionConfig;
        event EventHandler ShowDataBaseConfig;
        event EventHandler ShowMainImportOrders;
        void CustomizeDesign();
        void HideSubMenu();
        void ShowSubMenu(Panel submenu);
        void ShowMainPanel();
        void HideMainPanel();
    }
}