﻿using System;
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

            _CustomerParameterList = ListGodClass.Instance.CustomerParameterList;
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
            //string text = "Remove bin from " + bin.Unit.Name + "?";
            //string title = "Remove bin?";
            //if (_TreeView.ConfirmMessage(title, text))
            //{
            //    bin.SetSubroute();
            //}
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
            //RemoveBinFromSubrouteCommand = new RelayCommandT1<Bin>(RemoveBinFromSubroute);
            ShowPropInListCommand = new RelayCommandT1<IConfigObject>(ShowPropInList);
            OpenParameterSheetWindowCommand = new RelayCommand(OpenParameterSheetWindow);
            OpenCreateProcesCellWindowCommand = new RelayCommandT1<ProcesCellType>(OpenCreateProcesCell);
            OpenCreateParameterWindowCommand = new RelayCommand(OpenCreateParameterWindow);
            OpenEditSubrouteWindowCommand = new RelayCommandT1<Route>(OpenEditSubrouteWindow);
            OpenCreateSubrouteWindowCommand = new RelayCommandT1<ProcessCel>(OpenCreateSubrouteWindow);
            OpenAddParameterToObjectWindowCommand = new RelayCommandT1<IObjectWithParameters>(OpenAddParameterToObjectWindow);
        }

        public ICommand DeleteClickCommand { get; set; }
        public ICommand ChangeColorClickCommand { get; set; }
        public ICommand CreateObjectClickCommand { get; set; }
        public ICommand SetbinCommand { get; set; }
        //public ICommand RemoveBinFromSubrouteCommand { get; set; }
        public ICommand ShowPropInListCommand { get; set; }
        public ICommand OpenParameterSheetWindowCommand { get; set; }
        public ICommand OpenCreateParameterWindowCommand { get; set; }
        public ICommand OpenCreateProcesCellWindowCommand { get; set; }
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
