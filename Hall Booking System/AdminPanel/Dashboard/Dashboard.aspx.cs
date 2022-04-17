using HallBookingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Dashboard_Dashboard : System.Web.UI.Page
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
            FillCardView();
        }
        ShowChartData();
    }
    #endregion

    #region Fill Card View
    protected void FillCardView()
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        ManagerBAL balManager = new ManagerBAL();
        HallBAL balHall = new HallBAL();
        DataTable dataTable = new DataTable();

        dataTable = balAdminDetails.SelectAll();
        lblTotalAdmin.Text = dataTable.Rows.Count.ToString();

        dataTable = balUserDetails.SelectAll();
        lblTotalUser.Text = dataTable.Rows.Count.ToString();

        dataTable = balManager.SelectAll();
        lblTotalManager.Text = dataTable.Rows.Count.ToString();

        dataTable = balHall.SelectAll();
        lblTotalHall.Text = dataTable.Rows.Count.ToString();
    }
    #endregion

    #region Show Chart Data
    private void ShowChartData()
    {
        OrderBAL balOrder = new OrderBAL();
        DataTable dtOrder = new DataTable();

        dtOrder = balOrder.SelectAll();

        int count = 0;
        int arrayCount = 0;

        DateTime currentDate = System.DateTime.Now.Date;
        DateTime lastWeekdate = currentDate.AddDays(-13);

        int[] data = new int[14];
        string[] label = new string[14];

        while (lastWeekdate <= currentDate)
        {
            foreach (DataRow row in dtOrder.Rows)
            {
                DateTime dataTabelDate = Convert.ToDateTime(row["BookingDate"].ToString());

                if (dataTabelDate == lastWeekdate)
                {
                    count++;
                }
            }
            label[arrayCount] = lastWeekdate.ToShortDateString().ToString();
            data[arrayCount] = count;
            count = 0;
            arrayCount++;
            lastWeekdate = lastWeekdate.AddDays(1);
        }

        if (dtOrder != null)
        {
            String chart = "";
            chart = "<canvas id=\"line-chart\" width =\"100%\" height=\"40%\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"line-chart\"), {type: 'line', data:{labels: [";

            // more details in x-axis
            for (int i = 0; i < 14; i++)
            {
                chart += "\"" + string.Format("{0}", label[i]) + "\",";
            }
            chart = chart.Substring(0, chart.Length - 1);

            chart += "],datasets: [{label:'No of Order', data: [";

            // put data from database to chart
            String value = "";
            for (int i = 0; i < 14; i++)
            {
                value += data[i] + ",";
            }
            value = value.Substring(0, value.Length - 1);

            chart += value;

            chart += "],borderColor: \"#3e95cd\",fill: false,tension: 0.1}";
            chart += @"]}";
            chart += "});";
            chart += "</script>";
            ltChart.Text = chart;
        }
    }
    #endregion
}