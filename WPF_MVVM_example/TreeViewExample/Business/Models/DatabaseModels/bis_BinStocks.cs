namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bis_BinStocks
    {
        [Key]
        [StringLength(50)]
        public string bis_BinId { get; set; }

        public double bis_Stock { get; set; }

        public virtual Bin bin_Bins { get; set; }
    }
}
