﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Singletons
{
    /// <summary>
    /// This class is used to keep the most important 3 lists in one place without having to request them another time during run time
    /// </summary>
    public class ListGodClass : ViewModelBase
    {
        private static ListGodClass _Instance;

        private ObservableCollection<ProcessCel> _ProcessCelList = new ObservableCollection<ProcessCel>();
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private ObservableCollection<ParameterDefinition> _ParameterDefinitionList = new ObservableCollection<ParameterDefinition>();

        private ListGodClass()
        {
         
        }

        public void LoadDataFromDB()
        {
            AddProcesCells();
            GetAllParameterDefinitions();
            GetBinsFromDatabase();

            //validateAll()

 
        }

        public static ListGodClass Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ListGodClass();
                }
                return _Instance;
            }
        }

        #region Properties

        public ObservableCollection<ProcessCel> ProcessCelList
        {
            get { return _ProcessCelList; }
            set { _ProcessCelList = value; }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { _BinList = value; }
        }
        public ObservableCollection<ParameterDefinition> ParameterDefinitionList
        {
            get { return _ParameterDefinitionList; }
            set
            {
                SetProperty(ref _ParameterDefinitionList, value);
            }
        }

        #endregion

        #region Methods

        private void GetAllParameterDefinitions()
        {
            ParameterDefinition.GetAllParametersDefinitions();

            foreach (ParameterDefinition paf in ParameterDefinitionList)
            {
                paf.ConvertValidValues();
            }
        }




        //these need to go away in their own classes
        private void AddProcesCells()
        {
            ProcessCel procCell = new ProcessCel();
            ProcessCelList = procCell.GetAllProcesCells();
        }
        public void AddBin(Bin bin)
        {
            OrderObservableList.AddSorted(BinList, bin);
        }
        public void DeleteBin(Bin bin)
        {
            BinList.Remove(bin);
        }
        private void GetBinsFromDatabase()
        {
            Bin.GetAllBins();
        }
        public int? GetFirstAvailableProccellId(ProcessCel cell)
        {
            List<int> procIds = new List<int>();
            procIds.Add(0);

            foreach (ProcessCel r in ProcessCelList)
            {
                if (cell.ProcesCellTypeId == r.ProcesCellTypeId)
                {
                    string routeid = new String(r.ProcesCellId.Where(Char.IsDigit).ToArray());
                    procIds.Add(Convert.ToInt32(routeid));
                }
            }
            int? firstAvailable = Enumerable.Range(0, int.MaxValue).Except(procIds).FirstOrDefault();

            return firstAvailable;
        }

        #endregion
    }
}
