namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bib_BinBatches
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bib_BinId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string bib_BatchNm { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string bib_FlowTypeId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bib_UniqueId { get; set; }

        public int bib_SeqNr { get; set; }

        public double bib_Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string bib_AmountUOM { get; set; }

        public DateTime? bib_DateTimeFilledUp { get; set; }

        public DateTime? bib_PerishableDate { get; set; }

        public DateTime? bib_ActStartDateTime { get; set; }

        [StringLength(50)]
        public string bib_LotId { get; set; }

        public int bib_Status { get; set; }

        public double bib_AmountPaid { get; set; }

        public double bib_AmountUnpaid { get; set; }

        public virtual Bin bin_Bins { get; set; }

        //public virtual flt_FlowTypes flt_FlowTypes { get; set; }

        //public virtual lto_Lots lto_Lots { get; set; }
    }
}
