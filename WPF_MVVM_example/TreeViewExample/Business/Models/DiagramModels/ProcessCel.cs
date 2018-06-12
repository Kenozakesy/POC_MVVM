using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using TreeViewExample.Business.Attributes;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModelsF;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.Interfaces;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;


namespace TreeViewExample.Business.Models
{
    [Table("prc_ProcCells")]
    public class ProcessCel : ViewModelBase, IObjectWithParameters
    {
        private  ProcesCellBusiness db = new ProcesCellBusiness(new MSSQL_ProcesCellRepository());

        private ObservableCollection<Route> _RouteList = new ObservableCollection<Route>();
        private ObservableCollection<SubRoute> _SubrouteList = new ObservableCollection<SubRoute>();

        private bool _IsExpanded;
        private Brush _Brush;
        private static Random ran = new Random();
        private IsValidated _Isvalid;
        private ProcesCellType _Type;
        
        private bool _BatchOptionsP;
        private bool _BatchOptionsD;
        private bool _BatchOptionsS;
        private bool _BatchOptionsL;
        private bool _BatchOptionsR;

        #region prc_columns fields

        private string _ProcesCellId;
        private string _ProcesCellName;
        private string _ShortProcesCellName;
        private bool _ProdLocked;
        private string _ProcesCellTypeId;
        private string _OAProcesCellId;
        private string _OABatchReqObjectName;
        private string _BatchRegTypeId;
        private string _BatchStartTypeId;
        private string _BatchOptions;
        private string _Display;

        #endregion

        /// <summary>
        /// constructor for entity framework
        /// </summary>
        public ProcessCel()
        {
            pca_ProcCellPars = new ObservableCollection<pca_ProcCellPars>();
            Validate();
        }

        public ProcessCel(ProcesCellType type)
        {
            this._Type = type;
            ProcesCellTypeId = _Type.ToString();

            int? firstAvailable = ListGodClass.Instance.GetFirstAvailableProccellId(this);
         
            ProcesCellId = _Type.ToString() + firstAvailable;
            ProcesCellName = Enumerations.GetEnumDescription(_Type) + " " + firstAvailable;
            ShortProcesCellName = _Type.ToString() + firstAvailable;
            ProdLocked = false;
            OAProcesCellId = "pc" + _Type.ToString() + "" + firstAvailable;
            OABatchReqObjectName = "Customer."+ Enumerations.GetEnumDescription(_Type) + ".pc" + _Type.ToString() + firstAvailable + ".General.scBatchRequest" + _Type.ToString() + firstAvailable;
            _BatchRegTypeId = "DC";
            _BatchStartTypeId = "Scheduled";
            BatchOptions = "";
            Display = "1";

            pca_ProcCellPars = new ObservableCollection<pca_ProcCellPars>();

            AddRequiredParametersToNewProcescell();

            AddDefaultRoute();
            Validate();
        }

        #region Properties

        public virtual ObservableCollection<Route> RouteList
        {
            get { return _RouteList; }
            set { SetProperty(ref _RouteList, value); }
        }
        public virtual ObservableCollection<SubRoute> SubrouteList
        {
            get { return _SubrouteList; }
            set { SetProperty(ref _SubrouteList, value); }
        }
        public virtual ObservableCollection<pca_ProcCellPars> pca_ProcCellPars { get; set; }
        public virtual ObservableCollection<opc_OAProcCellDefs> opc_OAProcCellDefs { get; set; }

        [NotMapped]
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { SetProperty(ref _IsExpanded, value); }
        }
        [NotMapped]
        public ProcesCellType ProcesCellType
        {
            get
            {
                return _Type;
            }
            set
            {
                SetProperty(ref _Type, value);
                ProcesCellTypeId = value.ToString();
            }
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
        [NotMapped]
        public bool BatchOptionsP
        {
            get { return _BatchOptionsP; }
            set { SetProperty(ref _BatchOptionsP, value); BatchOptionsChange(); }
        }
        [NotMapped]
        public bool BatchOptionsD
        {
            get { return _BatchOptionsD; }
            set
            {
                SetProperty(ref _BatchOptionsD, value);
                BatchOptionsChange();
            }
        }
        [NotMapped]
        public bool BatchOptionsS
        {
            get { return _BatchOptionsS; }
            set {
                SetProperty(ref _BatchOptionsS, value);
                BatchOptionsChange();
            }
        }
        [NotMapped]
        public bool BatchOptionsL
        {
            get { return _BatchOptionsL; }
            set { SetProperty(ref _BatchOptionsL, value);
                BatchOptionsChange();
            }
        }
        [NotMapped]
        public bool BatchOptionsR
        {
            get { return _BatchOptionsR; }
            set { SetProperty(ref _BatchOptionsR, value);
                BatchOptionsChange();
            }
        }

        #region prc_columns properties

        [Key]
        [DatabaseProperty]
        [Column("prc_ProcCellId")]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [DatabaseProperty]
        [Column("prc_ProcCellNm")]
        public string ProcesCellName
        {
            get { return _ProcesCellName; }
            set { SetProperty(ref _ProcesCellName, value); }
        }
        [DatabaseProperty]
        [Column("prc_ShortProcCellNm")]
        public string ShortProcesCellName
        {
            get { return _ShortProcesCellName; }
            set { SetProperty(ref _ShortProcesCellName, value); }
        }
        [DatabaseProperty]
        [Column("prc_ProdLocked")]
        public bool ProdLocked
        {
            get { return _ProdLocked; }
            set { SetProperty(ref _ProdLocked, value); }
        }
        [DatabaseProperty]
        [Column("prc_ProcCellTypeId")]
        public string ProcesCellTypeId
        {
            get { return _ProcesCellTypeId; }
            set { SetProperty(ref _ProcesCellTypeId, value); }
        }
        [DatabaseProperty]
        [Column("prc_OAProcCellId")]
        public string OAProcesCellId
        {
            get { return _OAProcesCellId; }
            set { SetProperty(ref _OAProcesCellId, value); }
        }
        [DatabaseProperty]
        [Column("prc_OABatchReqObjectNm")]
        public string OABatchReqObjectName
        {
            get { return _OABatchReqObjectName; }
            set { SetProperty(ref _OABatchReqObjectName, value); }
        }
        [DatabaseProperty]
        [Column("prc_BatchRegTypeId")]
        public string BatchRegTypeId
        {
            get { return _BatchRegTypeId; }
            set { SetProperty(ref _BatchRegTypeId, value); }
        }
        [DatabaseProperty]
        [Column("prc_BatchStartTypeId")]
        public string BatchStartTypeId
        {
            get { return _BatchStartTypeId; }
            set { SetProperty(ref _BatchStartTypeId, value); }
        }
        [DatabaseProperty]
        [Column("prc_BatchOptions")]
        public string BatchOptions
        {
            get { return _BatchOptions; }
            set { SetProperty(ref _BatchOptions, value); }
        }
        [DatabaseProperty]
        [Column("prc_Display")]
        public string Display
        {
            get { return _Display; }
            set { SetProperty(ref _Display, value); }
        }

        #endregion

        #endregion


        #region Methods

        private void AddRequiredParametersToNewProcescell()
        {
            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            foreach (ParameterDefinition PD in requiredParameters)
            {
                pca_ProcCellPars procescellparameter = new pca_ProcCellPars(this, PD);
                pca_ProcCellPars.Add(procescellparameter);
            }
        }
        public bool AddParameter(ParameterDefinition paramdefinition)
        {
            pca_ProcCellPars procescellparameter = new pca_ProcCellPars(this, paramdefinition);
            if (procescellparameter.DatabaseInsert())
            {
                return true;
            }
            return false;
        }
        public void AddRequiredParameters()
        {
            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !pca_ProcCellPars.Any(x => x.ParameterDefinition == y)).ToList();
            foreach (ParameterDefinition PD in ParameterDefinitionsNotInObject)
            {
                AddParameter(PD);
            }
        }
        public void AddNewSubroute(string name)
        {
            List<int> subRouteIds = new List<int>();
            foreach (SubRoute sr in SubrouteList)
            {
                string routeid = new string(sr.SubRouteId.Where(char.IsDigit).ToArray());
                subRouteIds.Add(Convert.ToInt32(routeid));
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(subRouteIds).FirstOrDefault();

            SubRoute subroute = new SubRoute(this, "SR" + firstAvailable, name);
            subroute.DatabaseInsert();
            subroute.ProcessCel = this;
            OrderObservableList.AddSorted(SubrouteList, subroute);
        }
        public void AddGeneratedRoute()
        {
            List<int> RouteIds = new List<int>();
            foreach (Route r in RouteList)
            {
                string routeid = new string(r.RouteId.Where(char.IsDigit).ToArray());
                RouteIds.Add(Convert.ToInt32(routeid));
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(RouteIds).FirstOrDefault();

            Route route = new Route("R" + firstAvailable, 1, 1, this);       
            RouteList.Add(route);
        }
        public Route GetGeneratedRoute()
        {
            List<int> RouteIds = new List<int>();
            foreach (Route r in RouteList)
            {
                string routeid = new String(r.RouteId.Where(Char.IsDigit).ToArray());
                RouteIds.Add(Convert.ToInt32(routeid));
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(RouteIds).FirstOrDefault();

            Route route = new Route("R" + firstAvailable, 1, 1, this);
            return route;
        }
        private void AddDefaultRoute()
        {
            Route route = new Route("R" + 1, 1, 1, this);
            RouteList.Add(route);
        }
        public void RemoveGeneratedRoute()
        {
            if (RouteList.Count > 0)
            {
                RouteList.RemoveAt(RouteList.Count - 1);
            }
        }
        private void BatchOptionsChange()
        {
            BatchOptions = "";
            if (BatchOptionsP)
            {
                BatchOptions += "P";
            }
            if (BatchOptionsD)
            {
                BatchOptions += "D";
            }
            if (BatchOptionsS)
            {
                BatchOptions += "S";
            }
            if (BatchOptionsL)
            {
                BatchOptions += "L";
            }
            if (BatchOptionsR)
            {
                BatchOptions += "R";
            }
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
        public bool Validate()
        {
            List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
            List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !pca_ProcCellPars.Any(x => x.ParameterDefinition == y)).ToList();

            bool allRoutesAreValid = true;
            foreach (Route route in RouteList)
            {
                if (!route.Validate())
                {
                    allRoutesAreValid = false;
                }
            }

            if (ParameterDefinitionsNotInObject.Count > 0)
            {
                IsValid = IsValidated.InValid;
                return false;
            }
            else
            {
                if (allRoutesAreValid)
                {
                    IsValid = IsValidated.Valid;
                    return true;
                }
                else
                {
                    IsValid = IsValidated.InValidChildren;
                    return false;
                }
            }
        }
        public string GetValidationMessage()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    return "Object is valid.";

                case IsValidated.InValid:
                    List<ParameterDefinition> requiredParameters = db.GetAllRequiredParameterDefinition(this);
                    List<ParameterDefinition> ParameterDefinitionsNotInObject = requiredParameters.Where(y => !pca_ProcCellPars.Any(x => x.ParameterDefinition == y)).ToList();

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
                
                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.ProcesCellId);
                configList.Add(mainListViewModel);
            }

            if (IsExpanded)
            {
                foreach (Route R in RouteList)
                {
                    configList.Add(new MainListViewModel("", "", ""));
                    List<MainListViewModel> routeConfigList = R.GenerateListViewList();
                    configList.AddRange(routeConfigList);
                }
            }

            return configList;
        }
        public ObservableCollection<ProcessCel> GetAllProcesCells()
        {
             return db.GetAllProcesCells();
        }
        public ObservableCollection<IParameterObject> GetParameterList()
        {
            ObservableCollection<IParameterObject> parameterList = new ObservableCollection<IParameterObject>(pca_ProcCellPars);
            return parameterList;
        }
        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters()
        {
            ObservableCollection<ParameterDefinition> ParameterDefinitionList = new ObservableCollection<ParameterDefinition>();
            ParameterDefinitionList = db.GetAddAbleStandardParameters(this);
            return ParameterDefinitionList;
        }
    
        public string GetName()
        {
            return ProcesCellId;
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

        public int CompareTo(object obj)
        {
            ProcessCel cell = obj as ProcessCel;
            return string.Compare(this.ProcesCellId, cell.ProcesCellId);
        }



        #endregion




    }
}
