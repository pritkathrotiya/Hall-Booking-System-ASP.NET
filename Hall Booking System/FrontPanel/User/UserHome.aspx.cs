using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_User_UserHome : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
            Response.Redirect("~/FrontPanel/Authorization/UserLogin.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            FillControls(Convert.ToInt32(Session["UserID"]));
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 UserID)
    {
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();

        entUserDetails = balUserDetails.SelectByPK(UserID);

        if (!entUserDetails.Username.IsNull)
            lblUsername.Text = entUserDetails.Username.Value.ToString();

        if (!entUserDetails.DisplayName.IsNull)
            lblDisplayName.Text = entUserDetails.DisplayName.Value.ToString();

        if (!entUserDetails.Email.IsNull)
            lblEmail.Text = entUserDetails.Email.Value.ToString();

        if (!entUserDetails.PhoneNo.IsNull)
            lblPhoneNo.Text = entUserDetails.PhoneNo.Value.ToString();

        if (!entUserDetails.Gender.IsNull)
            lblGender.Text = entUserDetails.Gender.Value.ToString();

        if (!entUserDetails.BirthDate.IsNull)
            lblBirthDate.Text = entUserDetails.BirthDate.Value.ToString();

        if (!entUserDetails.PhotoPath.IsNull)
            imgUserPhoto.ImageUrl = entUserDetails.PhotoPath.Value.ToString();
    }
    #endregion

    #region Button Edit Click
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/User/UserAddEdit.aspx");
    }
    #endregion

    #region Button Upload Click
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuUserPhoto.HasFile)
        {
            string strPhotoPath = "~/Content/FrontPanel/Assets/img/UserPhotos/";
            string strPhysicalPath = Server.MapPath(strPhotoPath);
            strPhysicalPath += fuUserPhoto.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuUserPhoto.SaveAs(strPhysicalPath);

            #region Update Photo Path In SQL
            UserDetailsBAL balUserDetails = new UserDetailsBAL();
            UserDetailsENT entUserDetails = new UserDetailsENT();

            #region Delete Old Photo Into Local Storage
            entUserDetails = balUserDetails.SelectByPK(Convert.ToInt32(Session["UserID"].ToString()));
            if (!entUserDetails.PhotoPath.IsNull)
            {
                if ((entUserDetails.PhotoPath.Value.ToString()) != "~/Content/FrontPanel/Assets/img/UserPhotos/default.jpg")
                {
                    File.Delete(Server.MapPath(entUserDetails.PhotoPath.ToString()));
                }
            }
            #endregion

            entUserDetails.UserID = Convert.ToInt32(Session["UserID"].ToString());
            entUserDetails.PhotoPath = (strPhotoPath += fuUserPhoto.FileName);

            if (balUserDetails.UpdatePhotoPath(entUserDetails))
            {
                Response.Redirect("~/FrontPanel/User/UserHome.aspx");
            }
            else
            {
                lblErrorMessage.Text = balUserDetails.Message;
            }
            #endregion
        }
    }
    #endregion
}