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
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Singletons;
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

            ListGodClass.Instance.LoadDataFromDB();

            _CustomerParameterList = ListGodClass.Instance.ParameterDefinitionList;
            _ProcessCelList = ListGodClass.Instance.ProcessCelList;
            _BinList = ListGodClass.Instance.BinList;
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

        public List<ProcesCellType> ProcesCellTypes
        {
            get
            {
                return Enum.GetValues(typeof(ProcesCellType)).Cast<ProcesCellType>().ToList();
            }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void DeleteClick(IConfigObject obj)
        {
            if (_TreeView.ConfirmMessage("delete " + obj.GetName(), "Are you sure you want to delete " + obj.GetName() + "?"))
            {
                try
                {
                    if (obj is ProcessCel)
                    {
                        foreach (ProcessCel P in _ProcessCelList)
                        {
                            if (P == obj)
                            {
                                obj.DatabaseDelete();
                                ProcessCelList.Remove(P);
                                break;
                            }
                        }
                    }
                    else if (obj != null)
                    {
                        obj.DatabaseDelete();
                    }
                }
                catch (NotImplementedException e)
                {
                    e.ToString();
                    _TreeView.ShowMessage("This functionality has not been implemented yet.");
                }
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
        private void ShowPropInList(IConfigObject obj)
        {
            //ListView.Clear();
            //List<MainListViewModel> listView = obj.GenerateListViewList();
            //foreach (MainListViewModel ML in listView)
            //{
            //    ListView.Add(ML);
            //}        
        }
        private void ValidateObject(IConfigObject obj)
        {
            List<string> wrongParameterList = obj.Validate();

            StringBuilder builder = new StringBuilder();
            foreach (string nm in wrongParameterList)
            {
                builder.Append("-" + nm + Environment.NewLine);
            }

            if (wrongParameterList.Count > 0)
            {
                _TreeView.ShowMessage("These parameter are missing " + Environment.NewLine + Environment.NewLine + builder);
            }
            else
            {
                _TreeView.ShowMessage("Object is valid");
            }
        }


        private void OpenParameterSheetWindow()
        {
            _TreeView.OpenParameterSheetWindow();
        }
        private void OpenCreateParameterWindow()
        {
            _TreeView.OpenCreateParameterWindow();
        }
        private void OpenCreateProcesCell(ProcesCellType type)
        {
            ProcessCel procescell = new ProcessCel(type);
            _TreeView.OpenCreateProcesCellWindow(procescell);
        }
        private void OpenCreateRouteWindow(ProcessCel cell)
        {
            Route route = cell.GetGeneratedRoute();
            _TreeView.OpenCreateRouteWindow(route);
        }
        private void OpenEditSubrouteWindow(Route route)
        {
            _TreeView.OpenEditSubrouteWindow(route);
        }
        private void OpenCreateSubrouteWindow(ProcessCel processcel)
        {
            _TreeView.OpenCreateSubrouteWindow(processcel);
        }
        private void OpenAddParameterToObjectWindow(IObjectWithParameters obj)
        {
            _TreeView.OpenAddParameterToObjectWindow(obj);
        }
        private void OpenSetBinsWindow(sri_SubRoutesInRoutes subrouteInRoute)
        {
            _TreeView.OpenSetBinsWindow(subrouteInRoute.sur_SubRoutes);
        }

        #endregion

        #region commandlogic

        private void InitializeCommand()
        {    
            DeleteClickCommand = new RelayCommandT1<IConfigObject>(DeleteClick);
            ChangeColorClickCommand = new RelayCommandT1<IConfigObject>(ChangeColorClick);
            ShowPropInListCommand = new RelayCommandT1<IConfigObject>(ShowPropInList);
            ValidateObjectCommand = new RelayCommandT1<IConfigObject>(ValidateObject);

            OpenParameterSheetWindowCommand = new RelayCommand(OpenParameterSheetWindow);
            OpenCreateProcesCellWindowCommand = new RelayCommandT1<ProcesCellType>(OpenCreateProcesCell);
            OpenCreateRouteWindowCommand = new RelayCommandT1<ProcessCel>(OpenCreateRouteWindow);
            OpenCreateParameterWindowCommand = new RelayCommand(OpenCreateParameterWindow);
            OpenEditSubrouteWindowCommand = new RelayCommandT1<Route>(OpenEditSubrouteWindow);
            OpenCreateSubrouteWindowCommand = new RelayCommandT1<ProcessCel>(OpenCreateSubrouteWindow);
            OpenAddParameterToObjectWindowCommand = new RelayCommandT1<IObjectWithParameters>(OpenAddParameterToObjectWindow);
            OpenSetBinsWindowCommand = new RelayCommandT1<sri_SubRoutesInRoutes>(OpenSetBinsWindow);
        }

        public ICommand DeleteClickCommand { get; set; }
        public ICommand ChangeColorClickCommand { get; set; }
        public ICommand ShowPropInListCommand { get; set; }
        public ICommand ValidateObjectCommand { get; set; }

        public ICommand OpenParameterSheetWindowCommand { get; set; }
        public ICommand OpenCreateParameterWindowCommand { get; set; }
        public ICommand OpenCreateProcesCellWindowCommand { get; set; }
        public ICommand OpenCreateRouteWindowCommand { get; set; }
        public ICommand OpenEditSubrouteWindowCommand { get; set; }
        public ICommand OpenCreateSubrouteWindowCommand { get; set; }
        public ICommand OpenAddParameterToObjectWindowCommand { get; set; }
        public ICommand OpenSetBinsWindowCommand { get; set; }

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
