using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Interfaces;

namespace TreeViewExample.Dal.DatabaseConnection
{
    public class ParameterDefinitionBusiness
    {
        IParameterDefinitionRepository _Repository;

        public ParameterDefinitionBusiness(IParameterDefinitionRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

        public ObservableCollection<ParameterDefinition> GetAllParameterDefinitions()
        {
            List<ParameterDefinition> paramDefinitions = _Repository.GetAllParameterDefinitions();

            var selected = from p in paramDefinitions
                           select p;

            ObservableCollection<ParameterDefinition> paramDefinitionsForReturn = new ObservableCollection<ParameterDefinition>(selected.ToList());
            return paramDefinitionsForReturn;
        }



        #endregion 
    }
}
