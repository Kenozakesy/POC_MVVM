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
        private ObservableCollection<ParameterDefinition> _ParameterDefinitionList = new ObservableCollection<ParameterDefinition>();

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

        public ObservableCollection<ParameterDefinition> ParameterDefinitionList
        {
            get { return _ParameterDefinitionList; }
            set { SetProperty(ref _ParameterDefinitionList, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Wordt op het moment op een foute plek aangeroepen (moet veranderd worden)
        /// </summary>
        public void InitializeParameters()
        {
            ParameterDefinitionList = ParameterObject.GetParameterList();
        }


        #endregion

        #region ItemHandlers

        private void RemoveParameter(ParameterDefinition paramdef)
        {
            ParameterDefinitionList.Remove(paramdef);
            ParameterObject.RemoveParameter(paramdef);
        }

        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            RemoveParameterCommand = new RelayCommandT1<ParameterDefinition>(RemoveParameter);
        }
        public ICommand RemoveParameterCommand { get; set; }

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
