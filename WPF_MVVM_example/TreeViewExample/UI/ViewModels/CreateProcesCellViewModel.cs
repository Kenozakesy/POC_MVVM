using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class CreateProcesCellViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ProcessCel> procesCellList = ListGodClass.Instance.ProcessCelList;

        private ICreateProcesCellView _View;
        public CreateProcesCellViewModel(ICreateProcesCellView view) : base(view)
        {
            _View = view;
            InitializeCommand();
            ProcesCell = new ProcessCel();
        }

        public ProcessCel ProcesCell { get; set; }

        public List<ProcesCellType> ProcCellTypeList
        {
            get
            {
                return Enum.GetValues(typeof(ProcesCellType)).Cast<ProcesCellType>().ToList(); ;
            }
        }

        #region Methods

        #endregion

        #region ItemHandlers

        /// <summary>
        /// Adds a new route with the first available number
        /// </summary>
        private void AddRoute()
        {
            ProcesCell.AddGeneratedRoute();
        }
        private void RemoveRoute()
        {
            ProcesCell.RemoveGeneratedRoute();
        }
        private void AddBatch()
        {
 
        }

        private void RemoveBatch()
        {
        
        }

        private void SaveProcesCell()
        {
            if (ProcesCell.DatabaseInsert())
            {
                OrderObservableList.AddSorted(procesCellList, ProcesCell);
            }
            else
            {
                _View.ShowMessage("An error occurred. Procescell cannot be made.");
            }
            _View.CloseWindow();
        }

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {
            AddRouteCommand = new RelayCommand(AddRoute);
            RemoveRouteCommand = new RelayCommand(RemoveRoute);
            AddBatchCommand = new RelayCommand(AddBatch);
            RemoveBatchCommand = new RelayCommand(RemoveBatch);
            SaveProcesCellCommand = new RelayCommand(SaveProcesCell);
        }

        public ICommand AddRouteCommand { get; set; }
        public ICommand RemoveRouteCommand { get; set; }
        public ICommand AddBatchCommand { get; set; }
        public ICommand RemoveBatchCommand { get; set; }
        public ICommand SaveProcesCellCommand { get; set; }

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
