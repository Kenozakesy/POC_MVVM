using System;
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
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("bin_Bins")]
    public class Bin : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        private ObservableCollection<BinParameter> _BinParameterList = new ObservableCollection<BinParameter>();
        private Unit _Unit;
        private Brush _Brush;
        private IsValidated _IsValid;

        public Bin()
        {
            _Brush = Brushes.Orange;
            GetBinParameters();
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
        public IsValidated IsValid
        {
            get { return _IsValid; }
            set {
                SetProperty(ref _IsValid, value);
                SetColor();
            }
        }

        [NotMapped]
        public ObservableCollection<BinParameter> BinParameterList
        {
            get { return _BinParameterList; }
            set { SetProperty(ref _BinParameterList, value); }
        }
        [NotMapped]
        public Unit Unit
        {
            get { return _Unit; }
            private set
            {
                SetProperty(ref _Unit, value);
                Validate();
            }
        }

        //public virtual ObservableCollection<bip_BinPars> bip_BinPars { get; set; }
        //public virtual ObservableCollection<bir_BinsInSubRoutes> bir_BinsInSubRoutes { get; set; }

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

        private void GetBinParameters()
        {
            for (int i = 0; i < 5; i++)
            {
                BinParameter binParameter = new BinParameter("Name", "description", "1", "-", "1;2;3;4;5", true, true, this);
                BinParameterList.Add(binParameter);
            }
        }
        public void SetSubroute(Unit unit = null)
        {
            if (this.Unit != null)
            {
                this.Unit.DeleteBin(this);
            }
            Unit = unit;            
        }
        public void Validate()
        {
            if (_Unit == null)
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
                    Brush = Brushes.LightGreen;
                    break;
                case IsValidated.NotConnected:
                    Brush = Brushes.Orange;
                    break;
                default:
                    break;
            }
        }
        public void ChangeColor()
        {
            throw new NotImplementedException();
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
            return string.Compare(this.bin_BinNm ,bin.bin_BinNm);
        }
        public ObservableCollection<Parameter> GetParameterList()
        {
            ObservableCollection<Parameter> parameterList = new ObservableCollection<Parameter>();
            foreach (BinParameter BP in BinParameterList)
            {
                parameterList.Add(BP);
            }
            return parameterList;
        }
        public void RemoveParameter(Parameter paramdef)
        {
            throw new NotImplementedException();
        }


        public string GetName()
        {
            return bin_BinNm;
        }

        #endregion
    }
}
