using System;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;
using System.Data.SqlClient;
using TreeViewExample.Dal.DatabaseConnection;

namespace TreeViewExample.Dal.SQLServerRepository
{
    public class MSSQL_ParameterDefinitionRepository : IParameterDefinitionRepository
    {
        public bool CheckIfParamNameExists(ParameterDefinition ConfigurationParameter)
        {        
            if (DatabaseConnectionClass.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseConnectionClass.connect;

                    cmd.CommandText = "SELECT paf.paf_ParNm FROM paf_ParDefs paf WHERE paf.paf_ParNm = @Name";
                    cmd.Parameters.Add(new SqlParameter("Name", ConfigurationParameter.ParName));

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                }
                finally
                {
                    DatabaseConnectionClass.CloseConnection();
                }
                return true;
            }
            return false;
        }

        public bool InsertNewParameterDefinition(ParameterDefinition ConfigurationParameter)
        {
            throw new NotImplementedException();
        }
    }
}
