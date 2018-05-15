namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pca_ProcCellPars : IParameterObject
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string pca_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pca_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string pca_ParDesc { get; set; }

        [StringLength(100)]
        public string pca_ParValue { get; set; }

        [StringLength(50)]
        public string pca_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string pca_DisplayToUser { get; set; }

        public virtual ProcessCel prc_ProcCells { get; set; }
    }
}
