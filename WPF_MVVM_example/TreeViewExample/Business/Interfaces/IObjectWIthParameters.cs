using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Business.Interfaces
{
    public interface IObjectWithParameters
    {
        ObservableCollection<ParameterDefinition> GetParameterList();
        void RemoveParameter(ParameterDefinition paramdef);

    }
}
