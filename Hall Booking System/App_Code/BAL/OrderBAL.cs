using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class OrderBAL
    {
        #region Constructor
        public OrderBAL()
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
        public Boolean InsertByUserID(OrderENT entOrder)
        {
            OrderDAL dalOrder = new OrderDAL();
            if (dalOrder.InsertByUserID(entOrder))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean UpdateByUserID(OrderENT entOrder)
        {
            OrderDAL dalOrder = new OrderDAL();
            if (dalOrder.UpdateByUserID(entOrder))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation

        #region DeleteByUserIDByPK
        public Boolean DeleteByUserID(SqlInt32 OrderID, SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();

            if (dalOrder.DeleteByUserID(OrderID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion

        #region DeleteByUserID
        public Boolean Delete(SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();

            if (dalOrder.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion

        #endregion Delete Operation

        #region Select Operation

        #region SelectAllByUserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();
            return dalOrder.SelectAllByUserID(UserID);
        }
        #endregion SelectAll

        #region SelectStartEndDates
        public DataTable SelectStartEndDatesByHallID(SqlInt32 HallID)
        {
            OrderDAL dalOrder = new OrderDAL();
            return dalOrder.SelectStartEndDatesByHallID(HallID);
        }
        #endregion SelectAll

        #region SelectByUserIDByPK
        public OrderENT SelectByUserIDByPK(SqlInt32 OrderID, SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();
            return dalOrder.SelectByUserIDByPK(OrderID, UserID);
        }
        #endregion SelectByPK

        #region SelectByPK
        public OrderENT SelectByPK(SqlInt32 OrderID)
        {
            OrderDAL dalOrder = new OrderDAL();
            return dalOrder.SelectByPK(OrderID);
        }
        #endregion SelectByPK

        #region SelectAll
        public DataTable SelectAll()
        {
            OrderDAL dalOrder = new OrderDAL();
            return dalOrder.SelectAll();
        }
        #endregion SelectAll

        #endregion Select Operation
    }
}