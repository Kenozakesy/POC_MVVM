namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bir_BinsInSubRoutes
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bir_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string bir_SubRouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string bir_SourceDest { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string bir_BinId { get; set; }

        public virtual Bin bin_Bins { get; set; }

        public virtual SubRoute sur_SubRoutes { get; set; }
    }
}
