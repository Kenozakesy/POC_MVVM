using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Interfaces
{
    public interface IDatabaseModelsActions
    {
        bool DatabaseInsert();
        bool DatabaseUpdate();
        bool DatabaseDelete();
    }
}
