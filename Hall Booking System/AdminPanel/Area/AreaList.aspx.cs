using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Area_AreaList : System.Web.UI.Page
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
            FillAreaGridView();
        }
    }
    #endregion

    #region Fill Area Grid View
    private void FillAreaGridView()
    {
        AreaBAL balArea = new AreaBAL();
        DataTable dtArea = new DataTable();

        dtArea = balArea.SelectAll();

        if (dtArea != null && dtArea.Rows.Count > 0)
        {
            gvArea.DataSource = dtArea;
            gvArea.DataBind();
        }
        else
        {
            gvArea.DataSource = null;
            gvArea.DataBind();
        }
    }
    #endregion

    #region Button AddArea Click
    protected void btnAddArea_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Area/AreaAddEdit.aspx");
    }
    #endregion

    #region Button Delete or Edit Click
    protected void gvArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                AreaBAL balArea = new AreaBAL();
                if (balArea.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillAreaGridView();
                }
                else
                {
                    lblErrorMessage.Text = balArea.Message;
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

    #region Area Row DataBound
    protected void gvArea_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}