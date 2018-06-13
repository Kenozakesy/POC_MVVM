using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
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
                    e.ToString();
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
                    context.ProcesCells.Attach(route.ProcesCell);
                    foreach (rop_RoutePars rop in route.rop_RoutePars)
                    {
                        context.ParameterDefinitions.Attach(rop.ParameterDefinition);
                    }

                    context.Routes.Add(route);
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
            Route route = obj as Route;

            throw new NotImplementedException();
        }

        public List<string> GetAllRequiredParameterDefinitionNames(Route route)
        {
            List<string> paramdefsnames = new List<string>();
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
                                  && a.pac_IsRequired == true
                                  select r.paf_ParNm);
                    paramdefsnames = select.ToList();
                }
                catch (Exception)
                {

                }
            }
            return paramdefsnames;
        }

        public List<string> GetAllParameterDefinitionNames(Route route)
        {
            List<string> paramdefsnames = new List<string>();
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
                                  select r.paf_ParNm);
                    paramdefsnames = select.ToList();
                }
                catch (Exception)
                {
                }
            }
            return paramdefsnames;
        }
    }
}
