using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Registration_UserRegistration : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtEmail.Text = "";
    }
    #endregion

    #region Button SignUp Click

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string msg = "";
        msg = checkForDeplicateEmailAndUsername();

        if (msg == "nothing")
        {
            #region Server Validation
            string strErrorMsg = "";

            if (txtUsername.Text == "")
                strErrorMsg += "Enter Username</br>";

            if (txtPassword.Text == "")
                strErrorMsg += "Enter Password</br>";

            if (txtEmail.Text == "")
                strErrorMsg += "Enter Email</br>";

            if (strErrorMsg.Trim() != "")
            {
                lblErrorMessage.Text = strErrorMsg.ToString().Trim();
                return;
            }
            #endregion

            #region Collect Date
            UserDetailsENT entuserDetails = new UserDetailsENT();

            if (txtUsername.Text != "")
                entuserDetails.Username = txtUsername.Text.Trim().ToString();

            if (txtPassword.Text != "")
                entuserDetails.Password = txtPassword.Text.Trim().ToString();

            if (txtEmail.Text != "")
                entuserDetails.Email = txtEmail.Text.Trim().ToString();
            #endregion

            UserDetailsBAL balUserDetails = new UserDetailsBAL();

            if (balUserDetails.Insert(entuserDetails))
            {
                Response.Redirect("~/FrontPanel/Authorization/UserLogin.aspx");
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balUserDetails.Message;
            }
        }
        else
        {
            if (msg == "username")
            {
                lblErrorMessage.Text = "This username is already being used";
            }
            else if (msg == "email")
            {
                lblErrorMessage.Text = "This email address is already being used";
            }
        }
    }
    #endregion

    #region Check For Deplicate Email And Username
    protected string checkForDeplicateEmailAndUsername()
    {
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        DataTable dtUserDetails = new DataTable();

        dtUserDetails = balUserDetails.SelectAll();
        string username = txtUsername.Text;
        string email = txtEmail.Text;
        string msg = "";

        if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
        {
            foreach (DataRow rows in dtUserDetails.Rows)
            {
                string dtUsername = rows["Username"].ToString();
                string dtEmail = rows["Email"].ToString();

                if (dtUsername == username)
                {
                    msg = "username";
                    break;
                }
                else if (dtEmail == email)
                {
                    msg = "email";
                    break;
                }
                else
                {
                    msg = "nothing";
                }
            }
            return msg;
        }
        else
        {
            msg = balUserDetails.Message;
            return msg;
        }
    }
    #endregion
}