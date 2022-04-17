using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminDetailsDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class AdminDetailsDAL : DatabaseConfig
    {
        #region Constructor
        public AdminDetailsDAL()
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

        #region Update Operation

        #region Update Operaion
        public Boolean Update(AdminDetailsENT entAdminDetails)
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
                        objCmd.CommandText = "PR_AdminDetails_UpdateByPK";

                        objCmd.Parameters.Add("AdminID", SqlDbType.Int).Value = entAdminDetails.AdminID;
                        objCmd.Parameters.Add("Username", SqlDbType.VarChar).Value = entAdminDetails.Username;
                        objCmd.Parameters.Add("Password", SqlDbType.VarChar).Value = entAdminDetails.Password;
                        objCmd.Parameters.Add("DisplayName", SqlDbType.VarChar).Value = entAdminDetails.DisplayName;
                        objCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = entAdminDetails.Email;
                        objCmd.Parameters.Add("PhoneNo", SqlDbType.VarChar).Value = entAdminDetails.PhoneNo;
                        objCmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = entAdminDetails.Gender;
                        objCmd.Parameters.Add("BirthDate", SqlDbType.VarChar).Value = entAdminDetails.BirthDate;
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

        #region Update PhotoPath
        public Boolean UpdatePhotoPath(AdminDetailsENT entAdminDetails)
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
                        objCmd.CommandText = "PR_AdminDetails_UpdatePhotoPathByPK";

                        objCmd.Parameters.Add("AdminID", SqlDbType.Int).Value = entAdminDetails.AdminID;
                        objCmd.Parameters.Add("PhotoPath", SqlDbType.VarChar).Value = entAdminDetails.PhotoPath;
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

        #endregion

        #region Select Operation

        #region SelectByPK
        public AdminDetailsENT SelectByPK(SqlInt32 AdminID)
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
                        objCmd.CommandText = "PR_AdminDetails_SelectByPK";

                        objCmd.Parameters.Add("AdminID", SqlDbType.Int).Value = AdminID;
                        #endregion

                        #region ReadData and Set Controls
                        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["AdminID"].Equals(DBNull.Value))
                                        entAdminDetails.AdminID = Convert.ToInt32(objSDR["AdminID"]);

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entAdminDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["Username"].Equals(DBNull.Value))
                                        entAdminDetails.Username = objSDR["Username"].ToString();

                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                        entAdminDetails.Password = objSDR["Password"].ToString();

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entAdminDetails.Email = objSDR["Email"].ToString();

                                    if (!objSDR["Phoneno"].Equals(DBNull.Value))
                                        entAdminDetails.PhoneNo = objSDR["Phoneno"].ToString();

                                    if (!objSDR["Gender"].Equals(DBNull.Value))
                                        entAdminDetails.Gender = objSDR["Gender"].ToString();

                                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                        entAdminDetails.BirthDate = objSDR["BirthDate"].ToString();

                                    if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                        entAdminDetails.PhotoPath = objSDR["PhotoPath"].ToString();
                                }
                            }
                        }
                        return entAdminDetails;
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

        #region SelectForUsernamePassword
        public AdminDetailsENT SelectForUsernamePassword(SqlString Username, SqlString Password)
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
                        objCmd.CommandText = "PR_AdminDetails_SelectByUsernamePassword";

                        objCmd.Parameters.Add("Username", SqlDbType.VarChar).Value = Username;
                        objCmd.Parameters.Add("Password", SqlDbType.VarChar).Value = Password;
                        #endregion

                        #region ReadData and Set Controls
                        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if(objSDR.HasRows)
                            {
                                while(objSDR.Read())
                                {
                                    if (!objSDR["AdminID"].Equals(DBNull.Value))
                                        entAdminDetails.AdminID = Convert.ToInt32(objSDR["AdminID"]);

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entAdminDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                        entAdminDetails.PhotoPath = objSDR["PhotoPath"].ToString();
                                }
                            }
                            else
                            {
                                Message = "Username Or Password Doesn't Match";
                            }
                        }
                        return entAdminDetails;
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

        #region SelectByEmail
        public AdminDetailsENT SelectByEmail(SqlString Email)
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
                        objCmd.CommandText = "PR_AdminDetails_SelectByEmail";

                        objCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = Email;
                        #endregion

                        #region ReadData and Set Controls
                        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["AdminID"].Equals(DBNull.Value))
                                        entAdminDetails.AdminID = Convert.ToInt32(objSDR["AdminID"]);

                                    if (!objSDR["Username"].Equals(DBNull.Value))
                                        entAdminDetails.Username = objSDR["Username"].ToString();

                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                        entAdminDetails.Password = objSDR["Password"].ToString();

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entAdminDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entAdminDetails.Email = objSDR["Email"].ToString();
                                }
                            }
                            else
                            {
                                Message = "Email Doesn't Match, Enter Correct Email";
                            }
                        }
                        return entAdminDetails;
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
                        objCmd.CommandText = "PR_AdminDetails_SelectAll";
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

        #endregion
    }
}