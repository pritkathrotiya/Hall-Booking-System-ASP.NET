using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class OrderDAL : DatabaseConfig
    {
        #region Constructor
        public OrderDAL()
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
        public Boolean InsertByUserID(OrderENT entOrder)
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
                        objCmd.CommandText = "PR_Order_InsertByUserID";

                        objCmd.Parameters.Add("OrderID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("StartDate", SqlDbType.VarChar).Value = entOrder.StartDate;
                        objCmd.Parameters.Add("EndDate", SqlDbType.VarChar).Value = entOrder.EndDate;
                        objCmd.Parameters.Add("TotalDays", SqlDbType.Int).Value = entOrder.TotalDays;
                        objCmd.Parameters.Add("TotalAmount", SqlDbType.Int).Value = entOrder.TotalAmount;
                        objCmd.Parameters.Add("Status", SqlDbType.VarChar).Value = entOrder.Status;
                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = entOrder.HallID;
                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = entOrder.UserID;
                        objCmd.Parameters.Add("BookingDate", SqlDbType.VarChar).Value = entOrder.BookingDate;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["OrderID"].Value != null)
                            entOrder.OrderID = Convert.ToInt32(objCmd.Parameters["OrderID"].Value);

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
        public Boolean UpdateByUserID(OrderENT entOrder)
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
                        objCmd.CommandText = "PR_Order_UpdateByUserIDByPK";

                        objCmd.Parameters.Add("OrderID", SqlDbType.Int).Value = entOrder.OrderID;
                        objCmd.Parameters.Add("StartDate", SqlDbType.VarChar).Value = entOrder.StartDate;
                        objCmd.Parameters.Add("EndDate", SqlDbType.VarChar).Value = entOrder.EndDate;
                        objCmd.Parameters.Add("TotalDays", SqlDbType.Int).Value = entOrder.TotalDays;
                        objCmd.Parameters.Add("TotalAmount", SqlDbType.Int).Value = entOrder.TotalAmount;
                        objCmd.Parameters.Add("Status", SqlDbType.VarChar).Value = entOrder.Status;
                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = entOrder.HallID;
                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = entOrder.UserID;
                        objCmd.Parameters.Add("BookingDate", SqlDbType.VarChar).Value = entOrder.BookingDate;
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

        #region DeleteByUserIDByPK
        public Boolean DeleteByUserID(SqlInt32 OrderID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Order_DeleteByUserIDByPK";

                        objCmd.Parameters.Add("OrderID", SqlDbType.Int).Value = OrderID;
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

        #region DeleteByUserID 
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
                        objCmd.CommandText = "PR_Order_DeleteByUserID";

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

        #endregion

        #region Select Operation

        #region SelectAllByUserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Order_SelectAllByUSerID";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = UserID;
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

        #region SelectStartEndDatesByHallID
        public DataTable SelectStartEndDatesByHallID(SqlInt32 HallID)
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
                        objCmd.CommandText = "PR_Order_SelectStartEndDatesByHallID";
                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = HallID;
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

        #region SelectByUserIDByPK
        public OrderENT SelectByUserIDByPK(SqlInt32 OrderID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Order_SelectByUserIDByPK";

                        objCmd.Parameters.Add("UserID", SqlDbType.Int).Value = UserID;
                        objCmd.Parameters.Add("OrderID", SqlDbType.Int).Value = OrderID;
                        #endregion

                        #region ReadData and Set Controls
                        OrderENT entOrder = new OrderENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["OrderID"].Equals(DBNull.Value))
                                        entOrder.OrderID = Convert.ToInt32(objSDR["OrderID"]);

                                    if (!objSDR["StartDate"].Equals(DBNull.Value))
                                        entOrder.StartDate = objSDR["StartDate"].ToString();

                                    if (!objSDR["EndDate"].Equals(DBNull.Value))
                                        entOrder.EndDate = objSDR["EndDate"].ToString();

                                    if (!objSDR["TotalDays"].Equals(DBNull.Value))
                                        entOrder.TotalDays = Convert.ToInt32(objSDR["TotalDays"]);

                                    if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                        entOrder.TotalAmount = Convert.ToInt32(objSDR["TotalAmount"]);

                                    if (!objSDR["Status"].Equals(DBNull.Value))
                                        entOrder.Status = objSDR["Status"].ToString().Trim();

                                    if (!objSDR["HallID"].Equals(DBNull.Value))
                                        entOrder.HallID = Convert.ToInt32(objSDR["HallID"]);

                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                        entOrder.UserID = Convert.ToInt32(objSDR["UserID"]);

                                    if (!objSDR["BookingDate"].Equals(DBNull.Value))
                                        entOrder.BookingDate = objSDR["BookingDate"].ToString();
                                }
                            }
                        }
                        return entOrder;
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
        public OrderENT SelectByPK(SqlInt32 OrderID)
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
                        objCmd.CommandText = "PR_Order_SelectByPK";
                        
                        objCmd.Parameters.Add("OrderID", SqlDbType.Int).Value = OrderID;
                        #endregion

                        #region ReadData and Set Controls
                        OrderENT entOrder = new OrderENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["OrderID"].Equals(DBNull.Value))
                                        entOrder.OrderID = Convert.ToInt32(objSDR["OrderID"]);

                                    if (!objSDR["StartDate"].Equals(DBNull.Value))
                                        entOrder.StartDate = objSDR["StartDate"].ToString();

                                    if (!objSDR["EndDate"].Equals(DBNull.Value))
                                        entOrder.EndDate = objSDR["EndDate"].ToString();

                                    if (!objSDR["TotalDays"].Equals(DBNull.Value))
                                        entOrder.TotalDays = Convert.ToInt32(objSDR["TotalDays"]);

                                    if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                        entOrder.TotalAmount = Convert.ToInt32(objSDR["TotalAmount"]);

                                    if (!objSDR["Status"].Equals(DBNull.Value))
                                        entOrder.Status = objSDR["Status"].ToString().Trim();

                                    if (!objSDR["HallID"].Equals(DBNull.Value))
                                        entOrder.HallID = Convert.ToInt32(objSDR["HallID"]);

                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                        entOrder.UserID = Convert.ToInt32(objSDR["UserID"]);

                                    if (!objSDR["BookingDate"].Equals(DBNull.Value))
                                        entOrder.BookingDate = objSDR["BookingDate"].ToString();
                                }
                            }
                        }
                        return entOrder;
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
                        objCmd.CommandText = "PR_Order_SelectAll";
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