namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Dal.Repository.BusinessGlueCode;
    using Dal.Repository.SQLServerRepository;
    using Dal.SQLServerRepository;
    using Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UI.ViewModels;

    public partial class pca_ProcCellPars : ViewModelBase, IParameterObject
    {
        private static ProcescellParameterBusiness db = new ProcescellParameterBusiness(new MSSQL_ProcescellParameterRepository());

        #region Fields

        private string _Value;

        #endregion

        public pca_ProcCellPars()
        {

        }

        public pca_ProcCellPars(ProcessCel cell, ParameterDefinition param)
        {
            pca_ProcCellId = cell.ProcesCellId;
            pca_ParNm = param.paf_ParNm;
            pca_ParDesc = param.paf_ParDesc;
            Value = param.paf_DefValue;
            pca_ParValueUOM = param.paf_ParValueUOM;
            pca_DisplayToUser = param.paf_DisplayToUser;

            prc_ProcCells = cell;
            ParameterDefinition = param;
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string pca_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pca_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string pca_ParDesc { get; set; }


        private static bool check = true;
        [StringLength(100)]
        [Column("pca_ParValue")]
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
        public string pca_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string pca_DisplayToUser { get; set; }

        [ForeignKey("pca_ProcCellId")]
        public virtual ProcessCel prc_ProcCells { get; set; }

        [ForeignKey("pca_ParNm")]
        public virtual ParameterDefinition ParameterDefinition { get; set; }


        #region Methods

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

        #endregion
    }
}
