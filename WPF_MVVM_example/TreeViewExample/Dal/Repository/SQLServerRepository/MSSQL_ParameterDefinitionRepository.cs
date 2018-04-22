using System;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;
using System.Data.SqlClient;
using TreeViewExample.Dal.DatabaseConnection;
using System.Collections.Generic;

namespace TreeViewExample.Dal.SQLServerRepository
{
    public class MSSQL_ParameterDefinitionRepository : IParameterDefinitionRepository
    {
        public List<ParameterDefinition> GetAllParameterDefinitions()
        {
            List<ParameterDefinition> parameterDefinitionList = new List<ParameterDefinition>();

            if (DatabaseConnectionClass.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseConnectionClass.connect;

                    cmd.CommandText = "SELECT * FROM paf_ParDefs paf";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //required parameters
                        string parname = (reader["paf_ParNm"].ToString());
                        string description = (reader["paf_ParDesc"].ToString());
                        int beforeSep = (Convert.ToInt32(reader["paf_BeforeSep"]));
                        int afterSep = (Convert.ToInt32(reader["paf_AfterSep"]));
                        bool isEditable = (Convert.ToBoolean(reader["paf_Editable"]));
                        string displayToUser = ((reader["paf_DisplayToUser"]).ToString());
                        bool displayToUserBoolean = true;
                        if (displayToUser == "0")
                        {
                            displayToUserBoolean = false;
                        }
                        bool isStandard = (Convert.ToBoolean(reader["paf_IsStandardPar"]));

                        //not required parameters

                        //connections


                        ParameterDefinition paramdef = new ParameterDefinition(parname, description, beforeSep, afterSep, isEditable, displayToUserBoolean, isStandard);
                        parameterDefinitionList.Add(paramdef);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                }
                finally
                {
                    DatabaseConnectionClass.CloseConnection();
                }           
            }
            return parameterDefinitionList;
        }

        public bool InsertNewParameterDefinition(ParameterDefinition ConfigurationParameter)
        {
            if (DatabaseConnectionClass.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseConnectionClass.connect;

                    cmd.CommandText = "INSERT INTO paf_ParDefs (paf_ParNm, paf_ParDesc, paf_BeforeSep, paf_AfterSep, paf_Type, paf_alignm, paf_Editable, paf_DisplayToUser, paf_IsStandardPar)" +
                                                        " VALUES (@ParNm, @ParDesc, @BeforeSep, @AfterSep, @Type, @Alignm, @Editable, @DisplayToUser, @IsStandardPar)";

                    cmd.Parameters.Add(new SqlParameter("ParNm", ConfigurationParameter.ParName));
                    cmd.Parameters.Add(new SqlParameter("ParDesc", ConfigurationParameter.Description));
                    cmd.Parameters.Add(new SqlParameter("BeforeSep", ConfigurationParameter.BeforeSep));
                    cmd.Parameters.Add(new SqlParameter("AfterSep", ConfigurationParameter.AfterSep));
                    cmd.Parameters.Add(new SqlParameter("Type", ConfigurationParameter.Type));
                    cmd.Parameters.Add(new SqlParameter("Alignm", ConfigurationParameter.Alignm));
                    cmd.Parameters.Add(new SqlParameter("Editable", ConfigurationParameter.IsEditable));
                    string yesOrNo = "0";
                    if (ConfigurationParameter.DisplayToUser)
                    {
                        yesOrNo = "1";
                    }
                    cmd.Parameters.Add(new SqlParameter("DisplayToUser", yesOrNo));
                    cmd.Parameters.Add(new SqlParameter("IsStandardPar", ConfigurationParameter.IsStandardParameter));

                    cmd.ExecuteNonQuery();                 
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                    return false;
                }
                finally
                {
                    DatabaseConnectionClass.CloseConnection();
                }
            }
            return true;
        }
    }
}
