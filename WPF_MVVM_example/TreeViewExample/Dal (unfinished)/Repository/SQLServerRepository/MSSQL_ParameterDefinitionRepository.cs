using System;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;
using System.Data.SqlClient;
using TreeViewExample.Dal.DatabaseConnection;
using System.Collections.Generic;
using System.Data;
using TreeViewExample.Dal.EntityFramework;
using System.Linq;
using TreeViewExample.Business.Singletons;

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
                    var parId = ListGodClass.Instance.ParameterDefinitionList.Select(x => x.paf_ParNm).ToArray();

                    var select = (from r in context.ParameterDefinitions
                                  .Where(x => !parId.Contains(x.paf_ParNm))
                                  select r);

                    parameterDefinitionList = select.ToList();
                }
                catch (Exception)
                {
                }
            }
            return parameterDefinitionList;
        }

    }
}
