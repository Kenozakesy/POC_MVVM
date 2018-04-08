using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class EditSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<SubRoute> _SubRouteList = new ObservableCollection<SubRoute>();

        #endregion

        private IEditSubrouteView _IEditSubrouteView;
        public EditSubrouteViewModel(IEditSubrouteView view) : base(view)
        {
            this._IEditSubrouteView = view;

            FillListTest();
        }

        #region Properties

        public ObservableCollection<SubRoute> SubRouteList
        {
            get { return _SubRouteList; }
            set { SetProperty(ref _SubRouteList, value); }
        }

        #endregion

        #region ItemHandlers

        private void FillListTest()
        {
            for (int i = 1; i <= 10 ; i++)
            {
                SubRouteList.Add(new SubRoute("route " + i , i, null));
            }
        }

        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            //CreateRouteCommand = new RelayCommand(CreateRoute);
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
