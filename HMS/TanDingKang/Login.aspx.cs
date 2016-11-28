using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strRetrieve;
            SqlCommand cmdRetrieve;
            SqlDataReader dtr;
            strRetrieve = "SELECT LoginID , LoginPW FROM Login WHERE LoginID = '" + txtUserName.Text.Trim().Replace("'", "''") + "' and LoginPW = '" + txtPw.Text.Trim().Replace("'", "''") + "'";

            cmdRetrieve = new SqlCommand(strRetrieve, conHMS);
            dtr = cmdRetrieve.ExecuteReader();

            if (dtr.Read())
            {
                Session["LoginID"] = txtUserName.Text;
                //redirect to other page
                Response.Redirect("~/TanDingKang/AppointmentHomePage.aspx");
                //Response.Redirect("AddAppointment.aspx");

                //To redirect users to another page by using a server-side method
                //Server.Transfer("Page2.aspx", true);
            }
            else
            {
                MessageBox.Show("Please check User Name and Password");
                txtUserName.Focus();
            }
        }
    }
}