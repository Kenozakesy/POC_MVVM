using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
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

            //voorbeeld voor later
            //var selected = from p in paramDefinitions
            //               where p.ParName == ConfigurationParameter.ParName
            //               select p;
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
