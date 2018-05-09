using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region BIN fields

        private string _BinId;
        private string _BinNm;
        private string _ArtId;
        private float _Cap;
        private float _Stock;
        private string _StatusFill;
        private string _StatusDisc;
        private int _PropPrioNr;
        private string _DateEmpty;
        private string _TimeEmpty;
        private string _DateCleaned;
        private string _TimeCleaned;
        private string _DateFilledUp;
        private string _TimeFilledUp;
        private string _ProdOrderId;
        private int _PropPosSeqNr;
        private int _NoFlowDetected;
        private string _LocTypeId;
        private float _MaxLevel;
        private float _CallLevel;
        private float _MinLevel;
        private string _LevelUOM;
        private string _OccupControler;
        private string _StockControler;
        private int _DefViewSequence;
        private string _OptRcp;
        private string _OAObjectNm;
        private string _DeclaredEmpty;
        private int _IsFGBin;
        private int _IsSemiFinishedBin;
        private string _Options;
        private string _LocBatchId;
        private string _BinDivideCode;
        private string _LocTypeFeedtrac;
        private int _EmptyInterval;
        private int _EmptyControl;
        private string _BinBlocked;
        private string _BinGroupId;
        private string _WareHouseId;
        private float _DimLStraight;
        private float _DimLAngled;
        private float _DimAMax;
        private float _DimAMin;
        private string _WareHousePositionId;

        #endregion

        public Bin()
        {
            _Brush = Brushes.Orange;
            GetBinParameters();
            Validate();
        }

        #region Properties

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


        #region BIN columns


        public string BinId
        {
            get { return _BinId; }
            set { SetProperty(ref _BinId, value); }
        }
        public string BinNm
        {
            get { return _BinNm; }
            set { SetProperty(ref _BinNm, value); }
        }
        public string ArtId
        {
            get { return _ArtId; }
            set { SetProperty(ref _ArtId, value); }
        }
        public float Cap
        {
            get { return _Cap; }
            set { SetProperty(ref _Cap, value); }
        }
        public float Stock
        {
            get { return _Stock; }
            set { SetProperty(ref _Stock, value); }
        }
        public string StatusFill
        {
            get { return _StatusFill; }
            set { SetProperty(ref _StatusFill, value); }
        }
        public string StatusDisc
        {
            get { return _StatusDisc; }
            set { SetProperty(ref _StatusDisc, value); }
        }
        public int PropPrioNr
        {
            get { return _PropPrioNr; }
            set { SetProperty(ref _PropPrioNr, value); }
        }
        public string DateEmpty
        {
            get { return _DateEmpty; }
            set { SetProperty(ref _DateEmpty, value); }
        }
        public string TimeEmpty
        {
            get { return _TimeEmpty; }
            set { SetProperty(ref _TimeEmpty, value); }
        }
        public string DateCleaned
        {
            get { return _DateCleaned; }
            set { SetProperty(ref _DateCleaned, value); }
        }     
        public string TimeCleaned
        {
            get { return _TimeCleaned; }
            set { SetProperty(ref _TimeCleaned, value); }
        }
        public string DateFilledUp
        {
            get { return _DateFilledUp; }
            set { SetProperty(ref _DateFilledUp, value); }
        }
        public string TimeFilledUp
        {
            get { return _TimeFilledUp; }
            set { SetProperty(ref _TimeFilledUp, value); }
        }
        public string ProdOrderId
        {
            get { return _ProdOrderId; }
            set { SetProperty(ref _ProdOrderId, value); }
        }


        //private int _PropPosSeqNr;
        //private int _NoFlowDetected;
        //private string _LocTypeId;
        //private float _MaxLevel;
        //private float _CallLevel;
        //private float _MinLevel;
        //private string _LevelUOM;
        //private string _OccupControler;
        //private string _StockControler;
        //private int _DefViewSequence;
        //private string _OptRcp;
        //private string _OAObjectNm;
        //private string _DeclaredEmpty;
        //private int _IsFGBin;
        //private int _IsSemiFinishedBin;amewor
        //private string _Options;
        //private string _LocBatchId;
        //private string _BinDivideCode;
        //private string _LocTypeFeedtrac;
        //private int _EmptyInterval;
        //private int _EmptyControl;
        //private string _BinBlocked;
        //private string _BinGroupId;
        //private string _WareHouseId;
        //private float _DimLStraight;
        //private float _DimLAngled;
        //private float _DimAMax;
        //private float _DimAMin;
        //private string _WareHousePositionId;


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
            return string.Compare(this._BinNm, bin._BinNm);
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
            return _BinNm;
        }

        #endregion
    }
}
