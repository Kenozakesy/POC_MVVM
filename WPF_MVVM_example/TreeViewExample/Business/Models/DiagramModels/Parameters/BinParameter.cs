﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class BinParameter : Parameter
    {
        #region Fields

        private Bin _Bin;

        public BinParameter(string parName, string description, string value, string parValueUOM, string validValues, bool displayToUser, bool isStandard, Bin bin) : base(parName, description, value, parValueUOM, validValues, displayToUser, isStandard)
        {
            this._Bin = bin;
        }

        #endregion


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
