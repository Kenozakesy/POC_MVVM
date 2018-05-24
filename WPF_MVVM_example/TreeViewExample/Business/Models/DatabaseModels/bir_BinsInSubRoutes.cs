namespace TreeViewExample.Business.Models.DatabaseModels
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Media;
    using UI.ViewModels;
    using NonDiagramModels;
    using Enums;
    using Dal.Repository.BusinessGlueCode;
    using Dal.Repository.SQLServerRepository;

    public partial class bir_BinsInSubRoutes : ViewModelBase, IConfigObject
    {

        #region Fields

        BinInSubrouteBusiness db = new BinInSubrouteBusiness(new MSSQL_BinInSubrouteRepository());
        private Brush _Brush;

        #endregion

        public bir_BinsInSubRoutes()
        {


        }

        public bir_BinsInSubRoutes(Bin bin, SubRoute subroute, SourceDest sourcedest)
        {
            bir_ProcCellId = subroute.ProcesCellId;
            bir_SubRouteId = subroute.SubRouteId;
            bir_BinId = bin.bin_BinId;
            bir_SourceDest = sourcedest.ToString();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bir_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string bir_SubRouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string bir_SourceDest { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string bir_BinId { get; set; }

        public virtual Bin bin_Bins { get; set; }

        public virtual SubRoute sur_SubRoutes { get; set; }

        [NotMapped]
        public Brush Brush
        {
            get { return bin_Bins.Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        public void ChangeColor()
        {
            bin_Bins.ChangeColor();
        }


        public void DeleteChild(IConfigObject obj)
        {
            throw new NotImplementedException();
        }

        public void CreateChild()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            bir_BinsInSubRoutes binInSubroute = obj as bir_BinsInSubRoutes;
            return binInSubroute.bin_Bins.CompareTo(bin_Bins);
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

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
            sur_SubRoutes.bir_BinsInSubRoutes.Remove(this);
            bin_Bins.bir_BinsInSubRoutes.Remove(this);
            return db.DatabaseDelete(this);
        }
    }
}
