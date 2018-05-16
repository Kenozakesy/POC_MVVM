namespace TreeViewExample.Business.Models.DatabaseModelsF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class opc_OAProcCellDefs
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string opc_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string opc_RouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string opc_OAProcCellPUObjectNm { get; set; }

        [Required]
        [StringLength(256)]
        public string opc_OAProcCellBatchInfo { get; set; }

        public int? opc_OAProcCellColor { get; set; }

        [StringLength(50)]
        public string opc_BatchNm { get; set; }

        public virtual ProcessCel prc_ProcCells { get; set; }
    }
}
