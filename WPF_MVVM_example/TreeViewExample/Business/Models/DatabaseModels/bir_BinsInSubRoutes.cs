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
    using Singletons;

    public partial class bir_BinsInSubRoutes : ViewModelBase, IConfigObject
    {
        private static BinInSubrouteBusiness db = new BinInSubrouteBusiness(new MSSQL_BinInSubrouteRepository());

        #region Fields

        private bool _IsExpanded;
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
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { SetProperty(ref _IsExpanded, value); }
        }
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



        public bool Validate()
        {
            throw new NotImplementedException();
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            configList.AddRange(bin_Bins.GenerateListViewList());
            return configList;
        }

        public int CompareTo(object obj)
        {
            bir_BinsInSubRoutes binInSubroute = obj as bir_BinsInSubRoutes;
            return binInSubroute.bin_Bins.CompareTo(bin_Bins);
        }

        public string GetName()
        {
            return "the connection with Bin: " + this.bir_BinId;
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
            bool check = db.DatabaseDelete(this);

            //tijdelijke oplossing----
            foreach (Bin B in ListGodClass.Instance.BinList)
            {
                B.Validate();
            }
            //------------------------

            return check;
        }

        public string GetValidationMessage()
        {
            throw new NotImplementedException();
        }
    }
}
