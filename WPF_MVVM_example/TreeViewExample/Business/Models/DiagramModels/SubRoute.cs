
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;
using TreeViewExample.Business.Attributes;
using TreeViewExample.Business.Enums;
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

        private bool _IsExpanded;
        private Brush _Brush;
        private static Random ran = new Random();

        private ObservableCollection<sri_SubRoutesInRoutes> _SubrouteInRouteList = new ObservableCollection<sri_SubRoutesInRoutes>();
        private ObservableCollection<bir_BinsInSubRoutes> _BinInSubRouteList = new ObservableCollection<bir_BinsInSubRoutes>();
        private ObservableCollection<uis_UnitsInSubRoutes> _UnitsInSubroute = new ObservableCollection<uis_UnitsInSubRoutes>();

        private ProcessCel _ProcessCel;

        private string _ProcesCellId;
        private string _SubRouteId;
        private string _SubRouteName;

        public SubRoute()
        {
            Validate();
        }

        public SubRoute(ProcessCel procescell, string id, string name)
        {
            this.ProcesCellId = procescell.ProcesCellId;
            this.SubRouteId = id;
            this.SubRouteName = name;


            Validate();
        }

        #region Properties

        [NotMapped]
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { SetProperty(ref _IsExpanded, value); }
        }
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

        public virtual ObservableCollection<sri_SubRoutesInRoutes> sri_SubRoutesInRoutes
        {
            get { return _SubrouteInRouteList; }
            set { SetProperty(ref _SubrouteInRouteList, value); }
        }
        public virtual ObservableCollection<bir_BinsInSubRoutes> bir_BinsInSubRoutes
        {
            get { return _BinInSubRouteList; }
            set { SetProperty(ref _BinInSubRouteList, value); }
        }
        public virtual ObservableCollection<uis_UnitsInSubRoutes> uis_UnitsInSubRoutes
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
        [DatabaseProperty]
        [Column("sur_ProcCellId", Order = 0)]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [Key]
        [DatabaseProperty]
        [Column("sur_SubRouteId", Order = 1)]
        public string SubRouteId
        {
            get { return _SubRouteId; }
            set { SetProperty(ref _SubRouteId, value); }
        }
        [DatabaseProperty]
        [Column("sur_SubRouteNm")]
        public string SubRouteName
        {
            get { return _SubRouteName; }
            set { SetProperty(ref _SubRouteName, value); }
        }

        #endregion

        #region Methods

        public ObservableCollection<bir_BinsInSubRoutes> GetAllSourceBins()
        {
            ObservableCollection<bir_BinsInSubRoutes> SourceBins = new ObservableCollection<bir_BinsInSubRoutes>();

            foreach (bir_BinsInSubRoutes bir in bir_BinsInSubRoutes)
            {
                if (bir.bir_SourceDest == "S" )
                {
                    OrderObservableList.AddSorted(SourceBins, bir);
                }
            }

            return SourceBins;
        }
        public ObservableCollection<bir_BinsInSubRoutes> GetAllDestinationBins()
        {
            ObservableCollection<bir_BinsInSubRoutes> DestinationBins = new ObservableCollection<bir_BinsInSubRoutes>();

            foreach (bir_BinsInSubRoutes bir in bir_BinsInSubRoutes)
            {
                if (bir.bir_SourceDest == "D")
                {
                    OrderObservableList.AddSorted(DestinationBins, bir);
                }
            }

            return DestinationBins;
        }
        public bool AddBinToSubroute(Bin bin, SourceDest sourcedest)
        {
            bir_BinsInSubRoutes BinInSubroute = new bir_BinsInSubRoutes(bin, this, sourcedest);
            if (BinInSubroute.DatabaseInsert())
            {
                BinInSubroute.bin_Bins = bin;
                BinInSubroute.sur_SubRoutes = this;

                OrderObservableList.AddSorted(bir_BinsInSubRoutes, BinInSubroute);
                OrderObservableList.AddSorted(bin.bir_BinsInSubRoutes, BinInSubroute);
                return true;
            }
            return false;
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

            foreach (var prop in this.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(DatabaseProperty))))
            {
                string name = prop.Name;
                var varValue = prop.GetValue(this, null);
                string value = "";

                if (varValue == null)
                    value = "Null";
                else
                    value = varValue.ToString();

                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.SubRouteName);
                configList.Add(mainListViewModel);
            }

            if (IsExpanded)
            {
                foreach (bir_BinsInSubRoutes bir in bir_BinsInSubRoutes)
                {
                    configList.Add(new MainListViewModel("", "", ""));
                    List<MainListViewModel> routeConfigList = bir.GenerateListViewList();
                    configList.AddRange(routeConfigList);
                }
            }

            return configList;
        }

        public bool Validate()
        {
            _Brush = Brushes.LightGreen;
            return true;
            
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
        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        public string GetValidationMessage()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
