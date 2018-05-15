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
                                  .Include(x => x.pca_ProcCellPars)
                                  .Include(x => x.pca_ProcCellPars.Select(z => z.prc_ProcCells))

                                  .Include(x => x.RouteList)
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars))
                                  .Include(x => x.RouteList.Select(z => z.rop_RoutePars.Select(y => y.rot_Routes)))

                                  .Include(x => x.RouteList.Select(y => y.SubrouteInRouteList))
                      
                                  .Include(x => x.SubrouteList)
                                  .Include(x => x.SubrouteList.Select(y => y.sri_SubRoutesInRoutes))

                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins)))

                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bip_BinPars)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bip_BinPars.Select(s => s.bin_Bins))))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bis_BinStocks)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bis_BinStocks.bin_Bins)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bib_BinBatches)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bib_BinBatches.Select(s => s.bin_Bins))))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.tbb_TempBinBatches)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.tbb_TempBinBatches.Select(s => s.bin_Bins))))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.pri_PropIns)))
                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.pri_PropIns.Select(s => s.bin_Bins))))

                                  .Include(x => x.SubrouteList.Select(y => y.bir_BinsInSubRoutes.Select(z => z.bin_Bins.bir_BinsInSubRoutes.Select(s => s.sur_SubRoutes))))
                                  .Include(x => x.SubrouteList.Select(y => y.uis_UnitsInSubRoutes))
                                  .Include(x => x.SubrouteList.Select(y => y.uis_UnitsInSubRoutes.Select(z => z.Unit)))
                                  .Include(x => x.SubrouteList.Select(y => y.uis_UnitsInSubRoutes.Select(z => z.Unit.uis_UnitsInSubRoutes.Select(s => s.sur_SubRoutes))))
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
