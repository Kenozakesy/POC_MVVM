using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Singletons
{
    /// <summary>
    /// This class is used to keep the most important 3 lists in one place without having to request them another time during run time
    /// </summary>
    public class ListGodClass
    {
        private static ListGodClass _Instance;

        private ListGodClass()
        {

        }

        public ListGodClass Instance
        {
            get
            {
                if (Instance == null)
                {
                    _Instance = new ListGodClass();
                }
                return Instance;
            }
        }
    }
}
