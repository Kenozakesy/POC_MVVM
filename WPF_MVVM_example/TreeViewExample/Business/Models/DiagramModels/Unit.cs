using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("oud_OAUnitDefs")]
    public class Unit : ViewModelBase, IConfigObject
    {
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private ObservableCollection<uis_UnitsInSubRoutes> _UnitsInSubroute = new ObservableCollection<uis_UnitsInSubRoutes>();

        private Brush _Brush;
        private static Random ran = new Random();

        public Unit()
        {
            Validate();
        }

        #region Properties

        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        [NotMapped]
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }

        public virtual ObservableCollection<uis_UnitsInSubRoutes> uis_UnitsInSubRoutes
        {
            get { return _UnitsInSubroute; }
            set { SetProperty(ref _UnitsInSubroute, value); }
        }

        #region Oud columns

        [Key]
        [StringLength(50)]
        public string oud_OAUnitId { get; set; }

        [Required]
        [StringLength(256)]
        public string oud_OAUnitPUObjectNm { get; set; }

        [StringLength(256)]
        public string oud_OAOperPUObjectNm { get; set; }

        [StringLength(256)]
        public string oud_OAUnitAllocNm { get; set; }

        [StringLength(256)]
        public string oud_OAUnitCntObjectNm { get; set; }

        [StringLength(256)]
        public string oud_OAPropEMObjectNm { get; set; }

        [StringLength(256)]
        public string oud_OAIndObjectNm { get; set; }

        [StringLength(50)]
        public string oud_ImplementedIFs { get; set; }

        [StringLength(50)]
        public string oud_UnitNm { get; set; }

        [StringLength(50)]
        public string oud_UnitRoles { get; set; }

        [StringLength(50)]
        public string oud_BatchRegTypeId { get; set; }

        public bool? oud_IsUnit { get; set; }

        public bool? oud_IsTransportHandler { get; set; }

        public bool? oud_OAUnitInTransportHandler { get; set; }


        #endregion

        #endregion

        #region Methods

        public void ChangeColor()
        {
            if (_Brush == Brushes.Red)
            {
                Brush = Brushes.LightGreen;
            }
            else
            {
                Brush = Brushes.Red;
            }
        }


        public int CompareTo(object obj)
        {
            Unit cell = obj as Unit;
            return string.Compare(this.oud_UnitNm, cell.oud_UnitNm);
        }


        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            //foreach (var prop in this.GetType().GetProperties())
            //{
            //    if (!prop.PropertyType.FullName.StartsWith("System.") || prop.Name == "Brush")
            //    {
            //        continue;
            //    }
            //    string name = prop.Name;
            //    string value = prop.GetValue(this, null).ToString();
            //    MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.Name);
            //    configList.Add(mainListViewModel);
            //}
            return configList;
        }

        public bool Validate()
        {
            int newRan = ran.Next(0, 10);
            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
            }
            return true;
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public bool DatabaseInsert()
        {
            throw new NotImplementedException();
        }

        public bool DatabaseUpdate()
        {
            throw new NotImplementedException();
        }

        public bool DatabaseDelete()
        {
            throw new NotImplementedException();
        }

        public string GetValidationMessage()
        {
            throw new NotImplementedException();
        }



        #endregion

    }


}
