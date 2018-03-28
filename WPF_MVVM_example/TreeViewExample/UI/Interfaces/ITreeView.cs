using System.Collections.ObjectModel;
using TreeViewExample.Business.Models;

namespace WPF_MVVM_example.UI.Interfaces
{
    public interface ITreeView : IView
    {
        int Refresh();
        bool ConfirmMessage();
        void OpenDragDropWindow();
        Bin OpenSelectBinWindow(ObservableCollection<Bin> binList);
    }
}
