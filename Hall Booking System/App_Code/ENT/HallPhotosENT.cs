using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HallPhotosENT
/// </summary>
namespace HallBookingSystem.ENT
{
    public class HallPhotosENT
    {
        #region Constructor
        public HallPhotosENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region HallPhotoID
        protected SqlInt32 _HallPhotoID;
        public SqlInt32 HallPhotoID
        {
            get
            {
                return _HallPhotoID;
            }
            set
            {
                _HallPhotoID = value;
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

        #region Photo1
        protected SqlString _Photo1;
        public SqlString Photo1
        {
            get
            {
                return _Photo1;
            }
            set
            {
                _Photo1 = value;
            }
        }
        #endregion

        #region Photo2
        protected SqlString _Photo2;
        public SqlString Photo2
        {
            get
            {
                return _Photo2;
            }
            set
            {
                _Photo2 = value;
            }
        }
        #endregion

        #region Photo3
        protected SqlString _Photo3;
        public SqlString Photo3
        {
            get
            {
                return _Photo3;
            }
            set
            {
                _Photo3 = value;
            }
        }
        #endregion

        #region Photo4
        protected SqlString _Photo4;
        public SqlString Photo4
        {
            get
            {
                return _Photo4;
            }
            set
            {
                _Photo4 = value;
            }
        }
        #endregion

        #region Photo5
        protected SqlString _Photo5;
        public SqlString Photo5
        {
            get
            {
                return _Photo5;
            }
            set
            {
                _Photo5 = value;
            }
        }
        #endregion

        #region Photo1
        protected SqlString _Photo6;
        public SqlString Photo6
        {
            get
            {
                return _Photo6;
            }
            set
            {
                _Photo6 = value;
            }
        }
        #endregion
    }
}