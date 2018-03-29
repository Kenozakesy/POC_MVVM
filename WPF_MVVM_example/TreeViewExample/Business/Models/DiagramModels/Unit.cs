using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models.NonDiagramModels;
using TreeViewExample.Business.Singletons;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models
{
    public class Unit : ViewModelBase, IConfigObject
    {
        private SubRoute _Subroute;
        private string _Name;
        private int _Number;
        private Brush _Brush;
        private static Random ran = new Random();

        public Unit(string name, int number, SubRoute subroute)
        {
            this._Name = name;
            this._Number = number;
            this._Subroute = subroute;

            int newRan = ran.Next(0, 10);

            if (newRan >= 8)
            {
                _Brush = Brushes.Red;
            }
            else
            {
                _Brush = Brushes.LightGreen;
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

        #region Methods

        public void ChangeColor()
        {
            if (_Brush == Brushes.Red)
            {
                Brush = Brushes.LightGreen;
            }
            else
            {
                Brush = Brushes.Red;
            }
        }

        public void Delete()
        {
            this._Subroute.DeleteChild(this);
        }

        public void DeleteChild(IConfigObject obj)
        {
            throw new NotImplementedException();
        }

        public void CreateChild()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            Unit unit = obj as Unit;
            if (this._Number > unit._Number)
            {
                return 1;
            }
            else if (this._Number < unit._Number)
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return _Name;
        }

        public List<MainListViewModel> GenerateListViewList()
        {
            List<MainListViewModel> configList = new List<MainListViewModel>();
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.PropertyType.FullName.StartsWith("System.") || prop.Name == "Brush")
                {
                    continue;
                }
                string name = prop.Name;
                string value = prop.GetValue(this, null).ToString();
                MainListViewModel mainListViewModel = new MainListViewModel(name, value, this.Name);
                configList.Add(mainListViewModel);
            }
            return configList;
        }



        #endregion

    }


}
