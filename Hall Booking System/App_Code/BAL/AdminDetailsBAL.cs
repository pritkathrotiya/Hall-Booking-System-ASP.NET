using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminDetailsBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class AdminDetailsBAL
    {
        #region Constructor
        public AdminDetailsBAL()
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

        #region Update Operation
        public Boolean Update(AdminDetailsENT entAdminDetails)
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            if (dalAdminDetails.Update(entAdminDetails))
            {
                return true;
            }
            else
            {
                Message = dalAdminDetails.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Update PhotoPath
        public Boolean UpdatePhotoPath(AdminDetailsENT entAdminDetails)
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            if (dalAdminDetails.UpdatePhotoPath(entAdminDetails))
            {
                return true;
            }
            else
            {
                Message = dalAdminDetails.Message;
                return false;
            }
        }
        #endregion

        #endregion

        #region Select Operation

        #region SelectByPK
        public AdminDetailsENT SelectByPK(SqlInt32 AdminID)
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            return dalAdminDetails.SelectByPK(AdminID);
        }
        #endregion

        #region SelectForUsernamePassword
        public AdminDetailsENT SelectForUsernamePassword(SqlString Username, SqlString Password)
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            AdminDetailsENT entadminDetails = new AdminDetailsENT();

            entadminDetails = dalAdminDetails.SelectForUsernamePassword(Username, Password);
            if (dalAdminDetails.Message == null)
            {
                return entadminDetails;
            }
            else
            {
                Message = dalAdminDetails.Message;
                return null;
            }
        }
        #endregion SelectAll

        #region SelectByEmail
        public AdminDetailsENT SelectByEmail(SqlString Email)
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            AdminDetailsENT entadminDetails = new AdminDetailsENT();

            entadminDetails = dalAdminDetails.SelectByEmail(Email);
            if (dalAdminDetails.Message == null)
            {
                return entadminDetails;
            }
            else
            {
                Message = dalAdminDetails.Message;
                return null;
            }
        }
        #endregion

        #region SelectAll
        public DataTable SelectAll()
        {
            AdminDetailsDAL dalAdminDetails = new AdminDetailsDAL();
            return dalAdminDetails.SelectAll();
        }
        #endregion SelectAll

        #endregion Select Operation
    }
}