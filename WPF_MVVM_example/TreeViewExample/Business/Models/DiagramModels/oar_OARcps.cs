namespace TreeViewExample.Business.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TreeViewExample.Business.Models;

    public partial class oar_OARcps
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string oar_ProcedureId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string oar_OAStateId { get; set; }

        [Required]
        [StringLength(256)]
        public string oar_OARcpNM { get; set; }

        public virtual pru_Procedures pru_Procedures { get; set; }
    }
}
