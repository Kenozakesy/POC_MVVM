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
using TreeViewExample.Business.Attributes;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    [Table("bin_Bins")]
    public class Bin : ViewModelBase, IObjectWithParameters, IEquatable<Bin>
    {
        private static BinBusiness db = new BinBusiness(new MSSQL_BinRepository());

        private ObservableCollection<bir_BinsInSubRoutes> _BinInSubRouteList = new ObservableCollection<bir_BinsInSubRoutes>();

        private Brush _Brush;
        private IsValidated _IsValid;

        public Bin()
        {
            OrderObservableList.AddSorted(ListGodClass.Instance.BinList, this);
        }

        #region Properties


        [NotMapped]
        public Brush Brush
        {
            get
            {
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
                ChangeColor();
            }
        }

        public virtual ObservableCollection<bir_BinsInSubRoutes> bir_BinsInSubRoutes
        {
            get { return _BinInSubRouteList; }
            set
            {
                SetProperty(ref _BinInSubRouteList, value);

            }
        }
        public virtual ObservableCollection<bip_BinPars> bip_BinPars { get; set; }
        public virtual ObservableCollection<bib_BinBatches> bib_BinBatches { get; set; }
        public virtual ObservableCollection<tbb_TempBinBatches> tbb_TempBinBatches { get; set; }
        public virtual bis_BinStocks bis_BinStocks { get; set; }
        public virtual ObservableCollection<pri_PropIns> pri_PropIns { get; set; }

        #region BIN columns

        [Key]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_BinId { get; set; }

        [DatabaseProperty]
        [StringLength(50)]
        public string bin_BinNm { get; set; }

        [DatabaseProperty]
        [StringLength(50)]
        public string bin_ArtId { get; set; }
        [DatabaseProperty]
        public double? bin_Cap { get; set; }
        [DatabaseProperty]
        public double bin_Stock { get; set; }

        [Required]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_StatusFill { get; set; }

        [Required]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_StatusDisc { get; set; }
        [DatabaseProperty]
        public int bin_PropPrioNr { get; set; }
        [DatabaseProperty]
        public DateTime? bin_DateEmpty { get; set; }
        [DatabaseProperty]
        public DateTime? bin_TimeEmpty { get; set; }
        [DatabaseProperty]
        public DateTime? bin_DateCleaned { get; set; }
        [DatabaseProperty]
        public DateTime? bin_TimeCleaned { get; set; }
        [DatabaseProperty]
        public DateTime? bin_DateFilledUp { get; set; }
        [DatabaseProperty]
        public DateTime? bin_TimeFilledUp { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_ProdOrderId { get; set; }
        [DatabaseProperty]
        public int bin_PropPosSeqNr { get; set; }
        [DatabaseProperty]
        public int? bin_NoFlowDetected { get; set; }

        [Required]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_LocTypeId { get; set; }
        [DatabaseProperty]
        public double? bin_MaxLevel { get; set; }
        [DatabaseProperty]
        public double? bin_CallLevel { get; set; }
        [DatabaseProperty]
        public double? bin_MinLevel { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_LevelUOM { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_OccupControler { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_StockControler { get; set; }
        [DatabaseProperty]
        public int? bin_DefViewSequence { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_OptRcp { get; set; }
        [DatabaseProperty]
        [StringLength(256)]
        public string bin_OAObjectNm { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_DeclaredEmpty { get; set; }
        [DatabaseProperty]
        public int? bin_IsFGBin { get; set; }
        [DatabaseProperty]
        public int? bin_IsSemiFinishedBin { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_Options { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_LocBatchId { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_BinDivideCode { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_LocTypeFeedtrac { get; set; }
        [DatabaseProperty]
        public int bin_EmptyInterval { get; set; }
        [DatabaseProperty]
        public int bin_EmptyControl { get; set; }

        [Required]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_BinBlocked { get; set; }

        [Required]
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_BinGroupId { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_WareHouseId { get; set; }
        [DatabaseProperty]
        public double? bin_DimLStraight { get; set; }
        [DatabaseProperty]
        public double? bin_DimLAngled { get; set; }
        [DatabaseProperty]
        public double? bin_DimAMax { get; set; }
        [DatabaseProperty]
        public double? bin_DimAMin { get; set; }
        [DatabaseProperty]
        [StringLength(50)]
        public string bin_WareHousePositionId { get; set; }

        #endregion



        #endregion

        #region Methods

        public bool AddParameter(ParameterDefinition paramdefinition)
        {
            bip_BinPars binparameter = new bip_BinPars(this, paramdefinition);
            if (binparameter.DatabaseInsert())
            {
                return true;
            }
            return false;
        }
        public void AddRequiredParameters()
        {
            //this method is implemented yet
        }

        public bool Validate()
        {
            if (bir_BinsInSubRoutes.Count > 0)
            {
                IsValid = IsValidated.Connected;
                return true;
            }
            else
            {
                IsValid = IsValidated.Valid;
                return true;
            }
        }

        public void ChangeColor()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    Brush = Brushes.LightGreen;
                    break;
                case IsValidated.InValid:
                    Brush = Brushes.Red;
                    break;
                case IsValidated.InValidChildren:
                    Brush = Brushes.Orange;
                    break;
                case IsValidated.Connected:
                    Brush = Brushes.LightBlue;
                    break;
            }
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();

            foreach (var prop in this.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(DatabaseProperty))))
            {
                string name = prop.Name;
                var varValue = prop.GetValue(this, null);
                string value = "";

                if (varValue == null)
                    value = "Null";
                else
                    value = varValue.ToString();

                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.bin_BinNm);
                configList.Add(mainListViewModel);
            }

            return configList;
        }
        public int CompareTo(object obj)
        {
            Bin bin = obj as Bin;
            return string.Compare(bin.bin_BinId ,this.bin_BinId);
        }

        public string GetName()
        {
            return "Bin: " + bin_BinId;
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

        public bool DatabaseUpdate()
        {
            return db.DatabaseUpdate(this);
        }
        public bool DatabaseDelete()
        {
            if (db.DatabaseDelete(this))
            {
                ListGodClass.Instance.BinList.Remove(this);
                return true;
            }
            return false; 
        }
        public bool DatabaseInsert()
        {
           return db.DatabaseInsert(this);
        }

        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters()
        {
            ObservableCollection<ParameterDefinition> ParameterDefinitionList = new ObservableCollection<ParameterDefinition>();
            ParameterDefinitionList = db.GetAddAbleStandardParameters(this);
            return ParameterDefinitionList;
        }

        public string GetValidationMessage()
        {
            return "Object is valid.";
        }






        #endregion
    }
}
