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


        #endregion

        public Parameter()
        {

        }


        #region Methods

        /// <summary>
        /// Converts the string ValidValues to a Combobox if this a applicable
        /// </summary>
        
        //private void ConvertValidValues()
        //{
        //    if (ValidValuesText.Contains("<"))
        //    {
        //        ValidValuesFillLessThan();
        //    }
        //    else if (ValidValuesText.Contains("-"))
        //    {
        //        ValidValuesFillRange();
        //    }
        //    else if (ValidValuesText.Contains(":"))
        //    {
        //        ValidValuesFillRangeIncluding();
        //    }
        //    else if (ValidValuesText.Contains(";"))
        //    {
        //        ValidValuesFillOr();
        //    }
        //}
        //private void ValidValuesFillLessThan()
        //{
        //    int index = ValidValuesText.IndexOf("<") + 1;
        //    int location = ValidValuesText.Length - index;
        //    string maximumValueText = ValidValuesText.Substring(index, location);
        //    int maximumValue = Convert.ToInt32(maximumValueText);

        //    ValidValues = new Tuple<int, int>(0, maximumValue - 1);
        //}
        //private void ValidValuesFillRange()
        //{
        //    int index = ValidValuesText.IndexOf("-") + 1;
        //    int location = ValidValuesText.Length - index;

        //    string minimumValueText = ValidValuesText.Substring(0, location);
        //    string maximumValueText = ValidValuesText.Substring(index, location);
        //    int minimumValue = Convert.ToInt32(minimumValueText);
        //    int maximumValue = Convert.ToInt32(maximumValueText);

        //    ValidValues = new Tuple<int, int>(minimumValue, maximumValue - 1);
        //}
        //private void ValidValuesFillRangeIncluding()
        //{
        //    int index = ValidValuesText.IndexOf(":") + 1;
        //    int location = ValidValuesText.Length - index;

        //    string minimumValueText = ValidValuesText.Substring(0, location);
        //    string maximumValueText = ValidValuesText.Substring(index, location);
        //    int minimumValue = Convert.ToInt32(minimumValueText);
        //    int maximumValue = Convert.ToInt32(maximumValueText);

        //    ValidValues = new Tuple<int, int>(minimumValue, maximumValue);
        //}
        //private void ValidValuesFillOr()
        //{
        //    string[] array = ValidValuesText.Split(';');
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        ValidValuesComboBox.Add(array[i]);
        //    }
        //}

        #endregion
    }
}
