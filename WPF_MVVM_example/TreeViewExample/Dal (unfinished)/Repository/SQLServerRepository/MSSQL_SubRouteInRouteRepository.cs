using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_SubRouteInRouteRepository : ISubRouteInRouteRepository
    {
        public bool DatabaseDelete(object obj)
        {
            sri_SubRoutesInRoutes subrouteInRoute = obj as sri_SubRoutesInRoutes;
            using (var context = new UniContext())
            {
                try
                {
                    context.SubRoutes.Attach(subrouteInRoute.sur_SubRoutes);
                    context.Routes.Attach(subrouteInRoute.rot_Routes);

                    context.SubRoutesInRoutes.Attach(subrouteInRoute);
                    context.SubRoutesInRoutes.Remove(subrouteInRoute);

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
            sri_SubRoutesInRoutes subrouteInRoute = obj as sri_SubRoutesInRoutes;
            using (var context = new UniContext())
            {
                try
                {
                    context.SubRoutesInRoutes.Add(subrouteInRoute);
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
            throw new NotImplementedException();
        }
    }

}
