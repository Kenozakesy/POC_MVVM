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
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ProcessCel _ProcesCell;
        private string _SubrouteName;

        #endregion

        private ICreateSubrouteView _View;
        public CreateSubrouteViewModel(ICreateSubrouteView view) : base(view)
        {
            this._View = view;
            InitializeCommand();
        }

        #region Properties

        public ProcessCel ProcesCell
        {
            get { return _ProcesCell; }
            set { SetProperty(ref _ProcesCell, value); }
        }

        public string SubrouteName
        {
            get { return _SubrouteName; }
            set { SetProperty(ref _SubrouteName, value); }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void CreateNewSubroute()
        {
            if (string.IsNullOrEmpty(SubrouteName))
            {
                _View.ShowMessage("Please choose a name.");
            }
            else
            {
                ProcesCell.AddNewSubroute(SubrouteName);
            }
        }

        private void DeleteClick(IConfigObject obj)
        {
            if (_View.ConfirmMessage("delete " + obj.GetName(), "Are you sure you want to delete " + obj.GetName() + "?"))
            {
                try
                {
                    if (obj != null)
                    {
                        obj.DatabaseDelete();
                    }
                }
                catch (NotImplementedException e)
                {
                    e.ToString();
                    _View.ShowMessage("This functionality has not been implemented yet.");
                }
            }
        }

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {
            CreateNewSubrouteCommand = new RelayCommand(CreateNewSubroute);
            DeleteClickCommand = new RelayCommandT1<IConfigObject>(DeleteClick);
        }
        public ICommand CreateNewSubrouteCommand { get; set; }
        public ICommand DeleteClickCommand { get; set; }

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
