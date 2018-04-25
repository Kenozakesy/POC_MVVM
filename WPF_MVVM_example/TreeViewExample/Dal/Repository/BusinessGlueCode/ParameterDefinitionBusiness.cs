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

        public bool CheckIfParamNameExists(ParameterDefinition ConfigurationParameter)
        {
           List<ParameterDefinition> paramDefinitions = _Repository.GetAllParameterDefinitions();

            foreach (ParameterDefinition PD in paramDefinitions)
            {
                if (ConfigurationParameter.ParName == PD.ParName)
                {
                    return true;
                }
            }
            return false;
        }

        public ObservableCollection<ParameterDefinition> GetAllCustomerParameterDefinitions()
        {
            List<ParameterDefinition> paramDefinitions = _Repository.GetAllParameterDefinitions();

            var selected = from p in paramDefinitions
                           where p.IsStandardParameter == false
                           select p;

            ObservableCollection<ParameterDefinition> paramDefinitionsForReturn = new ObservableCollection<ParameterDefinition>();

            foreach (ParameterDefinition PD in selected.ToList())
            {
                OrderObservableList.AddSorted(paramDefinitionsForReturn, PD);
            }

            return paramDefinitionsForReturn;
        }

        public bool InsertParameterDefinition(ParameterDefinition configurationParameter)
        {
            return _Repository.InsertNewParameterDefinition(configurationParameter);
        }

        public bool InsertIntoTpm(ParameterDefinition ConfigurationParameter, string tableId)
        {
            return _Repository.InsertIntoTpm(ConfigurationParameter, tableId);
        }

        #endregion 
    }
}
