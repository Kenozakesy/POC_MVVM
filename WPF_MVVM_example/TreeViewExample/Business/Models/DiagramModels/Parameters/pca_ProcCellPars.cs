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


        [StringLength(100)]
        [Column("pca_ParValue")]
        public string Value
        {
            get { return _Value; }
            set
            {
                SetProperty(ref _Value, value);
                if (ParameterDefinition != null)
                {
                    DatabaseUpdate();
                }
            }
        }

        [StringLength(50)]
        public string pca_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string pca_DisplayToUser { get; set; }

        public virtual ProcessCel prc_ProcCells { get; set; }

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
