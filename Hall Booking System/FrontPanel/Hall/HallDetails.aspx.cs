using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Hall_HallDetails : System.Web.UI.Page
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
            FillControls(Convert.ToInt32(Request.QueryString["HallID"].ToString()));
        }
    }
    #endregion

    #region FillControls
    private void FillControls(SqlInt32 HallID)
    {
        HallBAL balHall = new HallBAL();
        HallENT entHall = new HallENT();

        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        AreaBAL balArea = new AreaBAL();
        AreaENT entArea = new AreaENT();

        ManagerBAL balManager = new ManagerBAL();
        ManagerENT entManager = new ManagerENT();

        HallPhotosBAL balHallPhotos = new HallPhotosBAL();
        HallPhotosENT entHallPhotos = new HallPhotosENT();

        entHall = balHall.SelectByPK(HallID);

        if (!entHall.CityID.IsNull)
            entCity = balCity.SelectByPK(entHall.CityID.Value);

        if (!entHall.AreaID.IsNull)
            entArea = balArea.SelectByPK(entHall.AreaID.Value);

        if (!entHall.ManagerID.IsNull)
            entManager = balManager.SelectByPK(entHall.ManagerID.Value);

        #region HallPhoto Control Fill
        entHallPhotos = balHallPhotos.SelectByHallID(HallID);
        String defaultPhoto = "~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg";

        if (!entHallPhotos.Photo1.IsNull)
            if (entHallPhotos.Photo1.Value == defaultPhoto)
                photo1.Visible = false;
            else
                imgPhoto1.ImageUrl = entHallPhotos.Photo1.Value;

        if (!entHallPhotos.Photo2.IsNull)
            if (entHallPhotos.Photo2.Value == defaultPhoto)
                photo2.Visible = false;
            else
                imgPhoto2.ImageUrl = entHallPhotos.Photo2.Value;

        if (!entHallPhotos.Photo3.IsNull)
            if (entHallPhotos.Photo3.Value == defaultPhoto)
                photo3.Visible = false;
            else
                imgPhoto3.ImageUrl = entHallPhotos.Photo3.Value;

        if (!entHallPhotos.Photo4.IsNull)
            if (entHallPhotos.Photo4.Value == defaultPhoto)
                photo4.Visible = false;
            else
                imgPhoto4.ImageUrl = entHallPhotos.Photo4.Value;

        if (!entHallPhotos.Photo5.IsNull)
            if (entHallPhotos.Photo5.Value == defaultPhoto)
                photo5.Visible = false;
            else
                imgPhoto5.ImageUrl = entHallPhotos.Photo5.Value;

        if (!entHallPhotos.Photo6.IsNull)
            if (entHallPhotos.Photo6.Value == defaultPhoto)
                photo6.Visible = false;
            else
                imgPhoto6.ImageUrl = entHallPhotos.Photo6.Value;
        #endregion

        #region Fill Table Controls
        if (!entHall.HallName.IsNull)
            lblHallName.Text = entHall.HallName.Value.ToString();

        if (!entHall.HallAddress.IsNull)
            lblAddress.Text = entHall.HallAddress.Value.ToString();

        if (!entCity.CityName.IsNull)
            lblCity.Text = entCity.CityName.Value.ToString();

        if (!entArea.AreaName.IsNull)
            lblArea.Text = entArea.AreaName.Value.ToString();

        if (!entArea.AreaPincode.IsNull)
            lblPincode.Text = entArea.AreaPincode.Value.ToString();

        if (!entHall.HallPeopleCapacity.IsNull)
            lblPeopleCapacity.Text = entHall.HallPeopleCapacity.Value.ToString();

        if (!entHall.HallVechileCapacity.IsNull)
            lblVechileCapacity.Text = entHall.HallVechileCapacity.Value.ToString();

        if (!entHall.HallPrice.IsNull)
            lblPrice.Text = entHall.HallPrice.Value.ToString();

        if (!entManager.ManagerName.IsNull)
            lblManagerName.Text = entManager.ManagerName.Value.ToString();

        if (!entManager.ManagerPhoneNo.IsNull)
            lblPhoneNo.Text = entManager.ManagerPhoneNo.Value.ToString();

        if (!entManager.ManagerEmail.IsNull)
            lblEmail.Text = entManager.ManagerEmail.Value.ToString();
        #endregion
    }
    #endregion

    #region Button Back Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Hall/HallList.aspx");
    }
    #endregion

    #region Button BookNow Click
    protected void btnBookNow_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Order/OrderAddEdit.aspx?HallID=" + Request.QueryString["HallID"].ToString());
    }
    #endregion
}