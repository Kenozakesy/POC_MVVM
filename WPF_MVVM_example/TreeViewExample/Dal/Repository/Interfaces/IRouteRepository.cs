using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Dal.Repository.Interfaces
{
    public interface IRouteRepository : IDatabaseActions
    {
        List<string> GetAllParameterDefinitionNames(Route route);
        List<string> GetAllRequiredParameterDefinitionNames(Route route);
    }
}
