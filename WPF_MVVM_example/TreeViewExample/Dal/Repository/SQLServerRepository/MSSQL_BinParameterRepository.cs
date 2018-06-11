using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    public class MSSQL_BinParameterRepository : IBinParameterRepository
    {
        public bool DatabaseDelete(object obj)
        {
            bip_BinPars binparameter = obj as bip_BinPars;
            using (var context = new UniContext())
            {
                try
                {
                    context.BinParameters.Attach(binparameter);
                    context.BinParameters.Remove(binparameter);

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
            bip_BinPars binparameter = obj as bip_BinPars;
            using (var context = new UniContext())
            {
                try
                {
                    context.ParameterDefinitions.Attach(binparameter.ParameterDefinition);
                    context.Bins.Attach(binparameter.bin_Bins);

                    context.BinParameters.Add(binparameter);
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
            bip_BinPars binparameter = obj as bip_BinPars;
            using (var context = new UniContext())
            {
                try
                {
                    var entry = context.BinParameters.Find(binparameter.bip_BinId, binparameter.bip_ParNm);
                    context.Entry(entry).CurrentValues.SetValues(binparameter);

                    context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {

                }
            }
            return false;
        }
    }
}
