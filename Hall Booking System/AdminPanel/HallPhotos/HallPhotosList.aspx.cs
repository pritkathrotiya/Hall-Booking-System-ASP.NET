using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_HallPhotos_HallPhotosList : System.Web.UI.Page
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
            FillControls();
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls()
    {
        HallBAL balHall = new HallBAL();
        DataTable dtHall = new DataTable();

        dtHall = balHall.SelectAll();

        if (dtHall != null && dtHall.Rows.Count > 0)
        {
            rptHallPhotos.DataSource = dtHall;
            rptHallPhotos.DataBind();
        }
    }
    #endregion

    #region Button More Photos Click
    protected void rptHallPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "MorePhotos")
            Response.Redirect(e.CommandArgument.ToString());
    }
    #endregion
}