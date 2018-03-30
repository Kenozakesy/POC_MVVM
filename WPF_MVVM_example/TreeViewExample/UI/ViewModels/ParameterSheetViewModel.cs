using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class ParameterSheetViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ConfigurationParameter> _ConfigurationParameterList = new ObservableCollection<ConfigurationParameter>();
        private string _TextboxSearch;

        private IParameterSheetView _ParameterSheetWindow;
        public ParameterSheetViewModel(IParameterSheetView view) : base(view)
        {
            this._ParameterSheetWindow = view;
            InitializeCommand();

            GenerateTestParameters();
        }

        #region Properties
        public ObservableCollection<ConfigurationParameter> ConfigurationParameterList
        {
            get { return _ConfigurationParameterList; }
            set { SetProperty(ref _ConfigurationParameterList, value); }
        }

        public string TextboxSearch
        {
            get { return _TextboxSearch; }
            set
            {
                SetProperty(ref _TextboxSearch, value);
                ParameterSearch();
            }
        }

        #endregion


        #region Methods

        public void GenerateTestParameters()
        {
            for (int i = 1; i <= 40; i++)
            {
                ConfigurationParameter configParam = new ConfigurationParameter("Parameter" + i, "test parameter", i.ToString(), "KG", true);
                ConfigurationParameterList.Add(configParam);
            }
        }

        private void ParameterSearch()
        {
            if (string.IsNullOrWhiteSpace(TextboxSearch))
            {
                foreach (ConfigurationParameter CP in ConfigurationParameterList)
                {                  
                        CP.IsVisible = true;         
                }
            }

            foreach (ConfigurationParameter CP in ConfigurationParameterList)
            {
                if (CP.ParName.Contains(TextboxSearch))
                {
                    CP.IsVisible = true;
                }
                else
                {
                    CP.IsVisible = false;
                }
            }
        }

        #endregion


        #region ItemHandlers

        #endregion


        #region commandlogic
        private void InitializeCommand()
        {
            //DeleteClickCommand = new RelayCommandT1<IConfigObject>(DeleteClick);
        }

        //public ICommand DeleteClickCommand { get; set; }

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
