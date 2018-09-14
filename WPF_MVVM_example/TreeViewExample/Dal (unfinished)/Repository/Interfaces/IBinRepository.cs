using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Dal.Repository.Interfaces
{
    public interface IBinRepository : IDatabaseActions
    {
        List<string> GetAllParameterDefinitionNames();
    }
}
