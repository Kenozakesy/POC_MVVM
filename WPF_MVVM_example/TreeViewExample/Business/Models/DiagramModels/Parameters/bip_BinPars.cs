namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bip_BinPars : IParameterObject
    {

        public bip_BinPars()
        {

        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bip_BinId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string bip_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string bip_ParDesc { get; set; }

        [StringLength(100)]
        public string bip_ParValue { get; set; }

        [StringLength(50)]
        public string bip_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string bip_DisplayToUser { get; set; }

        public virtual Bin bin_Bins { get; set; }
    }
}
