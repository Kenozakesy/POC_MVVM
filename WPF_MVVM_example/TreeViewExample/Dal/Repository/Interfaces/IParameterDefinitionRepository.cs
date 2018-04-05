using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Dal.Interfaces
{
    internal interface IParameterDefinitionRepository 
    {
        List<ParameterDefinition> GetParameterDefinitions();
        void InsertParameterDefinition(ParameterDefinition ConfigurationParameter);

        void AlterTableParameterDefinition(bool ParameterValue, string ParameterName);
        void AlterProcessCelTypeParameterDefinition(bool ParameterValue, string ParameterName);
    }
}
