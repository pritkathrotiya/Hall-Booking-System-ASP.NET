using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Hall_HallList : System.Web.UI.Page
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
            FillControls("name");
        }
    }
    #endregion

    #region FillControls
    private void FillControls(String sortBy)
    {
        HallBAL balHall = new HallBAL();
        DataTable dtHall = new DataTable();

        if (sortBy == "name")
        {
            dtHall = balHall.SelectAll();
        }
        else if (sortBy == "price")
        {
            dtHall = balHall.SelectAllSortByPrice();
        }
        else if (sortBy == "people")
        {
            dtHall = balHall.SelectAllSortByPeople();
        }
        else if (sortBy == "vechile")
        {
            dtHall = balHall.SelectAllSortByVechile();
        }

        if (dtHall.Rows.Count > 0 && dtHall != null)
        {
            rpHallList.DataSource = dtHall;
            rpHallList.DataBind();
        }
    }
    #endregion

    #region Button More Info or Book Now Click
    protected void rpHallList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "MoreInfo")
        {
            Response.Redirect(e.CommandArgument.ToString().Trim());
        }
        if (e.CommandName == "BookHall")
        {
            Response.Redirect(e.CommandArgument.ToString().Trim());
        }
    }
    #endregion

    #region Sort Selected Index Change
    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillControls(ddlSort.SelectedValue);
    }
    #endregion
}