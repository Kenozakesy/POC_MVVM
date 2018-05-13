namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Documents;
    using TreeViewExample.Business.Models;

    [Table("sri_SubRoutesInRoutes")]
    public partial class sri_SubRoutesInRoutes
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string sri_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string sri_RouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string sri_SubRouteId { get; set; }

        public int sri_SeqNr { get; set; }

        public virtual Route rot_Routes { get; set; }
        public virtual SubRoute sur_SubRoutes { get; set; }
    }
}
