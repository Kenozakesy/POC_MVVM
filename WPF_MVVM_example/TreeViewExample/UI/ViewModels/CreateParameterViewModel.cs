﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;
using System.Windows.Input;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateParameterViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ParameterDefinition> _CustomerParameterList = new ObservableCollection<ParameterDefinition>();

        private ICreateParameterView _ICreateParameterView;
        public CreateParameterViewModel(ICreateParameterView view) : base(view)
        {
            this._ICreateParameterView = view;
            InitializeCommand();
        }


        #region Properties

        public ObservableCollection<ParameterDefinition> CustomerParameterList
        {
            get { return _CustomerParameterList; }
            set { SetProperty(ref _CustomerParameterList, value); }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void CreateCustomerParameter()
        {
            ParameterDefinition paramdef = new ParameterDefinition("just created", "", "1", "0 = not created; 1 = created", true, false);
            CustomerParameterList.Add(paramdef);
        }

        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            CreateCustomerParameterCommand = new RelayCommand(CreateCustomerParameter);
        }

        public ICommand CreateCustomerParameterCommand { get; set; }


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
