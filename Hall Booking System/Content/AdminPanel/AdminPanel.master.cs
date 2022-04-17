using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AdminPanel_AdminPanel : System.Web.UI.MasterPage
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
        string liClass = "sidebar-item active";
        string activepage = Request.RawUrl;

        if (activepage.Contains("Dashboard.aspx"))
        {
            liDashboard.Attributes["class"] = liClass;
        }
        if (activepage.Contains("AdminHome.aspx"))
        {
            liProfile.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("CityList.aspx"))
        {
            liCity.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("AreaList.aspx"))
        {
            liArea.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("HallList.aspx"))
        {
            liHall.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("HallPhotosList.aspx"))
        {
            liHallPhotos.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("ManagerList.aspx"))
        {
            liManager.Attributes["class"] = liClass;
        }
        else if (activepage.Contains("OrderList.aspx"))
        {
            liOrder.Attributes["class"] = liClass;
        }
    }
    #endregion

    #region Fill Controls
    protected void FillControls()
    {
        lblAdminName.Text = Session["AdminDisplayName"].ToString();
        imgAdminImage.ImageUrl = Session["AdminPhotoPath"].ToString();
    }
    #endregion

    #region Link Logout Click
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            Session.Clear();
            Response.Redirect("~/AdminPanel/Authorization/AdminLogin.aspx");
        }
    }
    #endregion
}
