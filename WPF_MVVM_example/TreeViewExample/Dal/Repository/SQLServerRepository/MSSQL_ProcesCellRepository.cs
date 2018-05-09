using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;
using System.Data.Entity;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_ProcesCellRepository : IProcesCellRepository
    {
        public List<ProcessCel> GetAllProcesCells()
        {
            List<ProcessCel> procescells = new List<ProcessCel>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ProcesCells
                                  .Include(x => x.RouteList)
                                  .Include(x => x.SubrouteList)
                                  select r);
                    procescells = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return procescells;
        }

        public List<Route> GetAllRoutesByProcesCell(ProcessCel procescell)
        {
            List<Route> routeList = new List<Route>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r
                                  in context.Routes
                                  where r.ProcesCellId == procescell.ProcesCellId
                                  orderby r.RouteId select r);
                    routeList = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return routeList;
        }

        public List<SubRoute> GetAllSubroutesByProcesCell(ProcessCel procescell)
        {
            List<SubRoute> routeList = new List<SubRoute>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r
                                  in context.SubRoutes
                                  where r.ProcesCellId == procescell.ProcesCellId
                                  orderby r.SubRouteName
                                  select r);
                    routeList = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return routeList;
        }
    }
}
