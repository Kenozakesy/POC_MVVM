using System;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.Interfaces;
using System.Data.SqlClient;
using TreeViewExample.Dal.DatabaseConnection;
using System.Collections.Generic;
using System.Data;
using TreeViewExample.Business.Enums;

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
                        string parValueUOM = (reader["paf_ParValueUOM"] != DBNull.Value) ? Convert.ToString(reader["paf_ParValueUOM"]) : null;                          
                        int beforeSep = (Convert.ToInt32(reader["paf_BeforeSep"]));
                        int afterSep = (Convert.ToInt32(reader["paf_AfterSep"]));
                        string validValues = (reader["paf_ValidValues"] != DBNull.Value) ? Convert.ToString(reader["paf_ValidValues"]) : null;
                        string defValue = (reader["paf_DefValue"] != DBNull.Value) ? Convert.ToString(reader["paf_DefValue"]) : null;
                        int type = (reader["paf_Type"] != DBNull.Value) ? Convert.ToInt32(reader["paf_Type"]) : 0;
                        int alignm = (reader["paf_Alignm"] != DBNull.Value) ? Convert.ToInt32(reader["paf_Alignm"]) : 0;
                        int displaySeqNr = (reader["paf_DisplaySeqNr"] != DBNull.Value) ? Convert.ToInt32(reader["paf_DisplaySeqNr"]) : 0;
                        bool isEditable = (Convert.ToBoolean(reader["paf_Editable"]));
                        string displayToUser = ((reader["paf_DisplayToUser"]).ToString());
                        int displayWidth = (reader["paf_DisplayWidth"] != DBNull.Value) ? Convert.ToInt32(reader["paf_DisplayWidth"]) : 0;
                        string parUOM_TextId = (reader["paf_ParUOM_TextId"] != DBNull.Value) ? Convert.ToString(reader["paf_ParUOM_TextId"]) : null;
                        bool displayToUserBoolean = true;
                        if (displayToUser == "0")
                        {
                            displayToUserBoolean = false;
                        }
                        string column = (reader["paf_column"] != DBNull.Value) ? Convert.ToString(reader["paf_column"]) : null;
                        bool isStandard = (Convert.ToBoolean(reader["paf_IsStandardPar"]));

                        //connections
                        //connections

                        ParameterDefinition paramdef = new ParameterDefinition(parname, description, parValueUOM, beforeSep, afterSep, validValues, defValue, (ParameterType)type, (Alignment)alignm,
                                                                                displaySeqNr, isEditable, displayToUserBoolean, displayWidth, parUOM_TextId, column, isStandard);
                        parameterDefinitionList.Add(paramdef);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                    throw;
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
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO paf_ParDefs (paf_ParNm, paf_ParDesc, paf_ParValueUOM, paf_BeforeSep, paf_AfterSep, paf_ValidValues, paf_DefValue, paf_Type, paf_Alignm, paf_Editable, " +
                                                               "paf_DisplaySeqNr, paf_DisplayWidth, paf_ParUOM_TextId, paf_DisplayToUser, paf_IsRequired, paf_Column, paf_IsStandardPar)" +
                                                               " VALUES (@ParNm, @ParDesc, @ParValueUOM, @BeforeSep, @AfterSep, @ValidValues, @DefValue, @Type, @Alignm, @Editable, " +
                                                               " @DisplaySeqNr, @DisplayWidth, @ParUOM_TextID, @DisplayToUser, @IsRequired, @Column, @IsStandardPar)";
                     
                    cmd.Parameters.Add(new SqlParameter("ParNm", ConfigurationParameter.ParName));
                    cmd.Parameters.Add(new SqlParameter("ParDesc", ConfigurationParameter.Description));  
                                        
                    cmd.Parameters.AddWithValue("ParValueUOM", ConfigurationParameter.ParValueUOM == null ? (object)DBNull.Value : ConfigurationParameter.ParValueUOM);

                    cmd.Parameters.Add(new SqlParameter("BeforeSep", ConfigurationParameter.BeforeSep));
                    cmd.Parameters.Add(new SqlParameter("AfterSep", ConfigurationParameter.AfterSep));

                    cmd.Parameters.AddWithValue("ValidValues", ConfigurationParameter.ValidValues == null ? (object)DBNull.Value : ConfigurationParameter.ValidValues);
                    cmd.Parameters.AddWithValue("DefValue", ConfigurationParameter.DefaultValue == null ? (object)DBNull.Value : ConfigurationParameter.DefaultValue);

                    cmd.Parameters.Add(new SqlParameter("Type", ConfigurationParameter.Type));
                    cmd.Parameters.Add(new SqlParameter("Alignm", ConfigurationParameter.Alignm));
                    cmd.Parameters.Add(new SqlParameter("Editable", ConfigurationParameter.IsEditable));

                    cmd.Parameters.AddWithValue("DisplaySeqNr", ConfigurationParameter.DisplaySeqNr == null ? (object)DBNull.Value : ConfigurationParameter.DisplaySeqNr);
                    cmd.Parameters.AddWithValue("DisplayWidth", ConfigurationParameter.DisplayWidth == null ? (object)DBNull.Value : ConfigurationParameter.DisplayWidth);
                    cmd.Parameters.AddWithValue("ParUOM_TextID", ConfigurationParameter.ParUOM_TextId == null ? (object)DBNull.Value : ConfigurationParameter.ParUOM_TextId);

                    string yesOrNo = "0";
                    if (ConfigurationParameter.DisplayToUser)
                    {
                        yesOrNo = "1";
                    }
                    cmd.Parameters.Add(new SqlParameter("DisplayToUser", yesOrNo));
                    cmd.Parameters.Add(new SqlParameter("IsRequired", DBNull.Value)); 
                    cmd.Parameters.AddWithValue("Column", ConfigurationParameter.Column == null ? (object)DBNull.Value : ConfigurationParameter.Column);
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
