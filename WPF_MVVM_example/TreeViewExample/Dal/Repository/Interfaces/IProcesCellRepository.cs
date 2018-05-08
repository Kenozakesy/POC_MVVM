using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;

namespace TreeViewExample.Dal.Repository.Interfaces
{
    public interface IProcesCellRepository
    {
        List<ProcessCel> GetAllParameterDefinitions();
    }
}
