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

                    cmd.CommandText = "INSERT INTO paf_ParDefs (paf_ParNm, paf_ParDesc, paf_ParValueUOM, paf_BeforeSep, paf_AfterSep, paf_ValidValues, paf_DefValue, paf_Type, paf_Alignm, paf_Editable, " +
                                                               "paf_DisplaySeqNr, paf_DisplayWidth, paf_ParUOM_TextId, paf_DisplayToUser, paf_IsRequired, paf_Column, paf_IsStandardPar)" +
                                                               " VALUES (@ParNm, @ParDesc, @ParValueUOM, @BeforeSep, @AfterSep, @ValidValues, @DefValue, @Type, @Alignm, @Editable, " +
                                                               " @DisplaySeqNr, @DisplayWidth, @ParUOM_TextID, @DisplayToUser, @IsStandardPar)";
                     
                    cmd.Parameters.Add(new SqlParameter("ParNm", ConfigurationParameter.ParName));
                    cmd.Parameters.Add(new SqlParameter("ParDesc", ConfigurationParameter.Description));

                    cmd.Parameters.Add(new SqlParameter("ParValueUOM", ConfigurationParameter.ParValueUOM));

                    cmd.Parameters.Add(new SqlParameter("BeforeSep", ConfigurationParameter.BeforeSep));
                    cmd.Parameters.Add(new SqlParameter("AfterSep", ConfigurationParameter.AfterSep));

                    cmd.Parameters.Add(new SqlParameter("ValidValues", ConfigurationParameter.ValidValues)); 
                    cmd.Parameters.Add(new SqlParameter("DefValue", ConfigurationParameter.DefaultValue)); 

                    cmd.Parameters.Add(new SqlParameter("Type", ConfigurationParameter.Type));
                    cmd.Parameters.Add(new SqlParameter("Alignm", ConfigurationParameter.Alignm));
                    cmd.Parameters.Add(new SqlParameter("Editable", ConfigurationParameter.IsEditable));

                    cmd.Parameters.Add(new SqlParameter("DisplaySeqNr", ConfigurationParameter.DisplaySeqNr)); 
                    cmd.Parameters.Add(new SqlParameter("DisplayWidth", ConfigurationParameter.DisplayWidth));
                    cmd.Parameters.Add(new SqlParameter("ParUOM_TextID", ConfigurationParameter.ParUOM_TextId));  

                    string yesOrNo = "0";
                    if (ConfigurationParameter.DisplayToUser)
                    {
                        yesOrNo = "1";
                    }
                    cmd.Parameters.Add(new SqlParameter("DisplayToUser", yesOrNo));

                    //cmd.Parameters.Add(new SqlParameter("IsRequired",)); 
                    //cmd.Parameters.Add(new SqlParameter("Column",)); 

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

        public bool InsertIntoTpm(ParameterDefinition ConfigurationParameter, string tableId)
        {
            if (DatabaseConnectionClass.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseConnectionClass.connect;

                    cmd.CommandText = "INSERT INTO tpm_TableParMaps (tpm_ParNm, tpm_tableId, tpm_MappingIsEnabled)" +
                                                        " VALUES (@ParNm, @TableId, @MappingIsEnabled)";

                    cmd.Parameters.Add(new SqlParameter("ParNm", ConfigurationParameter.ParName));
                    cmd.Parameters.Add(new SqlParameter("TableId", tableId));
                    cmd.Parameters.Add(new SqlParameter("MappingIsEnabled", true));

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
