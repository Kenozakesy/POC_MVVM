
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.DatabaseConnection;
using TreeViewExample.Dal.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DiagramModels
{
    [Table("paf_ParDefs")]
    public class ParameterDefinition : ViewModelBase, IComparable, IEquatable<ParameterDefinition>
    {
        private static ParameterDefinitionBusiness db = new ParameterDefinitionBusiness(new MSSQL_ParameterDefinitionRepository());

        private ObservableCollection<pca_ProcCellPars> _ProcesCellParametersList = new ObservableCollection<pca_ProcCellPars>();
        private ObservableCollection<rop_RoutePars> _RouteParametersList = new ObservableCollection<rop_RoutePars>();
        private ObservableCollection<bip_BinPars> _BinParametersList = new ObservableCollection<bip_BinPars>();


        #region Fields

        private bool _IsVisible = true;
        private bool _IsHighlighted = false;
        private Brush _Brush;

        private List<string> _ValidvaluesCombobox = new List<string>();
        private Tuple<int, int> _ValidValues;

        //these fields might be useless
        //Necessary variables
        private string _ParName;
        private string _Description;
        private int _BeforeSep;
        private int _AfterSep;
        private ParameterType _Type;
        private Alignment _Alignm;
        private IsEditable _IsEditable;
        private bool _DisplayToUser;

        //Optional variables
        private string _ParValueUOM;
        private string _paf_ValidValues;
        private string _DefValue;
        private int? _DisplaySeqNr;
        private int? _DisPlayWidth;
        private string _ParUOM_TextId;
        private int? _Column;
        private bool _IsStandardParameter;

        #endregion

        #region ConfigurationFields

        private bool? _UsedForBG;
        private bool? _UsedForBL;
        private bool? _UsedForCL;
        private bool? _UsedForCS;
        public bool? _UsedForIL;
        public bool? _UsedForOL;
        public bool? _UsedForPL;
        public bool? _UsedForRL;
        public bool? _UsedForSL;
        public bool? _UsedForTL;
        public bool? _UsedForZG;
        public bool? _MappedToSYP;
        public bool? _MappedToPCA;
        public bool? _MappedToROP;
        public bool? _MappedToARP;
        public bool? _MappedToNONE;
        public bool? _MappedToPPP;
        public bool? _MappedToPSR;
        public bool? _MappedToRLP;
        public bool? _MappedToSDL;
        public bool? _MappedToSTA;
        public bool? _MappedToPPR;
        public bool? _MappedToBIN;


        #endregion

        #region Constructors

        /// <summary>
        /// This Constructor is used for testing
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="description"></param>
        /// <param name="defaulvalue"></param>
        /// <param name="parValueUOM"></param>
        /// <param name="displayToUser"></param>
        /// <param name="isStandardParameter"></param>
        public ParameterDefinition(string parName, string description, int beforeSep, int afterSep, IsEditable isEditable, bool displayToUser, bool isStandardParameter)
        {
            _ParName = parName;
            _Description = description;
            _BeforeSep = beforeSep;
            _AfterSep = afterSep;
            _IsEditable = isEditable;
            _DisplayToUser = displayToUser;
            _IsStandardParameter = isStandardParameter;

            _Brush = Brushes.LightGray;

            _UsedForBG = false;
            _UsedForBL = false;
            _UsedForCL = false;
            _UsedForCS = false;
            _UsedForIL = false;
            _UsedForOL = false;
            _UsedForPL = false;
            _UsedForRL = false;
            _UsedForSL = false;
            _UsedForTL = false;
            _UsedForZG = false;

            _MappedToSYP = false;
            _MappedToPCA = false;
            _MappedToROP = false;
            _MappedToARP = false;
            _MappedToNONE = false;
            _MappedToPPP = false;
            _MappedToPSR = false;
            _MappedToRLP = false;
            _MappedToSDL = false;
            _MappedToSTA = false;
            _MappedToPPR = false;
            _MappedToBIN = false;
            _DisplaySeqNr = 0;
        }

        public ParameterDefinition()
        {
            OrderObservableList.AddSorted(ListGodClass.Instance.ParameterDefinitionList, this);

            _Brush = Brushes.LightGray;

            _UsedForBG = false;
            _UsedForBL = false;
            _UsedForCL = false;
            _UsedForCS = false;
            _UsedForIL = false;
            _UsedForOL = false;
            _UsedForPL = false;
            _UsedForRL = false;
            _UsedForSL = false;
            _UsedForTL = false;
            _UsedForZG = false;

            _MappedToSYP = false;
            _MappedToPCA = true;
            _MappedToROP = false;
            _MappedToARP = false;
            _MappedToNONE = false;
            _MappedToPPP = false;
            _MappedToPSR = false;
            _MappedToRLP = false;
            _MappedToSDL = false;
            _MappedToSTA = false;
            _MappedToPPR = false;
            _MappedToBIN = false;
        }

        #endregion

        #region Properties

        public virtual ObservableCollection<pca_ProcCellPars> ProcesCellParametersList
        {
            get { return _ProcesCellParametersList; }
            set { SetProperty(ref _ProcesCellParametersList, value); }
        }
        public virtual ObservableCollection<rop_RoutePars> RouteParametersList
        {
            get { return _RouteParametersList; }
            set { SetProperty(ref _RouteParametersList, value); }
        }
        public virtual ObservableCollection<bip_BinPars> BinParametersList
        {
            get { return _BinParametersList; }
            set { SetProperty(ref _BinParametersList, value); }
        }
        public virtual ObservableCollection<tpm_TableParMaps> tpm_TableParMaps { get; set; }
        public virtual ObservableCollection<pat_ParTables> pat_ParTables { get; set; }
     

        [Key]
        [StringLength(50)]
        public string paf_ParNm { get; set; }

        [Required]
        [StringLength(50)]
        public string paf_ParDesc { get; set; }

        [StringLength(50)]
        public string paf_ParValueUOM { get; set; }

        public int paf_BeforeSep { get; set; }

        public int paf_AfterSep { get; set; }

        [StringLength(1000)]
        public string paf_ValidValues { get; set; }

        [StringLength(100)]
        public string paf_DefValue { get; set; }

        public int paf_Type { get; set; }

        public int paf_Alignm { get; set; }

        public int paf_Editable { get; set; }

        public int? paf_DisplaySeqNr { get; set; }

        public int? paf_DisplayWidth { get; set; }

        [StringLength(30)]
        public string paf_ParUOM_TextId { get; set; }

        [Required]
        [StringLength(50)]
        public string paf_DisplayToUser { get; set; }

        public bool? paf_IsRequired { get; set; }

        public int? paf_Column { get; set; }

        public bool paf_IsStandardPar { get; set; }

        [NotMapped]
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }
        [NotMapped]
        public Tuple<int, int> Validvalues
        {
            get { return _ValidValues; }
            set { SetProperty(ref _ValidValues, value); }
        }
        [NotMapped]
        public List<string> ValidValuesCombobox
        {
            get { return _ValidvaluesCombobox; }
            set { SetProperty(ref _ValidvaluesCombobox, value); }
        }
        [NotMapped]
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }
        [NotMapped]
        public bool IsHighlighted
        {
            get { return _IsHighlighted; }
            set { SetProperty(ref _IsHighlighted, value); }
        }  
        [NotMapped]
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #endregion

        #region ConfigurationProperties

        [NotMapped]
        public bool? UsedForBG
        {
            get { return _UsedForBG; }
            set { SetProperty(ref _UsedForBG, value); }
        }
        [NotMapped]
        public bool? UsedForBL
        {
            get { return _UsedForBL; }
            set { SetProperty(ref _UsedForBL, value); }
        }
        [NotMapped]
        public bool? UsedForCL
        {
            get { return _UsedForCL; }
            set { SetProperty(ref _UsedForCL, value); }
        }
        [NotMapped]
        public bool? UsedForCS
        {
            get { return _UsedForCS; }
            set { SetProperty(ref _UsedForCS, value); }
        }
        [NotMapped]
        public bool? UsedForIL
        {
            get { return _UsedForIL; }
            set { SetProperty(ref _UsedForIL, value); }
        }
        [NotMapped]
        public bool? UsedForOL
        {
            get { return _UsedForOL; }
            set { SetProperty(ref _UsedForOL, value); }
        }
        [NotMapped]
        public bool? UsedForPL
        {
            get { return _UsedForPL; }
            set { SetProperty(ref _UsedForPL, value); }
        }
        [NotMapped]
        public bool? UsedForRL
        {
            get { return _UsedForRL; }
            set { SetProperty(ref _UsedForRL, value); }
        }
        [NotMapped]
        public bool? UsedForSL
        {
            get { return _UsedForSL; }
            set { SetProperty(ref _UsedForSL, value); }
        }
        [NotMapped]
        public bool? UsedForTL
        {
            get { return _UsedForTL; }
            set { SetProperty(ref _UsedForTL, value); }
        }
        [NotMapped]
        public bool? UsedForZG
        {
            get { return _UsedForZG; }
            set { SetProperty(ref _UsedForZG, value); }
        }
        [NotMapped]
        public bool? MappedToSYP
        {
            get { return _MappedToSYP; }
            set { SetProperty(ref _MappedToSYP, value); }
        }
        [NotMapped]
        public bool? MappedToPCA
        {
            get { return _MappedToPCA; }
            set { SetProperty(ref _MappedToPCA, value); }
        }
        [NotMapped]
        public bool? MappedToROP
        {
            get { return _MappedToROP; }
            set { SetProperty(ref _MappedToROP, value); }
        }
        [NotMapped]
        public bool? MappedToARP
        {
            get { return _MappedToARP; }
            set { SetProperty(ref _MappedToARP, value); }
        }
        [NotMapped]
        public bool? MappedToNONE
        {
            get { return _MappedToNONE; }
            set { SetProperty(ref _MappedToNONE, value); }
        }
        [NotMapped]
        public bool? MappedToPPP
        {
            get { return _MappedToPPP; }
            set { SetProperty(ref _MappedToPPP, value); }
        }
        [NotMapped]
        public bool? MappedToPSR
        {
            get { return _MappedToPSR; }
            set { SetProperty(ref _MappedToPSR, value); }
        }
        [NotMapped]
        public bool? MappedToRLP
        {
            get { return _MappedToRLP; }
            set { SetProperty(ref _MappedToRLP, value); }
        }
        [NotMapped]
        public bool? MappedToSDL
        {
            get { return _MappedToSDL; }
            set { SetProperty(ref _MappedToSDL, value); }
        }
        [NotMapped]
        public bool? MappedToSTA
        {
            get { return _MappedToSTA; }
            set { SetProperty(ref _MappedToSTA, value); }
        }
        [NotMapped]
        public bool? MappedToPPR
        {
            get { return _MappedToPPR; }
            set { SetProperty(ref _MappedToPPR, value); }
        }
        [NotMapped]
        public bool? MappedToBIN
        {
            get { return _MappedToBIN; }
            set { SetProperty(ref _MappedToBIN, value); }
        }


        #endregion

        #region Methods


        public static ObservableCollection<ParameterDefinition> GetAllParametersDefinitions()
        {
            return db.GetAllParameterDefinitions();
        }

        public int CompareTo(object obj)
        {
            ParameterDefinition paramdef = obj as ParameterDefinition;
            return string.Compare(paramdef.paf_ParNm, paf_ParNm);
            //return string.Compare(paf_ParNm, paramdef.paf_ParNm );
        }

        public bool Equals(ParameterDefinition obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj.GetType() == typeof(ParameterDefinition)))
            {
                return false;
            }

            ParameterDefinition other = (ParameterDefinition)obj;

            if (other.paf_ParNm != paf_ParNm)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void ConvertValidValues()
        {
            if (paf_ValidValues == null || paf_ValidValues == "")
            {
                return;
            }

            try
            {
                if (paf_ValidValues.Contains("<") || paf_ValidValues.Contains(">"))
                {
                    ValidValuesFillLessThan();
                }
                else if (paf_ValidValues.Contains(";"))
                {
                    ValidValuesFillOr();
                }
                else if (paf_ValidValues.Contains("-"))
                {
                    ValidValuesFillRange();
                }
                else if (paf_ValidValues.Contains(":"))
                {
                    ValidValuesFillRangeIncluding();
                }
            }
            catch (Exception)
            {
                //Incorrect parameter exception for value (paf_validvalues)
            }
   
        }
        private void ValidValuesFillLessThan()
        {
            if (paf_ValidValues.Contains("<"))
            {
                int index = paf_ValidValues.IndexOf("<") + 1;
                int location = paf_ValidValues.Length - index;
                string maximumValueText = paf_ValidValues.Substring(index, location);
                int maximumValue = Convert.ToInt32(maximumValueText);
                Validvalues = new Tuple<int, int>(0, maximumValue - 1);
            }
            else if (paf_ValidValues.Contains(">"))
            {
                //needs to be worked on later
            }
        }
        private void ValidValuesFillRange()
        {
            int index = paf_ValidValues.IndexOf("-") + 1;
            int location = paf_ValidValues.Length - index;

            string minimumValueText = paf_ValidValues.Substring(0, location);
            string maximumValueText = paf_ValidValues.Substring(index, location);
            int minimumValue = Convert.ToInt32(minimumValueText);
            int maximumValue = Convert.ToInt32(maximumValueText);

            Validvalues = new Tuple<int, int>(minimumValue, maximumValue - 1);
        }
        private void ValidValuesFillRangeIncluding()
        {
            int index = paf_ValidValues.IndexOf(":") + 1;

            int location = paf_ValidValues.Length - index;

            string minimumValueText = paf_ValidValues.Substring(0, index - 1);
            string maximumValueText = paf_ValidValues.Substring(index, location);
            int minimumValue = Convert.ToInt32(minimumValueText);
            int maximumValue = Convert.ToInt32(maximumValueText);

            Validvalues = new Tuple<int, int>(minimumValue, maximumValue);
        }
        private void ValidValuesFillOr()
        {
            string[] array = paf_ValidValues.Split(';');
            for (int i = 0; i < array.Length; i++)
            {
                ValidValuesCombobox.Add(array[i]);
            }
        }

        #endregion

    }
}
