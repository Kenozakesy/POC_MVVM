using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;
using System.Data;
using TreeViewExample.Dal.EntityFramework;
using System.Linq;
using TreeViewExample.Business.Singletons;
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


        //hier moet een betere manier voor bedacht worden
        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters(ProcessCel cell)
        {
            ObservableCollection<ParameterDefinition> toRemove = new ObservableCollection<ParameterDefinition>();
            foreach (pca_ProcCellPars pca in cell.pca_ProcCellPars)
            {
                OrderObservableList.AddSorted(toRemove, pca.ParameterDefinition);               
            }
            ObservableCollection<ParameterDefinition> ToHave = new ObservableCollection<ParameterDefinition>();
            foreach (ParameterDefinition PD in ListGodClass.Instance.ParameterDefinitionList)
            {
                ToHave.Add(PD);
            }

            var result = ToHave.Except(toRemove);

            ObservableCollection<ParameterDefinition> addAbleParameters = new ObservableCollection<ParameterDefinition>();
            foreach (ParameterDefinition PD in result.ToList())
            {
                addAbleParameters.Add(PD);
            }

            List<ParameterDefinition> AllowedDefs = _Repository.GetAllParametersProcescell(cell); //repository method causes a weird bug that cannot be traced back
            //this loop counters out the bug. It removes the objects that the bug adds. It is not clear what is caising it.
            foreach (ParameterDefinition PD in AllowedDefs)
            {
                ListGodClass.Instance.ParameterDefinitionList.Remove(PD);
            }
    
            List<ParameterDefinition> intersect = addAbleParameters.Where(x => AllowedDefs.Any(y => y.paf_ParNm == x.paf_ParNm)).ToList();

            addAbleParameters = new ObservableCollection<ParameterDefinition>(intersect);

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
