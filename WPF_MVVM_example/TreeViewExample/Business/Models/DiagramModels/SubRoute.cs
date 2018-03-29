using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    public class SubRoute : ViewModelBase, IConfigObject
    {
        private ObservableCollection<Unit> _UnitList = new ObservableCollection<Unit>();
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();

        private Route _Route;
        private string _Name;
        private int _Number;
        private Brush _Brush;
        private static Random ran = new Random();

        public SubRoute(string name, int number, Route route , bool addUnits = false)
        {
            this._Name = name;
            this._Number = number;
            this._Route = route;

            int newRan = ran.Next(0, 10);
            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
            }

            if (addUnits)
            {
                AddUnits();
            }
        }

        #region Properties

        public ObservableCollection<Unit> UnitList
        {
            get { return _UnitList; }
            set { SetProperty(ref _UnitList, value); }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        public int Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }

        #endregion

        #region Methods

        private void AddUnits()
        {
            for (int i = 0; i < 3; i++)
            {
                UnitList.Add(new Unit("Unit " + i.ToString(), i, this));
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
            List<Unit> removableUnits = new List<Unit>();
            foreach (Unit U in UnitList)
            {
                removableUnits.Add(U);
            }
            foreach (Unit U in removableUnits)
            {
                U.Delete();
            }

            List<Bin> removableBins = new List<Bin>();
            foreach (Bin B in BinList)
            {
                removableBins.Add(B);              
            }
            foreach (Bin B in removableBins)
            {
                B.SetSubroute();
                BinList.Remove(B);
            }
                      
            this._Route.DeleteChild(this);
        }
        public void DeleteChild(IConfigObject obj)
        {
            Unit unit = obj as Unit;
            foreach (Unit U in UnitList)
            {
                if (U.Equals(unit))
                {
                    UnitList.Remove(unit);
                    break;
                }
            }

        }
        public void CreateChild()
        {
            List<int> intList = new List<int>();
            foreach (Unit R in UnitList)
            {
                intList.Add(R.Number);
            }
            int firstAvailable = Enumerable.Range(0, int.MaxValue).Except(intList).FirstOrDefault();

            Unit unit = new Unit("Unit " + firstAvailable, firstAvailable, this);
            OrderObservableList.AddSorted(UnitList, unit);
        }
        public bool AddBinToSubroute(Bin bin)
        {
            if (!_BinList.Contains(bin))
            {
                bin.SetSubroute(this);
                OrderObservableList.AddSorted(BinList, bin);             
                return true;
            }
            return false;
        }
        public void DeleteBin(Bin bin)
        {
            foreach (Bin B in BinList)
            {
                if (B == bin)
                {
                    BinList.Remove(B);
                    break;
                }
            }
        }

        public int CompareTo(object obj)
        {
            SubRoute subroute = obj as SubRoute;
       
            if (this._Number > subroute._Number)
            {
                return 1;
            }
            else if (this._Number < subroute._Number)
            {
                return -1;
            }
            return 0;
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
