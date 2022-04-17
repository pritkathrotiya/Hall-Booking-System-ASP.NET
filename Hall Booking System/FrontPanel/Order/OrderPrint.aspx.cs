using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Order_OrderPrint : System.Web.UI.Page
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
            FillControls();
        }
    }
    #endregion

    #region FillControls
    protected void FillControls()
    {
        #region Call Methods 

        OrderBAL balOrder = new OrderBAL();
        OrderENT entOrder = new OrderENT();

        HallBAL balHall = new HallBAL();
        HallENT entHall = new HallENT();

        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        AreaBAL balArea = new AreaBAL();
        AreaENT entArea = new AreaENT();

        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();

        try
        {
            entOrder = balOrder.SelectByPK(Convert.ToInt32(Request.QueryString["OrderID"]));

            if (!entOrder.UserID.IsNull)
                entUserDetails = balUserDetails.SelectByPK(entOrder.UserID.Value);

            if (!entOrder.HallID.IsNull)
                entHall = balHall.SelectByPK(entOrder.HallID.Value);

            if (!entHall.CityID.IsNull)
                entCity = balCity.SelectByPK(entHall.CityID.Value);

            if (!entHall.AreaID.IsNull)
                entArea = balArea.SelectByPK(entHall.AreaID.Value);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
        }
        #endregion

        #region Fill Label
        if (!entUserDetails.DisplayName.IsNull)
        {
            lblUsername1.Text = entUserDetails.DisplayName.Value.ToString();
            lblUsername2.Text = entUserDetails.DisplayName.Value.ToString();
        }
        else
        {
            if (!entUserDetails.Username.IsNull)
            {
                lblUsername1.Text = entUserDetails.Username.Value.ToString();
                lblUsername2.Text = entUserDetails.Username.Value.ToString();
            }
        }

        if (!entOrder.OrderID.IsNull)
            lblOrderID.Text = entOrder.OrderID.Value.ToString();

        if (!entOrder.BookingDate.IsNull)
            lblBookingDate.Text = entOrder.BookingDate.Value.ToString();

        if (!entHall.HallName.IsNull)
        {
            lblHallName1.Text = entHall.HallName.Value.ToString();
            lblHallName2.Text = entHall.HallName.Value.ToString();
        }

        if (!entUserDetails.PhoneNo.IsNull)
            lblPhoneNo.Text = entUserDetails.PhoneNo.Value.ToString();

        if (!entUserDetails.Email.IsNull)
            lblEmail.Text = entUserDetails.Email.Value.ToString();

        if (!entArea.AreaName.IsNull)
            lblArea.Text = entArea.AreaName.Value.ToString();

        if (!entCity.CityName.IsNull)
            lblCity.Text = entCity.CityName.Value.ToString();

        if (!entArea.AreaPincode.IsNull)
            lblPincode.Text = entArea.AreaPincode.Value.ToString();

        if (!entOrder.StartDate.IsNull)
            lblStartDate.Text = entOrder.StartDate.Value.ToString();

        if (!entOrder.EndDate.IsNull)
            lblEndDate.Text = entOrder.EndDate.Value.ToString();

        if (!entOrder.TotalAmount.IsNull)
        {
            lblOrderAmount1.Text = entOrder.TotalAmount.Value.ToString();
            lblOrderAmount2.Text = entOrder.TotalAmount.Value.ToString();
        }
        #endregion
    }
    #endregion
}