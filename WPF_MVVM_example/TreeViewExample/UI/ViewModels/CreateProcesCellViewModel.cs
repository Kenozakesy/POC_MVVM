using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateProcesCellViewModel : ViewModel, INotifyPropertyChanged
    {
        private ICreateProcesCellView _View;

        public CreateProcesCellViewModel(ICreateProcesCellView view) : base(view)
        {
            _View = view;
        }



        #region Commandlogic

        private void InitializeCommand()
        {
            //CreateCustomerParameterCommand = new RelayCommand(CreateCustomerParameter);
        }

        //public ICommand CreateCustomerParameterCommand { get; set; }

        #endregion

        #region property change logic

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
