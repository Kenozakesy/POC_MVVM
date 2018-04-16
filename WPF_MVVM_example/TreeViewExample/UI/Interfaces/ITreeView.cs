using System.Collections.ObjectModel;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace WPF_MVVM_example.UI.Interfaces
{
    public interface ITreeView : IView
    {
        int Refresh();
        bool ConfirmMessage(string title, string text);
        void OpenDragDropWindow();
        Bin OpenSelectBinWindow(ObservableCollection<Bin> binList);
        void OpenParameterSheetWindow();
        void OpenCreateParameterWindow(ObservableCollection<ParameterDefinition> customerParameterList);
        void OpenEditSubrouteWindow();
        void OpenCreateSubrouteWindow(ProcessCel processcel);
    }
}
