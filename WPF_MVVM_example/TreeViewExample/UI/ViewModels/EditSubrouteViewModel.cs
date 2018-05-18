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
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class EditSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Route _Route;
        public ObservableCollection<SubRoute> _SubRouteList;

        #endregion

        private IEditSubrouteView _IEditSubrouteView;
        public EditSubrouteViewModel(IEditSubrouteView view) : base(view)
        {
            this._IEditSubrouteView = view;
            InitializeCommand();
        }

        #region Properties

        public Route Route
        {
            get { return _Route; }
            set { SetProperty(ref _Route, value); }
        }
      
        public ObservableCollection<SubRoute> SubRouteList
        {
            get { return _SubRouteList; }
            set { SetProperty(ref _SubRouteList, value); }
        } 

        #endregion

        #region Methods

        public void ManageLists()
        {
            SubRouteList = Route.GetSubrouteNotInRoute();
        }

        #endregion

        #region ItemHandlers

        private void AddSubRouteToRoute(SubRoute subroute)
        {
            Route.AddSubroute(subroute);
            ManageLists();

        }

        private void RemoveSubRouteFromRoute(sri_SubRoutesInRoutes subrouteInRoute)
        {
            subrouteInRoute.RemoveSubrouteInRoute();
            ManageLists();
        }

        private void SequenceDown(sri_SubRoutesInRoutes subrouteInRoute)
        {
            throw new NotImplementedException();
        }

        private void SequenceUp(sri_SubRoutesInRoutes subrouteInRoute)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            AddSubRouteToRouteCommand = new RelayCommandT1<SubRoute>(AddSubRouteToRoute);
            RemoveSubRouteFromRouteCommand = new RelayCommandT1<sri_SubRoutesInRoutes>(RemoveSubRouteFromRoute);
        }

       public ICommand AddSubRouteToRouteCommand { get; set; }
       public ICommand RemoveSubRouteFromRouteCommand { get; set; }


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
