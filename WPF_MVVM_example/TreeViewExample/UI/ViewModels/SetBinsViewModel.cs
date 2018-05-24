using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class SetBinsViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<bir_BinsInSubRoutes> _DestinationBinList = new ObservableCollection<bir_BinsInSubRoutes>();
        private ObservableCollection<bir_BinsInSubRoutes> _SourceBinList = new ObservableCollection<bir_BinsInSubRoutes>();
        private SubRoute _Subroute;

        #endregion

        private ISetBinsView _View;
        public SetBinsViewModel(ISetBinsView view) : base(view)
        {
            _View = view;
            InitializeCommand();
            BinList = ListGodClass.Instance.BinList;

            SelectedBinList = new ObservableCollection<Bin>();
            SelectedDestinationBinList = new ObservableCollection<bir_BinsInSubRoutes>();
            SelectedSourceBinList = new ObservableCollection<bir_BinsInSubRoutes>();
        }

        #region Properties

        public SubRoute Subroute
        {
            get { return _Subroute; }
            set { SetProperty(ref _Subroute, value); }
        }

        public ObservableCollection<Bin> BinList { get; set; }
        public ObservableCollection<bir_BinsInSubRoutes> DestinationBinList
        {
            get { return _DestinationBinList; }
            set { SetProperty(ref _DestinationBinList, value); }
        }
        public ObservableCollection<bir_BinsInSubRoutes> SourceBinList
        {
            get { return _SourceBinList; }
            set { SetProperty(ref _SourceBinList, value); }
        }

        public ObservableCollection<Bin> SelectedBinList { get; set; }
        public ObservableCollection<bir_BinsInSubRoutes> SelectedDestinationBinList { get; set; }
        public ObservableCollection<bir_BinsInSubRoutes> SelectedSourceBinList { get; set; }

        #endregion


        #region Methods

        public void GetSourceDestinationLists()
        {
            DestinationBinList = Subroute.GetAllDestinationBins();
            SourceBinList = Subroute.GetAllSourceBins();
        }

        #endregion


        #region ItemHandlers

        private void RemoveSourceBin()
        {
            foreach (bir_BinsInSubRoutes bir in SelectedSourceBinList)
            {
                bir.DatabaseDelete();
            }
            GetSourceDestinationLists();
        }

        private void AddSourceBin()
        {
            foreach (Bin B in SelectedBinList)
            {
                Subroute.AddBinToSubroute(B, SourceDest.S);
            }
            GetSourceDestinationLists();
        }

        private void RemoveDestinationBin()
        {
            foreach (bir_BinsInSubRoutes bir in SelectedDestinationBinList)
            {
                bir.DatabaseDelete();
            }
            GetSourceDestinationLists();
        }

        private void AddDestinationBin()
        {
            foreach (Bin B in SelectedBinList)
            {
                Subroute.AddBinToSubroute(B, SourceDest.D);
            }
            GetSourceDestinationLists();
        }

        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            RemoveSourceBinCommand = new RelayCommand(RemoveSourceBin);
            AddSourceBinCommand = new RelayCommand(AddSourceBin);
            RemoveDestinationBinCommand = new RelayCommand(RemoveDestinationBin);
            AddDestinationBinCommand = new RelayCommand(AddDestinationBin);
        }

        public ICommand RemoveSourceBinCommand { get; set; }
        public ICommand AddSourceBinCommand { get; set; }
        public ICommand RemoveDestinationBinCommand { get; set; }
        public ICommand AddDestinationBinCommand { get; set; }

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
