using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_User_UserAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
            Response.Redirect("~/FrontPanel/Authorization/UserLogin.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            FillControls(Convert.ToInt32(Session["UserID"].ToString()));
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 AdminID)
    {
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();

        entUserDetails = balUserDetails.SelectByPK(AdminID);

        if (!entUserDetails.Username.IsNull)
            txtUsername.Text = entUserDetails.Username.Value.ToString();

        if (!entUserDetails.DisplayName.IsNull)
            txtDisplayName.Text = entUserDetails.DisplayName.Value.ToString();

        if (!entUserDetails.Email.IsNull)
            txtEmail.Text = entUserDetails.Email.Value.ToString();

        if (!entUserDetails.PhoneNo.IsNull)
            txtPhoneNo.Text = entUserDetails.PhoneNo.Value.ToString();

        if (!entUserDetails.Gender.IsNull)
        {
            if (entUserDetails.Gender == "Male")
            {
                rbMale.Checked = true;
            }
            if (entUserDetails.Gender == "Female")
            {
                rbFemale.Checked = true;
            }
        }

        if (!entUserDetails.BirthDate.IsNull)
            txtBirthDate.Text = entUserDetails.BirthDate.Value.ToString();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/User/UserHome.aspx");
    }
    #endregion

    #region Button Save Profile Click
    protected void btnSaveProfile_Click(object sender, EventArgs e)
    {
        string msg = "";
        msg = checkForDeplicateInput();

        if (msg == "nothing")
        {
            #region Server Validation
            string strErrorMsg = "";

            if (txtUsername.Text == "")
                strErrorMsg += "Enter Username</br>";

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
            UserDetailsBAL balUserDetails = new UserDetailsBAL();
            UserDetailsENT entUserDetails = new UserDetailsENT();

            entUserDetails = balUserDetails.SelectByPK(Convert.ToInt32(Session["UserID"].ToString()));

            if (txtUsername.Text != "")
                entUserDetails.Username = txtUsername.Text.Trim().ToString();

            if (txtDisplayName.Text != "")
                entUserDetails.DisplayName = txtDisplayName.Text.Trim().ToString();

            if (txtEmail.Text != "")
                entUserDetails.Email = txtEmail.Text.Trim().ToString();

            if (txtPhoneNo.Text != "")
                entUserDetails.PhoneNo = txtPhoneNo.Text.Trim().ToString();

            if (txtBirthDate.Text != "")
                entUserDetails.BirthDate = txtBirthDate.Text.Trim().ToString();

            if (rbMale.Checked == true)
                entUserDetails.Gender = "Male";

            if (rbFemale.Checked == true)
                entUserDetails.Gender = "Female";
            #endregion

            if (balUserDetails.Update(entUserDetails))
            {
                Response.Redirect("~/FrontPanel/User/UserHome.aspx");
            }
            else
            {
                lblErrorProfile.Text = balUserDetails.Message;
            }
        }
        else
        {
            if (msg == "username")
            {
                lblErrorProfile.Text = "This username is already being used";
            }
            else if (msg == "email")
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
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        DataTable dtUserDetails = new DataTable();

        dtUserDetails = balUserDetails.SelectAll();
        int UserID = Convert.ToInt32(Session["UserID"].ToString());
        string username = txtUsername.Text;
        string email = txtEmail.Text;
        string phoneNo = txtPhoneNo.Text;
        string msg = "";

        if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
        {
            foreach (DataRow rows in dtUserDetails.Rows)
            {
                int dtUserID = Convert.ToInt32(rows["UserID"].ToString());
                string dtUsername = rows["Username"].ToString();
                string dtEmail = rows["Email"].ToString();
                string dtPhoneNo = rows["PhoneNo"].ToString();

                if (dtUsername == username)
                {
                    if (UserID != dtUserID)
                    {
                        msg = "username";
                        break;
                    }
                    else
                    {
                        msg = "nothing";
                    }
                }
                if (dtEmail == email)
                {
                    if (UserID != dtUserID)
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
                    if (UserID != dtUserID)
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
            msg = balUserDetails.Message;
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
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();

        entUserDetails = balUserDetails.SelectByPK(Convert.ToInt32(Session["UserID"].ToString()));

        if (entUserDetails.Password.Value.ToString() == txtCurrentPassword.Text)
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
                entUserDetails.Password = txtReNewPassword.Text.Trim().ToString();
            #endregion

            if (balUserDetails.Update(entUserDetails))
            {
                lblChangePassword.Text = "Password change successfully...";
            }
            else
            {
                lblErrorPassword.Text = balUserDetails.Message;
            }
        }
        else
        {
            lblErrorPassword.Text = "Current password does not match";
        }
        ClearControlsPassword();
    }
    #endregion

    #region Button Delete Click
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string PhotoPath = null;
        int UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();
        OrderBAL balOrder = new OrderBAL();
        OrderENT entOrder = new OrderENT();

        entUserDetails = balUserDetails.SelectByPK(UserID);

        if ((entUserDetails.PhotoPath.Value.ToString()) != "~/Content/FrontPanel/Assets/img/UserPhotos/default.jpg")
        {
            PhotoPath = entUserDetails.PhotoPath.ToString();
        }

        if (balOrder.Delete(UserID) && balUserDetails.Delete(UserID))
        {
            if (PhotoPath != null)
            {
                File.Delete(Server.MapPath(PhotoPath));
            }
            Session.Clear();
            Response.Redirect("~/FrontPanel/Authorization/UserLogin.aspx");
        }
        else
        {
            lblErrorDelete.Text = balUserDetails.Message;
        }
    }
    #endregion
}