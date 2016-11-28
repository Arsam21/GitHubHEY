using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMS
{
    public partial class ReportAppointment2 : System.Web.UI.Page
    {
        static int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strAppointment;
            SqlCommand cmdAppointment;
            SqlDataReader dtr;
            //getPatientID
            strAppointment = "SELECT P.PatientID, P.PatientName, P.PatientContactNo, A.AppointmentType, A.AppointmentDate, A.AppointmentTime " +
                             "FROM Patient P, Appointment A " +
                             "WHERE P.PatientID = A.PatientID AND A.AppointmentStatus ='" + ddlType.SelectedItem.Text + "' Order by AppointmentType";

            cmdAppointment = new SqlCommand(strAppointment, conHMS);
            dtr = cmdAppointment.ExecuteReader();
            gridViewReport.DataSource = dtr;
            gridViewReport.DataBind();
            dtr.Close();

            totalCount = gridViewReport.Rows.Count;
            lblTotal.Text = "Total Appointment : " + totalCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strAppointment;
            SqlCommand cmdAppointment;
            SqlDataReader dtr;

            strAppointment = "SELECT P.PatientID, P.PatientName, P.PatientContactNo, A.AppointmentType, A.AppointmentDate, A.AppointmentTime " +
                             "FROM Patient P, Appointment A " +
                             "WHERE P.PatientID = A.PatientID AND A.AppointmentStatus ='" + ddlType.SelectedItem.Text + "' Order by AppointmentType";

            cmdAppointment = new SqlCommand(strAppointment, conHMS);

            dtr = cmdAppointment.ExecuteReader();

            gridViewReport.DataSource = dtr;
            gridViewReport.DataBind();

            totalCount = gridViewReport.Rows.Count;
            dtr.Close();

            lblTotal.Text = "Total Appointment : " + totalCount;
        }
    }
}