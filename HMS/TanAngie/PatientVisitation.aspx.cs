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
    public partial class PatientVisitation : System.Web.UI.Page
    {
        static string patientid = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Patient Where PatientIC = @IC";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@IC", tbIc.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                lblWelcome.Text = "Welcome " + dtr["PatientName"].ToString();
                lblSelection.Visible = true;
                ddlServiceChoose.Visible = true;
                btnOk.Visible = true;
                lblAppointment.Visible = true;
                rblAppointment.Visible = true;
                patientid = dtr["PatientID"].ToString();
            }
            else
            {
                lblWelcome.Text = "Sorry, Your are not a member in the hospital.\nPlease Register at the Hospital Reception Counter. ";
            }
            conDatabase.Close();
            dtr.Close();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to queue up?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String visitationid = VisitationIdAssign();
                String visitationDate = DateTime.Today.ToString("dd/MM/yyyy");
                String appointmentid = AppointmentIDCheck();
                if (appointmentid.Equals("ntg"))
                {
                }
                else
                {
                    try
                    {
                        SqlConnection conDatabase;
                        string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                        conDatabase = new SqlConnection(connStr);
                        conDatabase.Open();
                        string strCreate;
                        SqlCommand cmdCreate;
                        strCreate = "Insert Into Visitation (VisitationID,VisitationDate,ServiceChose,MedicalCondition,AppointmentID,PatientID,StaffID) Values " +
                           "(@VisitationID,@VisitationDate,@ServiceChoose,@MedicalCondition,@AppointmentID,@PatientID,@StaffID)";
                        cmdCreate = new SqlCommand(strCreate, conDatabase);
                        cmdCreate.Parameters.AddWithValue("@VisitationID", visitationid);
                        cmdCreate.Parameters.AddWithValue("@VisitationDate", visitationDate);
                        cmdCreate.Parameters.AddWithValue("@ServiceChoose", ddlServiceChoose.SelectedItem.Value);
                        cmdCreate.Parameters.AddWithValue("@MedicalCondition", DBNull.Value);
                        if (!string.IsNullOrEmpty(appointmentid))
                            cmdCreate.Parameters.AddWithValue("@AppointmentID", appointmentid);
                        else
                            cmdCreate.Parameters.AddWithValue("@AppointmentID", DBNull.Value);
                        cmdCreate.Parameters.AddWithValue("@PatientID", patientid);
                        cmdCreate.Parameters.AddWithValue("@StaffID", DBNull.Value);
                        int n = cmdCreate.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("Please wait for calling by Nurse.\nYour Number: " + visitationid + "\nYour Service Choose: " + ddlServiceChoose.SelectedItem.Value);
                            Response.Redirect("~/TanAngie/PatientVisitation.aspx"); 
                        }
                        else
                        {
                            MessageBox.Show("Visitation create failed.");
                        }
                        conDatabase.Close();
                        patientid = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please wait for nurse calling ur number.");
                    }
                }
            }
        }

        protected string AppointmentIDCheck()
        {
            if (rblAppointment.SelectedItem.Value.Equals("Yes"))
            {
                String today = DateTime.Today.ToString("dd/MM/yyyy");
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strCheck;
                SqlCommand cmdCheck;
                strCheck = "Select * From dbo.Appointment Where PatientID = @PatientID And AppointmentStatus = @AppointmentStatus And AppointmentDate = @AppointmentDate";
                cmdCheck = new SqlCommand(strCheck, conDatabase);
                cmdCheck.Parameters.AddWithValue("@PatientID", patientid);
                cmdCheck.Parameters.AddWithValue("@AppointmentStatus", "Approved");
                cmdCheck.Parameters.AddWithValue("@AppointmentDate", today);
                SqlDataReader dtr;
                dtr = cmdCheck.ExecuteReader();
                if (dtr.Read())
                {
                    return dtr["AppointmentID"].ToString();
                }
                else
                {
                    MessageBox.Show("You did not make Appointment For Today.");
                    return "ntg";
                }
                conDatabase.Close();
                dtr.Close();
            }
            return "";
        }

        protected String VisitationIdAssign()
        {
            String lastId;
            String convertId;
            Int32 idAdd1;
            String newId = null;

            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select TOP 1 VisitationID From dbo.Visitation Order By VisitationID DESC";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                lastId = "" + dtr["VisitationID".ToString()];
                convertId = lastId.Substring(1);
                idAdd1 = Convert.ToInt32(convertId);
                idAdd1 += 1;
                if (idAdd1 < 9)
                    newId = "V000" + Convert.ToString(idAdd1);
                else if (idAdd1 < 99)
                    newId = "V00" + Convert.ToString(idAdd1);
                else if (idAdd1 < 999)
                    newId = "V0" + Convert.ToString(idAdd1);
                else if (idAdd1 < 9999)
                    newId = "V" + Convert.ToString(idAdd1);
            }
            else
            {
                MessageBox.Show("Visitation ID Assign Failed.");
            }
            conDatabase.Close();
            dtr.Close();
            return newId;
        }
    }
    
}