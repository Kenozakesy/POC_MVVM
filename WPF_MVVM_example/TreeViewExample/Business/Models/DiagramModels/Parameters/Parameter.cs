using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public abstract class Parameter : ViewModelBase
    {
        #region Fields

        private string _ParName;
        private string _Description;
        private string _Value;
        private string _ParValueUOM;
        private bool _DisplayToUser;

        #endregion

        public Parameter()
        {

        }

        #region Properties

        public string ParName
        {
            get { return _ParName; }
            set { SetProperty(ref _ParName, value); }
        }
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
        public string ParValueUOM
        {
            get { return _ParValueUOM; }
            set { SetProperty(ref _ParValueUOM, value); }
        }
        public string Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }
        public bool DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }

        #endregion

        #region Methods

        #endregion
    }
}
