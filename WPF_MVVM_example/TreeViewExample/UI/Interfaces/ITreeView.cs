using System.Collections.Generic;
using System.Collections.ObjectModel;
using TreeViewExample.Business.Enums;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace WPF_MVVM_example.UI.Interfaces
{
    public interface ITreeView : IView
    {
        void OpenParameterSheetWindow();
        void OpenAddParameterToObjectWindow(IObjectWithParameters obj);
        void OpenCreateParameterWindow();
        void OpenCreateProcesCellWindow(ProcessCel procescell);
        void OpenCreateRouteWindow(Route route);
        void OpenEditSubrouteWindow(Route route);
        void OpenCreateSubrouteWindow(ProcessCel processcel);
        void OpenSetBinsWindow(SubRoute subroute);

    }
}
