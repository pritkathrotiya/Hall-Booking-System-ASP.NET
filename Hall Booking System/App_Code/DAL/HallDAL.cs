using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class HallDAL : DatabaseConfig
    {
        #region Constructor
        public HallDAL()
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
        public Boolean Insert(HallENT entHall)
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
                        objCmd.CommandText = "PR_Hall_Insert";

                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("HallName", SqlDbType.VarChar).Value = entHall.HallName;
                        objCmd.Parameters.Add("HallAddress", SqlDbType.VarChar).Value = entHall.HallAddress;
                        objCmd.Parameters.Add("AreaID", SqlDbType.Int).Value = entHall.AreaID;
                        objCmd.Parameters.Add("CityID", SqlDbType.Int).Value = entHall.CityID;
                        objCmd.Parameters.Add("HallPeopleCapacity", SqlDbType.Int).Value = entHall.HallPeopleCapacity;
                        objCmd.Parameters.Add("HallVechileCapacity", SqlDbType.Int).Value = entHall.HallVechileCapacity;
                        objCmd.Parameters.Add("HallPrice", SqlDbType.Int).Value = entHall.HallPrice;
                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Value = entHall.ManagerID;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["HallID"].Value != null)
                            entHall.HallID = Convert.ToInt32(objCmd.Parameters["HallID"].Value);

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
        public Boolean Update(HallENT entHall)
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
                        objCmd.CommandText = "PR_Hall_UpdateByPK";

                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = entHall.HallID;
                        objCmd.Parameters.Add("HallName", SqlDbType.VarChar).Value = entHall.HallName;
                        objCmd.Parameters.Add("HallAddress", SqlDbType.VarChar).Value = entHall.HallAddress;
                        objCmd.Parameters.Add("AreaID", SqlDbType.Int).Value = entHall.AreaID;
                        objCmd.Parameters.Add("CityID", SqlDbType.Int).Value = entHall.CityID;
                        objCmd.Parameters.Add("HallPeopleCapacity", SqlDbType.Int).Value = entHall.HallPeopleCapacity;
                        objCmd.Parameters.Add("HallVechileCapacity", SqlDbType.Int).Value = entHall.HallVechileCapacity;
                        objCmd.Parameters.Add("HallPrice", SqlDbType.Int).Value = entHall.HallPrice;
                        objCmd.Parameters.Add("ManagerID", SqlDbType.Int).Value = entHall.ManagerID;
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
        public Boolean Delete(SqlInt32 HallID)
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
                        objCmd.CommandText = "PR_Hall_DeleteByPK";

                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = HallID;
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
                        objCmd.CommandText = "PR_Hall_SelectAll";
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

        #region SelectAllSortByPrice
        public DataTable SelectAllSortByPrice()
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
                        objCmd.CommandText = "PR_Hall_SelectAllSortByPrice";
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

        #region SelectAllSortByProple
        public DataTable SelectAllSortByPeople()
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
                        objCmd.CommandText = "PR_Hall_SelectAllSortByPeople";
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

        #region SelectAllSortByVechile
        public DataTable SelectAllSortByVechile()
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
                        objCmd.CommandText = "PR_Hall_SelectAllSortByVechile";
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
        public HallENT SelectByPK(SqlInt32 HallID)
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
                        objCmd.CommandText = "PR_Hall_SelectByPK";

                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = HallID;
                        #endregion

                        #region ReadDate and Set Controls
                        HallENT entHall = new HallENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["HallID"].Equals(DBNull.Value))
                                        entHall.HallID = Convert.ToInt32(objSDR["HallID"].ToString().Trim());

                                    if (!objSDR["HallName"].Equals(DBNull.Value))
                                        entHall.HallName = objSDR["HallName"].ToString().Trim();

                                    if (!objSDR["HallAddress"].Equals(DBNull.Value))
                                        entHall.HallAddress = objSDR["HallAddress"].ToString().Trim();

                                    if (!objSDR["CityID"].Equals(DBNull.Value))
                                        entHall.CityID = Convert.ToInt32(objSDR["CityID"].ToString().Trim());

                                    if (!objSDR["AreaID"].Equals(DBNull.Value))
                                        entHall.AreaID = Convert.ToInt32(objSDR["AreaID"].ToString().Trim());

                                    if (!objSDR["HallPeopleCapacity"].Equals(DBNull.Value))
                                        entHall.HallPeopleCapacity = Convert.ToInt32(objSDR["HallPeopleCapacity"].ToString().Trim());

                                    if (!objSDR["HallVechileCapacity"].Equals(DBNull.Value))
                                        entHall.HallVechileCapacity = Convert.ToInt32(objSDR["HallVechileCapacity"].ToString().Trim());

                                    if (!objSDR["HallPrice"].Equals(DBNull.Value))
                                        entHall.HallPrice = Convert.ToInt32(objSDR["HallPrice"].ToString().Trim());

                                    if (!objSDR["ManagerID"].Equals(DBNull.Value))
                                        entHall.ManagerID = Convert.ToInt32(objSDR["ManagerID"].ToString().Trim());
                                }
                            }
                        }
                        return entHall;
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