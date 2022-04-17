using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authorization_AdminResetPassword : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Button Reset Password Click
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        Email.sendEmailOfAdminResetPassword(txtEmail.Text.ToString());
        if (Email.Message == "Password has been sent to your email address.")
        {
            lblMessage.CssClass = "text-success";
        }
        else
        {
            lblMessage.CssClass = "text-danger";
        }
        lblMessage.Text = Email.Message;
    }
    #endregion
}