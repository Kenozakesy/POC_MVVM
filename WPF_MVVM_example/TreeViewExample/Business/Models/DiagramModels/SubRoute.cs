
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("sur_SubRoutes")]
    public class SubRoute : ViewModelBase, IConfigObject
    {
        private SubrouteBusiness db = new SubrouteBusiness(new MSSQL_SubrouteRepository());


        private Brush _Brush;
        private static Random ran = new Random();

        private List<sri_SubRoutesInRoutes> _SubrouteInRouteList = new List<sri_SubRoutesInRoutes>();
        private List<bir_BinsInSubRoutes> _BinInSubRouteList = new List<bir_BinsInSubRoutes>();
        private List<uis_UnitsInSubRoutes> _UnitsInSubroute = new List<uis_UnitsInSubRoutes>();

        private ProcessCel _ProcessCel;

        private string _ProcesCellId;
        private string _SubRouteId;
        private string _SubRouteName;

        public SubRoute()
        {
            Validate();
        }

        public SubRoute(ProcessCel procescell, string id)
        {
            this.ProcesCellId = procescell.ProcesCellId;
            this.SubRouteId = id;
            this.SubRouteName = procescell.ProcesCellId + " " + id;


            Validate();
        }

        #region Properties

        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set
            {
                SetProperty(ref _Brush, value);

                foreach (sri_SubRoutesInRoutes sri in _SubrouteInRouteList)
                {
                    sri.Brush = Brush;
                }
            }
        }

        public virtual List<sri_SubRoutesInRoutes> sri_SubRoutesInRoutes
        {
            get { return _SubrouteInRouteList; }
            set { SetProperty(ref _SubrouteInRouteList, value); }
        }

        public virtual List<bir_BinsInSubRoutes> bir_BinsInSubRoutes
        {
            get { return _BinInSubRouteList; }
            set { SetProperty(ref _BinInSubRouteList, value); }
        }

        public virtual List<uis_UnitsInSubRoutes> uis_UnitsInSubRoutes
        {
            get { return _UnitsInSubroute; }
            set { SetProperty(ref _UnitsInSubroute, value); }
        }

        [ForeignKey("ProcesCellId")]
        public virtual ProcessCel ProcessCel
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
            db.DatabaseDelete(this);
        }
        public void DeleteChild(IConfigObject obj)
        {
            //Unit unit = obj as Unit;
            //foreach (Unit U in UnitList)
            //{
            //    if (U.Equals(unit))
            //    {
            //        UnitList.Remove(unit);
            //        break;
            //    }
            //}

        }
        public void CreateChild()
        {
            //List<int> intList = new List<int>();
            //foreach (Unit R in UnitList)
            //{
            //    intList.Add(R.Number);
            //}
            //int firstAvailable = Enumerable.Range(0, int.MaxValue).Except(intList).FirstOrDefault();

            //Unit unit = new Unit("Unit " + firstAvailable, firstAvailable, this);
            //OrderObservableList.AddSorted(UnitList, unit);
        }
        public int CompareTo(object obj)
        {
            SubRoute subroute = obj as SubRoute;
            int other = Convert.ToInt32(subroute.SubRouteId.Replace("SR", ""));
            int current = Convert.ToInt32(this.SubRouteId.Replace("SR", ""));

            if (current > other)
            {
                return 1;
            }
            else if(current < other)
            {
                return -1;
            }
            return 0;
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

        public string GetName()
        {
            return "Subroute " + this.SubRouteName;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj.GetType() == typeof(SubRoute)))
            {
                return false;
            }

            SubRoute other = (SubRoute)obj;

            if ((other.ProcesCellId != ProcesCellId || other.SubRouteId != SubRouteId))
            {
                return false;
            }

            return true;
        }

        public bool DatabaseInsert()
        {
            return db.DatabaseInsert(this);
        }

        public bool DatabaseUpdate()
        {
            return db.DatabaseUpdate(this);
        }

        public bool DatabaseDelete()
        {
            return db.DatabaseDelete(this);
        }

        #endregion

    }
}
