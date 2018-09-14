using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Dal.Repository.Interfaces
{
    public interface IDatabaseActions
    {
        bool DatabaseUpdate(object obj);
        bool DatabaseDelete(object obj);
        bool DatabaseInsert(object obj);

    }
}
