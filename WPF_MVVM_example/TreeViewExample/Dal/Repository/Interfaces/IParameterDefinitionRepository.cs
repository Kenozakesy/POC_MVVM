using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Dal.Interfaces
{
    public interface IParameterDefinitionRepository 
    {
        bool InsertNewParameterDefinition(ParameterDefinition ConfigurationParameter);
        bool CheckIfParamNameExists(ParameterDefinition ConfigurationParameter);

    }
}
