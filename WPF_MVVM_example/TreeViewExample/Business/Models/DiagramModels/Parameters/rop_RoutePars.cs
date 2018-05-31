namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    using Dal.Repository.BusinessGlueCode;
    using Dal.Repository.SQLServerRepository;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using UI.ViewModels;

    public partial class rop_RoutePars : ViewModelBase, IParameterObject
    {
        private static RouteParameterBusiness db = new RouteParameterBusiness(new MSSQL_RouteParameterRepository());
        private string _Value;

        public rop_RoutePars()
        { }

        public rop_RoutePars(Route route, ParameterDefinition paramdef)
        {
            rop_ProcCellId = route.ProcesCell.ProcesCellId;
            rop_RouteId = route.RouteId;
            rop_ParNm = paramdef.paf_ParNm;
            rop_ParDesc = paramdef.paf_ParDesc;
            Value = paramdef.paf_DefValue;
            rop_ParValueUOM = paramdef.paf_ParValueUOM;
            rop_DisplayToUser = paramdef.paf_DisplayToUser;

            rot_Routes = route;
            ParameterDefinition = paramdef;
        }


        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string rop_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string rop_RouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string rop_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string rop_ParDesc { get; set; }

        private static bool check = true;
        [StringLength(100)]
        [Column("rop_ParValue")]
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
        public string rop_ParValueUOM { get; set; }

        [Required]
        [StringLength(50)]
        public string rop_DisplayToUser { get; set; }

        public virtual Route rot_Routes { get; set; }
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
