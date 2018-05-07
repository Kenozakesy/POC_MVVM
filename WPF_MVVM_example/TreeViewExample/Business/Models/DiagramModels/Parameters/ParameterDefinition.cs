
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Dal.DatabaseConnection;
using TreeViewExample.Dal.SQLServerRepository;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DiagramModels
{
    [Table("paf_ParDefs")]
    public class ParameterDefinition : ViewModelBase, IComparable
    {
        private ParameterDefinitionBusiness db = new ParameterDefinitionBusiness(new MSSQL_ParameterDefinitionRepository());

        #region Fields

        private bool _IsVisible = true;
        private bool _IsHighlighted = false;
        private Brush _Brush;

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
        private string _ValidValues;
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
        public ParameterDefinition(string parName, string description, string parValueUOM, int beforeSep, int afterSep, string validValues, string defaultValue, ParameterType type, Alignment alignm, int? sequenceNumber, IsEditable isEditable, bool displayToUser, int? displayWidth, string parUOM_TextId, int? column, bool isStandard)
        {
            _Brush = Brushes.LightGray;

            _ParName = parName;
            _Description = description;
            _ParValueUOM = parValueUOM;
            _BeforeSep = beforeSep;
            _AfterSep = afterSep;
            _ValidValues = validValues;
            _DefValue = defaultValue;
            _Type = type;
            _Alignm = alignm;
            _DisplaySeqNr = sequenceNumber;
            _IsEditable = isEditable;
            _DisplayToUser = displayToUser;
            _DisPlayWidth = displayWidth;
            _ParUOM_TextId = parUOM_TextId;
            _Column = column;
            _IsStandardParameter = isStandard;


            //_UsedForBG = usedForBG;
            //_UsedForBL = usedForBL;
            //_UsedForCL = usedForCL;
            //_UsedForCS = usedForCS;
            //_UsedForIL = usedForIL;
            //_UsedForOL = usedForOL;
            //_UsedForPL = usedForPL;
            //_UsedForRL = usedForRL;
            //_UsedForSL = usedForSL;
            //_UsedForTL = usedForTL;
            //_UsedForZG = usedForZG;

            //_MappedToSYP = mappedToSYP;
            //_MappedToPCA = mappedToPCA;
            //_MappedToROP = MappedToROP;
            //_MappedToARP = mappedToARP;
            //_MappedToNONE = mappedToNONE;
            //_MappedToPPP = mappedToPPP;
            //_MappedToPSR = mappedToPSR;
            //_MappedToRLP = mappedToRLP;
            //_MappedToSDL = mappedToSDL;
            //_MappedToSTA = mappedToSTA;
            //_MappedToPPR = mappedToPPR;
            //_MappedToBIN = mappedToBIN;


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
        public ParameterDefinition(string parName, string description, int beforeSep, int afterSep, IsEditable isEditable, bool displayToUser, bool isStandardParameter)
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
            _DisplaySeqNr = 0;
        }

        /// <summary>
        /// This constructor is used for creating a new customer parameter dynamically 
        /// </summary>
        public ParameterDefinition()
        {
            _IsStandardParameter = false;
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
            _DisplaySeqNr = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// required variables
        /// </summary>
        [Key]
        [Column("paf_ParNm")]
        public string ParName
        {
            get { return _ParName; }
            set { SetProperty(ref _ParName, value); }
        }

        [Column("paf_ParDesc")]
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        [Column("paf_BeforeSep")]
        public int BeforeSep
        {
            get { return _BeforeSep; }
            set { SetProperty(ref _BeforeSep, value); }
        }

        [Column("paf_AfterSep")]
        public int AfterSep
        {
            get { return _AfterSep; }
            set { SetProperty(ref _AfterSep, value); }
        }

        [Column("paf_Type")]
        public ParameterType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        [Column("paf_Alignm")]
        public Alignment Alignm
        {
            get { return _Alignm; }
            set { SetProperty(ref _Alignm, value); }
        }

        [Column("paf_Editable")]
        public IsEditable IsEditable
        {
            get { return _IsEditable; }
            set { SetProperty(ref _IsEditable, value); }
        }

        [NotMapped]
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }

        [Column("paf_DisplayToUser")]
        public string DisplayToUserText
        {
            get
            {
                if (DisplayToUser)
                {
                    return "1";
                }
                else 
                {
                    return "0";
                };
            }
            set
            {
                if (value.ToString() == "0")
                {
                    DisplayToUser = false;
                }
                else if (value.ToString() == "1")
                {
                    DisplayToUser = true;
                };
            }
        }

        /// <summary>
        /// Optional Variables
        /// </summary>
        [Column("paf_ParValueUOM")]
        public string ParValueUOM
        {
            get { return _ParValueUOM; }
            set { SetProperty(ref _ParValueUOM, value); }
        }
        [Column("paf_ValidValues")]
        public string ValidValues
        {
            get { return _ValidValues; }
            set { SetProperty(ref _ValidValues, value); }
        }
        [Column("paf_DefValue")]
        public string DefaultValue
        {
            get { return _DefValue; }
            set { SetProperty(ref _DefValue, value); }
        }
        [Column("paf_DisplaySeqNr")]
        public int? DisplaySeqNr
        {
            get { return _DisplaySeqNr; }
            set { SetProperty(ref _DisplaySeqNr, value); }
        }
        [Column("paf_DisplayWidth")]
        public int? DisplayWidth
        {
            get { return _DisPlayWidth; }
            set { SetProperty(ref _DisPlayWidth, value); }
        }
        [Column("paf_ParUOM_TextId")]
        public string ParUOM_TextId
        {
            get { return _ParUOM_TextId; }
            set { SetProperty(ref _ParUOM_TextId, value); }
        }
        [Column("paf_Column")]
        public int? Column
        {
            get { return _Column; }
            set { SetProperty(ref _Column, value); }
        }
        [Column("paf_IsStandardPar")]
        public bool IsStandardParameter
        {
            get { return _IsStandardParameter; }
            set { SetProperty(ref _IsStandardParameter, value); }
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
        public bool InsertParameterDefinition()
        {
            if (db.InsertParameterDefinition(this))
            {
                InsertParameterConnections();
                return true;
            }
            return false;
        }
        private void InsertParameterConnections()
        {
            //for TPM table
            if (_MappedToARP == true)
            {
                db.InsertIntoTpm(this, "arp_ArtPars");
            }
            if (_MappedToBIN == true)
            {
                db.InsertIntoTpm(this, "bip_BinPars");
            }
            if (_MappedToNONE == true)
            {
                db.InsertIntoTpm(this, "NONE");
            }
            if (_MappedToPCA == true)
            {
                db.InsertIntoTpm(this, "pca_ProcCellPars");
            }
            if (_MappedToPPP == true)
            {
                db.InsertIntoTpm(this, "ppp_ProdPresPars");
            }
            if (_MappedToPSR == true)
            {
                db.InsertIntoTpm(this, "psr_ParSetPars");
            }
            if (_MappedToRLP == true)
            {
                db.InsertIntoTpm(this, "rlp_RelationPars");
            }
            if (_MappedToROP == true)
            {
                db.InsertIntoTpm(this, "rop_RoutePars");
            }
            if (_MappedToSDL == true)
            {
                db.InsertIntoTpm(this, "sdl_SupplyLnDetailLns");
            }
            if (_MappedToSTA == true)
            {
                db.InsertIntoTpm(this, "sta_SPTranspBatchPars");
            }
            if (_MappedToSYP == true)
            {
                db.InsertIntoTpm(this, "syp_SystemPars");
            }
        }
        private void UpdateCellType()
        {
            //hier moet route en cell aangevinkt worden
        }
        public ObservableCollection<ParameterDefinition> GetAllCustomerParameters()
        {
            return db.GetAllCustomerParameterDefinitions();
        }

        public int CompareTo(object obj)
        {
            ParameterDefinition paramdef = obj as ParameterDefinition;
            return string.Compare(ParName, paramdef.ParName);
        }



        #endregion

    }
}
