using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Manager_ManagerList : System.Web.UI.Page
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
            FillManagerGridView();
        }
    }
    #endregion

    #region Fill Manager Grid View
    private void FillManagerGridView()
    {
        ManagerBAL balManager = new ManagerBAL();
        DataTable dtManager = new DataTable();

        dtManager = balManager.SelectAll();

        if (dtManager.Rows.Count > 0 && dtManager != null)
        {
            gvManager.DataSource = dtManager;
            gvManager.DataBind();
        }
        else
        {
            gvManager.DataSource = null;
            gvManager.DataBind();
        }
    }
    #endregion

    #region Button Add Manager Click
    protected void btnAddManager_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Manager/ManagerAddEdit.aspx");
    }
    #endregion

    #region Button Delete or Edit Click
    protected void gvManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ManagerBAL balManager = new ManagerBAL();
                if (balManager.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FillManagerGridView();
                }
                else
                {
                    lblErrorMessage.Text = balManager.Message;
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

    #region Manager Row DataBound
    protected void gvManager_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}