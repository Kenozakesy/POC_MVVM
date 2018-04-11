using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<SubRoute> _SubrouteList = new ObservableCollection<SubRoute>();
        private ProcessCel _ProcessCel;

        #endregion

        private ICreateSubrouteView _ICreateSubrouteView;
        public CreateSubrouteViewModel(ICreateSubrouteView view) : base(view)
        {
            this._ICreateSubrouteView = view;
            InitializeCommand();
        }

        #region Properties

        public ObservableCollection<SubRoute> SubrouteList
        {
            get { return _SubrouteList; }
            set { SetProperty(ref _SubrouteList, value); }
        }

        public ProcessCel ProcessCel
        {
            get { return _ProcessCel; }
            set { SetProperty(ref _ProcessCel, value); }
        }

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
