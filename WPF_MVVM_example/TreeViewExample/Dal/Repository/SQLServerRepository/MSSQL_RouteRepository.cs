using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
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
                    if (route.pru_Procedures != null)
                    {
                        context.Procedures.Remove(route.pru_Procedures);
                    }
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
            using (var context = new UniContext())
            {
                try
                {
                    route.ProcesCell = null;
                    context.Routes.Add(route);
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

        public bool DatabaseUpdate(object obj)
        {
            Route route = obj as Route;

            throw new NotImplementedException();
        }

        public List<ParameterDefinition> GetAllParametersProcescell(Route route)
        {
            List<ParameterDefinition> paramdefs = new List<ParameterDefinition>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ParameterDefinitions
                                  join x in context.tpm_TableParMaps on r.paf_ParNm equals x.tpm_ParNm
                                  join p in context.pat_ParTables on x.tpm_TableId equals p.pat_TableId
                                  join a in context.pac_ParDefsProcCellTypes on r.paf_ParNm equals a.pac_ParNm
                                  join t in context.pct_ProcCellTypes on a.pac_ProcCellTypeId equals t.pct_ProcCellTypeId
                                  where t.pct_ProcCellTypeId == route.ProcesCell.ProcesCellTypeId                                
                                  && p.pat_TableId == "rop_RoutePars"
                                  && r.paf_IsStandardPar == true
                                  select r);
                    paramdefs = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return paramdefs;
        }
    }
}
