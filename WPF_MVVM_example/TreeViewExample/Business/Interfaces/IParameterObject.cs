using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Business.Interfaces
{
    public interface IParameterObject : IDatabaseModelsActions
    {
        string Value { get; set; }
        ParameterDefinition ParameterDefinition { get; set; }
    }
}
