using System.ComponentModel;
using WPF_MVVM_example.UI.Interfaces;

namespace WPF_MVVM_example.UI.ViewModels
{
    public class ViewModel
    {
        public IView View { get; private set; }
        public ViewModel(IView view)
        {
            View = view;
        }

    }
}
