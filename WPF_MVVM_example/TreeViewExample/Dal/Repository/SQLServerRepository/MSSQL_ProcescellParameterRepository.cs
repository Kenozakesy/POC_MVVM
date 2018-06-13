using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.SQLServerRepository
{
    class MSSQL_ProcescellParameterRepository : IProcescellParameterRepository
    {
        public bool DatabaseDelete(object obj)
        {
            pca_ProcCellPars cellparameter = obj as pca_ProcCellPars;
            using (var context = new UniContext())
            {
                try
                {
                    context.ProcescellParameters.Attach(cellparameter);
                    context.ProcescellParameters.Remove(cellparameter);

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
            pca_ProcCellPars cellparameter = obj as pca_ProcCellPars;
            using (var context = new UniContext())
            {
                try
                {
                    context.ProcesCells.Attach(cellparameter.prc_ProcCells);
                    context.ParameterDefinitions.Attach(cellparameter.ParameterDefinition);
       

                    context.ProcescellParameters.Add(cellparameter);
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
            pca_ProcCellPars procescellParameter = obj as pca_ProcCellPars;
            using (var context = new UniContext())
            {
                try
                {
                    var entry = context.ProcescellParameters.Find(procescellParameter.pca_ProcCellId, procescellParameter.pca_ParNm);
                    context.Entry(entry).CurrentValues.SetValues(procescellParameter);

                    context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return false;
        }
    }
}
