namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TreeViewExample.Business.Models.DiagramModels;

    public partial class pat_ParTables
    {
        public pat_ParTables()
        {
            tpm_TableParMaps = new ObservableCollection<tpm_TableParMaps>();
            paf_ParDefs = new ObservableCollection<ParameterDefinition>();
        }

        [Key]
        [StringLength(50)]
        public string pat_TableId { get; set; }

        [Required]
        [StringLength(50)]
        public string pat_TableDesc { get; set; }

        [Required]
        [StringLength(50)]
        public string pat_Priority { get; set; }

        public virtual ObservableCollection<tpm_TableParMaps> tpm_TableParMaps { get; set; }

        public virtual ObservableCollection<ParameterDefinition> paf_ParDefs { get; set; }
    }
}
