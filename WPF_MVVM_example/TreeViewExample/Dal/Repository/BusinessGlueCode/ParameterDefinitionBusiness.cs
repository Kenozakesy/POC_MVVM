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

        public bool CheckIfParamNameExists(ParameterDefinition ConfigurationParameter)
        {
           return _Repository.CheckIfParamNameExists(ConfigurationParameter);
        }

        public bool InsertParameterDefinition(ParameterDefinition configurationParameter)
        {
           return _Repository.InsertNewParameterDefinition(configurationParameter);
        }

    }
}
