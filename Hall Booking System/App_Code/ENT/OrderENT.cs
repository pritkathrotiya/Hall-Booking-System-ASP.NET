using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class OrderENT
    {
        #region Constructor
        public OrderENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region OrderID
        protected SqlInt32 _OrderID;
        public SqlInt32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }
        #endregion

        #region StartDate
        protected SqlString _StartDate;
        public SqlString StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        #endregion

        #region EndDate
        protected SqlString _EndDate;
        public SqlString EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        #endregion

        #region BookingDate
        protected SqlString _BookingDate;
        public SqlString BookingDate
        {
            get
            {
                return _BookingDate;
            }
            set
            {
                _BookingDate = value;
            }
        }
        #endregion

        #region TotalDays
        protected SqlInt32 _TotalDays;
        public SqlInt32 TotalDays
        {
            get
            {
                return _TotalDays;
            }
            set
            {
                _TotalDays = value;
            }
        }
        #endregion

        #region TotalAmount
        protected SqlInt32 _TotalAmount;
        public SqlInt32 TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                _TotalAmount = value;
            }
        }
        #endregion

        #region Status
        protected SqlString _Status;
        public SqlString Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        #endregion

        #region HallID
        protected SqlInt32 _HallID;
        public SqlInt32 HallID
        {
            get
            {
                return _HallID;
            }
            set
            {
                _HallID = value;
            }
        }
        #endregion

        #region UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion
    }
}