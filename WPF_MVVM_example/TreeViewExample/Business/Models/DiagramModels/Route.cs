using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    public class Route : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        #region Fields

        private ObservableCollection<RouteParameter> _RouteParameterList = new ObservableCollection<RouteParameter>();
        private ObservableCollection<SubRoute> _SubRouteList = new ObservableCollection<SubRoute>();
        private ProcessCel _ProcessCel;

        private string _Name;
        private int _Number;
        private Brush _Brush;
        private static Random ran = new Random();

        #endregion

        public Route(string name, int number, ProcessCel processCel, bool addsubroutes = false)
        {
            this._Number = number;
            this._Name = name;
            this._ProcessCel = processCel;

            int newRan = ran.Next(0, 10);
            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
            }

            if (addsubroutes)
            { 
                AddSubRoutes();
            }
            GetRouteParameters();
        }

        #region Properties

        public ObservableCollection<RouteParameter> RouteParameterList
        {
            get { return _RouteParameterList; }
            set { SetProperty(ref _RouteParameterList, value); }
        }
        public ObservableCollection<SubRoute> SubRouteList
        {
            get { return _SubRouteList; }
            set { SetProperty(ref _SubRouteList, value); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        public int Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Moet omgebouwd worden zodat die naar de databasde toe gaat
        /// </summary>
        private void GetRouteParameters()
        {
            for (int i = 0; i < 5; i++)
            {
                RouteParameter routeParameter = new RouteParameter("Name", "description", "1", "-", "1;2;3;4;5", true, true, this);
                RouteParameterList.Add(routeParameter);
            }
        }
        private void AddSubRoutes()
        {
            for (int i = 0; i < 3; i++)
            {
                SubRouteList.Add(new SubRoute("Subroute " + i.ToString(), i, this, true));
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
            List<SubRoute> removableSubroutes = new List<SubRoute>();
            foreach (SubRoute S in SubRouteList)
            {
                removableSubroutes.Add(S);
            }
            foreach (SubRoute S in removableSubroutes)
            {
                S.Delete();
            }
            this._ProcessCel.DeleteChild(this);
        }
        public void DeleteChild(IConfigObject obj)
        {
            SubRoute unit = obj as SubRoute;
            foreach (SubRoute U in SubRouteList)
            {
                if (U.Equals(unit))
                {
                    SubRouteList.Remove(unit);
                    break;
                }
            }
        }
        public void CreateChild()
        {
            List<int> intList = new List<int>();
            foreach (SubRoute R in SubRouteList)
            {
                intList.Add(R.Number);
            }
            int firstAvailable = Enumerable.Range(0, int.MaxValue).Except(intList).FirstOrDefault();

            SubRoute subroute = new SubRoute("Subroute " + firstAvailable, firstAvailable, this);
            OrderObservableList.AddSorted(SubRouteList, subroute);

        }
        public override string ToString()
        {
            return _Name;
        }
        public int CompareTo(object obj)
        {
            Route route = obj as Route;
            if (this._Number > route._Number)
            {
                return 1;
            }
            else if (this._Number < route._Number)
            {
                return -1;
            }
            return 0;
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
        public ObservableCollection<Parameter> GetParameterList()
        {
            ObservableCollection<Parameter> parameterList = new ObservableCollection<Parameter>();
            foreach (RouteParameter RP in RouteParameterList)
            {
                parameterList.Add(RP);
            }
            return parameterList;
        }
        public void RemoveParameter(Parameter paramdef)
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }




        #endregion

    }
}
