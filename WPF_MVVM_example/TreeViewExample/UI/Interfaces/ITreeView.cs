﻿using System.Collections.ObjectModel;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace WPF_MVVM_example.UI.Interfaces
{
    public interface ITreeView : IView
    {
        int Refresh();
        Bin OpenSelectBinWindow(ObservableCollection<Bin> binList);
        void OpenParameterSheetWindow();
        void OpenAddParameterToObjectWindow(IObjectWithParameters obj);
        void OpenCreateParameterWindow(ObservableCollection<ParameterDefinition> customerParameterList);
        void OpenEditSubrouteWindow();
        void OpenCreateSubrouteWindow(ProcessCel processcel);
    }
}
