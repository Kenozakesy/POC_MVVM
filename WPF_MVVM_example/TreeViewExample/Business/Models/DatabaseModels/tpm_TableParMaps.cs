namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TreeViewExample.Business.Models.DiagramModels;

    public partial class tpm_TableParMaps
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string tpm_ParNm { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string tpm_TableId { get; set; }

        public bool tpm_MappingIsEnabled { get; set; }

        public virtual ParameterDefinition paf_ParDefs { get; set; }

        public virtual pat_ParTables pat_ParTables { get; set; }
    }
}
