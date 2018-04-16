
using System.Windows.Media;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DiagramModels
{
    public class ParameterDefinition : ViewModelBase
    {
        #region Fields
        private bool _IsVisible = true;
        private bool _IsHighlighted = false;

        private string _ParName;
        private string _Description;
        private string _Value;
        private string _ParValueUOM;
        private bool _IsStandardParameter;
        private Brush _Brush;

        //private string _ValidValues;
        //private List<string> _ComboItems;

        private bool _DisplayToUser;

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

        public ParameterDefinition(string parName, string description, string value, string parValueUOM, bool displayToUser, 
                         bool? usedForBG, bool? usedForBL, bool? usedForCL, bool? usedForCS, bool? usedForIL, bool? usedForOL, bool? usedForPL, bool? usedForRL, bool? usedForSL, bool? usedForTL, bool? usedForZG,
                         bool? mappedToSYP, bool? mappedToPCA, bool? mappedToROP, bool? mappedToARP, bool? mappedToNONE, bool? mappedToPPP, bool? mappedToPSR, bool? mappedToRLP, bool? mappedToSDL,
                         bool? mappedToSTA, bool? mappedToPPR, bool? mappedToBIN, int sequencenumber)
        {
            _ParName = parName;
            _Description = description;
            _Value = value;
            _ParValueUOM = parValueUOM;
            _DisplayToUser = displayToUser;

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
            _SequenceNumber = sequencenumber;     
        }

        public ParameterDefinition(string parName, string description, string value, string parValueUOM, bool displayToUser, bool isStandardParameter)
        {
            _ParName = parName;
            _Description = description;
            _Value = value;
            _ParValueUOM = parValueUOM;
            _DisplayToUser = displayToUser;

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
            _IsVisible = isStandardParameter;
            _Brush = Brushes.LightGray;
        }

        #endregion

        #region Properties

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
        public string Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }
        public string ParValueUOM
        {
            get { return _ParValueUOM; }
            set { SetProperty(ref _ParValueUOM, value); }
        }
        //public string ValidValues { get; set; }
        //public List<string> ComboItems { get; set; }
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }

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

        

        #endregion

    }
}
