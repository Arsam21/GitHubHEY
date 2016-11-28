using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HMS
{
    public partial class WardStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conStaff;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conStaff = new SqlConnection(connStr);
                conStaff.Open();

                string strRetrieve;
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT StaffID as 'Staff ID', StaffName as 'Staff Name', EmailID as 'Email'," +
                    " Position, DepartmentName as 'Department' FROM Staff, Department WHERE" +
                    " Staff.DepartmentID = Department.DepartmentID AND Position = 'Nurse' AND" +
                    " StaffStatus = 'Active' AND" +
                    " DepartmentName = (SELECT DepartmentName FROM Department WHERE DepartmentID = Staff.DepartmentID)";

                cmdRetrieve = new SqlCommand(strRetrieve, conStaff);

                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();

                GridView1.DataSource = dtr;
                GridView1.DataBind();

                conStaff.Close();
                dtr.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.DataSource = null;
            GridView2.DataBind();

            SqlConnection conAdmission;
            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conAdmission = new SqlConnection(connStr);
            conAdmission.Open();

            string strRetrieve;
            SqlCommand cmdRetrieve;
            strRetrieve = "SELECT Patient.PatientID as 'Patient ID',PatientName as 'Patient Name',"+
                " MedicalCondition as 'Medical Condition', WardNo as 'Ward No', BedNo as 'Bed No'"+
                " FROM Admission, Visitation, Patient WHERE Admission.VisitationID = Visitation.VisitationID" +
                " AND Visitation.PatientID = Patient.PatientID AND AdmissionStatus = 'Admitted' AND" +
                " Patient.PatientID = (SELECT PatientID FROM Patient WHERE PatientID = Visitation.PatientID) AND" +
                " PatientName = (SELECT PatientName FROM Patient WHERE PatientID = Visitation.PatientID) AND"+
                " Admission.StaffID = '"+GridView1.SelectedRow.Cells[1].Text+"'";
                
            cmdRetrieve = new SqlCommand(strRetrieve, conAdmission);

            SqlDataReader dtr;
            dtr = cmdRetrieve.ExecuteReader();
            if (dtr.HasRows)
            {
                lblText.Text = "Nurse " + "<strong>" + GridView1.SelectedRow.Cells[2].Text + "</strong>" +
               " is currently in charge of the following patients :";
                GridView2.DataSource = dtr;
                GridView2.DataBind();
                conAdmission.Close();
                dtr.Close();               
            }
            else
            {              
                  lblText.Text = "Nurse " + "<strong>" + GridView1.SelectedRow.Cells[2].Text + "</strong>" +
                " is not in charge of any patients at the moment";         
            }              
        }
    }
}