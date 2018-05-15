using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_RouteRepository : IRouteRepository
    {
        public bool DatabaseDelete(object obj)
        {
            Route route = obj as Route;

            using (var context = new UniContext())
            {
                try
                {
                    context.Routes.Attach(route);
                    context.Routes.Remove(route);

                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    context.Dispose();
                    return false;
                }
            }
        }

        public bool DatabaseInsert(object obj)
        {
            Route route = obj as Route;

            throw new NotImplementedException();
        }

        public bool DatabaseUpdate(object obj)
        {
            Route route = obj as Route;

            throw new NotImplementedException();
        }
    }
}
