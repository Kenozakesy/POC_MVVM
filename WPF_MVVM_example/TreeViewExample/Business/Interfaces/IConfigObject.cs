using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Interfaces
{
    public interface IConfigObject : IComparable
    {
        void ChangeColor();
        void Delete();
        void DeleteChild(IConfigObject obj);
        void CreateChild();
    }
}
