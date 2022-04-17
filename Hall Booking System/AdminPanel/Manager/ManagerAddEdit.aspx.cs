using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Manager_ManagerAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["ManagerID"] == null)
            {
                lblPageHeader.Text = "Manager Add";
                lblNavigationHeader.Text = "ManagerAdd";
            }
            else
            {
                lblPageHeader.Text = "Manager Edit";
                lblNavigationHeader.Text = "ManagerEdit";
                FillControls(Convert.ToInt32(Request.QueryString["ManagerID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Controls
    private void FillControls(SqlInt32 ManagerID)
    {
        ManagerBAL balManager = new ManagerBAL();
        ManagerENT entManager = new ManagerENT();

        entManager = balManager.SelectByPK(ManagerID);

        if (!entManager.ManagerName.IsNull)
            txtManagerName.Text = entManager.ManagerName.Value.ToString();

        if (!entManager.ManagerEmail.IsNull)
            txtEmail.Text = entManager.ManagerEmail.Value.ToString();

        if (!entManager.ManagerPhoneNo.IsNull)
            txtPhoneNo.Text = entManager.ManagerPhoneNo.Value.ToString();

        if (!entManager.ManagerSalary.IsNull)
            txtSalary.Text = entManager.ManagerSalary.Value.ToString();

        if (!entManager.ManagerGender.IsNull)
        {
            if (entManager.ManagerGender.Value.ToString() == "Male")
                rbMale.Checked = true;

            if (entManager.ManagerGender.Value.ToString() == "Female")
                rbFemale.Checked = true;
        }
    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        txtManagerName.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtSalary.Text = "";
        rbMale.Checked = true;

        txtManagerName.Focus();
    }
    #endregion

    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Manager/ManagerList.aspx");
    }
    #endregion

    #region Button Save Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strErrorMsg = "";

        if (txtManagerName.Text == "")
            strErrorMsg += "Enter Manager Name</br>";

        if (txtEmail.Text == "")
            strErrorMsg += "Enter Email</br>";

        if (txtPhoneNo.Text == "")
            strErrorMsg += "Enter Phone No</br>";

        if (rbMale.Checked == false && rbFemale.Checked == false)
            strErrorMsg += "Select Gender";

        if (txtSalary.Text == "")
            strErrorMsg += "Enter Salary";

        if (strErrorMsg.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMsg.ToString().Trim();
            return;
        }
        #endregion

        #region Collect Date
        ManagerENT entManager = new ManagerENT();

        if (txtManagerName.Text != "")
            entManager.ManagerName = txtManagerName.Text.Trim().ToString();

        if (txtEmail.Text != "")
            entManager.ManagerEmail = txtEmail.Text.Trim().ToString();

        if (txtPhoneNo.Text != "")
            entManager.ManagerPhoneNo = txtPhoneNo.Text.Trim().ToString();

        if (txtSalary.Text != "")
            entManager.ManagerSalary = Convert.ToInt32(txtSalary.Text.Trim().ToString());

        if (rbMale.Checked == true)
            entManager.ManagerGender = "Male";

        if (rbFemale.Checked == true)
            entManager.ManagerGender = "Female";
        #endregion

        ManagerBAL balManager = new ManagerBAL();

        if (Request.QueryString["ManagerID"] == null)
        {
            if (balManager.Insert(entManager))
            {
                lblSuccess.Text = "Data Insert Successfully...";
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balManager.Message;
            }
        }
        else
        {
            entManager.ManagerID = Convert.ToInt32(Request.QueryString["ManagerID"]);

            if (balManager.Update(entManager))
            {
                Response.Redirect("~/AdminPanel/Manager/ManagerList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balManager.Message;
            }
        }
    }
    #endregion
}