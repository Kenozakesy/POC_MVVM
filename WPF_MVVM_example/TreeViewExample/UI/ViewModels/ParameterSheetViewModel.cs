using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class ParameterSheetViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ParameterDefinition> _ConfigurationParameterList = new ObservableCollection<ParameterDefinition>();
        private string _TextboxSearch;

        private IParameterSheetView _ParameterSheetWindow;
        public ParameterSheetViewModel(IParameterSheetView view) : base(view)
        {
            this._ParameterSheetWindow = view;
            InitializeCommand();

            GenerateTestParameters();
        }

        #region Properties
        public ObservableCollection<ParameterDefinition> ConfigurationParameterList
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

        /// <summary>
        /// This is test code 
        /// </summary>
        public void GenerateTestParameters()
        {
            for (int i = 1; i <= 40; i++)
            {
                ParameterDefinition configParam = new ParameterDefinition("Parameter" + i, "test parameter", i.ToString(), "KG", true, true);
                OrderObservableList.AddSorted(ConfigurationParameterList, configParam);
            }
            ParameterDefinition configParam2 = new ParameterDefinition("AAA", "test parameter", "41", "KG", true, true);
            OrderObservableList.AddSorted(ConfigurationParameterList, configParam2);
        }

        private void ParameterSearch()
        {
            if (string.IsNullOrWhiteSpace(TextboxSearch))
            {
                foreach (ParameterDefinition CP in ConfigurationParameterList)
                {                  
                        CP.IsVisible = true;         
                }
            }

            foreach (ParameterDefinition CP in ConfigurationParameterList)
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
        private void DeleteParameter(ParameterDefinition obj)
        {
            foreach (ParameterDefinition CP in ConfigurationParameterList)
            {
                if(CP == obj)
                {
                    ConfigurationParameterList.Remove(CP);
                    break;
                }          
            }
        }

        private void HighLightParameter(ParameterDefinition obj)
        {
            if (obj.IsHighlighted)
            {
                obj.IsHighlighted = false;
            }
            else
            {
                obj.IsHighlighted = true;
            }
        }


        #endregion


        #region commandlogic
        private void InitializeCommand()
        {
            DeleteParameterCommand = new RelayCommandT1<ParameterDefinition>(DeleteParameter);
            HighLightParameterCommand = new RelayCommandT1<ParameterDefinition>(HighLightParameter);
        }
  
        public ICommand DeleteParameterCommand { get; set; }
        public ICommand HighLightParameterCommand { get; set; }

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
