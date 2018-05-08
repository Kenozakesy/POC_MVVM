﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;


namespace TreeViewExample.Business.Models
{
    [Table("prc_ProcCells")]
    public class ProcessCel : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        private ProcesCellBusiness db = new ProcesCellBusiness(new MSSQL_ProcesCellRepository());


        private ObservableCollection<Route> _RouteList = new ObservableCollection<Route>();
        private ObservableCollection<SubRoute> _SubrouteList = new ObservableCollection<SubRoute>();
        private ObservableCollection<ProcessCelParameter> _ProcessCelParameterList = new ObservableCollection<ProcessCelParameter>();

        private Brush _Brush;
        private static Random ran = new Random();
        private IsValidated _Isvalid;

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
            AddRoutes();
            GetProcesscelParameters();
            Validate();
        }

        #region Properties

        [NotMapped]
        public ObservableCollection<Route> RouteList
        {
            get { return _RouteList; }
            set { SetProperty(ref _RouteList, value); }
        }
        [NotMapped]
        public ObservableCollection<SubRoute> SubrouteList
        {
            get { return _SubrouteList; }
            set { SetProperty(ref _SubrouteList, value); }
        }
        [NotMapped]
        public ObservableCollection<ProcessCelParameter> ProcessCelParameterList
        {
            get { return _ProcessCelParameterList; }
            set { SetProperty(ref _ProcessCelParameterList, value); }
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
            set { SetProperty(ref _Isvalid, value); }
        }

        #region prc_columns properties

        [Key]
        [Column("prc_ProcCellId")]
        public string ProcesCellId
        {
            get { return _ProcesCellId; }
            set { SetProperty(ref _ProcesCellId, value); }
        }
        [Column("prc_ProcCellNm")]
        public string ProcesCellName
        {
            get { return _ProcesCellName; }
            set { SetProperty(ref _ProcesCellName, value); }
        }
        [Column("prc_ShortProcCellNm")]
        public string ShortProcesCellName
        {
            get { return _ShortProcesCellName; }
            set { SetProperty(ref _ShortProcesCellName, value); }
        }
        [Column("prc_ProdLocked")]
        public bool ProdLocked
        {
            get { return _ProdLocked; }
            set { SetProperty(ref _ProdLocked, value); }
        }
        [Column("prc_ProcCellTypeId")]
        public string ProcesCellTypeId
        {
            get { return _ProcesCellTypeId; }
            set { SetProperty(ref _ProcesCellTypeId, value); }
        }
        [Column("prc_OAProcCellId")]
        public string OAProcesCellId
        {
            get { return _OAProcesCellId; }
            set { SetProperty(ref _OAProcesCellId, value); }
        }
        [Column("prc_OABatchReqObjectNm")]
        public string OABatchReqObjectName
        {
            get { return _OABatchReqObjectName; }
            set { SetProperty(ref _OABatchReqObjectName, value); }
        }
        [Column("prc_BatchRegTypeId")]
        public string BatchRegTypeId
        {
            get { return _BatchRegTypeId; }
            set { SetProperty(ref _BatchRegTypeId, value); }
        }
        [Column("prc_BatchStartTypeId")]
        public string BatchStartTypeId
        {
            get { return _BatchStartTypeId; }
            set { SetProperty(ref _BatchStartTypeId, value); }
        }
        [Column("prc_BatchOptions")]
        public string BatchOptions
        {
            get { return _BatchOptions; }
            set { SetProperty(ref _BatchOptions, value); }
        }
        [Column("prc_Display")]
        public string Display
        {
            get { return _Display; }
            set { SetProperty(ref _Display, value); }
        }

        #endregion

        #endregion



        #region Methods

        /// <summary>
        /// Moet omgebouwd worden zodat die naar de databasde toe gaat
        /// </summary>
        private void GetProcesscelParameters()
        {
            for (int i = 0; i < 5; i++)
            {
                ProcessCelParameter procescelparameter = new ProcessCelParameter("Name", "description", "1", "-", "1-5", true, true, this);
                ProcessCelParameterList.Add(procescelparameter);
            }
        }
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
            Route route = obj as Route;
            foreach (Route U in RouteList)
            {
                if (U.Equals(route))
                {
                    RouteList.Remove(route);
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
            //    MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.ProcesCellId);
            //    configList.Add(mainListViewModel);
            //}

            return configList;
        }
        public int CompareTo(object obj)
        {
            ProcessCel cell = obj as ProcessCel;
            return string.Compare(this.ProcesCellId, cell.ProcesCellId);        
        }

        public ObservableCollection<Parameter> GetParameterList()
        {
            ObservableCollection<Parameter> parameterList = new ObservableCollection<Parameter>();
            foreach (ProcessCelParameter PP in ProcessCelParameterList)
            {
                parameterList.Add(PP);
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

        public ObservableCollection<ProcessCel> GetAllProcesCells()
        {
             return db.GetAllProcesCells();
        }

        public string GetName()
        {
            return ProcesCellId;
        }





        #endregion




    }
}
