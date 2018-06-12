namespace TreeViewExample.Business.Models.DatabaseModels
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Documents;
    using System.Windows.Media;
    using TreeViewExample.Business.Models;
    using UI.ViewModels;
    using NonDiagramModels;
    using Dal.Repository.BusinessGlueCode;
    using Dal.Repository.SQLServerRepository;
    using Dal.Repository.Interfaces;

    [Table("sri_SubRoutesInRoutes")]
    public partial class sri_SubRoutesInRoutes : ViewModelBase, IConfigObject
    {
        #region Fields

        private bool _IsExpanded;
        private Brush _Brush;
        SubrouteInRouteBusiness db = new SubrouteInRouteBusiness(new MSSQL_SubRouteInRouteRepository());

        #endregion

        public sri_SubRoutesInRoutes()
        {

        }

        public sri_SubRoutesInRoutes(Route route, SubRoute subroute)
        {
            sri_ProcCellId = route.ProcesCellId;
            sri_RouteId = route.RouteId;
            sri_SubRouteId = subroute.SubRouteId;
            sri_SeqNr = 1;
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string sri_ProcCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string sri_RouteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string sri_SubRouteId { get; set; }

        public int sri_SeqNr { get; set; }

        public virtual Route rot_Routes { get; set; }
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
            get { return sur_SubRoutes.Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #region Methods

        public void ChangeColor()
        {
            sur_SubRoutes.ChangeColor();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            configList.AddRange(sur_SubRoutes.GenerateListViewList());

            if (IsExpanded)
            {
                foreach (bir_BinsInSubRoutes bir in sur_SubRoutes.bir_BinsInSubRoutes)
                {
                    configList.Add(new MainListViewModel("", "", ""));
                    List<MainListViewModel> routeConfigList = bir.GenerateListViewList();
                    configList.AddRange(routeConfigList);
                }
            }
            return configList;
        }

        public int CompareTo(object obj)
        {
            sri_SubRoutesInRoutes subrouteinRoute = obj as sri_SubRoutesInRoutes;
            return sur_SubRoutes.CompareTo(subrouteinRoute.sur_SubRoutes);
        }

        public string GetName()
        {
            return "the connection with subroute: " + this.sri_SubRouteId;
        }

        #endregion

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

        public string GetValidationMessage()
        {
            throw new NotImplementedException();
        }
    }
}
