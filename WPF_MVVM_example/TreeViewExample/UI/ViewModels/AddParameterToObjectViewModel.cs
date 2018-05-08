using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class AddParameterToObjectViewModel : ViewModel, INotifyPropertyChanged
    {
        private IObjectWithParameters _ParameterObject;
        private ObservableCollection<Parameter> _ParameterList = new ObservableCollection<Parameter>();
        //private ObservableCollection<Parameter> _ParameterList = new ObservableCollection<Parameter>();
        //private ObservableCollection<Parameter> _ParameterList = new ObservableCollection<Parameter>();

        private IAddParameterToObjectView _IAddParameterToObjectView;
        public AddParameterToObjectViewModel(IAddParameterToObjectView view) : base(view)
        {
            this._IAddParameterToObjectView = view;
            InitializeCommand();
        }

        #region Properties

        public IObjectWithParameters ParameterObject
        {
            get { return _ParameterObject; }
            set { SetProperty(ref _ParameterObject, value); }
        }

        public ObservableCollection<Parameter> ParameterList
        {
            get { return _ParameterList; }
            set { SetProperty(ref _ParameterList, value); }
        }
        public string ViewHeader
        {
            get { return _ParameterObject.GetName() + " ParameterAddWindow"; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Wordt op het moment op een foute plek aangeroepen (moet veranderd worden)
        /// </summary>
        public void InitializeParameters()
        {
            ParameterList = ParameterObject.GetParameterList();
        }


        #endregion

        #region ItemHandlers

        private void RemoveParameter(Parameter parameter)
        {
            ParameterList.Remove(parameter);
            ParameterObject.RemoveParameter(parameter);
        }
        private void FinishEditing()
        {
            _IAddParameterToObjectView.CloseDialog();
        }
        private void OpenCreateParameterWindow()
        {
            _IAddParameterToObjectView.OpenCreateParameterWindow();
        }

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {
            RemoveParameterCommand = new RelayCommandT1<Parameter>(RemoveParameter);
            FinishEditingCommand = new RelayCommand(FinishEditing);
            OpenCreateParameterWindowCommand = new RelayCommand(OpenCreateParameterWindow);
        }

        public ICommand RemoveParameterCommand { get; set; }
        public ICommand FinishEditingCommand { get; set; }
        public ICommand OpenCreateParameterWindowCommand { get; set; }

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
