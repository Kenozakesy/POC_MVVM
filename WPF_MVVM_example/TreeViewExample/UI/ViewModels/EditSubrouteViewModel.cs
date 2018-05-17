﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class EditSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields


        #endregion

        private IEditSubrouteView _IEditSubrouteView;
        public EditSubrouteViewModel(IEditSubrouteView view) : base(view)
        {
            this._IEditSubrouteView = view;

            SubRouteInRouteList = new ObservableCollection<sri_SubRoutesInRoutes>();
            Subroutelist = new ObservableCollection<SubRoute>();

            generatetest();
        }

        #region Properties

        public ObservableCollection<sri_SubRoutesInRoutes> SubRouteInRouteList { get; set; }

        public ObservableCollection<SubRoute> Subroutelist { get; set; }


        #endregion

        #region Methods

        private void generatetest()
        {
            for (int i = 0; i < 3; i++)
            {
                sri_SubRoutesInRoutes test = new sri_SubRoutesInRoutes();
                SubRouteInRouteList.Add(test);
            }
            for (int i = 0; i < 3; i++)
            {
                SubRoute test = new SubRoute();
                Subroutelist.Add(test);
            }
        }

        #endregion

        #region ItemHandlers


        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            //CreateRouteCommand = new RelayCommand(CreateRoute);
        }

        //public ICommand CreateRouteCommand { get; set; }


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
