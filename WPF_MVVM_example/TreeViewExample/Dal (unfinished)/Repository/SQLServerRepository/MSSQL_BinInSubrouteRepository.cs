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
    public class MSSQL_BinInSubrouteRepository : IBinInSubrouteRepository
    {
        public bool DatabaseDelete(object obj)
        {
            bir_BinsInSubRoutes bininSubroute = obj as bir_BinsInSubRoutes;
            using (var context = new UniContext())
            {
                try
                {
                    context.SubRoutes.Attach(bininSubroute.sur_SubRoutes);
                    context.Bins.Attach(bininSubroute.bin_Bins);

                    context.BinsInSubroutes.Attach(bininSubroute);
                    context.BinsInSubroutes.Remove(bininSubroute);

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
            bir_BinsInSubRoutes bininSubroute = obj as bir_BinsInSubRoutes;
            using (var context = new UniContext())
            {
                try
                {
                    context.BinsInSubroutes.Add(bininSubroute);
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
