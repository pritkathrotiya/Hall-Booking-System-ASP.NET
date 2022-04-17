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

public partial class AdminPanel_HallPhotos_HallPhotosAddEdit : System.Web.UI.Page
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
            FillControls(Convert.ToInt32(Request.QueryString["HallPhotoID"]));
        }
    }
    #endregion

    #region Set and Get Hidden Field Value
    protected String LabelProperty
    {
        get
        {
            return hfPhotoID.Value;
        }
        set
        {
            hfPhotoID.Value = value;
        }
    }
    #endregion

    #region Fill Controls
    protected void FillControls(SqlInt32 HallPhotoID)
    {
        HallPhotosBAL balHallPhotos = new HallPhotosBAL();
        HallPhotosENT entHallPhotos = new HallPhotosENT();

        entHallPhotos = balHallPhotos.SelectByPK(HallPhotoID);

        if (!entHallPhotos.Photo1.IsNull)
            imgPhoto1.ImageUrl = entHallPhotos.Photo1.Value.ToString();

        if (!entHallPhotos.Photo2.IsNull)
            imgPhoto2.ImageUrl = entHallPhotos.Photo2.Value.ToString();

        if (!entHallPhotos.Photo3.IsNull)
            imgPhoto3.ImageUrl = entHallPhotos.Photo3.Value.ToString();

        if (!entHallPhotos.Photo4.IsNull)
            imgPhoto4.ImageUrl = entHallPhotos.Photo4.Value.ToString();

        if (!entHallPhotos.Photo5.IsNull)
            imgPhoto5.ImageUrl = entHallPhotos.Photo5.Value.ToString();

        if (!entHallPhotos.Photo6.IsNull)
            imgPhoto6.ImageUrl = entHallPhotos.Photo6.Value.ToString();
    }
    #endregion

    #region Button Upload Click
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuHallPhoto.HasFile)
        {
            #region Collect Data
            string strPhotoPath = "~/Content/AdminPanel/Assets/img/HallPhotos/";
            string strPhysicalPath = Server.MapPath(strPhotoPath);
            strPhysicalPath += fuHallPhoto.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuHallPhoto.SaveAs(strPhysicalPath);

            HallPhotosENT entHallPhotos = new HallPhotosENT();

            entHallPhotos.HallPhotoID = Convert.ToInt32(Request.QueryString["HallPhotoID"].ToString());

            if (hfPhotoID.Value == "Photo1")
                entHallPhotos.Photo1 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo1 = imgPhoto1.ImageUrl.ToString();

            if (hfPhotoID.Value == "Photo2")
                entHallPhotos.Photo2 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo2 = imgPhoto2.ImageUrl.ToString();

            if (hfPhotoID.Value == "Photo3")
                entHallPhotos.Photo3 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo3 = imgPhoto3.ImageUrl.ToString();

            if (hfPhotoID.Value == "Photo4")
                entHallPhotos.Photo4 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo4 = imgPhoto4.ImageUrl.ToString();

            if (hfPhotoID.Value == "Photo5")
                entHallPhotos.Photo5 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo5 = imgPhoto5.ImageUrl.ToString();

            if (hfPhotoID.Value == "Photo6")
                entHallPhotos.Photo6 = (strPhotoPath += fuHallPhoto.FileName);
            else
                entHallPhotos.Photo6 = imgPhoto6.ImageUrl.ToString();
            #endregion

            HallPhotosBAL balHallPhotos = new HallPhotosBAL();

            if (balHallPhotos.Update(entHallPhotos))
            {
                Response.Redirect("~/AdminPanel/HallPhotos/HallPhotosAddEdit.aspx?HallPhotoID=" + Request.QueryString["HallPhotoID"]);
            }
            else
            {
                lblError.Text = balHallPhotos.Message;
            }
        }
    }
    #endregion

    #region Button Default Photo Click
    protected void btnDefaultPhoto_Click(object sender, EventArgs e)
    {
        #region Collect Data
        HallPhotosENT entHallPhotos = new HallPhotosENT();

        entHallPhotos.HallPhotoID = Convert.ToInt32(Request.QueryString["HallPhotoID"].ToString());

        if (hfPhotoID.Value == "Photo1")
            entHallPhotos.Photo1 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo1 = imgPhoto1.ImageUrl.ToString();

        if (hfPhotoID.Value == "Photo2")
            entHallPhotos.Photo2 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo2 = imgPhoto2.ImageUrl.ToString();

        if (hfPhotoID.Value == "Photo3")
            entHallPhotos.Photo3 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo3 = imgPhoto3.ImageUrl.ToString();

        if (hfPhotoID.Value == "Photo4")
            entHallPhotos.Photo4 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo4 = imgPhoto4.ImageUrl.ToString();

        if (hfPhotoID.Value == "Photo5")
            entHallPhotos.Photo5 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo5 = imgPhoto5.ImageUrl.ToString();

        if (hfPhotoID.Value == "Photo6")
            entHallPhotos.Photo6 = ("~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg");
        else
            entHallPhotos.Photo6 = imgPhoto6.ImageUrl.ToString();
        #endregion

        HallPhotosBAL balHallPhotos = new HallPhotosBAL();

        if (balHallPhotos.Update(entHallPhotos))
        {
            Response.Redirect("~/AdminPanel/HallPhotos/HallPhotosAddEdit.aspx?HallPhotoID=" + Request.QueryString["HallPhotoID"]);
        }
        else
        {
            lblError.Text = balHallPhotos.Message;
        }
    }
    #endregion
}