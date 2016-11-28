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
    public partial class PatientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String patientid = null;
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie["loginRole"].Equals("Patient"))
                {
                    patientid = cookie["loginFieldID"];
                    btnUpdate.Visible = false;
                    btnChangePassword.Visible = true;
                }
                else
                {
                    patientid = Request.QueryString["patientid"];
                }
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Patient Where PatientID = @ID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@ID", patientid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    tbAddress.Text = dtr["PatientAddr"].ToString();
                    tbContactNum.Text = dtr["PatientContactNo"].ToString();
                    tbEmail.Text = dtr["PatientEmail"].ToString();
                    tbGender.Text = dtr["PatientGender"].ToString();
                    tbIC.Text = dtr["PatientIC"].ToString();
                    tbName.Text = dtr["PatientName"].ToString();
                    tbPatientId.Text = dtr["PatientId"].ToString();
                }
                else
                {
                    MessageBox.Show("Error.Cannot get Patient Details.");
                }
                conDatabase.Close();
                dtr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String patientid = Request.QueryString["patientid"];
            Response.Redirect("~/TanAngie/PatientUpdate.aspx?patientid=" + patientid);
        }
        
    }
}