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

public partial class FrontPanel_Order_OrderAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["OrderID"] == null)
            {
                lblPageHeader.Text = "Order Add";
                lblNavigationHeader.Text = "OrderAdd";
            }
            else
            {
                lblPageHeader.Text = "Order Edit";
                lblNavigationHeader.Text = "OrderEdit";
                FillControls(Convert.ToInt32(Request.QueryString["OrderID"].ToString()));
            }
            DateTextBoxValidation();
        }
    }
    #endregion

    #region DateTextBox Validation
    protected void DateTextBoxValidation()
    {
        string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
        string maxDate = Convert.ToDateTime(todayDate).AddDays(30).ToString("yyyy-MM-dd");
        txtStartDate.Attributes.Add("min", todayDate);
        txtEndDate.Attributes.Add("min", todayDate);
        txtStartDate.Attributes.Add("max", maxDate);
    }
    #endregion

    #region Button Check Available Click
    protected void btnCheckAvailable_Click(object sender, EventArgs e)
    {
        float totaldays = ((Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text)).Days) + 1;

        if (totaldays < 1)
        {
            panelAvailable.Visible = false;
            panelMessage.Visible = true;
            lblCheckMessage.Text = "Please select Start date greate than End date";
        }
        else if (totaldays >= 1 && totaldays <= 14)
        {
            #region Local Varibles And Intianlization
            int HallID = 0;
            int OrderID = 0;
            int count = 0;

            OrderBAL balOrder = new OrderBAL();
            OrderENT entOrder = new OrderENT();
            DataTable dtDates = new DataTable();

            if (Request.QueryString["OrderID"] != null)
            {
                entOrder = balOrder.SelectByUserIDByPK(Convert.ToInt32(Request.QueryString["OrderID"]), Convert.ToInt32(Session["UserID"]));

                if (!entOrder.HallID.IsNull)
                    HallID = Convert.ToInt32(entOrder.HallID.ToString());

                if (!entOrder.OrderID.IsNull)
                    OrderID = Convert.ToInt32(entOrder.OrderID.ToString());
            }
            if (Request.QueryString["HallID"] != null)
            {
                HallID = Convert.ToInt32(Request.QueryString["HallID"].ToString());
            }
            #endregion

            dtDates = balOrder.SelectStartEndDatesByHallID(HallID);

            foreach (DataRow row in dtDates.Rows)
            {
                Boolean notSkip = true;
                int orderIDFromTable = Convert.ToInt32(row["OrderID"].ToString());
                DateTime searchStartDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime searchEndDate = Convert.ToDateTime(txtEndDate.Text);

                if (OrderID == orderIDFromTable)
                {
                    notSkip = false;
                }
                if (notSkip)
                {
                    while (searchStartDate <= searchEndDate)
                    {
                        DateTime startDate = Convert.ToDateTime(row["StartDate"].ToString());
                        DateTime endDate = Convert.ToDateTime(row["EndDate"].ToString());

                        while (startDate <= endDate)
                        {
                            if (startDate == searchStartDate)
                            {
                                lblCheckMessage.Text = "Sorry! Hall is not available on this days";
                                panelAvailable.Visible = false;
                                panelMessage.Visible = true;
                                count++;
                                break;
                            }
                            startDate = startDate.AddDays(1);
                        }
                        searchStartDate = searchStartDate.AddDays(1);
                    }
                }
                if (count > 0)
                {
                    break;
                }
            }
            if (count == 0)
            {
                panelAvailable.Visible = true;
                panelMessage.Visible = false;
                FillHiddenControls(totaldays, HallID);
            }
        }
        else if (totaldays > 14)
        {
            panelAvailable.Visible = false;
            panelMessage.Visible = true;
            lblCheckMessage.Text = "Maximum 14 days booking allowed";
        }
    }
    #endregion

    #region FillControls
    protected void FillControls(SqlInt32 OrderID)
    {
        OrderBAL balOrder = new OrderBAL();
        OrderENT entOrder = new OrderENT();

        entOrder = balOrder.SelectByUserIDByPK(OrderID, Convert.ToInt32(Session["UserID"]));

        if (!entOrder.StartDate.IsNull)
            txtStartDate.Text = entOrder.StartDate.ToString();

        if (!entOrder.EndDate.IsNull)
            txtEndDate.Text = entOrder.EndDate.ToString();
    }
    #endregion

    #region FillHiddenControls
    protected void FillHiddenControls(float totaldays, int HallID)
    {
        txtTotalDays.Text = (totaldays).ToString();

        HallBAL balHall = new HallBAL();
        HallENT entHall = new HallENT();

        entHall = balHall.SelectByPK(HallID);

        if (!entHall.HallPrice.IsNull)
            txtTotalAmount.Text = (Convert.ToInt32(entHall.HallPrice.Value.ToString()) * totaldays).ToString();

        if (!entHall.HallName.IsNull)
            txtHallName.Text = entHall.HallName.ToString();

        if (!entHall.HallAddress.IsNull)
            txtAddress.Text = entHall.HallAddress.ToString();
    }
    #endregion

    #region Button BookAndPayNow Click
    protected void btnBookAndPayNow_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strErrorMsg = "";

        if (txtStartDate.Text == "")
            strErrorMsg += "Select Start Date</br>";

        if (txtEndDate.Text == "")
            strErrorMsg += "Selct End Date";

        if (strErrorMsg.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMsg.ToString().Trim();
            return;
        }
        #endregion

        #region Collect Data
        OrderENT entorder = new OrderENT();

        if (txtStartDate.Text != "")
            entorder.StartDate = txtStartDate.Text.Trim().ToString();

        if (txtEndDate.Text != "")
            entorder.EndDate = txtEndDate.Text.Trim().ToString();

        if (txtTotalDays.Text != "")
            entorder.TotalDays = Convert.ToInt32(txtTotalDays.Text.Trim().ToString());

        if (txtTotalAmount.Text != "")
            entorder.TotalAmount = Convert.ToInt32(txtTotalAmount.Text.Trim().ToString());

        if (Request.QueryString["HallID"] != null)
            entorder.HallID = Convert.ToInt32(Request.QueryString["HallID"].ToString());

        if (Request.QueryString["OrderID"] != null)
            entorder.OrderID = Convert.ToInt32(Request.QueryString["OrderID"].ToString());

        if (Session["UserID"] != null)
            entorder.UserID = Convert.ToInt32(Session["UserID"].ToString());

        if (DateTime.Now.ToString("yyyy-MM-dd") != "")
            entorder.BookingDate = DateTime.Now.ToString("yyyy-MM-dd");

        entorder.Status = "Completed";
        #endregion

        OrderBAL balOrder = new OrderBAL();

        if (Request.QueryString["HallID"] != null)
        {
            if (balOrder.InsertByUserID(entorder))
            {
                Response.Redirect("~/FrontPanel/Order/OrderList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balOrder.Message;
            }
        }
        if (Request.QueryString["OrderID"] != null)
        {
            if (balOrder.UpdateByUserID(entorder))
            {
                Response.Redirect("~/FrontPanel/Order/OrderList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balOrder.Message;
            }
        }
    }
    #endregion

    #region Button Back Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Hall/HallList.aspx");
    }
    #endregion
}