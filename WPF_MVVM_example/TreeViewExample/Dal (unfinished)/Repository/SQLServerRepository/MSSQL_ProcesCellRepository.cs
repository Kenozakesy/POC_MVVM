﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TreeViewExample.Business.Models.DiagramModels;
using System.Windows.Media;
using TreeViewExample.Business.Models.DiagramModels.Parameters;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_ProcesCellRepository : IProcesCellRepository
    {
        public bool DatabaseDelete(object obj)
        {
            ProcessCel cell = obj as ProcessCel;
            using (var context = new UniContext())
            {
                try
                {
                    context.ProcesCells.Attach(cell);
                    foreach (Route R in cell.RouteList)
                    {
                        if (R.pru_Procedures != null)
                        {
                            context.Procedures.Attach(R.pru_Procedures);
                            context.Procedures.Remove(R.pru_Procedures);
                        }
                    }

                    context.ProcesCells.Remove(cell);
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
            ProcessCel cell = obj as ProcessCel;
            using (var context = new UniContext())
            {
                try
                {

                    foreach (pca_ProcCellPars pca in cell.pca_ProcCellPars)
                    {
                        context.ParameterDefinitions.Attach(pca.ParameterDefinition);
                    }

                    context.ProcesCells.Add(cell);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    context.Dispose();
                    
                    e.ToString();
                    return false;
                }
            }
            
        }

        public bool DatabaseUpdate(object obj)
        {
            ProcessCel cell = obj as ProcessCel;
            using (var context = new UniContext())
            {
                try
                {
                    context.ProcesCells.Attach(cell);

                    var procescell = context.ProcesCells.Find(cell.ProcesCellId);
                    context.Entry(procescell).CurrentValues.SetValues(cell);

                    context.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    context.Dispose();
                    e.ToString();
                    return false;
                }
            }
        }

        public List<ProcessCel> GetAllProcesCells()
        {
            List<ProcessCel> procescells = new List<ProcessCel>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ProcesCells
                                  .Include(x => x.pca_ProcCellPars)
                                  .Include(x => x.pca_ProcCellPars.Select(z => z.prc_ProcCells))
                                  .Include(x => x.pca_ProcCellPars.Select(z => z.ParameterDefinition))
                                  .Include(x => x.pca_ProcCellPars.Select(z => z.ParameterDefinition.ProcesCellParametersList))

                                  .Include(x => x.opc_OAProcCellDefs)
                                  .Include(x => x.opc_OAProcCellDefs.Select(z => z.prc_ProcCells))

                                  .Include(x => x.RouteList)
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars))
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars.Select(y => y.rot_Routes)))
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars.Select(y => y.ParameterDefinition)))
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars.Select(y => y.ParameterDefinition.RouteParametersList)))

                                  .Include(x => x.RouteList.Select(z => z.pru_Procedures))
                                  .Include(x => x.RouteList.Select(z => z.pru_Procedures.rot_Routes))

                                  .Include(x => x.RouteList.Select(z => z.pru_Procedures.oar_OARcps))
                                  .Include(x => x.RouteList.Select(z => z.pru_Procedures.oar_OARcps.Select(y => y.pru_Procedures)))

                                  .Include(x => x.RouteList.Select(y => y.SubrouteInRouteList))

                                  select r);
                    procescells = select.ToList();


                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return procescells;
        }

        public List<string> GetAllRequiredParameterDefinitionNames(ProcessCel cell)
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
                                  where t.pct_ProcCellTypeId == cell.ProcesCellTypeId
                                  && p.pat_TableId == "pca_ProcCellPars"
                                  && a.pac_IsRequired == true
                                  select r.paf_ParNm);
                    paramdefsnames = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return paramdefsnames;
        }

        public List<string> GetAllParameterDefinitionNames(ProcessCel cell)
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
                                  where t.pct_ProcCellTypeId == cell.ProcesCellTypeId
                                  && p.pat_TableId == "pca_ProcCellPars"
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
