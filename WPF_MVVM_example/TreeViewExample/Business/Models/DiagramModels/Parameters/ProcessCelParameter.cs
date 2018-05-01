using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class ProcessCelParameter : Parameter
    {
        #region Fields

        private ProcessCel _Processcel;

        #endregion

        public ProcessCelParameter(string parName, string description, string value, string parValueUOM, string validValues, bool displayToUser, bool isStandard, ProcessCel processcel) : base(parName, description, value, parValueUOM, validValues, displayToUser, isStandard)
        {
            this._Processcel = processcel;
            ConvertValidValues();
        }

        #region Properties

        public ProcessCel Processcel
        {
            get { return _Processcel; }
            set { SetProperty(ref _Processcel, value); }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Converts the string ValidValues to a Combobox if this a applicable
        /// </summary>
        private void ConvertValidValues()
        {
            if (ValidValues.Contains("<"))
            {
                ValidValuesFillLessThan();
            }
            else if (ValidValues.Contains("-"))
            {
                ValidValuesFillRange();
            }
            else if (ValidValues.Contains(":"))
            {
                ValidValuesFillRangeIncluding();
            }
            else if (ValidValues.Contains(";"))
            {
                ValidValuesFillOr();
            }
        }

        private void ValidValuesFillLessThan()
        {
            int index = ValidValues.IndexOf("<") + 1;
            int location = ValidValues.Length - index;
            string number = ValidValues.Substring(index, location);

            //to be continued
        }
        private void ValidValuesFillRange()
        {
            int index = ValidValues.IndexOf("-") + 1;
            int location = ValidValues.Length - index;

            //to be continued

        }
        private void ValidValuesFillRangeIncluding()
        {
            int index = ValidValues.IndexOf(":") + 1;
            int location = ValidValues.Length - index;

            //to be continued
        }
        private void ValidValuesFillOr()
        {
            string[] array = ValidValues.Split(';');
            for (int i = 0; i < array.Length; i++)
            {
                ValidValuesComboBox.Add(array[i]);
            }                      
        }

        #endregion
    }
}
