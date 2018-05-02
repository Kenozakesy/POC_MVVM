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
        private string _ValidValuesText;
        private Tuple<int, int> _ValidValues;    
        private List<string> _ValidValuesComboBox;
        private bool _DisplayToUser;
        private bool _IsStandard;

        #endregion

        public Parameter(string parName, string description, string value, string parValueUOM, string validValues, bool displayToUser, bool isStandard)
        {
            this._ParName = parName;
            this._Description = description;
            this._Value = value;
            this._ValidValuesText = validValues;
            this._ParValueUOM = parValueUOM;
            this._DisplayToUser = displayToUser;
            this._IsStandard = isStandard;
            this._ValidValuesComboBox = new List<string>();

            ConvertValidValues();
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
        public string ValidValuesText
        {
            get { return _ValidValuesText; }
            set { SetProperty(ref _ValidValuesText, value); }
        }
        public Tuple<int, int> ValidValues
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

        /// <summary>
        /// Converts the string ValidValues to a Combobox if this a applicable
        /// </summary>
        private void ConvertValidValues()
        {
            if (ValidValuesText.Contains("<"))
            {
                ValidValuesFillLessThan();
            }
            else if (ValidValuesText.Contains("-"))
            {
                ValidValuesFillRange();
            }
            else if (ValidValuesText.Contains(":"))
            {
                ValidValuesFillRangeIncluding();
            }
            else if (ValidValuesText.Contains(";"))
            {
                ValidValuesFillOr();
            }
        }

        private void ValidValuesFillLessThan()
        {
            int index = ValidValuesText.IndexOf("<") + 1;
            int location = ValidValuesText.Length - index;
            string maximumValueText = ValidValuesText.Substring(index, location);
            int maximumValue = Convert.ToInt32(maximumValueText);

            ValidValues = new Tuple<int, int>(0, maximumValue - 1);
        }
        private void ValidValuesFillRange()
        {
            int index = ValidValuesText.IndexOf("-") + 1;
            int location = ValidValuesText.Length - index;

            string minimumValueText = ValidValuesText.Substring(0, location);
            string maximumValueText = ValidValuesText.Substring(index, location);
            int minimumValue = Convert.ToInt32(minimumValueText);
            int maximumValue = Convert.ToInt32(maximumValueText);

            ValidValues = new Tuple<int, int>(minimumValue, maximumValue - 1);
        }
        private void ValidValuesFillRangeIncluding()
        {
            int index = ValidValuesText.IndexOf(":") + 1;
            int location = ValidValuesText.Length - index;

            string minimumValueText = ValidValuesText.Substring(0, location);
            string maximumValueText = ValidValuesText.Substring(index, location);
            int minimumValue = Convert.ToInt32(minimumValueText);
            int maximumValue = Convert.ToInt32(maximumValueText);

            ValidValues = new Tuple<int, int>(minimumValue, maximumValue);
        }
        private void ValidValuesFillOr()
        {
            string[] array = ValidValuesText.Split(';');
            for (int i = 0; i < array.Length; i++)
            {
                ValidValuesComboBox.Add(array[i]);
            }
        }

        #endregion
    }
}
