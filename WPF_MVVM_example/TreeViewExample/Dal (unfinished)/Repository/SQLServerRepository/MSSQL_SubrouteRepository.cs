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
    public class MSSQL_SubrouteRepository : ISubrouteRepository
    {
        public bool DatabaseDelete(object obj)
        {
            SubRoute subroute = obj as SubRoute;
            using (var context = new UniContext())
            {
                try
                {
                    context.SubRoutes.Attach(subroute);
                    context.SubRoutes.Remove(subroute);

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
            SubRoute subroute = obj as SubRoute;
            using (var context = new UniContext())
            {
                try
                {
                    context.SubRoutes.Add(subroute);
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
