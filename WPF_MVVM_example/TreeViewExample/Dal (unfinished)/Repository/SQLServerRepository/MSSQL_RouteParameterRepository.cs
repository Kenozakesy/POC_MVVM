using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_RouteParameterRepository : IRouteParameterRepository
    {
        public bool DatabaseDelete(object obj)
        {
            rop_RoutePars routeparameter = obj as rop_RoutePars;
            using (var context = new UniContext())
            {
                try
                {
                    context.RouteParameters.Attach(routeparameter);
                    context.RouteParameters.Remove(routeparameter);

                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
            }
        }

        public bool DatabaseInsert(object obj)
        {
            rop_RoutePars routeparameter = obj as rop_RoutePars;
            using (var context = new UniContext())
            {
                try
                {
                    context.ParameterDefinitions.Attach(routeparameter.ParameterDefinition);
                    context.Routes.Attach(routeparameter.rot_Routes);
                    context.ProcesCells.Attach(routeparameter.rot_Routes.ProcesCell);

                    context.RouteParameters.Add(routeparameter);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
            }
        }

        public bool DatabaseUpdate(object obj)
        {
            rop_RoutePars routeparameter = obj as rop_RoutePars;
            using (var context = new UniContext())
            {
                try
                {
                    var entry = context.RouteParameters.Find(routeparameter.rop_ProcCellId, routeparameter.rop_RouteId, routeparameter.rop_ParNm);
                    context.Entry(entry).CurrentValues.SetValues(routeparameter);

                    context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
    }
}
