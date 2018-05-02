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

        }

        #region Properties

        public ProcessCel Processcel
        {
            get { return _Processcel; }
            set { SetProperty(ref _Processcel, value); }
        }

        #endregion

        #region Methods


    

        #endregion
    }
}
