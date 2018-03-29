using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.NonDiagramModels
{
    public class MainListViewModel : ViewModelBase
    {
        private string _Name;
        private string _Value;
        private string _OrginalObject;

        public MainListViewModel(string name, string value, string originalobject)
        {
            this._Name = name;
            this._Value = value;
            this._OrginalObject = originalobject;
        }

        #region Properties

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        public string Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }

        public string OrginalObject
        {
            get { return _OrginalObject; }
            set { SetProperty(ref _OrginalObject, value); }
        }

        #endregion
    }
}
