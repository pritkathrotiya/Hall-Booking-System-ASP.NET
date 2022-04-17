using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login_AdminLogin : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            lblErrorMessage.Text = "Another user is already logged in on this browser";
            btnLogin.Enabled = false;
        }
    }
    #endregion

    #region Button Login Click
    protected void login_Click(object sender, EventArgs e)
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

        entAdminDetails = balAdminDetails.SelectForUsernamePassword(txtUsername.Text, txtPassword.Text);

        if (balAdminDetails.Message == null)
        {
            if (!entAdminDetails.AdminID.IsNull)
                Session["AdminID"] = entAdminDetails.AdminID.Value.ToString();

            if (!entAdminDetails.DisplayName.IsNull)
                Session["AdminDisplayName"] = entAdminDetails.DisplayName.Value.ToString();

            if (!entAdminDetails.PhotoPath.IsNull)
                Session["AdminPhotoPath"] = entAdminDetails.PhotoPath.Value.ToString();

            Response.Redirect("~/AdminPanel/Dashboard/Dashboard.aspx");
        }
        else
        {
            lblErrorMessage.Text = balAdminDetails.Message;
        }
    }
    #endregion
}