using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Admin_AdminAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["AdminID"] == null)
            Response.Redirect("~/AdminPanel/Authorization/AdminLogin.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            FillControls(Convert.ToInt32(Session["AdminID"].ToString()));
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 AdminID)
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

        entAdminDetails = balAdminDetails.SelectByPK(AdminID);

        if (!entAdminDetails.DisplayName.IsNull)
            txtDisplayName.Text = entAdminDetails.DisplayName.Value.ToString();

        if (!entAdminDetails.Email.IsNull)
            txtEmail.Text = entAdminDetails.Email.Value.ToString();

        if (!entAdminDetails.PhoneNo.IsNull)
            txtPhoneNo.Text = entAdminDetails.PhoneNo.Value.ToString();

        if (!entAdminDetails.Gender.IsNull)
        {
            if (entAdminDetails.Gender == "Male")
            {
                rbMale.Checked = true;
            }
            if (entAdminDetails.Gender == "Female")
            {
                rbFemale.Checked = true;
            }
        }

        if (!entAdminDetails.BirthDate.IsNull)
            txtBirthDate.Text = entAdminDetails.BirthDate.Value.ToString();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminHome.aspx");
    }
    #endregion

    #region Button Profile Save Click
    protected void btnSaveProfile_Click(object sender, EventArgs e)
    {
        string msg = "";
        msg = checkForDeplicateInput();

        if (msg == "nothing")
        {
            #region Server Validation
            string strErrorMsg = "";

            if (txtDisplayName.Text == "")
                strErrorMsg += "Enter DisplayName</br>";

            if (txtEmail.Text == "")
                strErrorMsg += "Enter Email";

            if (txtPhoneNo.Text == "")
                strErrorMsg += "Enter PhoneNo";

            if (txtBirthDate.Text == "")
                strErrorMsg += "Enter BirthDate";

            if (rbMale.Checked == false && rbFemale.Checked == false)
                strErrorMsg += "Select Gender";

            if (strErrorMsg.Trim() != "")
            {
                lblErrorProfile.Text = strErrorMsg.ToString().Trim();
                return;
            }
            #endregion

            #region Collect Data
            AdminDetailsENT entAdminDetails = new AdminDetailsENT();
            AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();

            entAdminDetails = balAdminDetails.SelectByPK(Convert.ToInt32(Session["AdminID"].ToString()));

            if (txtDisplayName.Text != "")
                entAdminDetails.DisplayName = txtDisplayName.Text.Trim().ToString();

            if (txtEmail.Text != "")
                entAdminDetails.Email = txtEmail.Text.Trim().ToString();

            if (txtPhoneNo.Text != "")
                entAdminDetails.PhoneNo = txtPhoneNo.Text.Trim().ToString();

            if (txtBirthDate.Text != "")
                entAdminDetails.BirthDate = txtBirthDate.Text.Trim().ToString();

            if (rbMale.Checked == true)
                entAdminDetails.Gender = "Male";

            else if (rbFemale.Checked == true)
                entAdminDetails.Gender = "Female";
            #endregion

            if (balAdminDetails.Update(entAdminDetails))
            {
                Response.Redirect("~/AdminPanel/Admin/AdminHome.aspx");
            }
            else
            {
                lblErrorProfile.Text = balAdminDetails.Message;
            }
        }
        else
        {
            if (msg == "email")
            {
                lblErrorProfile.Text = "This email is already being used";
            }
            else if (msg == "phoneNo")
            {
                lblErrorProfile.Text = "This phone number is already being used";
            }
        }
    }
    #endregion

    #region Check For Deplicate Input
    protected string checkForDeplicateInput()
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        DataTable dtUserDetails = new DataTable();

        dtUserDetails = balAdminDetails.SelectAll();
        int AdminID = Convert.ToInt32(Session["AdminID"].ToString());
        string email = txtEmail.Text;
        string phoneNo = txtPhoneNo.Text;
        string msg = "";

        if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
        {
            foreach (DataRow rows in dtUserDetails.Rows)
            {
                int dtAdminID = Convert.ToInt32(rows["AdminID"].ToString());
                string dtEmail = rows["Email"].ToString();
                string dtPhoneNo = rows["PhoneNo"].ToString();

                if (dtEmail == email)
                {
                    if (AdminID != dtAdminID)
                    {
                        msg = "email";
                        break;
                    }
                    else
                    {
                        msg = "nothing";
                    }
                }
                if (dtPhoneNo == phoneNo)
                {
                    if (AdminID != dtAdminID)
                    {
                        msg = "phoneNo";
                        break;
                    }
                    else
                    {
                        msg = "nothing";
                    }
                }
            }
            return msg;
        }
        else
        {
            msg = balAdminDetails.Message;
            return msg;
        }
    }
    #endregion

    #region Clear Controls Password
    protected void ClearControlsPassword()
    {
        txtCurrentPassword.Text = "";
        txtNewPassword.Text = "";
        txtReNewPassword.Text = "";
    }
    #endregion

    #region Button Save Password Click
    protected void btnSavePassword_Click(object sender, EventArgs e)
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

        entAdminDetails = balAdminDetails.SelectByPK(Convert.ToInt32(Session["AdminID"].ToString()));

        if (entAdminDetails.Password.Value.ToString() == txtCurrentPassword.Text)
        {
            #region Server Validation
            string strErrorMsg = "";

            if (txtReNewPassword.Text == "")
                strErrorMsg += "Enter Password</br>";

            if (strErrorMsg.Trim() != "")
            {
                lblErrorProfile.Text = strErrorMsg.ToString().Trim();
                return;
            }
            #endregion

            #region Collect Data
            if (txtReNewPassword.Text != "")
                entAdminDetails.Password = txtReNewPassword.Text.Trim().ToString();
            #endregion

            if (balAdminDetails.Update(entAdminDetails))
            {
                lblChangePassword.Text = "Password change successfully...";
            }
            else
            {
                lblErrorPassword.Text = balAdminDetails.Message;
            }
        }
        else
        {
            lblErrorPassword.Text = "Current password does not match";
        }
        ClearControlsPassword();
    }
    #endregion
}