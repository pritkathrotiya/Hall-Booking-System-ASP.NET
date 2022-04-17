using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AreaDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class AreaDAL : DatabaseConfig
    {
        #region Constructor
        public AreaDAL()
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
        public Boolean Insert(AreaENT entArea)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Commmand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Area_Insert";

                        objCmd.Parameters.Add("AreaID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("AreaName", SqlDbType.VarChar).Value = entArea.AreaName;
                        objCmd.Parameters.Add("AreaAddress", SqlDbType.VarChar).Value = entArea.AreaAddress;
                        objCmd.Parameters.Add("AreaPincode", SqlDbType.Int).Value = entArea.AreaPincode;
                        objCmd.Parameters.Add("CityID", SqlDbType.Int).Value = entArea.CityID;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["AreaID"].Value != null)
                            entArea.AreaID = Convert.ToInt32(objCmd.Parameters["AreaID"].Value);

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
        public Boolean Update(AreaENT entArea)
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
                        objCmd.CommandText = "PR_Area_UpdateByPK";

                        objCmd.Parameters.Add("AreaID", SqlDbType.Int).Value = entArea.AreaID;
                        objCmd.Parameters.Add("AreaName", SqlDbType.VarChar).Value = entArea.AreaName;
                        objCmd.Parameters.Add("AreaAddress", SqlDbType.VarChar).Value = entArea.AreaAddress;
                        objCmd.Parameters.Add("AreaPincode", SqlDbType.Int).Value = entArea.AreaPincode;
                        objCmd.Parameters.Add("CityID", SqlDbType.Int).Value = entArea.CityID;
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
        public Boolean Delete(SqlInt32 AreaID)
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
                        objCmd.CommandText = "PR_Area_DeleteByPK";

                        objCmd.Parameters.Add("AreaID", SqlDbType.Int).Value = AreaID;
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
                        objCmd.CommandText = "PR_Area_SelectAll";
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
        public AreaENT SelectByPK(SqlInt32 AreaID)
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
                        objCmd.CommandText = "PR_Area_SelectByPK";

                        objCmd.Parameters.Add("AreaID", SqlDbType.Int).Value = AreaID;
                        #endregion

                        #region ReadDate and Set Controls
                        AreaENT entArea = new AreaENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["AreaID"].Equals(DBNull.Value))
                                        entArea.AreaID = Convert.ToInt32(objSDR["AreaID"].ToString().Trim());

                                    if (!objSDR["AreaName"].Equals(DBNull.Value))
                                        entArea.AreaName = objSDR["AreaName"].ToString().Trim();

                                    if (!objSDR["AreaAddress"].Equals(DBNull.Value))
                                        entArea.AreaAddress = objSDR["AreaAddress"].ToString().Trim();

                                    if (!objSDR["AreaPincode"].Equals(DBNull.Value))
                                        entArea.AreaPincode = Convert.ToInt32(objSDR["AreaPincode"].ToString().Trim());

                                    if (!objSDR["CityID"].Equals(DBNull.Value))
                                        entArea.CityID = Convert.ToInt32(objSDR["CityID"].ToString().Trim());
                                }
                            }
                        }
                        return entArea;
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

        #region SelectForDropDownListByCityID
        public DataTable SelectForDropDownListByCityID(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_Area_SelectForDropDownListByCityID";

                        objCmd.Parameters.Add("CityID", SqlDbType.Int).Value = CityID;
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