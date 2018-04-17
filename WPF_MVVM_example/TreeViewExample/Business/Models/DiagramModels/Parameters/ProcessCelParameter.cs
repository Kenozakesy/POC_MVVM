using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class ProcessCelParameter : ParameterDefinition
    {
        #region Fields

        private ProcessCel _Processcel;

        public ProcessCelParameter(string parName, string description, string value, string parValueUOM, bool displayToUser, bool isStandardParameter, ProcessCel processcel) : base(parName, description, value, parValueUOM, displayToUser, isStandardParameter)
        {
            _Processcel = processcel;
        }

        #endregion

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
