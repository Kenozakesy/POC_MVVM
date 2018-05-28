using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;
using System.Data.Entity;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Business.Models
{
    [Table("rot_Routes")]
    public class Route : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        RouteBusiness db = new RouteBusiness(new MSSQL_RouteRepository());

        #region Fields

        private ObservableCollection<RouteParameter> _RouteParameterList = new ObservableCollection<RouteParameter>();
        private ProcessCel _ProcessCel;
        private ObservableCollection<sri_SubRoutesInRoutes> _SubrouteInRouteList = new ObservableCollection<sri_SubRoutesInRoutes>();
        private ObservableCollection<SubRoute> _SubRouteList = new ObservableCollection<SubRoute>();

        private Brush _Brush;
        private static Random ran = new Random();

        private string _ProcesCellId;
        private string _RouteId;
        private string _RouteName;
        private string _ShortRouteName;
        private string _ProcedureId;
        private int _Available;
        private int _SelectPriority;

        #endregion

        /// <summary>
        /// Used with entity framework
        /// </summary>
        public Route()
        {            
            Validate();
        }

        public Route(string routeid, int available, int selectpriority, ProcessCel processCel)
        {
            this.RouteId = routeid;
            this.RouteName = processCel.ProcesCellId +":"+ routeid +":";
            this.ShortRouteName = routeid;
            this.Available = available;
            this.SelectPriority = selectpriority;
            this.ProcedureId = processCel.ProcesCellId + routeid;
            this.ProcesCellId = processCel.ProcesCellId;

            this.ProcesCell = processCel;

            pru_Procedures procedure = new pru_Procedures(this);
            pru_Procedures = procedure;

            Validate();
        }

        #region Properties

        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        public virtual ObservableCollection<sri_SubRoutesInRoutes> SubrouteInRouteList
        {
            get { return _SubrouteInRouteList; }
            set
            {
                SetProperty(ref _SubrouteInRouteList, value);
            }
        }
        public virtual ObservableCollection<rop_RoutePars> rop_RoutePars { get; set; }
        public virtual pru_Procedures pru_Procedures { get; set; }

        public virtual ProcessCel ProcesCell
        {
            get { return _ProcessCel; }
            set { SetProperty(ref _ProcessCel, value); }
        }

        #region rot_Routes Columns

        [Key]
        [Column("rot_ProcCellId", Order = 0)]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [Key]
        [Column("rot_RouteId", Order = 1)]
        public string RouteId
        {
            get { return _RouteId; }
            set { SetProperty(ref _RouteId, value); }
        }
        [Column("rot_RouteNm")]
        public string RouteName
        {
            get { return _RouteName; }
            set { SetProperty(ref _RouteName, value); }
        }
        [Column("rot_ShortRouteNm")]
        public string ShortRouteName
        {
            get { return _ShortRouteName; }
            set { SetProperty(ref _ShortRouteName, value); }
        }
        [Column("rot_ProcedureId")]
        public string ProcedureId
        {
            get { return _ProcedureId; }
            set { SetProperty(ref _ProcedureId, value); }
        }
        [Column("rot_Available")]
        public int Available
        {
            get { return _Available; }
            set { SetProperty(ref _Available, value); }
        }
        [Column("rot_SelectPriority")]
        public int SelectPriority
        {
            get { return _SelectPriority; }
            set { SetProperty(ref _SelectPriority, value); }
        }

        #endregion

        #endregion

        #region Methods

        public bool AddSubroute(SubRoute subroute)
        {
            sri_SubRoutesInRoutes SubrouteInRoute = new sri_SubRoutesInRoutes(this, subroute);
            if (SubrouteInRoute.DatabaseInsert())
            {
                SubrouteInRoute.sur_SubRoutes = subroute;
                SubrouteInRoute.rot_Routes = this;

                OrderObservableList.AddSorted(SubrouteInRouteList, SubrouteInRoute);
                OrderObservableList.AddSorted(subroute.sri_SubRoutesInRoutes, SubrouteInRoute);
                return true;
            }
            return false;
        }
        public ObservableCollection<SubRoute> GetSubrouteNotInRoute()
        {
            ObservableCollection<SubRoute> inRoute = new ObservableCollection<SubRoute>();
            foreach (sri_SubRoutesInRoutes sri in SubrouteInRouteList)
            {
                inRoute.Add(sri.sur_SubRoutes);
            }

            ObservableCollection<SubRoute> notInRoute = new ObservableCollection<SubRoute>();
            foreach (SubRoute S in ProcesCell.SubrouteList)
            {
                if (!inRoute.Contains(S))
                {
                    OrderObservableList.AddSorted(notInRoute, S);
                }
   
            }

            return notInRoute;
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
        }
        public void DeleteChild(IConfigObject obj)
        {
            throw new NotImplementedException();
            //SubRoute unit = obj as SubRoute;
            //foreach (SubRoute U in SubRouteList)
            //{
            //    if (U.Equals(unit))
            //    {
            //        SubRouteList.Remove(unit);
            //        break;
            //    }
            //}
        }
        public void CreateChild()
        {
            throw new NotImplementedException();
        }
        public int CompareTo(object obj)
        {
            Route route = obj as Route;
            return string.Compare(this.RouteName, route.RouteName);
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
        public ObservableCollection<IParameterObject> GetParameterList()
        {
            ObservableCollection<IParameterObject> parameterList = new ObservableCollection<IParameterObject>(rop_RoutePars);
            return parameterList;
        }
        public void RemoveParameter(Parameter paramdef)
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


        public string GetName()
        {
            return "Route " + RouteId;
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

        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters()
        {
            throw new NotImplementedException();
        }

        public bool AddParameter(ParameterDefinition paramdefinition)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
