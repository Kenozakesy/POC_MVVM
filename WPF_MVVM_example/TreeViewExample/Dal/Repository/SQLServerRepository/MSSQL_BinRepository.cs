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
                    e.ToString();
                    return false;
                }
            }
        }

        public bool DatabaseInsert(object obj)
        {
            Bin bin = obj as Bin;
            using (var context = new UniContext())
            {
                try
                {
                    context.Bins.Add(bin);
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
                    e.ToString();
                    return false;
                }
            }
        }

        public List<string> GetAllParameterDefinitionNames()
        {
            List<string> paramdefs = new List<string>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ParameterDefinitions
                                  join x in context.tpm_TableParMaps on r.paf_ParNm equals x.tpm_ParNm
                                  join p in context.pat_ParTables on x.tpm_TableId equals p.pat_TableId
                                  where p.pat_TableId == "bip_BinPars"
                                  && r.paf_IsStandardPar == true
                                  select r.paf_ParNm);
                    paramdefs = select.ToList();
                }
                catch (Exception)
                {

                }
            }
            return paramdefs;
        }
    }
}
