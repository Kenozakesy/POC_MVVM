﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("bin_Bins")]
    public class Bin : ViewModelBase, IConfigObject, IObjectWithParameters, IEquatable<Bin>
    {
        private static BinBusiness db = new BinBusiness(new MSSQL_BinRepository());

        private ObservableCollection<bir_BinsInSubRoutes> _BinInSubRouteList = new ObservableCollection<bir_BinsInSubRoutes>();
        private Brush _Brush;
        private IsValidated _IsValid;

        public Bin()
        {
            _Brush = Brushes.Orange;
            ListGodClass.Instance.AddBin(this);
        }

        #region Properties


        [NotMapped]
        public Brush Brush
        {
            get
            {
                //Validate();
                return _Brush;
            }
            set
            {
                SetProperty(ref _Brush, value);

                foreach (bir_BinsInSubRoutes bir in _BinInSubRouteList)
                {
                    bir.Brush = Brush;
                }
            }
        }
        [NotMapped]
        public IsValidated IsValid
        {
            get { return _IsValid; }
            set {
                SetProperty(ref _IsValid, value);
                SetColor();
            }
        }

        public virtual ObservableCollection<bir_BinsInSubRoutes> bir_BinsInSubRoutes
        {
            get { return _BinInSubRouteList; }
            set { SetProperty(ref _BinInSubRouteList, value); }
        }
        public virtual ObservableCollection<bip_BinPars> bip_BinPars { get; set; }
        public virtual ObservableCollection<bib_BinBatches> bib_BinBatches { get; set; }
        public virtual ObservableCollection<tbb_TempBinBatches> tbb_TempBinBatches { get; set; }
        public virtual bis_BinStocks bis_BinStocks { get; set; }
        public virtual ObservableCollection<pri_PropIns> pri_PropIns { get; set; }

        #region BIN columns

        [Key]
        [StringLength(50)]
        public string bin_BinId { get; set; }

        [StringLength(50)]
        public string bin_BinNm { get; set; }

        [StringLength(50)]
        public string bin_ArtId { get; set; }

        public double? bin_Cap { get; set; }

        public double bin_Stock { get; set; }

        [Required]
        [StringLength(50)]
        public string bin_StatusFill { get; set; }

        [Required]
        [StringLength(50)]
        public string bin_StatusDisc { get; set; }

        public int bin_PropPrioNr { get; set; }

        public DateTime? bin_DateEmpty { get; set; }

        public DateTime? bin_TimeEmpty { get; set; }

        public DateTime? bin_DateCleaned { get; set; }

        public DateTime? bin_TimeCleaned { get; set; }

        public DateTime? bin_DateFilledUp { get; set; }

        public DateTime? bin_TimeFilledUp { get; set; }

        [StringLength(50)]
        public string bin_ProdOrderId { get; set; }

        public int bin_PropPosSeqNr { get; set; }

        public int? bin_NoFlowDetected { get; set; }

        [Required]
        [StringLength(50)]
        public string bin_LocTypeId { get; set; }

        public double? bin_MaxLevel { get; set; }

        public double? bin_CallLevel { get; set; }

        public double? bin_MinLevel { get; set; }

        [StringLength(50)]
        public string bin_LevelUOM { get; set; }

        [StringLength(50)]
        public string bin_OccupControler { get; set; }

        [StringLength(50)]
        public string bin_StockControler { get; set; }

        public int? bin_DefViewSequence { get; set; }

        [StringLength(50)]
        public string bin_OptRcp { get; set; }

        [StringLength(256)]
        public string bin_OAObjectNm { get; set; }

        [StringLength(50)]
        public string bin_DeclaredEmpty { get; set; }

        public int? bin_IsFGBin { get; set; }

        public int? bin_IsSemiFinishedBin { get; set; }

        [StringLength(50)]
        public string bin_Options { get; set; }

        [StringLength(50)]
        public string bin_LocBatchId { get; set; }

        [StringLength(50)]
        public string bin_BinDivideCode { get; set; }

        [StringLength(50)]
        public string bin_LocTypeFeedtrac { get; set; }

        public int bin_EmptyInterval { get; set; }

        public int bin_EmptyControl { get; set; }

        [Required]
        [StringLength(50)]
        public string bin_BinBlocked { get; set; }

        [Required]
        [StringLength(50)]
        public string bin_BinGroupId { get; set; }

        [StringLength(50)]
        public string bin_WareHouseId { get; set; }

        public double? bin_DimLStraight { get; set; }

        public double? bin_DimLAngled { get; set; }

        public double? bin_DimAMax { get; set; }

        public double? bin_DimAMin { get; set; }

        [StringLength(50)]
        public string bin_WareHousePositionId { get; set; }

        #endregion

      

        #endregion

        #region Methods


        public void SetSubroute(Unit unit = null)
        {
            //if (this.Unit != null)
            //{
            //    this.Unit.DeleteBin(this);
            //}
            //Unit = unit;            
        }
        public void Validate()
        {
            if (_BinInSubRouteList.Count == 0)
            {
                IsValid = IsValidated.NotConnected;
            }
            else
            {
                IsValid = IsValidated.Valid;
            }
        }
        private void SetColor()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    _Brush = Brushes.LightGreen;
                    break;
                case IsValidated.NotConnected:
                    _Brush = Brushes.Orange;
                    break;
                default:
                    break;
            }
        }
        public void ChangeColor()
        {
            if (_Brush == Brushes.Orange)
            {
                Brush = Brushes.LightGreen;
            }
            else
            {
                Brush = Brushes.Orange;
            }
        }
        public void Delete()
        {
            if (db.DatabaseDelete(this))
            {
                ListGodClass.Instance.DeleteBin(this);
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
        public int CompareTo(object obj)
        {
            Bin bin = obj as Bin;
            return string.Compare(bin.bin_BinId ,this.bin_BinId);
        }

        public void RemoveParameter(Parameter paramdef)
        {
            throw new NotImplementedException();
        }
        public string GetName()
        {
            return "Bin: " + bin_BinId;
        }

        public static List<Bin> GetAllBins()
        {
            List<Bin> BinList = new List<Bin>();
            return db.GetAllBins();
        }

        private void DatabaseUpdate()
        {
            db.DatabaseUpdate(this);
        }
        private void DatabaseDelete()
        {
            throw new NotImplementedException();
        }
        private void DatabaseInsert()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Bin obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj.GetType() == typeof(Bin)))
            {
                return false;
            }

            Bin other = (Bin)obj;

            if ((other.bin_BinId != bin_BinId))
            {
                return false;
            }

            return true;
        }

        public ObservableCollection<IParameterObject> GetParameterList()
        {
            ObservableCollection<IParameterObject> parameterList = new ObservableCollection<IParameterObject>(bip_BinPars);
            return parameterList;
        }

        #endregion
    }
}
