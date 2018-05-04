using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Statics;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class MainWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ProcessCel> _ProcessCelList = new ObservableCollection<ProcessCel>();
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private ObservableCollection<MainListViewModel> _ListView = new ObservableCollection<MainListViewModel>();
        private ObservableCollection<ParameterDefinition> _CustomerParameterList = new ObservableCollection<ParameterDefinition>();

        private ITreeView _TreeView;
        public MainWindowViewModel(ITreeView view) : base(view)
        {
            _TreeView = view;
            InitializeCommand();

            AddProcessCelsAndBins();
            AddCustomerParameters();   
        }

        #region Properties

        public ObservableCollection<ProcessCel> ProcessCelList 
        {
            get { return _ProcessCelList; }
            set { SetProperty(ref _ProcessCelList, value); }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }
        public ObservableCollection<MainListViewModel> ListView
        {
            get { return _ListView; }
            set { SetProperty(ref _ListView, value); }
        }
        public ObservableCollection<ParameterDefinition> CustomerParameterList
        {
            get { return _CustomerParameterList; }
            set { SetProperty(ref _CustomerParameterList, value); }
        }

        #endregion

        #region Methods

        private void CreateNewProcesCel()
        {
            List<int> intList = new List<int>();
            foreach (ProcessCel P in ProcessCelList)
            {
                intList.Add(P.Number);
            }
            int firstAvailable = Enumerable.Range(1, int.MaxValue).Except(intList).FirstOrDefault();

            ProcessCel procescel = new ProcessCel("procescel", firstAvailable);
            OrderObservableList.AddSorted(ProcessCelList, procescel);
        }
        /// <summary>
        /// Gets all Customer Parameters
        /// </summary>
        private void AddCustomerParameters()
        {
            ParameterDefinition paramDef = new ParameterDefinition();
            CustomerParameterList = paramDef.GetAllCustomerParameters();
        }
        /// <summary>
        /// This is a test method
        /// </summary>
        private void AddProcessCelsAndBins()
        {
            for (int i = 1; i <= 5; i++)
            {
                CreateNewProcesCel();
            }
            for (int i = 1; i <= 10; i++)
            {
                BinList.Add(new Bin("Bin"));
            }
        }

        #endregion

        #region ItemHandlers

        private void DeleteClick(IConfigObject obj)
        {
            try
            {
                IConfigObject configObject = obj as IConfigObject;
                if (configObject is ProcessCel)
                {
                    foreach (ProcessCel P in _ProcessCelList)
                    {
                        if (P == configObject)
                        {
                            P.Delete();
                            ProcessCelList.Remove(P);
                            break;
                        }
                    }
                }
                else if (configObject != null)
                {
                    configObject.Delete();
                }
            }
            catch (NotImplementedException e)
            {
                e.ToString();
                _TreeView.ShowMessage("This functionality has not been implemented yet.");
            }
           
        }
        private void ChangeColorClick(IConfigObject obj)
        {
            IConfigObject configObject = obj as IConfigObject;
            if (configObject != null)
            {
                configObject.ChangeColor();
            }
        }
        private void CreateObjectClick(IConfigObject obj)
        {
            IConfigObject configObject = obj as IConfigObject;         
            if (configObject != null)
            {
                configObject.CreateChild();
            }
        }
        private void SetBinToUnit(Unit unit)
        {
            Bin bin = _TreeView.OpenSelectBinWindow(BinList);
            if (bin == null)
            {
                //do nothing
            }
            else if (!unit.AddBinToSubroute(bin))
            {
                _TreeView.ShowMessage("This bin is already added to this subroute");
            }
        }
        private void RemoveBinFromSubroute(Bin bin)
        {
            string text = "Remove bin from " + bin.Unit.Name + "?";
            string title = "Remove bin?";
            if (_TreeView.ConfirmMessage(title, text))
            {
                bin.SetSubroute();
            }
        }
        private void CreateProcesCel()
        {
            CreateNewProcesCel();
        }
        private void ShowPropInList(IConfigObject obj)
        {
            ListView.Clear();
            List<MainListViewModel> listView = obj.GenerateListViewList();
            foreach (MainListViewModel ML in listView)
            {
                ListView.Add(ML);
            }        
        }
        private void OpenParameterSheetWindow()
        {
            _TreeView.OpenParameterSheetWindow();
            AddCustomerParameters();
        }
        private void OpenCreateParameterWindow()
        {
            _TreeView.OpenCreateParameterWindow(_CustomerParameterList);
        }
        private void OpenEditSubrouteWindow(Route route)
        {
            _TreeView.OpenEditSubrouteWindow();
        }
        private void OpenCreateSubrouteWindow(ProcessCel processcel)
        {
            _TreeView.OpenCreateSubrouteWindow(processcel);
        }
        private void OpenAddParameterToObjectWindow(IObjectWithParameters obj)
        {
            _TreeView.OpenAddParameterToObjectWindow(obj);
        }


        #endregion

        #region commandlogic

        private void InitializeCommand()
        {    
            DeleteClickCommand = new RelayCommandT1<IConfigObject>(DeleteClick);
            ChangeColorClickCommand = new RelayCommandT1<IConfigObject>(ChangeColorClick);
            CreateObjectClickCommand = new RelayCommandT1<IConfigObject>(CreateObjectClick);
            SetbinCommand = new RelayCommandT1<Unit>(SetBinToUnit);
            RemoveBinFromSubrouteCommand = new RelayCommandT1<Bin>(RemoveBinFromSubroute);
            CreateProcesCelCommand = new RelayCommand(CreateProcesCel);
            ShowPropInListCommand = new RelayCommandT1<IConfigObject>(ShowPropInList);
            OpenParameterSheetWindowCommand = new RelayCommand(OpenParameterSheetWindow);
            OpenCreateParameterWindowCommand = new RelayCommand(OpenCreateParameterWindow);
            OpenEditSubrouteWindowCommand = new RelayCommandT1<Route>(OpenEditSubrouteWindow);
            OpenCreateSubrouteWindowCommand = new RelayCommandT1<ProcessCel>(OpenCreateSubrouteWindow);
            OpenAddParameterToObjectWindowCommand = new RelayCommandT1<IObjectWithParameters>(OpenAddParameterToObjectWindow);
        }

        public ICommand DeleteClickCommand { get; set; }
        public ICommand ChangeColorClickCommand { get; set; }
        public ICommand CreateObjectClickCommand { get; set; }
        public ICommand SetbinCommand { get; set; }
        public ICommand RemoveBinFromSubrouteCommand { get; set; }
        public ICommand CreateProcesCelCommand { get; set; }
        public ICommand ShowPropInListCommand { get; set; }
        public ICommand OpenParameterSheetWindowCommand { get; set; }
        public ICommand OpenCreateParameterWindowCommand { get; set; }
        public ICommand OpenEditSubrouteWindowCommand { get; set; }
        public ICommand OpenCreateSubrouteWindowCommand { get; set; }
        public ICommand OpenAddParameterToObjectWindowCommand { get; set; }


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
