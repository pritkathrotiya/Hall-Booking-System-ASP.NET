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

public partial class AdminPanel_Admin_AdminHome : System.Web.UI.Page
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
            FillControls(Convert.ToInt32(Session["AdminID"]));
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 AdminID)
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

        entAdminDetails = balAdminDetails.SelectByPK(AdminID);

        if (!entAdminDetails.Username.IsNull)
            lblUsername.Text = entAdminDetails.Username.Value.ToString();

        if (!entAdminDetails.DisplayName.IsNull)
            lblDisplayName.Text = entAdminDetails.DisplayName.Value.ToString();

        if (!entAdminDetails.Email.IsNull)
            lblEmail.Text = entAdminDetails.Email.Value.ToString();

        if (!entAdminDetails.PhoneNo.IsNull)
            lblPhoneNo.Text = entAdminDetails.PhoneNo.Value.ToString();

        if (!entAdminDetails.Gender.IsNull)
            lblGender.Text = entAdminDetails.Gender.Value.ToString();

        if (!entAdminDetails.BirthDate.IsNull)
            lblBirthDate.Text = entAdminDetails.BirthDate.Value.ToString();

        if (!entAdminDetails.PhotoPath.IsNull)
            imgAdminPhoto.ImageUrl = entAdminDetails.PhotoPath.Value.ToString();
    }
    #endregion

    #region Button Edit Click
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminAddEdit.aspx");
    }
    #endregion

    #region Button Upload Click
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuAdminPhoto.HasFile)
        {
            string strPhotoPath = "~/Content/AdminPanel/Assets/img/AdminPhotos/";
            string strPhysicalPath = Server.MapPath(strPhotoPath);
            strPhysicalPath += fuAdminPhoto.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuAdminPhoto.SaveAs(strPhysicalPath);

            #region Update Photo Path In SQL
            AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
            AdminDetailsENT entAdminDetails = new AdminDetailsENT();

            #region Delete Photo From Local Storage
            entAdminDetails = balAdminDetails.SelectByPK(Convert.ToInt32(Session["AdminID"].ToString()));
            if (!entAdminDetails.PhotoPath.IsNull)
            {
                if ((entAdminDetails.PhotoPath.Value.ToString()) != "~/Content/AdminPanel/Assets/img/AdminPhotos/default.jpg")
                {
                    File.Delete(Server.MapPath(entAdminDetails.PhotoPath.ToString()));
                }
            }
            #endregion

            entAdminDetails.AdminID = Convert.ToInt32(Session["AdminID"].ToString());
            entAdminDetails.PhotoPath = (strPhotoPath += fuAdminPhoto.FileName);

            if (balAdminDetails.UpdatePhotoPath(entAdminDetails))
            {
                Response.Redirect("~/AdminPanel/Admin/AdminHome.aspx");
            }
            else
            {
                lblError.Text = balAdminDetails.Message;
            }
            #endregion
        }
    }
    #endregion
}