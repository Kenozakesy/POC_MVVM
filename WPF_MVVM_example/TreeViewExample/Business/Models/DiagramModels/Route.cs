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
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Attributes;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TreeViewExample.Business.Models
{
    [Table("rot_Routes")]
    public class Route : ViewModelBase, IObjectWithParameters
    {
        RouteBusiness db = new RouteBusiness(new MSSQL_RouteRepository());

        #region Fields

        private ProcessCel _ProcessCel;
        private ObservableCollection<sri_SubRoutesInRoutes> _SubrouteInRouteList = new ObservableCollection<sri_SubRoutesInRoutes>();
        private ObservableCollection<SubRoute> _SubRouteList = new ObservableCollection<SubRoute>();

        private bool _IsExpanded;
        private Brush _Brush;
        private static Random ran = new Random();
        private IsValidated _Isvalid;

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
            rop_RoutePars = new ObservableCollection<rop_RoutePars>();
            //Validate();
        }

        public Route(string routeid, int available, int selectpriority, ProcessCel processCel)
        {
            rop_RoutePars = new ObservableCollection<rop_RoutePars>();

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

            //deze twee methodes vetragen de hele boel
   
            new Thread(() =>
            {
                AddRequiredParametersToNewRoute();      
            }).Start();

            IsValid = IsValidated.Valid;
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
            set { SetProperty(ref _Brush, value); }
        }
        [NotMapped]
        public IsValidated IsValid
        {
            get { return _Isvalid; }
            set
            {
                SetProperty(ref _Isvalid, value);
                ChangeColor();
            }
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
        [DatabaseProperty]
        [Column("rot_ProcCellId", Order = 0)]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [Key]
        [DatabaseProperty]
        [Column("rot_RouteId", Order = 1)]
        public string RouteId
        {
            get { return _RouteId; }
            set { SetProperty(ref _RouteId, value); }
        }
        [DatabaseProperty]
        [Column("rot_RouteNm")]
        public string RouteName
        {
            get { return _RouteName; }
            set { SetProperty(ref _RouteName, value); }
        }
        [DatabaseProperty]
        [Column("rot_ShortRouteNm")]
        public string ShortRouteName
        {
            get { return _ShortRouteName; }
            set { SetProperty(ref _ShortRouteName, value); }
        }
        [DatabaseProperty]
        [Column("rot_ProcedureId")]
        public string ProcedureId
        {
            get { return _ProcedureId; }
            set { SetProperty(ref _ProcedureId, value); }
        }
        [DatabaseProperty]
        [Column("rot_Available")]
        public int Available
        {
            get { return _Available; }
            set { SetProperty(ref _Available, value); }
        }
        [DatabaseProperty]
        [Column("rot_SelectPriority")]
        public int SelectPriority
        {
            get { return _SelectPriority; }
            set { SetProperty(ref _SelectPriority, value); }
        }

        #endregion

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.Synchronized)]
        private  void AddRequiredParametersToNewRoute()
        {
            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            foreach (ParameterDefinition PD in requiredParameters)
            {
                rop_RoutePars routeParameter = new rop_RoutePars(this, PD);
                rop_RoutePars.Add(routeParameter);
            }
        }
        public bool AddParameter(ParameterDefinition paramdefinition)
        {
            rop_RoutePars procescellparameter = new rop_RoutePars(this, paramdefinition);
            if (procescellparameter.DatabaseInsert())
            {
                return true;
            }
            return false;
        }
        public void AddRequiredParameters()
        {
            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !rop_RoutePars.Any(x => x.ParameterDefinition == y)).ToList();
            foreach (ParameterDefinition PD in ParameterDefinitionsNotInObject)
            {
                AddParameter(PD);
            }
        }

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
     

        public int CompareTo(object obj)
        {
            Route route = obj as Route;
            return string.Compare(this.RouteName, route.RouteName);
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

                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.RouteName);
                configList.Add(mainListViewModel);
            }

            if (IsExpanded)
            {
                foreach (sri_SubRoutesInRoutes SR in SubrouteInRouteList)
                {
                    configList.Add(new MainListViewModel("", "", ""));
                    List<MainListViewModel> routeConfigList = SR.GenerateListViewList();
                    configList.AddRange(routeConfigList);
                }
            }

            return configList;
        }
        public ObservableCollection<IParameterObject> GetParameterList()
        {
            ObservableCollection<IParameterObject> parameterList = new ObservableCollection<IParameterObject>(rop_RoutePars);
            return parameterList;
        }

        public void ChangeColor()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    Brush = Brushes.LightGreen;
                    break;
                case IsValidated.InValid:
                    Brush = Brushes.Red;
                    break;
                case IsValidated.InValidChildren:
                    Brush = Brushes.Orange;
                    break;
            }
        }
        private static bool antiLimboStatic = true;
        public bool Validate()
        {
            bool checkIfValid = true;

            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !rop_RoutePars.Any(x => x.ParameterDefinition == y)).ToList();

            //foreach (sri_SubRoutesInRoutes sri in SubrouteInRouteList)
            //{
            //    if (!route.Validate())
            //    {
            //        IsValid = IsValidated.InValidChildren;
            //        return false;
            //    }
            //}

            if (ParameterDefinitionsNotInObject.Count > 0)
            {
                IsValid = IsValidated.InValid;
                checkIfValid = false;
            }
            else
            {
                IsValid = IsValidated.Valid;
                checkIfValid = true;
            }

            if (ProcesCell != null && antiLimboStatic)
            {
                antiLimboStatic = false;
                ProcesCell.Validate();
                antiLimboStatic = true;
            }
            return checkIfValid;
        }

        public string GetValidationMessage()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    return "Object is valid.";

                case IsValidated.InValid:
                    List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
                    List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !rop_RoutePars.Any(x => x.ParameterDefinition == y)).ToList();

                    StringBuilder builder = new StringBuilder();
                    foreach (ParameterDefinition nm in ParameterDefinitionsNotInObject)
                    {
                        builder.Append("-" + nm.paf_ParNm + Environment.NewLine);
                    }
                    return "Missing Parameter(s)" + Environment.NewLine + Environment.NewLine + builder.ToString();

                case IsValidated.InValidChildren:
                    return "Object is valid." + Environment.NewLine + "But one or more of the branches is not.";
                default:
                    return "Validation not found.";
            }
        }


        public string GetName()
        {
            return "Route: " + RouteName;
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
            ObservableCollection<ParameterDefinition> ParameterDefinitionList = new ObservableCollection<ParameterDefinition>();
            ParameterDefinitionList = db.GetAddAbleStandardParameters(this);
            return ParameterDefinitionList;
        }

  








        #endregion

    }
}
