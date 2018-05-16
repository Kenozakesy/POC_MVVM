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

    public partial class bir_BinsInSubRoutes : ViewModelBase, IConfigObject
    {

        #region Fields

        private Brush _Brush;

        #endregion

        public bir_BinsInSubRoutes()
        {


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
            throw new NotImplementedException();
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            throw new NotImplementedException();
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
