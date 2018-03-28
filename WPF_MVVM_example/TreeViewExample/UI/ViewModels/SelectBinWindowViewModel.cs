using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class SelectBinWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private Bin _Bin;

        private ISelectBinView _SelectBinView;
        public SelectBinWindowViewModel(ISelectBinView view) : base(view)
        {
            _SelectBinView = view;
            InitializeCommand();
        }

        #region Properties

        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { SetProperty(ref _BinList, value); }
        }

        public Bin Bin
        {
            get { return _Bin; }
            private set { SetProperty(ref _Bin, value); }
        }

        private void SelectBin(Bin bin)
        {
            Bin = bin;
            _SelectBinView.CloseWindow();
        }

        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            SelectBinCommand = new RelayCommandT1<Bin>(SelectBin);
        }
        public ICommand SelectBinCommand { get; set; }

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
