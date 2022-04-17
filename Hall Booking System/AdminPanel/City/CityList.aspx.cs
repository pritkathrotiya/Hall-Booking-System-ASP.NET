using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
            FillCityGridView();
        }
    }
    #endregion

    #region Fill City Grid View
    private void FillCityGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll();

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
        else
        {
            gvCity.DataSource = null;
            gvCity.DataBind();
        }
    }
    #endregion

    #region Button AddCity Click
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityAddEdit.aspx");
    }
    #endregion

    #region Button Delete or Edit Click
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balCity = new CityBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FillCityGridView();
                }
                else
                {
                    lblErrorMessage.Text = balCity.Message;
                }
            }
        }

        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }
    }
    #endregion

    #region City Row DataBound
    protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}