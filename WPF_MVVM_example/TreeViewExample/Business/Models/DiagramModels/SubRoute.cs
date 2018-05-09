using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("sur_SubRoutes")]
    public class SubRoute : ViewModelBase, IConfigObject, ICloneable
    {
        private Brush _Brush;
        private static Random ran = new Random();

        private ObservableCollection<Unit> _UnitList = new ObservableCollection<Unit>();
        private ProcessCel _ProcessCel;
        private List<Route> _RouteList;

        private string _ProcesCellId;
        private string _SubRouteId;
        private string _SubRouteName;

        public SubRoute()
        {

            AddUnits();
            Validate();
        }

        #region Properties

        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        [NotMapped]
        public ObservableCollection<Unit> UnitList
        {
            get { return _UnitList; }
            set { SetProperty(ref _UnitList, value); }
        }
        [NotMapped]
        public ProcessCel ProcessCel
        {
            get { return _ProcessCel; }
            set { SetProperty(ref _ProcessCel, value); }
        }

        [Key]
        [Column("sur_ProcCellId", Order = 0)]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [Key]
        [Column("sur_SubRouteId", Order = 1)]
        public string SubRouteId
        {
            get { return _SubRouteId; }
            set { SetProperty(ref _SubRouteId, value); }
        }
        [Column("sur_SubRouteNm")]
        public string SubRouteName
        {
            get { return _SubRouteName; }
            set { SetProperty(ref _SubRouteName, value); }
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
            throw new NotImplementedException();
            //List<Unit> removableUnits = new List<Unit>();
            //foreach (Unit U in UnitList)
            //{
            //    removableUnits.Add(U);
            //}
            //foreach (Unit U in removableUnits)
            //{
            //    U.Delete();
            //}
                    
            //this._RouteList.DeleteChild(this);
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
        public int CompareTo(object obj)
        {
            SubRoute subroute = obj as SubRoute;
            return string.Compare(this.SubRouteName, subroute._SubRouteName);
        }
        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            //foreach (var prop in this.GetType().GetProperties())
            //{
            //    if (!prop.PropertyType.FullName.StartsWith("System.") || prop.Name == "Brush")
            //    {
            //        continue;
            //    }
            //    string name = prop.Name;
            //    string value = prop.GetValue(this, null).ToString();
            //    MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.Name);
            //    configList.Add(mainListViewModel);
            //}
            return configList;
        }
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            int newRan = ran.Next(0, 10);
            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
            }

        }



        #endregion

    }
}
