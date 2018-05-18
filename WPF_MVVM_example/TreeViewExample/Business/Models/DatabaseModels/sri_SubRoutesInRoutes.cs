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

        public void Delete()
        {
            throw new NotImplementedException();
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
            
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            // throw new NotImplementedException();
            return null;
        }

        public int CompareTo(object obj)
        {
            sri_SubRoutesInRoutes subrouteinRoute = obj as sri_SubRoutesInRoutes;
            return sur_SubRoutes.CompareTo(subrouteinRoute.sur_SubRoutes);
        }

        public string GetName()
        {
            return "Subroute " + sri_RouteId; 
        }

        public void RemoveSubrouteInRoute()
        {
            //this should be just a delete.
            sur_SubRoutes.sri_SubRoutesInRoutes.Remove(this);
            rot_Routes.SubrouteInRouteList.Remove(this);
            if (DatabaseDelete())
            {
                //add routes back if it didn't work
            }                 
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
    }
}
