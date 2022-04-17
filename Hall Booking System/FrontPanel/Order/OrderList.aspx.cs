using HallBookingSystem.BAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Order_OrderList : System.Web.UI.Page
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
            FillOrderListGridView();
        }
        FillCardView();
    }
    #endregion

    #region Fill CardView
    protected void FillCardView()
    {
        OrderBAL balOrder = new OrderBAL();
        DataTable dtOrder = new DataTable();

        dtOrder = balOrder.SelectAllByUserID(Convert.ToInt32(Session["UserID"].ToString()));

        int totalOrder = dtOrder.Rows.Count;
        int totalAmount = 0;
        int completedOrder = 0;
        int pendingOrder = 0;

        if (dtOrder.Rows.Count > 0 && dtOrder != null)
        {
            foreach (DataRow rows in dtOrder.Rows)
            {
                totalAmount += Convert.ToInt32(rows["TotalAmount"].ToString());

                if ((rows["Status"].ToString()) == "Completed")
                {
                    completedOrder++;
                }
                else if ((rows["Status"].ToString()) == "Pending")
                {
                    pendingOrder++;
                }
            }
        }

        lblTotalOrders.Text = totalOrder.ToString();
        if (totalAmount == 0)
            lblTotalAmount.Text = "0";
        else
            lblTotalAmount.Text = string.Format("{0:#,#}", totalAmount);
        lblCompletedOrder.Text = completedOrder.ToString();
        lblPendingOrder.Text = pendingOrder.ToString();
    }
    #endregion

    #region Fill OrderList View
    private void FillOrderListGridView()
    {
        OrderBAL balOrder = new OrderBAL();
        DataTable dtOrder = new DataTable();

        dtOrder = balOrder.SelectAllByUserID(Convert.ToInt32(Session["UserID"].ToString()));

        if (dtOrder != null && dtOrder.Rows.Count > 0)
        {
            gvOrder.DataSource = dtOrder;
            gvOrder.DataBind();
        }
        else
        {
            gvOrder.DataSource = null;
            gvOrder.DataBind();
        }
    }
    #endregion

    #region Button Edit Or Delete Or Print Click
    protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            OrderBAL balOrder = new OrderBAL();

            if (balOrder.DeleteByUserID(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
            {
                FillCardView();
                FillOrderListGridView();
            }
            else
            {
                lblErrorMessage.Text = balOrder.Message;
            }
        }

        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString());
            }
        }

        if (e.CommandName == "PrintRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString());
            }
        }
    }
    #endregion

    #region Order Row Data Bound
    protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.TableSection = TableRowSection.TableHeader;
        }

        foreach (GridViewRow gridViewRow in gvOrder.Rows)
        {
            DateTime todayDate = DateTime.Today.Date;
            DateTime endDate = Convert.ToDateTime(gridViewRow.Cells[3].Text.ToString());
            if (endDate < todayDate)
            {
                gridViewRow.Cells[8].Text = "<a href=\"../ContactUs.aspx\">Contact Us</a>";
            }
            else
            {
                gridViewRow.Cells[7].Text = "...";
            }
        }
        //e.Row.Cells[6].Text = "<span class=\"badge-success badge\">" + e.Row.Cells[6].Text + "</span>";
    }
    #endregion
}