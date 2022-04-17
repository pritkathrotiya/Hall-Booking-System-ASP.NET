using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManagerDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class ManagerDAL : DatabaseConfig
    {
        #region Constructor
        public ManagerDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Local Variables
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region Insert Operation
        public Boolean Insert(ManagerENT entManager)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_Insert";

                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("ManagerName", SqlDbType.VarChar).Value = entManager.ManagerName;
                        objCmd.Parameters.Add("ManagerEmail", SqlDbType.VarChar).Value = entManager.ManagerEmail;
                        objCmd.Parameters.Add("ManagerPhoneNo", SqlDbType.VarChar).Value = entManager.ManagerPhoneNo;
                        objCmd.Parameters.Add("ManagerGender", SqlDbType.VarChar).Value = entManager.ManagerGender;
                        objCmd.Parameters.Add("ManagerSalary", SqlDbType.Int).Value = entManager.ManagerSalary;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["ManagerID"].Value != null)
                            entManager.ManagerID = Convert.ToInt32(objCmd.Parameters["ManagerID"].Value);

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(ManagerENT entManager)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_UpdateByPK";

                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Value = entManager.ManagerID;
                        objCmd.Parameters.Add("ManagerName", SqlDbType.VarChar).Value = entManager.ManagerName;
                        objCmd.Parameters.Add("ManagerEmail", SqlDbType.VarChar).Value = entManager.ManagerEmail;
                        objCmd.Parameters.Add("ManagerPhoneNo", SqlDbType.VarChar).Value = entManager.ManagerPhoneNo;
                        objCmd.Parameters.Add("ManagerGender", SqlDbType.VarChar).Value = entManager.ManagerGender;
                        objCmd.Parameters.Add("ManagerSalary", SqlDbType.Int).Value = entManager.ManagerSalary;
                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 ManagerID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_DeleteByPK";

                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Value = ManagerID;
                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_SelectAll";
                        #endregion

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region SelectByPK
        public ManagerENT SelectByPK(SqlInt32 ManagerID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_SelectByPK";

                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Value = ManagerID;
                        #endregion

                        #region ReadData and Set Controls
                        ManagerENT entManager = new ManagerENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["ManagerID"].Equals(DBNull.Value))
                                        entManager.ManagerID = Convert.ToInt32(objSDR["ManagerID"].ToString().Trim());

                                    if (!objSDR["ManagerName"].Equals(DBNull.Value))
                                        entManager.ManagerName = objSDR["ManagerName"].ToString().Trim();

                                    if (!objSDR["ManagerEmail"].Equals(DBNull.Value))
                                        entManager.ManagerEmail = objSDR["ManagerEmail"].ToString().Trim();

                                    if (!objSDR["ManagerPhoneNo"].Equals(DBNull.Value))
                                        entManager.ManagerPhoneNo = objSDR["ManagerPhoneNo"].ToString().Trim();

                                    if (!objSDR["ManagerGender"].Equals(DBNull.Value))
                                        entManager.ManagerGender = objSDR["ManagerGender"].ToString().Trim();

                                    if (!objSDR["ManagerSalary"].Equals(DBNull.Value))
                                        entManager.ManagerSalary = Convert.ToInt32(objSDR["ManagerSalary"].ToString().Trim());
                                }
                            }
                        }
                        return entManager;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Manager_SelectForDropDownList";
                        #endregion

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion
                    }
                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #endregion
    }
}
