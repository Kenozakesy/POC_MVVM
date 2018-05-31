using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateRouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Route _Route;

        #endregion

        private ICreateRouteView _View;

        public CreateRouteViewModel(ICreateRouteView view) : base(view)
        {
            _View = view;
            InitializeCommand();
        }

        #region Properties

        public ProcessCel ProcesCell { get; set; }
        public Route Route
        {
            get { return _Route; }
            set
            {
                SetProperty(ref _Route, value);
                ProcesCell = Route.ProcesCell;
            }
        }

        #endregion

        #region Methods

        private void GenerateRoute()
        {

        }

        #endregion


        #region ItemHandlers

        private void SaveRoute()
        {
            Route.DatabaseInsert();
            _View.CloseWindow();
        }

        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            SaveRouteCommand = new RelayCommand(SaveRoute);
        }

        public ICommand SaveRouteCommand { get; set; }


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
