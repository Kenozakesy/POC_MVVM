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

    [Table("sri_SubRoutesInRoutes")]
    public partial class sri_SubRoutesInRoutes : ViewModelBase, IConfigObject
    {
        #region Fields

        private Brush _Brush;


        #endregion

        public sri_SubRoutesInRoutes()
        {


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
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void DatabaseInsert()
        {
            throw new NotImplementedException();
        }

        public void DatabaseUpdate()
        {
            throw new NotImplementedException();
        }

        public void DatabaseDelete()
        {
            throw new NotImplementedException();
        }
    }
}
