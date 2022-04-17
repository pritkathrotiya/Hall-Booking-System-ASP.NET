using HallBookingSystem.DAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AreaBAL
/// </summary>
namespace HallBookingSystem.BAL
{
    public class AreaBAL
    {
        #region Constructor
        public AreaBAL()
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
        public Boolean Insert(AreaENT entArea)
        {
            AreaDAL dalArea = new AreaDAL();
            if (dalArea.Insert(entArea))
            {
                return true;
            }
            else
            {
                Message = dalArea.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(AreaENT entArea)
        {
            AreaDAL dalArea = new AreaDAL();
            if (dalArea.Update(entArea))
            {
                return true;
            }
            else
            {
                Message = dalArea.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 AreaID)
        {
            AreaDAL dalArea = new AreaDAL();

            if (dalArea.Delete(AreaID))
            {
                return true;
            }
            else
            {
                Message = dalArea.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public AreaENT SelectByPK(SqlInt32 AreaID)
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectByPK(AreaID);
        }
        #endregion SelectByPK

        #region SelectForDropDownListByCityID
        public DataTable SelectForDropDownListByCityID(SqlInt32 CityID)
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectForDropDownListByCityID(CityID);
        }
        #endregion

        #endregion Select Operation
    }
}
