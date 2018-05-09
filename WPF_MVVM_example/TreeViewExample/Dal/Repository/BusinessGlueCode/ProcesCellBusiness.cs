using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.BusinessGlueCode
{
    public class ProcesCellBusiness
    {
        IProcesCellRepository _Repository;

        public ProcesCellBusiness(IProcesCellRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

        public ObservableCollection<ProcessCel> GetAllProcesCells()
        {
            List<ProcessCel> paramDefinitions = _Repository.GetAllProcesCells();

            var selected = from p in paramDefinitions
                           select p;

            ObservableCollection<ProcessCel> ProcesCellList = new ObservableCollection<ProcessCel>();

            foreach (ProcessCel PC in selected.ToList())
            {
                OrderObservableList.AddSorted(ProcesCellList, PC);
            }

            return ProcesCellList;
        }

        public ObservableCollection<Route> GetAllRoutesByProcesCell(ProcessCel procescell)
        {
            List<Route> routes = _Repository.GetAllRoutesByProcesCell(procescell);

            var selected = from p in routes
                           select p;

            ObservableCollection<Route> RouteList = new ObservableCollection<Route>();

            foreach (Route PC in selected.ToList())
            {
                OrderObservableList.AddSorted(RouteList, PC);
            }

            return RouteList;
        }

        public ObservableCollection<SubRoute> GetAllSubRoutesByProcesCell(ProcessCel procescell)
        {
            List<SubRoute> subroutes = _Repository.GetAllSubroutesByProcesCell(procescell);

            var selected = from p in subroutes
                           select p;

            ObservableCollection<SubRoute> SubRouteList = new ObservableCollection<SubRoute>();

            foreach (SubRoute PC in selected.ToList())
            {
                OrderObservableList.AddSorted(SubRouteList, PC);
            }

            return SubRouteList;
        }

        #endregion
    }
}
