﻿using System.Collections.ObjectModel;
using TreeViewExample.Business.Models;

namespace WPF_MVVM_example.UI.Interfaces
{
    public interface ITreeView : IView
    {
        int Refresh();
        bool ConfirmMessage(string title, string text);
        void OpenDragDropWindow();
        Bin OpenSelectBinWindow(ObservableCollection<Bin> binList);
        void OpenParameterSheetWindow();
        void OpenCreateParameterWindow();
        void OpenEditSubrouteWindow();
    }
}
