using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class HallENT
    {
        #region Constructor
        public HallENT()
        {
            //
            // TODO: Add constructor logic here
            //
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

        #region HallName
        protected SqlString _HallName;
        public SqlString HallName
        {
            get
            {
                return _HallName;
            }
            set
            {
                _HallName = value;
            }
        }
        #endregion

        #region HallAddress
        protected SqlString _HallAddress;
        public SqlString HallAddress
        {
            get
            {
                return _HallAddress;
            }
            set
            {
                _HallAddress = value;
            }
        }
        #endregion

        #region HallPeopleCapacity
        protected SqlInt32 _HallPeopleCapacity;
        public SqlInt32 HallPeopleCapacity
        {
            get
            {
                return _HallPeopleCapacity;
            }
            set
            {
                _HallPeopleCapacity = value;
            }
        }
        #endregion

        #region HallVechileCapacity
        protected SqlInt32 _HallVechileCapacity;
        public SqlInt32 HallVechileCapacity
        {
            get
            {
                return _HallVechileCapacity;
            }
            set
            {
                _HallVechileCapacity = value;
            }
        }
        #endregion

        #region HallPrice
        protected SqlInt32 _HallPrice;
        public SqlInt32 HallPrice
        {
            get
            {
                return _HallPrice;
            }
            set
            {
                _HallPrice = value;
            }
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