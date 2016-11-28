using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HMS
{
    public partial class PrescriptionHomePage : System.Web.UI.Page
    {
        SqlConnection conHMS;
        HttpCookie cookies = new HttpCookie("Visitation");

        protected void Page_Load(object sender, EventArgs e)
        {
             

             try
             {
                 HttpCookie cookie = Request.Cookies["Login"];
                 string ID = cookie["loginFieldID"];

                 //HttpCookie cookie = Request.Cookies["Login"];
                 Session["LoginID"] = cookie["loginID"];
                 if (cookie["loginRole"].Equals("Doctor"))
                 {
                     //Add.Enabled = true;
                     //Update.Enabled = true;
                     //Delete.Enabled = true;
                     //View.Enabled = true;

                     Report1.Enabled = false;
                     Report2.Enabled = false;
                     StaffView.Enabled = false;

                     /*Step 1: Create and Open Connection*/
                     string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                     conHMS = new SqlConnection(connStr);
                     conHMS.Open();


                     /*Step2 : SQL Command object to retrieve data from table*/

                     string strDisplayDocHandleVitDetails;
                     SqlCommand cmdDisplayDocHandleVitDetails;
                     strDisplayDocHandleVitDetails = "Select Visitation.VisitationID, Visitation.MedicalCondition From Visitation, Patient, Staff " +
                         "WHERE Staff.StaffID ='" + ID.ToString() + "'" +
                         "AND Staff.StaffID = Visitation.StaffID AND Visitation.PatientID = Patient.PatientID AND Patient.PatientStatus IS NULL";
                     cmdDisplayDocHandleVitDetails = new SqlCommand(strDisplayDocHandleVitDetails, conHMS);

                     /*Step 3: Execute command to retrieve data*/

                     SqlDataReader drDisplayDocHandleVitDetails;
                     drDisplayDocHandleVitDetails = cmdDisplayDocHandleVitDetails.ExecuteReader();


                     /*Step 4: Bind data*/
                     if (!IsPostBack)
                     {
                         if (drDisplayDocHandleVitDetails.HasRows)
                         {
                             GridView1.DataSource = drDisplayDocHandleVitDetails;
                             GridView1.DataBind();
                         }
                         else
                         {
                             MessageBox.Show("You are not handle any Prescription.");
                         }
                     }
                     /*Step 5: Close SqlReader and Database connection*/
                     drDisplayDocHandleVitDetails.Close();
                     conHMS.Close();
                 }
                 else if (cookie["loginRole"].Equals("Staff"))
                 {
                     Add.Enabled = false;
                     Update.Enabled = false;
                     Delete.Enabled = false;
                     View.Enabled = false;

                     Report1.Enabled = false;
                     Report2.Enabled = false;
                     StaffView.Enabled = true;
                 }
                 else if (cookie["loginRole"].Equals("Admin"))
                 {
                     Add.Enabled = false;
                     Update.Enabled = false;
                     Delete.Enabled = false;
                     View.Enabled = false;

                     Report1.Enabled = true;
                     Report2.Enabled = true;
                     StaffView.Enabled = false;
                 }
                 else if (cookie["loginRole"].Equals("Patient"))
                 {
                     Add.Enabled = false;
                     Update.Enabled = false;
                     Delete.Enabled = false;
                     View.Enabled = false;

                     Report1.Enabled = false;
                     Report2.Enabled = false;
                     StaffView.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Please Login First");
                 Response.Redirect("~/TanAngie/LoginPage.aspx");
             }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string visitation = GridView1.SelectedRow.Cells[1].Text;
            cookies["VisitationID"] = visitation.ToString();
            Response.Cookies.Add(cookies);
            Add.Enabled = true;
            Delete.Enabled = true;
            Update.Enabled = true;
            View.Enabled = true;

        }

    }
}