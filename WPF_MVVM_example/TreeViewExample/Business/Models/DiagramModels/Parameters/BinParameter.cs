using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class BinParameter : ParameterDefinition
    {
        #region Fields

        private Bin _Bin;

        #endregion

        public BinParameter(string parName, string description, string value, string parValueUOM, bool displayToUser, bool isStandardParameter, Bin bin) : base(parName, description, value, parValueUOM, displayToUser, isStandardParameter)
        {
            _Bin = bin;           
        }

        #region Properties

        public Bin Bin
        {
            get { return _Bin; }
            set { SetProperty(ref _Bin, value); }
        }


        #endregion

        #region Methods



        #endregion
    }
}
