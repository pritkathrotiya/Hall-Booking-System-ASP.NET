using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetailsBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class UserDetailsBAL
    {
        #region Constructor
        public UserDetailsBAL()
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
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            if (dalUserDetails.Insert(entUserDetails))
            {
                return true;
            }
            else
            {
                Message = dalUserDetails.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation

        #region Update Operation
        public Boolean Update(UserDetailsENT entUserDetails)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            if (dalUserDetails.Update(entUserDetails))
            {
                return true;
            }
            else
            {
                Message = dalUserDetails.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Update PhotoPath
        public Boolean UpdatePhotoPath(UserDetailsENT entUserDetails)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            if (dalUserDetails.UpdatePhotoPath(entUserDetails))
            {
                return true;
            }
            else
            {
                Message = dalUserDetails.Message;
                return false;
            }
        }
        #endregion

        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 UserID)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            if (dalUserDetails.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUserDetails.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectByPK
        public UserDetailsENT SelectByPK(SqlInt32 UserID)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            return dalUserDetails.SelectByPK(UserID);
        }
        #endregion

        #region SelectForUsernamePassword
        public UserDetailsENT SelectForUsernamePassword(SqlString Username, SqlString Password)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            UserDetailsENT entadminDetails = new UserDetailsENT();

            entadminDetails = dalUserDetails.SelectForUsernamePassword(Username, Password);
            if (dalUserDetails.Message == null)
            {
                return entadminDetails;
            }
            else
            {
                Message = dalUserDetails.Message;
                return null;
            }
        }
        #endregion SelectAll
        
        #region SelectByEmail
        public UserDetailsENT SelectByEmail(SqlString Email)
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            UserDetailsENT entadminDetails = new UserDetailsENT();

            entadminDetails = dalUserDetails.SelectByEmail(Email);
            if (dalUserDetails.Message == null)
            {
                return entadminDetails;
            }
            else
            {
                Message = dalUserDetails.Message;
                return null;
            }
        }
        #endregion SelectAll

        #region SelectAll
        public DataTable SelectAll()
        {
            UserDetailsDAL dalUserDetails = new UserDetailsDAL();
            return dalUserDetails.SelectAll();
        }
        #endregion SelectAll

        #endregion Select Operation
    }
}