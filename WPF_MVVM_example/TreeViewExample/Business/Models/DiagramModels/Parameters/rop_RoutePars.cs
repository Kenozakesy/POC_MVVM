namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rop_RoutePars : IParameterObject
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string rop_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string rop_RouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string rop_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string rop_ParDesc { get; set; }

        [StringLength(100)]
        public string rop_ParValue { get; set; }

        [StringLength(50)]
        public string rop_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string rop_DisplayToUser { get; set; }

        public virtual Route rot_Routes { get; set; }
    }
}
