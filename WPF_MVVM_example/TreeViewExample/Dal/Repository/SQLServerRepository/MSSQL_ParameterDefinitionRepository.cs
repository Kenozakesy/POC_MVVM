using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;

namespace TreeViewExample.Dal.SQLServerRepository
{
    public class MSSQL_ParameterDefinitionRepository : IParameterDefinitionRepository
    {

        public void AlterProcessCelTypeParameterDefinition(bool ParameterValue, string ParameterName)
        {
            throw new NotImplementedException();
        }

        public void AlterTableParameterDefinition(bool ParameterValue, string ParameterName)
        {
            throw new NotImplementedException();
        }

        public List<ParameterDefinition> GetParameterDefinitions()
        {
            List<ParameterDefinition> ConfigParameters = new List<ParameterDefinition>();

            ConfigParameters.Add(new ParameterDefinition("weight", "heavyness", "1000", "kg", true, true));
            ConfigParameters.Add(new ParameterDefinition("weight", "heavyness", "1000", "kg", true, true));
            ConfigParameters.Add(new ParameterDefinition("weight", "heavyness", "1000", "kg", true, true));

            return ConfigParameters;
        }

        public void InsertParameterDefinition(ParameterDefinition ConfigurationParameter)
        {
            throw new NotImplementedException();
        }

    }
}
