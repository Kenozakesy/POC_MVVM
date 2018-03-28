using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Singletons
{
    //this singleton class needs to be replaces for something more readable later
    public class GlobalLists : ViewModelBase
    {
        private static GlobalLists _Instance;

        private ObservableCollection<Route> _RouteList = new ObservableCollection<Route>();
        private ObservableCollection<Unit> _UnitList = new ObservableCollection<Unit>();
        private MainWindowViewModel _Viewmodel;

        private GlobalLists()
        {
            
        }
        public static GlobalLists Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GlobalLists();
                }
                return _Instance;
            }
        }

        public MainWindowViewModel Viewmodel
        {
            set
            {
                SetProperty(ref _Viewmodel, value);
            }
        }

        public ObservableCollection<Route> RouteList
        {
            get { return _RouteList; }
            set { SetProperty(ref _RouteList, value); }
        }
        public ObservableCollection<Unit> UnitList
        {
            get { return _UnitList; }
            set { SetProperty(ref _UnitList, value); }
        }

        #region Methods

        public void AddRoute(Route route)
        {
            OrderObservableList.AddSorted(RouteList, route);
            _Viewmodel.RouteList = RouteList;
        }
        public void RemoveRoute(Route route)
        {
            RouteList.Remove(route);
            _Viewmodel.RouteList = RouteList;
        }


        #endregion
    }
}
