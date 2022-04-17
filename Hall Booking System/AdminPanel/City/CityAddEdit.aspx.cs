using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["CityID"] == null)
            {
                lblPageHeader.Text = "City Add";
                lblNavigationHeader.Text = "CityAdd";
            }
            else
            {
                lblPageHeader.Text = "City Edit";
                lblNavigationHeader.Text = "CityEdit";
                FillControls(Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

        if (!entCity.CityCode.IsNull)
            txtCityCode.Text = entCity.CityCode.Value.ToString();

    }
    #endregion

    #region Clear Controls
    public void ClearControls()
    {
        txtCityName.Text = "";
        txtCityCode.Text = "";

        txtCityName.Focus();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion

    #region Buttton Save Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strErrorMsg = "";

        if (txtCityName.Text.Trim() == "")
            strErrorMsg += "Enter City Name</br>";

        if (txtCityCode.Text.Trim() == "")
            strErrorMsg += "Enter City Code";

        if (strErrorMsg.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMsg.ToString().Trim();
            return;
        }
        #endregion

        #region Collect Data
        CityENT entCity = new CityENT();

        if (txtCityName.Text != "")
            entCity.CityName = txtCityName.Text.Trim().ToString();

        if (txtCityCode.Text != "")
            entCity.CityCode = Convert.ToInt32(txtCityCode.Text.Trim().ToString());
        #endregion

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                lblSuccess.Text = "Data Insert Successfully...";
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.Update(entCity))
            {
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
    }
    #endregion
}