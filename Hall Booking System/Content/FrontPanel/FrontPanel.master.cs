using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_FrontPanel_FrontPanel : System.Web.UI.MasterPage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillControls();
        }
        ActiveSlidebar();
    }
    #endregion

    #region Active Slidebar
    protected void ActiveSlidebar()
    {
        String activepage = Request.RawUrl;
        if (activepage.Contains("UserHome.aspx"))
        {
            liUserHome.Attributes["class"] = "sidebar-item active";
        }
        else if (activepage.Contains("HallList.aspx"))
        {
            liHallList.Attributes["class"] = "sidebar-item active";
        }
        else if (activepage.Contains("OrderList.aspx"))
        {
            liOrderList.Attributes["class"] = "sidebar-item active";
        }
    }
    #endregion

    #region Fill Controls
    protected void FillControls()
    {
        if (Session["UserID"] != null)
        {
            lblUserName.Text = Session["UserDisplayName"].ToString();
            imgUserImage.ImageUrl = Session["UserPhotoPath"].ToString();
        }
    }
    #endregion

    #region Link Logout Click
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Session.Clear();
            Response.Redirect("~/FrontPanel/Authorization/UserLogin.aspx");
        }
    }
    #endregion
}
