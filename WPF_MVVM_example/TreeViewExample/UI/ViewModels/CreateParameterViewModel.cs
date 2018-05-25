using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Business.UI_Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;


namespace TreeViewExample.UI.ViewModels
{
    public class CreateParameterViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private List<ParameterType> _TypeValuesList = new List<ParameterType>();
        private List<Alignment> _AlignmentValuesList = new List<Alignment>();
        private List<IsEditable> _IsEditableList = new List<IsEditable>();

        private ObservableCollection<ParameterDefinition> _CustomerParameterList = new ObservableCollection<ParameterDefinition>();
        private ParameterDefinition _CustomerParameter = new ParameterDefinition();

        private InformationFieldModel _ParNameModel = new InformationFieldModel();
        private string _ParName;

        private InformationFieldModel _DescriptionModel = new InformationFieldModel();
        private string _Description;

        private InformationFieldModel _BeforeSepModel = new InformationFieldModel();
        private string _BeforeSep;

        private InformationFieldModel _AfterSepModel = new InformationFieldModel();
        private string _AfterSep;

        private ParameterType _ParameterType;
        private Alignment _Alignment;
        private IsEditable _IsEditable;
        private bool _DisplayToUser;

        #endregion

        private ICreateParameterView _ICreateParameterView;
        public CreateParameterViewModel(ICreateParameterView view) : base(view)
        {
            this._ICreateParameterView = view;
            InitializeCommand();

            _CustomerParameterList = ListGodClass.Instance.ParameterDefinitionList;
        }

        #region Properties

        public List<ParameterType> TypeValuesList
        {
            get
            {
                return Enum.GetValues(typeof(ParameterType)).Cast<ParameterType>().ToList();
            }
            set { SetProperty(ref _TypeValuesList, value); }
        }
        public List<Alignment> AlignmentValuesList
        {
            get
            {
                return Enum.GetValues(typeof(Alignment)).Cast<Alignment>().ToList();
            }
            set { SetProperty(ref _AlignmentValuesList, value); }
        }
        public List<IsEditable> IsEditableList
        {
            get
            {
                return Enum.GetValues(typeof(IsEditable)).Cast<IsEditable>().ToList();
            }
            set { SetProperty(ref _IsEditableList, value); }
        }



        public ParameterType ParameterType
        {
            get { return _ParameterType; }
            set { SetProperty(ref _ParameterType, value); }
        }
        public Alignment Alignment
        {
            get { return _Alignment; }
            set { SetProperty(ref _Alignment, value); }
        }

        public ObservableCollection<ParameterDefinition> CustomerParameterList
        {
            get { return _CustomerParameterList; }
            set { SetProperty(ref _CustomerParameterList, value); }
        }
        public ParameterDefinition CustomerParameter
        {
            get { return _CustomerParameter; }
            set { SetProperty(ref _CustomerParameter, value); }
        }

        public InformationFieldModel ParNameModel
        {
            get { return _ParNameModel; }
            set { SetProperty(ref _ParNameModel, value); }
        }
        public string ParName
        {
            get { return _ParName; }
            set
            {
                SetProperty(ref _ParName, value);
                AdjustFieldValidation();
            }
        }

        public InformationFieldModel DescriptionModel
        {
            get { return _DescriptionModel; }
            set { SetProperty(ref _DescriptionModel, value); }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                SetProperty(ref _Description, value);
                AdjustFieldValidation();
            }
        }

        public InformationFieldModel BeforeSepModel
        {
            get { return _BeforeSepModel; }
            set { SetProperty(ref _BeforeSepModel, value); }
        }
        public string BeforeSep
        {
            get { return _BeforeSep; }
            set
            {
                SetProperty(ref _BeforeSep, value);
                AdjustFieldValidation();
            }
        }

        public InformationFieldModel AfterSepModel
        {
            get { return _AfterSepModel; }
            set { SetProperty(ref _AfterSepModel, value); }
        }
        public string AfterSep
        {
            get { return _AfterSep; }
            set
            {
                SetProperty(ref _AfterSep, value);
                AdjustFieldValidation();
            }
        }

        public IsEditable IsEditable
        {
            get { return _IsEditable; }
            set { SetProperty(ref _IsEditable, value); }
        }
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }

        #endregion

        #region Methods

        private void AdjustFieldValidation()
        {
            _CustomerParameter.paf_ParNm = ParName;
            if (string.IsNullOrEmpty(ParName) || ParName.Contains(" "))
            {
                ParNameModel.IsValid = IsValidated.InValid;
            }
            else
            {
                ParNameModel.IsValid = IsValidated.Valid;
            }

            if (string.IsNullOrEmpty(Description))
            {
                DescriptionModel.IsValid = IsValidated.InValid;
            }
            else
            {
                DescriptionModel.IsValid = IsValidated.Valid;
            }

            int before;
            if (int.TryParse(BeforeSep, out before))
            {
                BeforeSepModel.IsValid = IsValidated.Valid;
            }
            else
            {
                BeforeSepModel.IsValid = IsValidated.InValid;
            }

            int after;
            if (int.TryParse(AfterSep, out after))
            {
                AfterSepModel.IsValid = IsValidated.Valid;
            }
            else
            {
                AfterSepModel.IsValid = IsValidated.InValid;
            }
        }

        private void ClearFields()
        {
            ParName = "";
            Description = "";
            BeforeSep = "";
            AfterSep = "";
        }

        #endregion

        #region ItemHandlers

        private void DeleteCustomerParameter(ParameterDefinition paramdef)
        {
            if (!_ICreateParameterView.ConfirmMessage("Delete Parameter?!", "Are you sure you want to delete the parameterdefinition?" + Environment.NewLine + "(all parameters with this definition will be removed)"))
            {
                return;
            }

            foreach (ParameterDefinition P in CustomerParameterList)
            {
                if (P == paramdef)
                {
                    //p.delete or something here
                    CustomerParameterList.Remove(P);
                    break;
                }
            }
        }

        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            DeleteCustomerParameterCommand = new RelayCommandT1<ParameterDefinition>(DeleteCustomerParameter);
        }

        public ICommand DeleteCustomerParameterCommand { get; set; }


        #endregion

        #region property change logic

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
