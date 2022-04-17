using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManagerENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class ManagerENT
    {
        #region Constructor
        public ManagerENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region ManagerID
        protected SqlInt32 _ManagerID;
        public SqlInt32 ManagerID
        {
            get
            {
                return _ManagerID;
            }
            set
            {
                _ManagerID = value;
            }
        }
        #endregion

        #region ManagerName
        protected SqlString _ManagerName;
        public SqlString ManagerName
        {
            get
            {
                return _ManagerName;
            }
            set
            {
                _ManagerName = value;
            }
        }
        #endregion

        #region ManagerEmail
        protected SqlString _ManagerEmail;
        public SqlString ManagerEmail
        {
            get
            {
                return _ManagerEmail;
            }
            set
            {
                _ManagerEmail = value;
            }
        }
        #endregion

        #region ManagerPhoneNo
        protected SqlString _ManagerPhoneNo;
        public SqlString ManagerPhoneNo
        {
            get
            {
                return _ManagerPhoneNo;
            }
            set
            {
                _ManagerPhoneNo = value;
            }
        }
        #endregion

        #region ManagerGender
        protected SqlString _ManagerGender;
        public SqlString ManagerGender
        {
            get
            {
                return _ManagerGender;
            }
            set
            {
                _ManagerGender = value;
            }
        }
        #endregion

        #region ManagerSalary
        protected SqlInt32 _ManagerSalary;
        public SqlInt32 ManagerSalary
        {
            get
            {
                return _ManagerSalary;
            }
            set
            {
                _ManagerSalary = value;
            }
        }
        #endregion
    }
}