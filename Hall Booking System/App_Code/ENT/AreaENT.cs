using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AreaENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class AreaENT
    {
        #region Constructor
        public AreaENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region AreaID
        protected SqlInt32 _AreaID;
        public SqlInt32 AreaID
        {
            get
            {
                return _AreaID;
            }
            set
            {
                _AreaID = value;
            }
        }
        #endregion

        #region AreaName
        protected SqlString _AreaName;
        public SqlString AreaName
        {
            get
            {
                return _AreaName;
            }
            set
            {
                _AreaName = value;
            }
        }
        #endregion

        #region AreaAddress
        protected SqlString _AreaAddress;
        public SqlString AreaAddress
        {
            get
            {
                return _AreaAddress;
            }
            set
            {
                _AreaAddress = value;
            }
        }
        #endregion

        #region AreaPincode
        protected SqlInt32 _AreaPincode;
        public SqlInt32 AreaPincode
        {
            get
            {
                return _AreaPincode;
            }
            set
            {
                _AreaPincode = value;
            }
        }
        #endregion

        #region CityID
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion
    }
}