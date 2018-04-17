using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Business.Models.DiagramModels.Parameters
{
    public class RouteParameter : ParameterDefinition
    {
        #region Fields

        private Route _Route;

        public RouteParameter(string parName, string description, string value, string parValueUOM, bool displayToUser, bool isStandardParameter, Route route) : base(parName, description, value, parValueUOM, displayToUser, isStandardParameter)
        {
            _Route = route;
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
