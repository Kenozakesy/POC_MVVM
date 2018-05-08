﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    public class Bin : ViewModelBase, IConfigObject, IObjectWithParameters
    {
        private ObservableCollection<BinParameter> _BinParameterList = new ObservableCollection<BinParameter>();
        private Unit _Unit;

        private string _Name;
        private static int _StaticNumber = 1;
        private int _Number;
        private Brush _Brush;
        private IsValidated _IsValid;
    
        public Bin(string name, Unit unit = null)
        {
            _Number = _StaticNumber;
            _StaticNumber++;
            _Name = name + " " + _Number;
            _Unit = unit;


            _Brush = Brushes.Orange;
            GetBinParameters();
            Validate();
        }

        #region Properties

        public ObservableCollection<BinParameter> BinParameterList
        {
            get { return _BinParameterList; }
            set { SetProperty(ref _BinParameterList, value); }
        }
        public Unit Unit
        {
            get { return _Unit; }
            private set
            {
                SetProperty(ref _Unit, value);
                Validate();
            }
        }
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        public int Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }
        public IsValidated IsValid
        {
            get { return _IsValid; }
            set {
                SetProperty(ref _IsValid, value);
                SetColor();
            }
        }


        #endregion

        #region Methods

        private void GetBinParameters()
        {
            for (int i = 0; i < 5; i++)
            {
                BinParameter binParameter = new BinParameter("Name", "description", "1", "-", "1;2;3;4;5", true, true, this);
                BinParameterList.Add(binParameter);
            }
        }
        public void SetSubroute(Unit unit = null)
        {
            if (this.Unit != null)
            {
                this.Unit.DeleteBin(this);
            }
            Unit = unit;            
        }
        public void Validate()
        {
            if (_Unit == null)
            {
                IsValid = IsValidated.NotConnected;
            }
            else
            {
                IsValid = IsValidated.Valid;
            }
        }
        private void SetColor()
        {
            switch (IsValid)
            {
                case IsValidated.Valid:
                    Brush = Brushes.LightGreen;
                    break;
                case IsValidated.NotConnected:
                    Brush = Brushes.Orange;
                    break;
                default:
                    break;
            }
        }
        public void ChangeColor()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void DeleteChild(IConfigObject obj)
        {
            throw new NotImplementedException();
        }
        public void CreateChild()
        {
            throw new NotImplementedException();
        }
        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            //foreach (var prop in this.GetType().GetProperties())
            //{
            //    if (!prop.PropertyType.FullName.StartsWith("System.") || prop.Name == "Brush")
            //    {
            //        continue;
            //    }
            //    string name = prop.Name;
            //    string value = prop.GetValue(this, null).ToString();
            //    MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.Name);
            //    configList.Add(mainListViewModel);
            //}
            return configList;
        }
        public int CompareTo(object obj)
        {
            Bin bin = obj as Bin;
            if (this._Number > bin._Number)
            {
                return 1;
            }
            else if (this._Number < bin._Number)
            {
                return -1;
            }
            return 0;
        }
        public override string ToString()
        {
            return Name;
        }
        public ObservableCollection<Parameter> GetParameterList()
        {
            ObservableCollection<Parameter> parameterList = new ObservableCollection<Parameter>();
            foreach (BinParameter BP in BinParameterList)
            {
                parameterList.Add(BP);
            }
            return parameterList;
        }
        public void RemoveParameter(Parameter paramdef)
        {
            throw new NotImplementedException();
        }


        public string GetName()
        {
            return Name;
        }

        #endregion
    }
}
