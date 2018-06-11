using System;
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

            //validateAll()

            ReorderAllLists();
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

        private void ReorderAllLists()
        {
            ParameterDefinitionList = new ObservableCollection<ParameterDefinition>(ParameterDefinitionList.OrderByDescending(i => i));
            BinList = new ObservableCollection<Bin>(BinList.OrderByDescending(i => i));
        }


        //these need to go away in their own classes
        private void AddProcesCells()
        {
            var cel = new ProcessCel();
            ProcessCelList = cel.GetAllProcesCells();

            foreach (ProcessCel P in ProcessCelList)
            {
                P.Validate();
            }
            foreach (Bin B in BinList)
            {
                B.Validate();
            }
        }


        public int? GetFirstAvailableProccellId(ProcessCel cell)
        {
            List<int> procIds = new List<int>();

            foreach (ProcessCel r in ProcessCelList)
            {
                if (cell.ProcesCellTypeId == r.ProcesCellTypeId)
                {
                    string routeid = new string(r.ProcesCellId.Where(char.IsDigit).ToArray());
                    procIds.Add(Convert.ToInt32(routeid));
                }
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(procIds).FirstOrDefault();

            return firstAvailable;
        }

        #endregion
    }
}
