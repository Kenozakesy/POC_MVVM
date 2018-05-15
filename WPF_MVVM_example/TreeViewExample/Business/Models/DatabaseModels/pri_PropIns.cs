namespace TreeViewExample.Business.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pri_PropIns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pri_PropIns()
        {
            //pip_PropInsPars = new HashSet<pip_PropInsPars>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string pri_BinId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pri_PropInsId { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_PropInsNm { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_PropInsTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_PropLocId { get; set; }

        public double? pri_Tol { get; set; }

        [StringLength(50)]
        public string pri_TolUOM { get; set; }

        public int pri_PropSpeedCoarse { get; set; }

        public int pri_PropSpeedMedium { get; set; }

        public int pri_PropSpeedFine { get; set; }

        public double pri_PropAmountMedium { get; set; }

        public double pri_PropAmountFine { get; set; }

        public double pri_AfterFlow { get; set; }

        public double? pri_PropMinAmount { get; set; }

        public double? pri_PropMaxAmount { get; set; }

        public int? pri_PropMaxTime { get; set; }

        public int? pri_PropMaxTimeStandStill { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_Status { get; set; }

        public int pri_SuggPropTime { get; set; }

        public double pri_PropAcc { get; set; }

        public int pri_WeigherSelection { get; set; }

        public int pri_AutoRestartAfterNF { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_SaveSettings { get; set; }

        public double pri_FlowRate { get; set; }

        [Required]
        [StringLength(50)]
        public string pri_FlowRateUOM { get; set; }

        [StringLength(50)]
        public string pri_OptionsString { get; set; }

        public double? pri_PrefMinAmount { get; set; }

        public double? pri_PrefMaxAmount { get; set; }

        public int pri_PropSeqNr { get; set; }

        public double? pri_FlowDelay { get; set; }

        [StringLength(50)]
        public string pri_ToSubRoute { get; set; }

        public int pri_PropAbility { get; set; }

        [StringLength(50)]
        public string pri_PropInsGroupId { get; set; }

        public int? pri_TolWarnCount { get; set; }

        public virtual Bin bin_Bins { get; set; }

        //public virtual ICollection<pip_PropInsPars> pip_PropInsPars { get; set; }

        //public virtual pit_PropInsTypes pit_PropInsTypes { get; set; }
    }
}
