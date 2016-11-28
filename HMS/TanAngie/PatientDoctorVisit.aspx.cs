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
    public partial class PatientDoctorVisit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssignVisitation();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                String staffid = null;
                HttpCookie cookie = Request.Cookies["Login"];
                staffid = cookie["loginFieldID"];
                if (MessageBox.Show("Confirm to Submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conDatabase;
                    string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                    conDatabase = new SqlConnection(connStr);
                    conDatabase.Open();
                    string strUpdate;
                    SqlCommand cmdUpdate;
                    strUpdate = "Update Visitation SET MedicalCondition = @MedicalCondition,StaffID = @StaffID Where VisitationID = @VisitationID";
                    cmdUpdate = new SqlCommand(strUpdate, conDatabase);
                    cmdUpdate.Parameters.AddWithValue("@VisitationID", lbVisitationID.Text);
                    cmdUpdate.Parameters.AddWithValue("@MedicalCondition", tbMedicalCondition.Text);
                    cmdUpdate.Parameters.AddWithValue("@StaffID", staffid);
                    int n = cmdUpdate.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Submit success");
                        AssignVisitation();
                    }
                    else
                    {
                        MessageBox.Show("Submit Failed.");
                    }
                    conDatabase.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
            }
        }
        protected void AssignVisitation()
        {
            if (String.IsNullOrEmpty(VisitationCurrent()) || VisitationCurrent().Equals("ntg"))
            {
            }
            else
            {
                int appointmentCheck = AppointmentCheck(VisitationCurrent());
                if (appointmentCheck > 0)
                {
                }
                else
                {
                    do
                    {
                        if (String.IsNullOrEmpty(VisitationCurrent()))
                        {
                            break;
                        }
                        else
                        {
                            appointmentCheck = AppointmentCheck(VisitationNext());
                        }
                    } while (appointmentCheck > 0);
                }
            }
        }
        protected int AppointmentCheck(String appointmentid)
        {
            try
            {
                String visitationDate = DateTime.Today.ToString("dd/MM/yyyy");
                String staffid = null;
                HttpCookie cookie = Request.Cookies["Login"];
                staffid = cookie["loginFieldID"];
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Appointment Where AppointmentID=@AppointmentID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@AppointmentID", appointmentid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    if (dtr["StaffID"].ToString().Equals(staffid))
                        return 1;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
                return 0;
            }
        }
        protected String VisitationCurrent()
        {
            String visitationDate = DateTime.Today.ToString("dd/MM/yyyy");
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strGet;
            SqlCommand cmdGet;
            strGet = "Select * From Visitation,Patient Where VisitationDate = @VisitationDate And MedicalCondition IS NULL Order By VisitationID";
            cmdGet = new SqlCommand(strGet, conDatabase);
            cmdGet.Parameters.AddWithValue("@VisitationDate", visitationDate);
            SqlDataReader dtr;
            dtr = cmdGet.ExecuteReader();
            if (dtr.Read())
            {
                lbAppointmentId.Text = dtr["AppointmentID"].ToString();
                lbPatientID.Text = dtr["PatientID"].ToString();
                lbPatientName.Text = dtr["PatientName"].ToString();
                lbService.Text = dtr["ServiceChose"].ToString();
                lbVisitationDate.Text = dtr["VisitationDate"].ToString();
                lbVisitationID.Text = dtr["VisitationID"].ToString();
                return dtr["AppointmentID"].ToString();
            }
            else
            {
                MessageBox.Show("No more queue for visitation");
                Response.Redirect("~/TanAngie/StaffHomePage.aspx");
                return "ntg";
            }
        }
        protected String VisitationNext()
        {
            String lastId;
            String convertId;
            Int32 idAdd1;
            String newId = null;
            lastId = lbVisitationID.Text;
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
            String visitationDate = DateTime.Today.ToString("dd/MM/yyyy");
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strGet;
            SqlCommand cmdGet;
            strGet = "Select * From Visitation,Patient Where VisitationDate = @VisitationDate And MedicalCondition IS NULL And VisitationID = @VisitationID";
            cmdGet = new SqlCommand(strGet, conDatabase);
            cmdGet.Parameters.AddWithValue("@VisitationDate", visitationDate);
            cmdGet.Parameters.AddWithValue("@VisitationID", newId);
            SqlDataReader dtr;
            dtr = cmdGet.ExecuteReader();
            if (dtr.Read())
            {
                lbAppointmentId.Text = dtr["AppointmentID"].ToString();
                lbPatientID.Text = dtr["PatientID"].ToString();
                lbPatientName.Text = dtr["PatientName"].ToString();
                lbService.Text = dtr["ServiceChose"].ToString();
                lbVisitationDate.Text = dtr["VisitationDate"].ToString();
                lbVisitationID.Text = dtr["VisitationID"].ToString();
                return dtr["AppointmentID"].ToString();
            }
            else
            {
                MessageBox.Show("No more queue for visitation");
                Response.Redirect("~/TanAngie/StaffHomePage.aspx");
                return "ntg";
            }

        }
    }
}