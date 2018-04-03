using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateParameterViewModel : ViewModel, INotifyPropertyChanged
    {





        private ICreateParameterView _ICreateParameterView;
        public CreateParameterViewModel(ICreateParameterView view) : base(view)
        {
            this._ICreateParameterView = view;
            InitializeCommand();
        }




        #region Properties

        #endregion

        #region Methods

        #endregion



        #region Commandlogic
        private void InitializeCommand()
        {
           // CreateRouteCommand = new RelayCommand(CreateRoute);
        }

        //public ICommand CreateRouteCommand { get; set; }


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
