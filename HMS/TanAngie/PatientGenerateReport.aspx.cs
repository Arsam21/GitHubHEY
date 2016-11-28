using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffManagement
{
    public partial class PatientGenerateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMonthYear.Text = ddlMonth.SelectedItem.Value + ddlYear.SelectedItem.Value;
            lblMonth.Text = ddlMonth.SelectedItem.Text;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCount;
            SqlCommand cmdCount;
            strCount = "Select Count(VisitationID) From Visitation Where Substring(VisitationDate,4,7) = '"+ ddlMonth.SelectedItem.Value + ddlYear.SelectedItem.Value + "'";
            cmdCount = new SqlCommand(strCount, conDatabase);
            lblCountByMonth.Text = Convert.ToString(cmdCount.ExecuteScalar());
            conDatabase.Close();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCount;
            SqlCommand cmdCount;
            strCount = "Select Count(VisitationID) From Visitation Where Substring(VisitationDate,7,4) = '"+ddlYear.SelectedItem.Value+"'";
            cmdCount = new SqlCommand(strCount, conDatabase);
            lblCountByYear.Text = Convert.ToString(cmdCount.ExecuteScalar());
            conDatabase.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}