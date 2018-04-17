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

        public void AlterProcessCelTypeParameterDefinition(bool parameterValue, string parameterName)
        {
            _Repository.AlterProcessCelTypeParameterDefinition(parameterValue, parameterName);
        }

        public void AlterTableParameterDefinition(bool parameterValue, string parameterName)
        {
            _Repository.AlterTableParameterDefinition(parameterValue, parameterName);
        }

        public List<ParameterDefinition> GetParameterDefinitions()
        {
            List<ParameterDefinition> configList = new List<ParameterDefinition>();

            //now you do not have to edit the database specifically 
            var results = from c in configList            
                          where c.DisplayToUser == true
                          select c;

            return results.ToList();
        }

        public void InsertParameterDefinition(ParameterDefinition configurationParameter)
        {
            _Repository.InsertParameterDefinition(configurationParameter);
        }

    }
}
