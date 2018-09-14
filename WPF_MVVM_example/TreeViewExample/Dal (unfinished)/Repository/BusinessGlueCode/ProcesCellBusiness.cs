using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;
using System.Data;
using TreeViewExample.Business.Models.DiagramModels.Parameters;

namespace TreeViewExample.Dal.Repository.BusinessGlueCode
{
    public class ProcesCellBusiness
    {
        IProcesCellRepository _Repository;

        public ProcesCellBusiness(IProcesCellRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

        public ObservableCollection<ProcessCel> GetAllProcesCells()
        {
            List<ProcessCel> paramDefinitions = _Repository.GetAllProcesCells();

            var selected = from p in paramDefinitions
                           select p;

            ObservableCollection<ProcessCel> ProcesCellList = new ObservableCollection<ProcessCel>();

            foreach (ProcessCel PC in selected.ToList())
            {
                OrderObservableList.AddSorted(ProcesCellList, PC);
            }

            return ProcesCellList;
        }

        public List<ParameterDefinition> GetAllRequiredParameterDefinition(ProcessCel cell)
        {
            List<string> RequiredParameterNames = _Repository.GetAllRequiredParameterDefinitionNames(cell);
            return ListGodClass.Instance.ParameterDefinitionList.Where(x => RequiredParameterNames.Any(y => y == x.paf_ParNm)).ToList();
        }

        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters(ProcessCel cell)
        {
            List<string> paramDefNames = _Repository.GetAllParameterDefinitionNames(cell);
            List<ParameterDefinition> paramDef = ListGodClass.Instance.ParameterDefinitionList.Where(x => paramDefNames.Any(y => y == x.paf_ParNm)).ToList();

            List<ParameterDefinition> addAbleParametersList = paramDef.Where(x => !cell.pca_ProcCellPars.Any(y => y.ParameterDefinition == x)).ToList();

            ObservableCollection<ParameterDefinition> addAbleParameters = new ObservableCollection<ParameterDefinition>(addAbleParametersList);

            return addAbleParameters;
        }

        public bool DatabaseDelete(object obj)
        {
            return _Repository.DatabaseDelete(obj);
        }

        public bool DatabaseInsert(object obj)
        {
           return _Repository.DatabaseInsert(obj);
        }

        public bool DatabaseUpdate(object obj)
        {
            return _Repository.DatabaseUpdate(obj);
        }




        #endregion
    }
}
