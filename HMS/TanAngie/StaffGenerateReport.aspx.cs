using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class StaffGenerateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countTotal = 0;
            int countActived = 0;
            int countNonActive = 0;
            int countDoctor = 0;
            int countNurse = 0;
            int countClerk = 0;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strGet;
            SqlCommand cmdGet;
            strGet = "Select * From Staff Where DepartmentID = @DepartmentID";
            cmdGet = new SqlCommand(strGet, conDatabase);
            cmdGet.Parameters.AddWithValue("@DepartmentID", ddlDepartment.SelectedItem.Value);
            SqlDataReader dtr;
            dtr = cmdGet.ExecuteReader();
            using (dtr)
            {
                while (dtr.Read())
                {
                    if (dtr["StaffStatus"].ToString().Equals("Active"))
                        countActived += 1;
                    else
                        countNonActive += 1;
                    if (dtr["Position"].ToString().Equals("Doctor"))
                        countDoctor += 1;
                    else if (dtr["Position"].ToString().Equals("Nurse"))
                        countNurse += 1;
                    else if (dtr["Position"].ToString().Equals("Clerk"))
                        countClerk += 1;
                    else if (dtr["Position"].ToString().Equals("Manager"))
                        lblManagerName.Text = dtr["StaffName"].ToString();
                    countTotal += 1;
                }
            }
            conDatabase.Close();
            dtr.Close();
            lblActive.Text = "" + countActived;
            lblClerk.Text = "" + countClerk;
            lblNonActive.Text = "" + countNonActive;
            lblNurse.Text = "" + countNurse;
            lblTotal.Text = "" + countTotal;
            lblDoctor.Text = "" + countDoctor;
        }
    }
}