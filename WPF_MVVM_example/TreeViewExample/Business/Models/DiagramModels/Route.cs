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
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("rot_Routes")]
    public class Route : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        RouteBusiness db = new RouteBusiness(new MSSQL_RouteRepository());

        #region Fields

        private ObservableCollection<RouteParameter> _RouteParameterList = new ObservableCollection<RouteParameter>();
        private ObservableCollection<SubRoute> _SubRouteList = new ObservableCollection<SubRoute>();
        private ProcessCel _ProcessCel;

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
        /// Ued with entity framework
        /// </summary>
        public Route()
        {
            Validate();
            GetSubRoutesDatabase();           
            GetRouteParameters();
        }

        #region Properties

        [NotMapped]
        public ObservableCollection<RouteParameter> RouteParameterList
        {
            get { return _RouteParameterList; }
            set { SetProperty(ref _RouteParameterList, value); }
        }
        [NotMapped]
        public ObservableCollection<SubRoute> SubRouteList
        {
            get { return _SubRouteList; }
            set { SetProperty(ref _SubRouteList, value); }
        }
        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #region rot_Routes Columns

        public ProcessCel ProcesCell
        {
            get { return _ProcessCel; }
            set { SetProperty(ref _ProcessCel, value); }
        }

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
        private void GetSubRoutesDatabase()
        {
             //database stuff
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
            return RouteId;
        }


        #endregion

    }
}
