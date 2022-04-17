using HallBookingSystem;
using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hall_HallAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid Admin
        if (Session["AdminID"] == null)
            Response.Redirect("~/AdminPanel/Authorization/AdminLogin.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["HallID"] == null)
            {
                lblPageHeader.Text = "Hall Add";
                lblNavigationHeader.Text = "HallAdd";
            }
            else
            {
                lblPageHeader.Text = "Hall Edit";
                lblNavigationHeader.Text = "HallEdit";
                FillControls(Convert.ToInt32(Request.QueryString["HallID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Drop Down List
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCity(ddlCity);
        CommonFillMethods.FillDropDownListEmpty(ddlArea, "Area");
        CommonFillMethods.FillDropDownListManager(ddlManager);
    }
    #endregion

    #region City Selected Index Change
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListAreaByCityID(ddlArea, Convert.ToInt32(ddlCity.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlArea, "Area");
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 HallID)
    {
        HallBAL balHall = new HallBAL();
        HallENT entHall = new HallENT();

        entHall = balHall.SelectByPK(HallID);

        if (!entHall.HallName.IsNull)
            txtHallName.Text = entHall.HallName.Value.ToString();

        if (!entHall.HallAddress.IsNull)
            txtAddress.Text = entHall.HallAddress.Value.ToString();

        if (!entHall.HallPeopleCapacity.IsNull)
            txtPeopleCapacity.Text = entHall.HallPeopleCapacity.Value.ToString();

        if (!entHall.HallVechileCapacity.IsNull)
            txtVechileCapacity.Text = entHall.HallVechileCapacity.Value.ToString();

        if (!entHall.HallPrice.IsNull)
            txtHallPrice.Text = entHall.HallPrice.Value.ToString();

        if (!entHall.CityID.IsNull)
            ddlCity.SelectedValue = entHall.CityID.Value.ToString();
        ddlCity_SelectedIndexChanged(null, null);

        if (!entHall.AreaID.IsNull)
            ddlArea.SelectedValue = entHall.AreaID.Value.ToString();

        if (!entHall.ManagerID.IsNull)
            ddlManager.SelectedValue = entHall.ManagerID.Value.ToString();
    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        txtHallName.Text = "";
        txtAddress.Text = "";
        txtPeopleCapacity.Text = "";
        txtVechileCapacity.Text = "";
        txtHallPrice.Text = "";
        ddlCity.SelectedIndex = -1;
        ddlCity_SelectedIndexChanged(null, null);
        ddlManager.SelectedIndex = -1;

        txtHallName.Focus();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hall/HallList.aspx");
    }
    #endregion

    #region Button Save Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strErrorMsg = "";

        if (txtHallName.Text.Trim() == "")
            strErrorMsg += "Enter Hall Name</br>";

        if (txtAddress.Text.Trim() == "")
            strErrorMsg += "Enter Address</br>";

        if (ddlArea.SelectedIndex == 0)
            strErrorMsg += "Select Area</br>";

        if (ddlCity.SelectedIndex == 0)
            strErrorMsg += "Select City</br>";

        if (txtPeopleCapacity.Text.Trim() == "")
            strErrorMsg += "Enter People Capacity</br>";

        if (txtVechileCapacity.Text.Trim() == "")
            strErrorMsg += "Enter Vechile Capacity</br>";

        if (txtHallPrice.Text.Trim() == "")
            strErrorMsg += "Enter Hall Price</br>";

        if (ddlManager.SelectedIndex == 0)
            strErrorMsg += "Select Manager";

        if (strErrorMsg.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMsg.ToString().Trim();
            return;
        }
        #endregion

        #region Collect Data
        HallENT entHAll = new HallENT();

        if (txtHallName.Text != "")
            entHAll.HallName = txtHallName.Text.Trim().ToString();

        if (txtAddress.Text != "")
            entHAll.HallAddress = txtAddress.Text.Trim().ToString();

        if (txtPeopleCapacity.Text != "")
            entHAll.HallPeopleCapacity = Convert.ToInt32(txtPeopleCapacity.Text.Trim().ToString());

        if (txtVechileCapacity.Text != "")
            entHAll.HallVechileCapacity = Convert.ToInt32(txtVechileCapacity.Text.Trim().ToString());

        if (txtHallPrice.Text != "")
            entHAll.HallPrice = Convert.ToInt32(txtHallPrice.Text.Trim().ToString());

        if (ddlCity.SelectedIndex > 0)
            entHAll.CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlArea.SelectedIndex > 0)
            entHAll.AreaID = Convert.ToInt32(ddlArea.SelectedValue);

        if (ddlManager.SelectedIndex > 0)
            entHAll.ManagerID = Convert.ToInt32(ddlManager.SelectedValue);
        #endregion

        HallBAL balHall = new HallBAL();

        if (Request.QueryString["HallID"] == null)
        {
            if (balHall.Insert(entHAll))
            {
                lblSuccess.Text = "Data Insert Successfully...";
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balHall.Message;
            }

            #region Hall Photos Add
            HallPhotosBAL balHallPhotos = new HallPhotosBAL();
            HallPhotosENT entHallPhotos = new HallPhotosENT();

            if (!entHAll.HallID.IsNull)
                entHallPhotos.HallID = entHAll.HallID;

            if (balHallPhotos.Insert(entHallPhotos))
            {

            }
            else
            {
                lblErrorMessage.Text = balHallPhotos.Message;
            }
            #endregion
        }
        else
        {
            entHAll.HallID = Convert.ToInt32(Request.QueryString["HallID"]);

            if (balHall.Update(entHAll))
            {
                Response.Redirect("~/AdminPanel/Hall/HallList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balHall.Message;
            }
        }
    }
    #endregion
}