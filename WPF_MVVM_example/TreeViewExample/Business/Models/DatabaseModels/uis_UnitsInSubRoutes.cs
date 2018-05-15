namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class uis_UnitsInSubRoutes
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string uis_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string uis_SubRouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string uis_OAUnitId { get; set; }

        public int uis_SeqNr { get; set; }

        public virtual SubRoute sur_SubRoutes { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
