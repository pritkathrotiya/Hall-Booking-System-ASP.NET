using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_User_OrderList : System.Web.UI.Page
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
            FillGridView();
            FillControls();
        }
    }
    #endregion

    #region Fill Controls
    protected void FillControls()
    {
        OrderBAL balOrder = new OrderBAL();
        DataTable dtOrder = new DataTable();

        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        DataTable dtUserDetails = new DataTable();

        HallBAL balHall = new HallBAL();
        DataTable dtHall = new DataTable();

        dtUserDetails = balUserDetails.SelectAll();
        dtOrder = balOrder.SelectAll();
        dtHall = balHall.SelectAll();

        float totalOrder = dtOrder.Rows.Count;
        float totalUser = dtUserDetails.Rows.Count;
        float totalHall = dtHall.Rows.Count;

        lblTotalOrder.Text = Convert.ToString(totalOrder);

        lblOrderPerUser.Text = Convert.ToString(totalOrder / totalUser);

        lblOrderPerHall.Text = Convert.ToString(totalOrder / totalHall);
    }
    #endregion

    #region FillGridView
    protected void FillGridView()
    {
        OrderBAL balOrder = new OrderBAL();
        DataTable dtOrder = new DataTable();

        dtOrder = balOrder.SelectAll();

        if (dtOrder.Rows.Count > 0 && dtOrder != null)
        {
            gvOrder.DataSource = dtOrder;
            gvOrder.DataBind();
        }
    }
    #endregion

    #region Order Row DataBound
    protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }
    #endregion

    #region Order RowCommand
    protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PrintRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect("~/AdminPanel/User/OrderPrint.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }
    }
    #endregion
}