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
        private ObservableCollection<Route> _RouteList = new ObservableCollection<Route>();
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private string _tbName;


        private ITreeView _TreeView;
        public MainWindowViewModel(ITreeView view) : base(view)
        {
            //quick solution needs a observer pattern.
            GlobalLists.Instance.Viewmodel = this;

            _TreeView = view;
            AddProcessCelsAndBins();
            InitializeCommand();
        }

        #region Properties

        public ObservableCollection<ProcessCel> ProcessCelList 
        {
            get { return _ProcessCelList; }
            set { SetProperty(ref _ProcessCelList, value); }
        }
        public ObservableCollection<Route> RouteList
        {
            get { return _RouteList; }
            set { SetProperty(ref _RouteList, value); }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }

        public string tbName
        {
            get { return _tbName;}
            set { SetProperty(ref _tbName, value); }
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

        #endregion

        #region ItemHandlers

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
        private void DeleteClick(object obj)
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
        private void ChangeColorClick(object obj)
        {
            IConfigObject configObject = obj as IConfigObject;
            if (configObject != null)
            {
                configObject.ChangeColor();
            }
        }
        private void CreateObjectClick(object obj)
        {
            IConfigObject configObject = obj as IConfigObject;         
            if (configObject != null)
            {
                configObject.CreateChild();
            }
        }
        private void AddbinToSubroute(SubRoute subroute)
        {
            Bin bin = _TreeView.OpenSelectBinWindow(BinList);
            if (bin == null)
            {
                //do nothing
            }
            else if (!subroute.AddBinToSubroute(bin))
            {
                _TreeView.ShowMessage("This bin is already added to this subroute");
            }
        }
        private void RemoveBinFromSubroute(Bin bin)
        {
            if (_TreeView.ConfirmMessage())
            {
                bin.SetSubroute();
            }
        }
        private void CreateProcesCel()
        {
            CreateNewProcesCel();
        }
        private void OpenDragDropWindow(Route route)
        {
            _TreeView.OpenDragDropWindow();
        }

        #endregion

        #region commandlogic
        private void InitializeCommand()
        {    
            DeleteClickCommand = new RelayCommandT1<object>(DeleteClick);
            ChangeColorClickCommand = new RelayCommandT1<object>(ChangeColorClick);
            CreateObjectClickCommand = new RelayCommandT1<object>(CreateObjectClick);
            AddbinCommand = new RelayCommandT1<SubRoute>(AddbinToSubroute);
            RemoveBinFromSubrouteCommand = new RelayCommandT1<Bin>(RemoveBinFromSubroute);
            CreateProcesCelCommand = new RelayCommand(CreateProcesCel);
            OpenDragDropWindowCommand = new RelayCommandT1<Route>(OpenDragDropWindow);
        }

        public ICommand DeleteClickCommand { get; set; }
        public ICommand ChangeColorClickCommand { get; set; }
        public ICommand CreateObjectClickCommand { get; set; }
        public ICommand AddbinCommand { get; set; }
        public ICommand RemoveBinFromSubrouteCommand { get; set; }
        public ICommand CreateProcesCelCommand { get; set; }
        public ICommand OpenDragDropWindowCommand { get; set; }

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
