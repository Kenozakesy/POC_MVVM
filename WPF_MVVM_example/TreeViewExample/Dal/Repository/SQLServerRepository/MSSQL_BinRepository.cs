using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;
using System.Data.Entity;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_BinRepository : IBinRepository
    {
        public bool DatabaseDelete(object obj)
        {
            Bin bin = obj as Bin;
            using (var context = new UniContext())
            {
                try
                {                   
                    context.Bins.Attach(bin);
                    context.Bins.Remove(bin);

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
            throw new NotImplementedException();
        }

        public bool DatabaseUpdate(object obj)
        {
            Bin bin = obj as Bin;

            using (var context = new UniContext())
            {
                try
                {
                    var update = context.Bins.Find(bin.bin_BinId);
                    context.Entry(update).CurrentValues.SetValues(bin);

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

        public List<ParameterDefinition> GetAddAbleStandardParameters()
        {
            List<ParameterDefinition> paramdefs = new List<ParameterDefinition>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ParameterDefinitions
                                  join x in context.tpm_TableParMaps on r.paf_ParNm equals x.tpm_ParNm
                                  join p in context.pat_ParTables on x.tpm_TableId equals p.pat_TableId
                                  where p.pat_TableId == "bip_BinPars"
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

        public List<Bin> GetAllBins()
        {
            List<Bin> bins = new List<Bin>();
            using (var context = new UniContext())
            {
                try
                {
                    var binIds = ListGodClass.Instance.BinList.Select(x => x.bin_BinId).ToArray();

                    var select = (from r in context.Bins
                                  .Where(x => !binIds.Contains(x.bin_BinId))
                                  .Include(x => x.bir_BinsInSubRoutes)

                                  .Include(x => x.bip_BinPars)
                                  .Include(x => x.bip_BinPars.Select(y => y.bin_Bins))

                                  //.Include(x => x.bip_BinPars.Select(y => y.ParameterDefinition))
                                  //.Include(x => x.bip_BinPars.Select(y => y.ParameterDefinition.BinParametersList))

                                  .Include(x => x.bis_BinStocks)
                                  .Include(x => x.bis_BinStocks.bin_Bins)
                                  .Include(x => x.bip_BinPars)
                                  .Include(x => x.bip_BinPars.Select(z => z.bin_Bins))
                                  .Include(x => x.bib_BinBatches)
                                  .Include(x => x.bib_BinBatches.Select(z => z.bin_Bins))
                                  .Include(x => x.tbb_TempBinBatches)
                                  .Include(x => x.tbb_TempBinBatches.Select(z => z.bin_Bins))
                                  .Include(x => x.pri_PropIns)
                                  .Include(x => x.pri_PropIns.Select(z => z.bin_Bins))

                                  select r);

                    bins = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return bins;
        }

    
    }
}
