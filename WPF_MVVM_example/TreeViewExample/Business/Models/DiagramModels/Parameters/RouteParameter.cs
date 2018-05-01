using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class RouteParameter : Parameter
    {
        #region Fields

        private Route _Route;

        public RouteParameter(string parName, string description, string value, string parValueUOM, string validValues, bool displayToUser, bool isStandard, Route route) : base(parName, description, value, parValueUOM, validValues, displayToUser, isStandard)
        {
            this._Route = route;
        }

        #endregion

        #region Properties

        public Route Route
        {
            get { return _Route; }
            set { SetProperty(ref _Route, value); }
        }

        #endregion

        #region Methods



        #endregion
    }
}
