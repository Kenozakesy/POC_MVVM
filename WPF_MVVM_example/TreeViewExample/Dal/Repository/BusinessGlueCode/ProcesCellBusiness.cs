using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;

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
            List<ProcessCel> paramDefinitions = _Repository.GetAllParameterDefinitions();

            var selected = from p in paramDefinitions
                           select p;

            ObservableCollection<ProcessCel> ProcesCellList = new ObservableCollection<ProcessCel>();

            foreach (ProcessCel PC in selected.ToList())
            {
                OrderObservableList.AddSorted(ProcesCellList, PC);
            }

            return ProcesCellList;
        }

        #endregion
    }
}
