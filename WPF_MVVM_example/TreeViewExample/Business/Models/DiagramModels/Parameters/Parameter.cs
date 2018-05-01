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
        private string _ValidValues;
        private List<string> _ValidValuesComboBox;
        private bool _DisplayToUser;
        private bool _IsStandard;

        #endregion

        public Parameter(string parName, string description, string value, string parValueUOM, string validValues, bool displayToUser, bool isStandard)
        {
            this._ParName = parName;
            this._Description = description;
            this._Value = value;
            this._ParValueUOM = parValueUOM;
            this._ValidValues = validValues;
            this._DisplayToUser = displayToUser;
            this._IsStandard = isStandard;
            this._ValidValuesComboBox = new List<string>();
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
        public string ValidValues
        {
            get { return _ValidValues; }
            set { SetProperty(ref _ValidValues, value); }
        }
        public List<string> ValidValuesComboBox
        {
            get { return _ValidValuesComboBox; }
            set { SetProperty(ref _ValidValuesComboBox, value); }
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
        public bool IsStandard
        {
            get { return _IsStandard; }
            set { SetProperty(ref _IsStandard, value); }
        }

        #endregion

        #region Methods

        #endregion
    }
}
