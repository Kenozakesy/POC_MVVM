using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.NonDiagramModels;

namespace TreeViewExample.Business.Interfaces
{
    public interface IConfigObject : IComparable, IDatabaseModelsActions
    {
        string GetName();
        void ChangeColor();
        bool Validate();
        string GetValidationMessage();
        List<MainListViewModel> GenerateListViewList();

    }
}
