using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Interfaces
{
    public interface IParameterDefinitionRepository : IDatabaseActions
    {
        List<ParameterDefinition> GetAllParameterDefinitions();
    }
}
