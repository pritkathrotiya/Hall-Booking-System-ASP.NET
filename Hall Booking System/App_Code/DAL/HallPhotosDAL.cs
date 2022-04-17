using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallPhotosDAL
/// </summary>
namespace HallBookingSystem.DAL
{
    public class HallPhotosDAL : DatabaseConfig
    {
        #region Constructor
        public HallPhotosDAL()
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
        public Boolean Insert(HallPhotosENT entHallPhotos)
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
                        objCmd.CommandText = "PR_HallPhotos_Insert";

                        objCmd.Parameters.Add("HallPhotosID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = entHallPhotos.HallID;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["HallPhotosID"].Value != null)
                            entHallPhotos.HallPhotoID = Convert.ToInt32(objCmd.Parameters["HallPhotosID"].Value);

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
        public Boolean Update(HallPhotosENT entPhotosHall)
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
                        objCmd.CommandText = "PR_HallPhotos_UpdateByPK";

                        objCmd.Parameters.Add("HallPhotoID", SqlDbType.Int).Value = entPhotosHall.HallPhotoID;
                        objCmd.Parameters.Add("Photo1", SqlDbType.VarChar).Value = entPhotosHall.Photo1;
                        objCmd.Parameters.Add("Photo2", SqlDbType.VarChar).Value = entPhotosHall.Photo2;
                        objCmd.Parameters.Add("Photo3", SqlDbType.VarChar).Value = entPhotosHall.Photo3;
                        objCmd.Parameters.Add("Photo4", SqlDbType.VarChar).Value = entPhotosHall.Photo4;
                        objCmd.Parameters.Add("Photo5", SqlDbType.VarChar).Value = entPhotosHall.Photo5;
                        objCmd.Parameters.Add("Photo6", SqlDbType.VarChar).Value = entPhotosHall.Photo6;
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
                        objCmd.CommandText = "PR_HallPhotos_DeleteByHallID";

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

        #region SelectByPK
        public HallPhotosENT SelectByPK(SqlInt32 HallPhotoID)
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
                        objCmd.CommandText = "PR_HallPhotos_SelectByPK";

                        objCmd.Parameters.Add("HallPhotoID", SqlDbType.Int).Value = HallPhotoID;
                        #endregion

                        #region ReadDate and Set Controls
                        HallPhotosENT entHallPhotos = new HallPhotosENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["HallID"].Equals(DBNull.Value))
                                        entHallPhotos.HallID = Convert.ToInt32(objSDR["HallID"].ToString().Trim());

                                    if (!objSDR["HallPhotoID"].Equals(DBNull.Value))
                                        entHallPhotos.HallPhotoID = Convert.ToInt32(objSDR["HallPhotoID"].ToString().Trim());

                                    if (!objSDR["Photo1"].Equals(DBNull.Value))
                                        entHallPhotos.Photo1 = objSDR["Photo1"].ToString().Trim();

                                    if (!objSDR["Photo2"].Equals(DBNull.Value))
                                        entHallPhotos.Photo2 = objSDR["Photo2"].ToString().Trim();

                                    if (!objSDR["Photo3"].Equals(DBNull.Value))
                                        entHallPhotos.Photo3 = objSDR["Photo3"].ToString().Trim();

                                    if (!objSDR["Photo4"].Equals(DBNull.Value))
                                        entHallPhotos.Photo4 = objSDR["Photo4"].ToString().Trim();

                                    if (!objSDR["Photo5"].Equals(DBNull.Value))
                                        entHallPhotos.Photo5 = objSDR["Photo5"].ToString().Trim();

                                    if (!objSDR["Photo6"].Equals(DBNull.Value))
                                        entHallPhotos.Photo6 = objSDR["Photo6"].ToString().Trim();
                                }
                            }
                        }
                        return entHallPhotos;
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
        
        #region SelectByHallID
        public HallPhotosENT SelectByHallID(SqlInt32 HallID)
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
                        objCmd.CommandText = "PR_HallPhotos_SelectByHallID";

                        objCmd.Parameters.Add("HallID", SqlDbType.Int).Value = HallID;
                        #endregion

                        #region ReadDate and Set Controls
                        HallPhotosENT entHallPhotos = new HallPhotosENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["HallID"].Equals(DBNull.Value))
                                        entHallPhotos.HallID = Convert.ToInt32(objSDR["HallID"].ToString().Trim());

                                    if (!objSDR["HallPhotoID"].Equals(DBNull.Value))
                                        entHallPhotos.HallPhotoID = Convert.ToInt32(objSDR["HallPhotoID"].ToString().Trim());

                                    if (!objSDR["Photo1"].Equals(DBNull.Value))
                                        entHallPhotos.Photo1 = objSDR["Photo1"].ToString().Trim();

                                    if (!objSDR["Photo2"].Equals(DBNull.Value))
                                        entHallPhotos.Photo2 = objSDR["Photo2"].ToString().Trim();

                                    if (!objSDR["Photo3"].Equals(DBNull.Value))
                                        entHallPhotos.Photo3 = objSDR["Photo3"].ToString().Trim();

                                    if (!objSDR["Photo4"].Equals(DBNull.Value))
                                        entHallPhotos.Photo4 = objSDR["Photo4"].ToString().Trim();

                                    if (!objSDR["Photo5"].Equals(DBNull.Value))
                                        entHallPhotos.Photo5 = objSDR["Photo5"].ToString().Trim();

                                    if (!objSDR["Photo6"].Equals(DBNull.Value))
                                        entHallPhotos.Photo6 = objSDR["Photo6"].ToString().Trim();
                                }
                            }
                        }
                        return entHallPhotos;
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