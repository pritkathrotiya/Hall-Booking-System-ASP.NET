using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminDetailsENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class AdminDetailsENT
    {
        #region Constructor
        public AdminDetailsENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region AdminID
        protected SqlInt32 _AdminID;
        public SqlInt32 AdminID
        {
            get
            {
                return _AdminID;
            }
            set
            {
                _AdminID = value;
            }
        }
        #endregion

        #region DisplayName
        protected SqlString _DisplayName;
        public SqlString DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }
        #endregion

        #region Username
        protected SqlString _Username;
        public SqlString Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }
        #endregion

        #region Password
        protected SqlString _Password;
        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        #endregion

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion

        #region PhoneNo
        protected SqlString _PhoneNo;
        public SqlString PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }
        #endregion

        #region Gender
        protected SqlString _Gender;
        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }
        #endregion

        #region BirthDate
        protected SqlString _BirthDate;
        public SqlString BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }
        #endregion

        #region PhotoPath
        protected SqlString _PhotoPath;
        public SqlString PhotoPath
        {
            get
            {
                return _PhotoPath;
            }
            set
            {
                _PhotoPath = value;
            }
        }
        #endregion
    }
}