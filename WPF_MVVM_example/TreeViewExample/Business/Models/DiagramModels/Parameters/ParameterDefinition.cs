
using System;
using System.Windows.Media;
using TreeViewExample.Dal.DatabaseConnection;
using TreeViewExample.Dal.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DiagramModels
{
    public class ParameterDefinition : ViewModelBase, IComparable
    {
        private ParameterDefinitionBusiness db = new ParameterDefinitionBusiness(new MSSQL_ParameterDefinitionRepository());
        #region Fields

        private bool _IsVisible = true;
        private bool _IsHighlighted = false;

        private string _ParName;
        private string _Description;
        private int _BeforeSep;
        private int _AfterSep;
        private bool _IsEditable;
        private bool _DisplayToUser;
     
        private string _DefaultValue;
        private string _ParValueUOM;
    
        //private string _ValidValues;
        //private List<string> _ComboItems;

     

        private bool _IsStandardParameter;
        private Brush _Brush;

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
        public int _SequenceNumber;


        #endregion

        #region Constructors

        /// <summary>
        /// This methods is to be used when getting Parameterdefinitions from the database or changing them
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        /// <param name="parValueUOM"></param>
        /// <param name="displayToUser"></param>
        /// <param name="usedForBG"></param>
        /// <param name="usedForBL"></param>
        /// <param name="usedForCL"></param>
        /// <param name="usedForCS"></param>
        /// <param name="usedForIL"></param>
        /// <param name="usedForOL"></param>
        /// <param name="usedForPL"></param>
        /// <param name="usedForRL"></param>
        /// <param name="usedForSL"></param>
        /// <param name="usedForTL"></param>
        /// <param name="usedForZG"></param>
        /// <param name="mappedToSYP"></param>
        /// <param name="mappedToPCA"></param>
        /// <param name="mappedToROP"></param>
        /// <param name="mappedToARP"></param>
        /// <param name="mappedToNONE"></param>
        /// <param name="mappedToPPP"></param>
        /// <param name="mappedToPSR"></param>
        /// <param name="mappedToRLP"></param>
        /// <param name="mappedToSDL"></param>
        /// <param name="mappedToSTA"></param>
        /// <param name="mappedToPPR"></param>
        /// <param name="mappedToBIN"></param>
        /// <param name="sequencenumber"></param>
        public ParameterDefinition(string parName, string description, int beforeSep, int afterSep, bool isEditable, bool displayToUser,
                         bool? usedForBG, bool? usedForBL, bool? usedForCL, bool? usedForCS, bool? usedForIL, bool? usedForOL, bool? usedForPL, bool? usedForRL, bool? usedForSL, bool? usedForTL, bool? usedForZG,
                         bool? mappedToSYP, bool? mappedToPCA, bool? mappedToROP, bool? mappedToARP, bool? mappedToNONE, bool? mappedToPPP, bool? mappedToPSR, bool? mappedToRLP, bool? mappedToSDL,
                         bool? mappedToSTA, bool? mappedToPPR, bool? mappedToBIN)
        {
            _ParName = parName;
            _Description = description;
            _BeforeSep = beforeSep;
            _AfterSep = afterSep;
            _IsEditable = isEditable;
            _DisplayToUser = displayToUser;

            _Brush = Brushes.LightGray;

            _UsedForBG = usedForBG;
            _UsedForBL = usedForBL;
            _UsedForCL = usedForCL;
            _UsedForCS = usedForCS;
            _UsedForIL = usedForIL;
            _UsedForOL = usedForOL;
            _UsedForPL = usedForPL;
            _UsedForRL = usedForRL;
            _UsedForSL = usedForSL;
            _UsedForTL = usedForTL;
            _UsedForZG = usedForZG;

            _MappedToSYP = mappedToSYP;
            _MappedToPCA = mappedToPCA;
            _MappedToROP = MappedToROP;
            _MappedToARP = mappedToARP;
            _MappedToNONE = mappedToNONE;
            _MappedToPPP = mappedToPPP;
            _MappedToPSR = mappedToPSR;
            _MappedToRLP = mappedToRLP;
            _MappedToSDL = mappedToSDL;
            _MappedToSTA = mappedToSTA;
            _MappedToPPR = mappedToPPR;
            _MappedToBIN = mappedToBIN;
            //_SequenceNumber = sequencenumber;
        }

        /// <summary>
        /// This Constructor is used for testing
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="description"></param>
        /// <param name="defaulvalue"></param>
        /// <param name="parValueUOM"></param>
        /// <param name="displayToUser"></param>
        /// <param name="isStandardParameter"></param>
        public ParameterDefinition(string parName, string description, int beforeSep, int afterSep, bool isEditable, bool displayToUser, bool isStandardParameter)
        {
            _ParName = parName;
            _Description = description;
            _BeforeSep = beforeSep;
            _AfterSep = afterSep;
            _IsEditable = isEditable;
            _DisplayToUser = displayToUser;
            _IsStandardParameter = IsStandardParameter;

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
            _SequenceNumber = 0;
        }

        /// <summary>
        /// This constructor is used for creating a new parameter dynamically 
        /// </summary>
        public ParameterDefinition()
        {
            _IsStandardParameter = false;

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
            _SequenceNumber = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// required values
        /// </summary>
        public string ParName
        {
            get { return _ParName; }
            set { SetProperty(ref _ParName, value); }
        }
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
        public int BeforeSep
        {
            get { return _BeforeSep; }
            set { SetProperty(ref _BeforeSep, value); }
        }
        public int AfterSep
        {
            get { return _AfterSep; }
            set { SetProperty(ref _AfterSep, value); }
        }
        public bool IsEditable
        {
            get { return _IsEditable; }
            set { SetProperty(ref _IsEditable, value); }
        }
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }

        /// <summary>
        /// not vrequired values
        /// </summary>
        public string DefaultValue
        {
            get { return _DefaultValue; }
            set { SetProperty(ref _DefaultValue, value); }
        }
        public string ParValueUOM
        {
            get { return _ParValueUOM; }
            set { SetProperty(ref _ParValueUOM, value); }
        }

        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }
        public bool IsHighlighted
        {
            get { return _IsHighlighted; }
            set { SetProperty(ref _IsHighlighted, value); }
        }

        //public string ValidValues { get; set; }
        //public List<string> ComboItems { get; set; }

        public bool IsStandardParameter
        {
            get { return _IsStandardParameter; }
            set { SetProperty(ref _IsStandardParameter, value); }
        }

        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        #endregion

        #region ConfigurationProperties

        public bool? UsedForBG
        {
            get { return _UsedForBG; }
            set { SetProperty(ref _UsedForBG, value); }
        }
        public bool? UsedForBL
        {
            get { return _UsedForBL; }
            set { SetProperty(ref _UsedForBL, value); }
        }
        public bool? UsedForCL
        {
            get { return _UsedForCL; }
            set { SetProperty(ref _UsedForCL, value); }
        }
        public bool? UsedForCS
        {
            get { return _UsedForCS; }
            set { SetProperty(ref _UsedForCS, value); }
        }
        public bool? UsedForIL
        {
            get { return _UsedForIL; }
            set { SetProperty(ref _UsedForIL, value); }
        }
        public bool? UsedForOL
        {
            get { return _UsedForOL; }
            set { SetProperty(ref _UsedForOL, value); }
        }
        public bool? UsedForPL
        {
            get { return _UsedForPL; }
            set { SetProperty(ref _UsedForPL, value); }
        }
        public bool? UsedForRL
        {
            get { return _UsedForRL; }
            set { SetProperty(ref _UsedForRL, value); }
        }
        public bool? UsedForSL
        {
            get { return _UsedForSL; }
            set { SetProperty(ref _UsedForSL, value); }
        }
        public bool? UsedForTL
        {
            get { return _UsedForTL; }
            set { SetProperty(ref _UsedForTL, value); }
        }
        public bool? UsedForZG
        {
            get { return _UsedForZG; }
            set { SetProperty(ref _UsedForZG, value); }
        }
        public bool? MappedToSYP
        {
            get { return _MappedToSYP; }
            set { SetProperty(ref _MappedToSYP, value); }
        }
        public bool? MappedToPCA
        {
            get { return _MappedToPCA; }
            set { SetProperty(ref _MappedToPCA, value); }
        }
        public bool? MappedToROP
        {
            get { return _MappedToROP; }
            set { SetProperty(ref _MappedToROP, value); }
        }
        public bool? MappedToARP
        {
            get { return _MappedToARP; }
            set { SetProperty(ref _MappedToARP, value); }
        }
        public bool? MappedToNONE
        {
            get { return _MappedToNONE; }
            set { SetProperty(ref _MappedToNONE, value); }
        }
        public bool? MappedToPPP
        {
            get { return _MappedToPPP; }
            set { SetProperty(ref _MappedToPPP, value); }
        }
        public bool? MappedToPSR
        {
            get { return _MappedToPSR; }
            set { SetProperty(ref _MappedToPSR, value); }
        }
        public bool? MappedToRLP
        {
            get { return _MappedToRLP; }
            set { SetProperty(ref _MappedToRLP, value); }
        }
        public bool? MappedToSDL
        {
            get { return _MappedToSDL; }
            set { SetProperty(ref _MappedToSDL, value); }
        }
        public bool? MappedToSTA
        {
            get { return _MappedToSTA; }
            set { SetProperty(ref _MappedToSTA, value); }
        }
        public bool? MappedToPPR
        {
            get { return _MappedToPPR; }
            set { SetProperty(ref _MappedToPPR, value); }
        }
        public bool? MappedToBIN
        {
            get { return _MappedToBIN; }
            set { SetProperty(ref _MappedToBIN, value); }
        }
        public int SequenceNumber
        {
            get { return _SequenceNumber; }
            set { SetProperty(ref _SequenceNumber, value); }
        }

        #endregion

        #region Methods

        private bool? GetConversion(bool? isRequired)
        {
            switch (isRequired)
            {
                case true:
                    return null;
                case false:
                    return true;
                case null:
                    return false;
                default:
                    return null;
            }
        }

        private bool? SetConversion(bool? isRequired)
        {
            switch (isRequired)
            {
                case true:
                    return false;
                case false:
                    return null;
                case null:
                    return true;
                default:
                    return null;
            }
        }

        public bool CheckIfParNameExist()
        {
            if (db.CheckIfParamNameExists(this))
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            ParameterDefinition paramdef = obj as ParameterDefinition;
            return string.Compare(ParName, paramdef.ParName);
        }



        #endregion

    }
}
