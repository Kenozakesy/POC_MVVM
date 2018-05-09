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
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("oud_OAUnitDefs")]
    public class Unit : ViewModelBase, IConfigObject
    {
        private SubRoute _Subroute;
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();

        private Brush _Brush;
        private static Random ran = new Random();

        #region Oud fields

        private string _OAUnitId;
        private string _OAUnitPUObjectNm;
        private string _OAOperPUObjectNm;
        private string _OAUnitAllocNm;
        private string _OAUnitCntObjectNm;
        private string _OAPropEMObjectNm;
        private string _OAIndObjectNm;
        private string _ImplementedIFs;
        private string _UnitNm;
        private string _UnitRoles;
        private string _BatchRegTypeId;
        private bool _IsUnit;
        private bool _IsTransportHandler;
        private bool _OAUnitInTransportHandler;

        #endregion

        public Unit()
        {
            Validate();
        }

        #region Properties

        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }

        #region Oud columns

        [Key]
        [Column("oud_OAUnitId")]
        public string OAUnitId
        {
            get { return _OAUnitId; }
            set { SetProperty(ref _OAUnitId, value); }
        }
        [Column("oud_OAUnitPUObjectNm")]
        public string OAUnitPUObjectNm
        {
            get { return _OAUnitPUObjectNm; }
            set { SetProperty(ref _OAUnitPUObjectNm, value); }
        }
        [Column("oud_OAOperPUObjectNm")]
        public string OAOperPUObjectNm
        {
            get { return _OAOperPUObjectNm; }
            set { SetProperty(ref _OAOperPUObjectNm, value); }
        }
        [Column("oud_OAUnitAllocNm")]
        public string OAUnitAllocNm
        {
            get { return _OAUnitAllocNm; }
            set { SetProperty(ref _OAUnitAllocNm, value); }
        }
        [Column("oud_OAUnitCntObjectNm")]
        public string OAUnitCntObjectNm
        {
            get { return _OAUnitCntObjectNm; }
            set { SetProperty(ref _OAUnitCntObjectNm, value); }
        }
        [Column("oud_OAPropEMObjectNm")]
        public string OAPropEMObjectNm
        {
            get { return _OAPropEMObjectNm; }
            set { SetProperty(ref _OAPropEMObjectNm, value); }
        }
        [Column("oud_OAIndObjectNm")]
        public string OAIndObjectNm
        {
            get { return _OAIndObjectNm; }
            set { SetProperty(ref _OAIndObjectNm, value); }
        }
        [Column("oud_ImplementedIFs")]
        public string ImplementedIFs
        {
            get { return _ImplementedIFs; }
            set { SetProperty(ref _ImplementedIFs, value); }
        }
        [Column("oud_UnitNm")]
        public string UnitNm
        {
            get { return _UnitNm; }
            set { SetProperty(ref _UnitNm, value); }
        }
        [Column("oud_UnitRoles")]
        public string UnitRoles
        {
            get { return _UnitRoles; }
            set { SetProperty(ref _UnitRoles, value); }
        }
        [Column("oud_BatchRegTypeId")]
        public string BatchRegTypeId
        {
            get { return _BatchRegTypeId; }
            set { SetProperty(ref _BatchRegTypeId, value); }
        }
        [Column("oud_IsUnit")]
        public bool IsUnit
        {
            get { return _IsUnit; }
            set { SetProperty(ref _IsUnit, value); }
        }
        [Column("oud_IsTransportHandler")]
        public bool IsTransportHandler
        {
            get { return _IsTransportHandler; }
            set { SetProperty(ref _IsTransportHandler, value); }
        }
        [Column("oud_OAUnitInTransportHandler")]
        public bool OAUnitInTransportHandler
        {
            get { return _OAUnitInTransportHandler; }
            set { SetProperty(ref _OAUnitInTransportHandler, value); }
        }


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

        public void Delete()
        {
            List<Bin> removableBins = new List<Bin>();
            foreach (Bin B in BinList)
            {
                removableBins.Add(B);
            }
            foreach (Bin B in removableBins)
            {
                B.SetSubroute();
                BinList.Remove(B);
            }

            this._Subroute.DeleteChild(this);
        }

        public bool AddBinToSubroute(Bin bin)
        {
            if (!_BinList.Contains(bin))
            {
                bin.SetSubroute(this);
                OrderObservableList.AddSorted(BinList, bin);
                return true;
            }
            return false;
        }

        public void DeleteBin(Bin bin)
        {
            foreach (Bin B in BinList)
            {
                if (B == bin)
                {
                    BinList.Remove(B);
                    break;
                }
            }
        }

        public void DeleteChild(IConfigObject obj)
        {
            throw new NotImplementedException();
        }

        public void CreateChild()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            Unit cell = obj as Unit;
            return string.Compare(this.UnitNm, cell.UnitNm);
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

        public void Validate()
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
        }





        #endregion

    }


}
