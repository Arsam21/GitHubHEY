using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HMS
{
    public partial class AdmissionHomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                //Session["LoginID"] = cookie["loginID"];
                lblStaff.Text = cookie["loginID"];
                if (cookie["loginRole"].Equals("Doctor"))
                {
                    dischargeByDoctor.Visible = true;

                    patientCheckUp.Visible = false;
                    resourcesUsed.Visible = false;
                    todayAdmission.Visible = false;
                    createAdmission.Visible = false;
                    dischargeByNurse.Visible = false;
                    admissionReport.Visible = false;
                    summaryAdmissionReport.Visible = false;

                    wardStaff.Visible = true;
                    wardInfo.Visible = true;
                }
                else if (cookie["loginRole"].Equals("Nurse"))
                {
                    dischargeByDoctor.Visible = false;
                    admissionReport.Visible = false;
                    summaryAdmissionReport.Visible = false;

                    patientCheckUp.Visible = true;
                    resourcesUsed.Visible = true;
                    todayAdmission.Visible = true;
                    createAdmission.Visible = true;
                    dischargeByNurse.Visible = true;

                    wardStaff.Visible = true;
                    wardInfo.Visible = true;

                }
                else if (cookie["loginRole"].Equals("Admin"))
                {
                    admissionReport.Visible = true;
                    summaryAdmissionReport.Visible = true;

                    wardStaff.Visible = true;
                    wardInfo.Visible = true;

                    dischargeByDoctor.Visible = false;
                    patientCheckUp.Visible = false;
                    resourcesUsed.Visible = false;
                    todayAdmission.Visible = false;
                    createAdmission.Visible = false;
                    dischargeByNurse.Visible = false;
                    
                }
                else if (cookie["loginRole"].Equals("Patient"))
                {
                    admissionReport.Visible = false;
                    summaryAdmissionReport.Visible = false;

                    wardStaff.Visible = false;
                    wardInfo.Visible = false;

                    dischargeByDoctor.Visible = false;
                    patientCheckUp.Visible = false;
                    resourcesUsed.Visible = false;
                    todayAdmission.Visible = false;
                    createAdmission.Visible = false;
                    dischargeByNurse.Visible = false;

                    lblMessage.Text = "Patient is not allow to access.";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First");
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }
        }
    }
}