using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace HallBookingSystem
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region FillDropDownListCity
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();

            ddl.DataSource = balCity.SelectForDropdownList();
            ddl.DataTextField = "CityName";
            ddl.DataValueField = "CityID";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("-- Select City --", "-1"));
        }
        #endregion

        #region FillDropDownListAreaByCityID
        public static void FillDropDownListAreaByCityID(DropDownList ddl, SqlInt32 CityID)
        {
            AreaBAL balArea = new AreaBAL();

            ddl.DataSource = balArea.SelectForDropDownListByCityID(CityID);
            ddl.DataTextField = "AreaName";
            ddl.DataValueField = "AreaID";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("-- Select Area --", "-1"));
        }
        #endregion

        #region FillDropDownListManager
        public static void FillDropDownListManager(DropDownList ddl)
        {
            ManagerBAL balManager = new ManagerBAL();

            ddl.DataSource = balManager.SelectForDropDownList();
            ddl.DataTextField = "ManagerName";
            ddl.DataValueField = "ManagerID";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("-- Select Manager --", "-1"));
        }
        #endregion

        #region FillDropDownListEmpty
        public static void FillDropDownListEmpty(DropDownList ddl, String DropDownListName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("-- Select " + DropDownListName + " --", "-1"));
        }
        #endregion
    }
}