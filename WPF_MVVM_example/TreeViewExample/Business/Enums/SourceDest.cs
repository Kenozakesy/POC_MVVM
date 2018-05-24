using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Enums
{
    public enum SourceDest
    {
        [Description("Destination")]
        D,
        [Description("Source")]
        S,
    }
}
