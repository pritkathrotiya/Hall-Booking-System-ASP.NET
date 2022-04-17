using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetailsDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class UserDetailsDAL : DatabaseConfig
    {
        #region Constructor
        public UserDetailsDAL()
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
        public Boolean Insert(UserDetailsENT entUserDetails)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using(SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Commmand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_UserDetails_Insert";

                        objCmd.Parameters.Add("Username", SqlDbType.VarChar).Value = entUserDetails.Username;
                        objCmd.Parameters.Add("Password", SqlDbType.VarChar).Value = entUserDetails.Password;
                        objCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = entUserDetails.Email;
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

        #region Update Operation

        #region Update Operaion
        public Boolean Update(UserDetailsENT entUserDetails)
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
                        objCmd.CommandText = "PR_UserDetails_UpdateByPK";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = entUserDetails.UserID;
                        objCmd.Parameters.Add("Username", SqlDbType.VarChar).Value = entUserDetails.Username;
                        objCmd.Parameters.Add("Password", SqlDbType.VarChar).Value = entUserDetails.Password;
                        objCmd.Parameters.Add("DisplayName", SqlDbType.VarChar).Value = entUserDetails.DisplayName;
                        objCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = entUserDetails.Email;
                        objCmd.Parameters.Add("PhoneNo", SqlDbType.VarChar).Value = entUserDetails.PhoneNo;
                        objCmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = entUserDetails.Gender;
                        objCmd.Parameters.Add("BirthDate", SqlDbType.VarChar).Value = entUserDetails.BirthDate;
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
        public Boolean UpdatePhotoPath(UserDetailsENT entUserDetails)
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
                        objCmd.CommandText = "PR_UserDetails_UpdatePhotoPathByPK";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = entUserDetails.UserID;
                        objCmd.Parameters.Add("PhotoPath", SqlDbType.VarChar).Value = entUserDetails.PhotoPath;
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

        #region Delete Operation
        public Boolean Delete(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_UserDetails_DeleteByPK";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = UserID;
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

        #region SelectByPK
        public UserDetailsENT SelectByPK(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_UserDetails_SelectByPK";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = UserID;
                        #endregion

                        #region ReadData and Set Controls
                        UserDetailsENT entUserDetails = new UserDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                        entUserDetails.UserID = Convert.ToInt32(objSDR["UserID"]);

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entUserDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["Username"].Equals(DBNull.Value))
                                        entUserDetails.Username = objSDR["Username"].ToString();

                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                        entUserDetails.Password = objSDR["Password"].ToString();

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entUserDetails.Email = objSDR["Email"].ToString();

                                    if (!objSDR["Phoneno"].Equals(DBNull.Value))
                                        entUserDetails.PhoneNo = objSDR["Phoneno"].ToString();

                                    if (!objSDR["Gender"].Equals(DBNull.Value))
                                        entUserDetails.Gender = objSDR["Gender"].ToString();

                                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                        entUserDetails.BirthDate = objSDR["BirthDate"].ToString();

                                    if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                        entUserDetails.PhotoPath = objSDR["PhotoPath"].ToString();
                                }
                            }
                        }
                        return entUserDetails;
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
        public UserDetailsENT SelectForUsernamePassword(SqlString Username, SqlString Password)
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
                        objCmd.CommandText = "PR_UserDetails_SelectByUsernamePassword";

                        objCmd.Parameters.Add("Username", SqlDbType.VarChar).Value = Username;
                        objCmd.Parameters.Add("Password", SqlDbType.VarChar).Value = Password;
                        #endregion

                        #region ReadData and Set Controls
                        UserDetailsENT entUserDetails = new UserDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                        entUserDetails.UserID = Convert.ToInt32(objSDR["UserID"]);

                                    if (!objSDR["Username"].Equals(DBNull.Value))
                                        entUserDetails.Username = objSDR["Username"].ToString();

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entUserDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                        entUserDetails.PhotoPath = objSDR["PhotoPath"].ToString();
                                }
                            }
                            else
                            {
                                Message = "Username Or Password Doesn't Match";
                            }
                        }
                        return entUserDetails;
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

        #region SelectByEmail
        public UserDetailsENT SelectByEmail(SqlString Email)
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
                        objCmd.CommandText = "PR_UserDetails_SelectByEmail";

                        objCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = Email;
                        #endregion

                        #region ReadData and Set Controls
                        UserDetailsENT entUserDetails = new UserDetailsENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                        entUserDetails.UserID = Convert.ToInt32(objSDR["UserID"]);

                                    if (!objSDR["Username"].Equals(DBNull.Value))
                                        entUserDetails.Username = objSDR["Username"].ToString();

                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                        entUserDetails.Password = objSDR["Password"].ToString();

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entUserDetails.DisplayName = objSDR["DisplayName"].ToString();

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entUserDetails.Email = objSDR["Email"].ToString();
                                }
                            }
                            else
                            {
                                Message = "Email Doesn't Match, Enter Correct Email";
                            }
                        }
                        return entUserDetails;
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
                        objCmd.CommandText = "PR_UserDetails_SelectAll";
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