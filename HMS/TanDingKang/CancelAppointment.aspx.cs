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
    public partial class CancelAppointment : System.Web.UI.Page
    {
        //isPostBack crosspage
        static System.Web.UI.WebControls.Label doctorName;
        static System.Web.UI.WebControls.Label appID;
        static System.Web.UI.WebControls.Label appType;
        static System.Web.UI.WebControls.Label appDate;
        static System.Web.UI.WebControls.Label appTime;
        static System.Web.UI.WebControls.Label appStatus;

        static string UserName = null;

        //session
        static string DoctorName = null;
        static string AppointmentID = null;
        static string AppointmentType = null;
        static string AppointmentDate = null;
        static string AppointmentTime = null;
        static string AppointmentStatus = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }

            UserName = Session["LoginID"].ToString();
            lblUserName.Text = UserName;
            Session["LoginID"] = Session["LoginID"].ToString();


            DoctorName = Session["DoctorName"].ToString();
            lblName.Text = DoctorName;
            Session["DoctorName"] = Session["DoctorName"].ToString();

            AppointmentID = Session["AppointmentID"].ToString();
            lblID.Text = AppointmentID;
            Session["AppointmentID"] = Session["AppointmentID"].ToString();

            AppointmentType = Session["AppointmentType"].ToString();
            lblType.Text = AppointmentType;
            Session["AppointmentType"] = Session["AppointmentType"].ToString();

            AppointmentDate = Session["AppointmentDate"].ToString();
            lblDate.Text = AppointmentDate;
            Session["AppointmentDate"] = Session["AppointmentDate"].ToString();

            AppointmentTime = Session["AppointmentTime"].ToString();
            lblTime.Text = AppointmentTime;
            Session["AppointmentTime"] = Session["AppointmentTime"].ToString();

            AppointmentStatus = Session["AppointmentStatus"].ToString();
            lblStatus.Text = AppointmentStatus;
            Session["AppointmentStatus"] = Session["AppointmentStatus"].ToString();

            //if (!IsPostBack)
            //{
            //    doctorName = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblDoctorName"));
            //    appID = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblAppointmentID"));
            //    appType = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblAppointmentType"));
            //    appDate = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblDate"));
            //    appTime = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblTime"));
            //    appStatus = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblStatus"));

            //    lblName.Text = doctorName.Text;
            //    lblID.Text = appID.Text;
            //    lblType.Text = appType.Text;
            //    lblDate.Text = appDate.Text;
            //    lblTime.Text = appTime.Text;
            //    lblStatus.Text = appStatus.Text;
            //}
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure want to cancel the appointment?", "Cancel Appointment", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            DialogResult dialogResult = MessageBox.Show("Are you sure want to cancel the appointment?", "Cancel Appointment", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Step 1: Create and Open Connection
                SqlConnection conHMS;
                String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conHMS = new SqlConnection(connStr);
                conHMS.Open();

                String strCancel;
                SqlCommand cmdCancel;
                SqlDataReader dtr;
                string status = "Cancelled";

                //getPatientID
                strCancel = "UPDATE Appointment SET AppointmentStatus = @AppointmentStatus " +
                           "WHERE AppointmentID = '" + lblID.Text + "'";

                cmdCancel = new SqlCommand(strCancel, conHMS);
                cmdCancel.Parameters.AddWithValue("@AppointmentStatus", status);

                //int n = cmdCancel.ExecuteNonQuery();
                //if (n > 0)
                //    MessageBox.Show("Appointment details cancelled successfully");
                //else
                //    MessageBox.Show("Sorry, cancel failed.");

                dtr = cmdCancel.ExecuteReader();
                dtr.Close();
                conHMS.Close();
                MessageBox.Show("Your appointment have been cancel successful.");
                Response.Redirect("~/TanDingKang/AppointmentHomePage.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Sorry, cancel failed.");
                Response.Redirect("~/TanDingKang/AppointmentHomePage.aspx");
            }

            
        }
    }
}