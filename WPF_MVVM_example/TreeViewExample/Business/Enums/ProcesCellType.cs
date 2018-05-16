using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Enums
{
    public enum ProcesCellType
    {
        [Description("TransportLine")]
        TL,
        [Description("BlendingLine")]
        BL,
        [Description("IntakeLine")]
        IL,
        [Description("OutloadingLine")]
        OL,
        [Description("PressLine")]
        PL,
        [Description("RoutingLine")]
        RL,
        [Description("PackagingLine")]
        SL,
        [Description("Contraset")]
        CS
    }
}

  