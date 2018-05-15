namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbb_TempBinBatches
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string tbb_BatchNm { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string tbb_FlowTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string tbb_BinId { get; set; }

        public double tbb_Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string tbb_AmountUOM { get; set; }

        public virtual Bin bin_Bins { get; set; }

        //public virtual flt_FlowTypes flt_FlowTypes { get; set; }
    }
}
