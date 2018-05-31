namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System;
    using Dal.Repository.BusinessGlueCode;
    using Dal.Repository.SQLServerRepository;
    using UI.ViewModels;
    using Singletons;

    public partial class bip_BinPars : ViewModelBase, IParameterObject
    {
        private static BinParameterBusiness db = new BinParameterBusiness(new MSSQL_BinParameterRepository());
        private string _Value;

        public bip_BinPars()
        {

        }

        public bip_BinPars(Bin bin, ParameterDefinition paramdef)
        {
            bip_BinId = bin.bin_BinId;
            bip_ParNm = paramdef.paf_ParNm;
            bip_ParDesc = paramdef.paf_ParDesc;
            Value = paramdef.paf_DefValue;
            bip_ParValueUOM = paramdef.paf_ParValueUOM;
            bip_DisplayToUser = paramdef.paf_DisplayToUser;

            bin_Bins = bin;
            ParameterDefinition = paramdef;
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


        private static bool check = true;
        [StringLength(100)]
        [Column("bip_ParValue")]
        public string Value
        {
            get { return _Value; }
            set
            {
                SetProperty(ref _Value, value);
                if (check)
                {
                    check = false;
                    DatabaseUpdate();
                    check = true;
                }
            }
        }

        [StringLength(50)]
        public string bip_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string bip_DisplayToUser { get; set; }

        [ForeignKey("bip_BinId")]
        public virtual Bin bin_Bins { get; set; }
        [ForeignKey("bip_ParNm")]
        public virtual ParameterDefinition ParameterDefinition { get; set; }


        public bool DatabaseInsert()
        {
            return db.DatabaseInsert(this);
        }

        public bool DatabaseUpdate()
        {
            return db.DatabaseUpdate(this);
        }

        public bool DatabaseDelete()
        {
            return db.DatabaseDelete(this);
        }
    }
}
