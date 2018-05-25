using System;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;
using System.Data.SqlClient;
using TreeViewExample.Dal.DatabaseConnection;
using System.Collections.Generic;
using System.Data;
using TreeViewExample.Dal.EntityFramework;
using System.Linq;

namespace TreeViewExample.Dal.SQLServerRepository
{
    public class MSSQL_ParameterDefinitionRepository : IParameterDefinitionRepository
    {
        public bool DatabaseDelete(object obj)
        {
            throw new NotImplementedException();
        }

        public bool DatabaseInsert(object obj)
        {
            throw new NotImplementedException();
        }

        public bool DatabaseUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        public List<ParameterDefinition> GetAllParameterDefinitions()
        {
            List<ParameterDefinition> parameterDefinitionList = new List<ParameterDefinition>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ParameterDefinitions orderby r.paf_ParNm select r);
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
