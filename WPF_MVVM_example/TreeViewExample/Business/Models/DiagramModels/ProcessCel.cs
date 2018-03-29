using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;


namespace TreeViewExample.Business.Models
{
    public class ProcessCel : ViewModelBase, IConfigObject
    {
        private string _Name;
        private ObservableCollection<Route> _RouteList = new ObservableCollection<Route>();
        private Brush _Brush;
        private int _Number;
        private static Random ran = new Random();

        public ProcessCel(string name, int number)
        {
            this._Name = name + " " + number;
            this._Number = number;
          
            int newRan = ran.Next(0, 10);
            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
            }
            AddRoutes();
        }

        #region Properties

        public ObservableCollection<Route> RouteList
        {
            get { return _RouteList; }
            set { SetProperty(ref _RouteList, value); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        public int Number
        {
            get { return _Number; }
            private set { SetProperty(ref _Number, value); }
        }
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #endregion

        #region Methods

        private void AddRoutes()
        {
            for (int i = 0; i < 3; i++)
            {
                RouteList.Add(new Route("Route " + i, i, this, true));
            }         
        }

        public void ChangeColor()
        {
            if (_Brush == Brushes.Red)
            {
                Brush = Brushes.LightGreen;
            }
            else
            {
                Brush = Brushes.Red;
            }
        }

        public void Delete()
        {
            List<Route> removableRoutes = new List<Route>();
            foreach (Route R in RouteList)
            {
                removableRoutes.Add(R);
            }
            foreach (Route R in removableRoutes)
            {
                R.Delete();
            }  
        }

        public void DeleteChild(IConfigObject obj)
        {
            Route unit = obj as Route;
            foreach (Route U in RouteList)
            {
                if (U.Equals(unit))
                {
                    RouteList.Remove(unit);
                    break;
                }
            }
        }

        public void CreateChild()
        {
            List<int> intList = new List<int>();
            foreach (Route R in RouteList)
            {
                intList.Add(R.Number);
            }
            int firstAvailable = Enumerable.Range(0, int.MaxValue).Except(intList).FirstOrDefault();

            Route route = new Route("Route " + firstAvailable, firstAvailable, this);
            OrderObservableList.AddSorted(RouteList, route);
        }

        public int CompareTo(object obj)
        {
            ProcessCel cell = obj as ProcessCel;
            return string.Compare(this.Name, cell.Name);        
        }

        public override string ToString()
        {
            return _Name;
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.PropertyType.FullName.StartsWith("System.") || prop.Name == "Brush")
                {
                    continue;
                }
                string name = prop.Name;
                string value = prop.GetValue(this, null).ToString();
                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.Name);
                configList.Add(mainListViewModel);
            }
            return configList;
        }

        #endregion




    }
}
