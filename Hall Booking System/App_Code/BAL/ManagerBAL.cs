using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManagerBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class ManagerBAL
    {
        #region Constructor
        public ManagerBAL()
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
        public Boolean Insert(ManagerENT entManager)
        {
            ManagerDAL dalManager = new ManagerDAL();
            if (dalManager.Insert(entManager))
            {
                return true;
            }
            else
            {
                Message = dalManager.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ManagerENT entManager)
        {
            ManagerDAL dalManager = new ManagerDAL();
            if (dalManager.Update(entManager))
            {
                return true;
            }
            else
            {
                Message = dalManager.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ManagerID)
        {
            ManagerDAL dalManager = new ManagerDAL();

            if (dalManager.Delete(ManagerID))
            {
                return true;
            }
            else
            {
                Message = dalManager.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            ManagerDAL dalManager = new ManagerDAL();
            return dalManager.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public ManagerENT SelectByPK(SqlInt32 ManagerID)
        {
            ManagerDAL dalManager = new ManagerDAL();
            return dalManager.SelectByPK(ManagerID);
        }
        #endregion SelectByPK

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            ManagerDAL dalManager = new ManagerDAL();
            return dalManager.SelectForDropDownList();
        }
        #endregion

        #endregion Select Operation
    }
}