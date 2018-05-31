using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;

namespace TreeViewExample.Business.Interfaces
{
    public interface IObjectWithParameters : IConfigObject
    {
        string GetName();
        ObservableCollection<IParameterObject> GetParameterList();
        ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters();
        bool AddParameter(ParameterDefinition paramdefinition);
        void AddRequiredParameters();
    }
}
