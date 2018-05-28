namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pct_ProcCellTypes
    {
        public pct_ProcCellTypes()
        {
            pac_ParDefsProcCellTypes = new ObservableCollection<pac_ParDefsProcCellTypes>();
        }

        [Key]
        [StringLength(50)]
        public string pct_ProcCellTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string pct_ProcCellTypeNm { get; set; }

        public virtual ObservableCollection<pac_ParDefsProcCellTypes> pac_ParDefsProcCellTypes { get; set; }
    }
}
