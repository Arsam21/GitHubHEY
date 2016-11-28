using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class StaffHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie["loginRole"].Equals("Doctor"))
                {
                    ibSchedule.Visible = true;
                    hlSchedule.Visible = true;
                    hlVisitation.Visible = true;
                    ibVisitation.Visible = true;
                }
                else if (cookie["loginRole"].Equals("Admin"))
                {
                    ibStaffList.Visible = true;
                    ibStaffRegistration.Visible = true;
                    hlStaffList.Visible = true;
                    hlStaffRegistration.Visible = true;
                    ibPatientVisitationReport.Visible = true;
                    ibDepartmentStaffReport.Visible = true;
                    hlPatientReport.Visible = true;
                    hlStaffReport.Visible = true;
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