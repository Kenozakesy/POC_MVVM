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
    public class MSSQL_ProcesCellRepository : IProcesCellRepository
    {
        public List<ProcessCel> GetAllParameterDefinitions()
        {
            List<ProcessCel> parameterDefinitionList = new List<ProcessCel>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ProcesCells orderby r.ProcesCellName select r);
                    parameterDefinitionList = select.ToList();
                }
                catch (Exception)
                {
                    context.Dispose();
                }
            }
            return parameterDefinitionList;
        }
    }
}
