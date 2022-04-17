using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class HallBAL
    {
        #region Constructor
        public HallBAL()
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
        public Boolean Insert(HallENT entHall)
        {
            HallDAL dalHall = new HallDAL();
            if (dalHall.Insert(entHall))
            {
                return true;
            }
            else
            {
                Message = dalHall.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(HallENT entHall)
        {
            HallDAL dalHall = new HallDAL();
            if (dalHall.Update(entHall))
            {
                return true;
            }
            else
            {
                Message = dalHall.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 HallID)
        {
            HallDAL dalHall = new HallDAL();

            if (dalHall.Delete(HallID))
            {
                return true;
            }
            else
            {
                Message = dalHall.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            HallDAL dalHall = new HallDAL();
            return dalHall.SelectAll();
        }
        #endregion SelectAll

        #region SelectAllSortByPrice
        public DataTable SelectAllSortByPrice()
        {
            HallDAL dalHall = new HallDAL();
            return dalHall.SelectAllSortByPrice();
        }
        #endregion SelectAll

        #region SelectAllSortByPeople
        public DataTable SelectAllSortByPeople()
        {
            HallDAL dalHall = new HallDAL();
            return dalHall.SelectAllSortByPeople();
        }
        #endregion SelectAll

        #region SelectAllSortByVechile
        public DataTable SelectAllSortByVechile()
        {
            HallDAL dalHall = new HallDAL();
            return dalHall.SelectAllSortByVechile();
        }
        #endregion SelectAll

        #region SelectByPK
        public HallENT SelectByPK(SqlInt32 HallID)
        {
            HallDAL dalHall = new HallDAL();
            return dalHall.SelectByPK(HallID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}