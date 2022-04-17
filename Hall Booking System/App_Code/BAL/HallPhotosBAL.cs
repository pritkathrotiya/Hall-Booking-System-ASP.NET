using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallPhotosBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class HallPhotosBAL
    {
        #region Constructor
        public HallPhotosBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Local Veriables
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
            HallPhotosDAL dalPhotosHall = new HallPhotosDAL();
            if (dalPhotosHall.Insert(entHallPhotos))
            {
                return true;
            }
            else
            {
                Message = dalPhotosHall.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(HallPhotosENT entHallPhotos)
        {
            HallPhotosDAL dalPhotosHall = new HallPhotosDAL();
            if (dalPhotosHall.Update(entHallPhotos))
            {
                return true;
            }
            else
            {
                Message = dalPhotosHall.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 HallID)
        {
            HallPhotosDAL dalPhotoHall = new HallPhotosDAL();

            if (dalPhotoHall.Delete(HallID))
            {
                return true;
            }
            else
            {
                Message = dalPhotoHall.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectByPK
        public HallPhotosENT SelectByPK(SqlInt32 HallPhotoID)
        {
            HallPhotosDAL dalPhotosHall = new HallPhotosDAL();
            return dalPhotosHall.SelectByPK(HallPhotoID);
        }
        #endregion SelectByPK

        #region SelectByHallID
        public HallPhotosENT SelectByHallID(SqlInt32 HallID)
        {
            HallPhotosDAL dalPhotosHall = new HallPhotosDAL();
            return dalPhotosHall.SelectByHallID(HallID);
        }
        #endregion SelectByHallID

        #endregion Select Operation
    }
}