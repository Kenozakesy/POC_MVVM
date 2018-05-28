namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TreeViewExample.Business.Models.DiagramModels;

    public partial class pac_ParDefsProcCellTypes
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string pac_ParNm { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pac_ProcCellTypeId { get; set; }

        public bool pac_IsRequired { get; set; }

        public virtual ParameterDefinition paf_ParDefs { get; set; }

        public virtual pct_ProcCellTypes pct_ProcCellTypes { get; set; }
    }
}
