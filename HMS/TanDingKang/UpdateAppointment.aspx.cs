using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HMS
{
    public partial class UpdateAppointment : System.Web.UI.Page
    {
        //static string appoinmentID = null;
        //static string staffName = null;
        //static string appointmentType = null;
        //static string appointmentStatus = null;

        ////isPostBack crosspage
        //static System.Web.UI.WebControls.Label appID;
        //static System.Web.UI.WebControls.Label appType;
        //static System.Web.UI.WebControls.Label doctorName;
        //static System.Web.UI.WebControls.Label appDate;
        //static System.Web.UI.WebControls.Label appTime;
        //static System.Web.UI.WebControls.Label appStatus;

        static string generalDepartmentID = "DP003";
        static string checkUpDepartmentID = "DP002";
        static string departmentID = null;
        static string doctor = null;

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
            String UserName = Session["LoginID"].ToString();
            lblUserName.Text = UserName;
            Session["LoginID"] = Session["LoginID"].ToString();

            DoctorName = Session["DoctorName"].ToString();
            lblDoctorName.Text = DoctorName;
            Session["DoctorName"] = Session["DoctorName"].ToString();

            AppointmentID = Session["AppointmentID"].ToString();
            //lblID.Text = AppointmentID;
            Session["AppointmentID"] = Session["AppointmentID"].ToString();

            AppointmentType = Session["AppointmentType"].ToString();
            lblAppointmentType.Text = AppointmentType;
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

            //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
            //{
            //    appID = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblAppointmentID"));
            //    doctorName = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblDoctorName"));
            //    appType = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblAppointmentType"));
            //    appDate = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblDate"));
            //    appTime = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblTime"));
            //    appStatus = ((System.Web.UI.WebControls.Label)PreviousPage.FindControl("lblStatus"));

            //    staffName = doctorName.Text;
            //    appoinmentID = appID.Text;
            //    appointmentType = appType.Text;
            //    appointmentStatus = appStatus.Text;

            //    lblAppointmentType.Text = appointmentType;
            //    lblDoctorName.Text = staffName;
            //    lblDate.Text = appDate.Text;
            //    lblTime.Text = appTime.Text;
            //    lblStatus.Text = appStatus.Text;
            //}


            if (AppointmentStatus.Equals("Cancelled"))
            {
                Calendar1.Enabled = false;
                txtDate.Enabled = false;
                ddlTime.Enabled = false;
                btnConfirm.Enabled = false;
            }

            if (AppointmentType.Equals("General"))
            {
                departmentID = generalDepartmentID.ToString();
            }
            if (AppointmentType.Equals("Checkup"))
            {
                departmentID = checkUpDepartmentID.ToString();
            }

            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strSchedule, strDay, strTime, strDoctorName;
            SqlCommand cmdSchedule, cmdDay, cmdTime, cmdDoctorName;
            SqlDataReader dtr, dtr2, dtr3, dtr4;

            strSchedule = "SELECT DISTINCT WS.WorkDay AS 'Work Day', T.ShiftTime AS 'Shift Time' FROM WorkingSchedule WS , Time T, Staff S " +
                           "WHERE T.TimeID = WS.TimeID AND " +
                           "WS.StaffID = S.StaffID AND " +
                           "S.StaffName = '" + DoctorName + "'";

            //strDay = "SELECT DISTINCT WS.WorkDay AS 'Work Day' FROM WorkingSchedule WS , Time T, Staff S " +
            //               "WHERE WS.StaffID = S.StaffID AND " +
            //               "S.StaffName = '" + staffName + "'";

            strTime = "SELECT DISTINCT WS.WorkDay AS 'Work Day', T.ShiftTime AS 'Shift Time' FROM WorkingSchedule WS , Time T, Staff S " +
                           "WHERE T.TimeID = WS.TimeID AND " +
                           "WS.StaffID = S.StaffID AND " +
                           "S.StaffName = '" + DoctorName + "'";

            //strDoctorName = "SELECT StaffName FROM Staff WHERE Position = 'Doctor' AND " +
            //                "DepartmentID = '" + departmentID + "'";

            cmdSchedule = new SqlCommand(strSchedule, conHMS);
            dtr = cmdSchedule.ExecuteReader();
            ScheduleTime.DataSource = dtr;
            ScheduleTime.DataBind();
            dtr.Close();

            //cmdDate = new SqlCommand(strDate, conHMS);
            //dtr2 = cmdDate.ExecuteReader();
            //ddlDay.DataSource = dtr2;
            //ddlDay.Items.Add("");
            //ddlDay.DataValueField = "Work Day";
            //ddlDay.DataTextField = "Work Day";
            //ddlDay.DataBind();
            //dtr2.Close();

            cmdTime = new SqlCommand(strTime, conHMS);
            if (!IsPostBack)
            {
                dtr3 = cmdTime.ExecuteReader();
                ddlWSTime.DataSource = dtr3;
                //ddlTime.Items.Add("");
                //ddlTime.DataValueField = "Shift Time";
                ddlWSTime.DataTextField = "Shift Time";
                ddlWSTime.DataBind();
                dtr3.Close();
            }

            cmdTime = new SqlCommand(strTime, conHMS);
            if (!IsPostBack)
            {
                dtr3 = cmdTime.ExecuteReader();
                ddlWSDay.DataSource = dtr3;
                //ddlTime.Items.Add("");
                //ddlTime.DataValueField = "Shift Time";
                ddlWSDay.DataTextField = "Shift Time";
                ddlWSDay.DataBind();
                dtr3.Close();
            }
            //cmdDoctorName = new SqlCommand(strDoctorName, conHMS);
            //dtr4 = cmdDoctorName.ExecuteReader();
            //ddlDoctorName.DataSource = dtr4;
            //ddlDoctorName.DataValueField = "StaffName";
            //ddlDoctorName.DataTextField = "StaffName";
            //ddlDoctorName.DataBind();
            //dtr4.Close();

            //conHMS.Close();
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");

            TextBox1.Text = Calendar1.SelectedDate.DayOfWeek.ToString();

            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strTime;
            SqlCommand cmdTime;
            SqlDataReader dtr;

            strTime = "SELECT DISTINCT WS.WorkDay AS 'Work Day', T.ShiftTime AS 'Shift Time' FROM WorkingSchedule WS , Time T, Staff S " +
                           "WHERE T.TimeID = WS.TimeID AND " +
                           "WS.StaffID = S.StaffID AND " +
                           "WS.WorkDay = '" + TextBox1.Text + "'" + " AND " +
                           "S.StaffName = '" + lblDoctorName.Text + "'";

            cmdTime = new SqlCommand(strTime, conHMS);
            //if (!IsPostBack)
            //{
            dtr = cmdTime.ExecuteReader();
            ddlTime.DataSource = dtr;
            ddlTime.Items.Add("");
            //ddlTime.DataValueField = "Work Day";
            ddlTime.DataTextField = "Shift Time";
            ddlTime.DataBind();
            dtr.Close();
            //}
        }
        //disable previous date
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
            }

            //if (e.Day.Equals(ddlWSDay.Text))
            //{
            //    e.Day.IsSelectable = true;
            //}

            if (e.Day.Date > (System.DateTime.Now.AddDays(30)))
            {
                e.Day.IsSelectable = false;
                e.Cell.Font.Strikeout = true;
            }
            
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to update the appointment?", "Update Appointment", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Step 1: Create and Open Connection
                SqlConnection conHMS;
                String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conHMS = new SqlConnection(connStr);
                conHMS.Open();

                String strUpdate;
                SqlCommand cmdUpdate;
                SqlDataReader dtr;

                strUpdate = "UPDATE Appointment SET AppointmentDate = @AppointmentDate, AppointmentTime = @AppointmentTime " +
                            "WHERE AppointmentID = '" + AppointmentID + "'";

                cmdUpdate = new SqlCommand(strUpdate, conHMS);
                cmdUpdate.Parameters.AddWithValue("@AppointmentDate", txtDate.Text);
                cmdUpdate.Parameters.AddWithValue("@AppointmentTime", ddlTime.SelectedItem.Value.ToString());

                //int n = cmdUpdate.ExecuteNonQuery();
                //if (n > 0)
                //    MessageBox.Show("Appointment details update successfully");
                //else
                //    MessageBox.Show("Sorry, updated failed.");

                dtr = cmdUpdate.ExecuteReader();
                dtr.Close();
                conHMS.Close();
                MessageBox.Show("Your appointment have been update successful.");
                Response.Redirect("~/TanDingKang/AppointmentHomePage.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Sorry, update failed.");
                Response.Redirect("~/TanDingKang/AppointmentHomePage.aspx");
            }
        }
    }
}