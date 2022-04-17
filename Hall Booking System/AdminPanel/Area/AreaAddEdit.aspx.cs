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

public partial class AdminPanel_Area_AreaAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["AreaID"] == null)
            {
                lblPageHeader.Text = "Area Add";
                lblNavigationHeader.Text = "AreaAdd";
            }
            else
            {
                lblPageHeader.Text = "Area Edit";
                lblNavigationHeader.Text = "AreaEdit";
                FillControls(Convert.ToInt32(Request.QueryString["AreaID"].ToString().Trim()));
            }

            FillDropDownList();
        }
    }
    #endregion

    #region Fill Drop Down List
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCity(ddlCity);
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 AreaID)
    {
        AreaBAL balArea = new AreaBAL();
        AreaENT entArea = new AreaENT();

        entArea = balArea.SelectByPK(AreaID);

        if (!entArea.AreaName.IsNull)
            txtAreaName.Text = entArea.AreaName.Value.ToString();

        if (!entArea.AreaAddress.IsNull)
            txtAddress.Text = entArea.AreaAddress.Value.ToString();

        if (!entArea.AreaPincode.IsNull)
            txtPincode.Text = entArea.AreaPincode.Value.ToString();

        if (!entArea.CityID.IsNull)
            ddlCity.SelectedValue = entArea.CityID.Value.ToString();
    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        txtAreaName.Text = "";
        txtAddress.Text = "";
        txtPincode.Text = "";
        ddlCity.SelectedIndex = 0;

        txtAreaName.Focus();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Area/AreaList.aspx");
    }
    #endregion

    #region Button Save Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strErrorMsg = "";

        if (txtAreaName.Text == "")
            strErrorMsg += "Enter Area Name</br>";

        if (txtAddress.Text == "")
            strErrorMsg += "Enter Address</br>";

        if (txtPincode.Text == "")
            strErrorMsg += "Enter Pincode</br>";

        if (ddlCity.SelectedIndex == 0)
            strErrorMsg += "Select City";

        if (strErrorMsg.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMsg.ToString().Trim();
            return;
        }
        #endregion

        #region Collect Data
        AreaENT entArea = new AreaENT();

        if (txtAreaName.Text != "")
            entArea.AreaName = txtAreaName.Text.Trim().ToString();

        if (txtAddress.Text != "")
            entArea.AreaAddress = txtAddress.Text.Trim().ToString();

        if (txtPincode.Text != "")
            entArea.AreaPincode = Convert.ToInt32(txtPincode.Text.Trim().ToString());

        if (ddlCity.SelectedIndex > 0)
            entArea.CityID = Convert.ToInt32(ddlCity.SelectedValue);
        #endregion

        AreaBAL balArea = new AreaBAL();

        if (Request.QueryString["AreaID"] == null)
        {
            if (balArea.Insert(entArea))
            {
                lblSuccess.Text = "Data Insert Successfully...";
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balArea.Message;
            }
        }
        else
        {
            entArea.AreaID = Convert.ToInt32(Request.QueryString["AreaID"]);
            if (balArea.Update(entArea))
            {
                Response.Redirect("~/AdminPanel/Area/AreaList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balArea.Message;
            }
        }
    }
    #endregion
}