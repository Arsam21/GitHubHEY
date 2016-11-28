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
    public partial class ReportAppointment : System.Web.UI.Page
    {
        static int totalCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Step 1: Create and Open Connection
            SqlConnection conHMS;
            String connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            String strAppointment ,strRetrieve;
            SqlCommand cmdAppointment, cmdRetrieve;
            SqlDataReader dtr, dtr2;

            //getPatientID
            strAppointment = "SELECT P.PatientID, P.PatientName, P.PatientContactNo, A.AppointmentType, A.AppointmentDate, A.AppointmentTime " +
                             "FROM Patient P, Appointment A " +
                             "WHERE P.PatientID = A.PatientID Order by AppointmentType";

            strRetrieve = "SELECT DISTINCT SUBSTRING(AppointmentDate,4,2) AS Month, SUBSTRING(AppointmentDate,7,4) AS Year FROM Appointment";

            cmdAppointment = new SqlCommand(strAppointment, conHMS);
            dtr = cmdAppointment.ExecuteReader();
            gridViewReport.DataSource = dtr;
            gridViewReport.DataBind();
            dtr.Close();

            totalCount = gridViewReport.Rows.Count;
            lblTotal.Text = "Total Appointment : " + totalCount;

            cmdRetrieve = new SqlCommand(strRetrieve, conHMS);
            if (!IsPostBack)
            {
                dtr2 = cmdRetrieve.ExecuteReader();
                ddlMonth.DataSource = dtr2;
                ddlMonth.DataTextField = "Month";
                //ddlMonth.DataValueField = "AppointmentDate";
                ddlMonth.DataBind();
                dtr2.Close();
            }

            cmdRetrieve = new SqlCommand(strRetrieve, conHMS);
            if (!IsPostBack)
            {
                string[] store = new string[100];
                int i = 0;
                dtr2 = cmdRetrieve.ExecuteReader();
                while (dtr2.Read())
                {

                    store[i] = dtr2["Year"].ToString();
                    i++;
                }
                int count = 0;
                string[] store2 = new string[i];
                for(int a = 0 ; a < store.Length ;a++){
                    for (int b = 0; b < store2.Length; b++)
                    {
                        if (store[a] == store2[b])
                        {
                            b = store2.Length;
                        }
                        else if(b == store2.Length-1)
                        {
                            store2[count] = store[a];
                            count++;
                        }
                    }
                }

                for (int j = 0; j < store2.Length; j++)
                {
                    if (store2[j] != null && store2[j] != "")
                    {
                        ddlYear.Items.Insert(j, new ListItem(store2[j]));
                    }
                }
                
               // ddlYear.DataSource = dtr2;
                //ddlYear.DataTextField = "Year";
                //ddlYear.DataValueField = "year";
               // ddlYear.DataBind();
                dtr2.Close();
            }
        }


        protected void btnGenerate_Click1(object sender, EventArgs e)
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
                             "WHERE P.PatientID = A.PatientID AND " +
                             " SUBSTRING(A.AppointmentDate,4,2) = '" + ddlMonth.SelectedItem.Text + "'" + " AND " +
                             " SUBSTRING(A.AppointmentDate,7,4) = '" + ddlYear.SelectedItem.Text + "' Order by A.AppointmentType";

            cmdAppointment = new SqlCommand(strAppointment, conHMS);
            //cmdAppointment.Parameters.AddWithValue("@LoginID", UserName);

            dtr = cmdAppointment.ExecuteReader();

            gridViewReport.DataSource = dtr;
            gridViewReport.DataBind();

            totalCount = gridViewReport.Rows.Count;

            dtr.Close();

            string month = null;
            if (ddlMonth.SelectedItem.Text.Equals("01"))
            {
                month = "January";
            }
            if (ddlMonth.SelectedItem.Text.Equals("02"))
            {
                month = "February";
            }
            if (ddlMonth.SelectedItem.Text.Equals("03"))
            {
                month = "March";
            }
            if (ddlMonth.SelectedItem.Text.Equals("04"))
            {
                month = "April";
            }
            if (ddlMonth.SelectedItem.Text.Equals("05"))
            {
                month = "May";
            }
            if (ddlMonth.SelectedItem.Text.Equals("06"))
            {
                month = "June";
            }
            if (ddlMonth.SelectedItem.Text.Equals("07"))
            {
                month = "July";
            }
            if (ddlMonth.SelectedItem.Text.Equals("08"))
            {
                month = "August";
            }
            if (ddlMonth.SelectedItem.Text.Equals("09"))
            {
                month = "September";
            }
            if (ddlMonth.SelectedItem.Text.Equals("10"))
            {
                month = "October";
            }
            if (ddlMonth.SelectedItem.Text.Equals("11"))
            {
                month = "November";
            }
            if (ddlMonth.SelectedItem.Text.Equals("12"))
            {
                month = "December";
            }

            lblTitle.Text = "Total Appointment for " + month + " of " + ddlYear.SelectedItem.Text;
            lblTotal.Text = "Total Appointment : " + totalCount;
        }
    }
}