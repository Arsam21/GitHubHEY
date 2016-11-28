using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HMS
{
    public partial class AppointmentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                Session["LoginID"] = cookie["loginID"];
                if (cookie["loginRole"].Equals("Doctor"))
                {
                    sendEmail.Visible = true;
                    report1.Visible = true;
                    report2.Visible = true;
                    addAppointment.Visible = false;
                    editAppointment.Visible = false;
                }
                else if (cookie["loginRole"].Equals("Patient"))
                {
                    sendEmail.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    addAppointment.Visible = true;
                    editAppointment.Visible = true;
                }
                else if (cookie["loginRole"].Equals("Admin"))
                {
                    sendEmail.Visible = false;
                    report1.Visible = true;
                    report2.Visible = true;
                    addAppointment.Visible = false;
                    editAppointment.Visible = false;
                }
                else if (cookie["loginRole"].Equals("Manager"))
                {
                    sendEmail.Visible = false;
                    report1.Visible = true;
                    report2.Visible = true;
                    addAppointment.Visible = false;
                    editAppointment.Visible = false;
                }
                else if (cookie["loginRole"].Equals("Nurse"))
                {
                    sendEmail.Visible = false;
                    report1.Visible = true;
                    report2.Visible = true;
                    addAppointment.Visible = false;
                    editAppointment.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First");
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }

            //HttpCookie cookies = Request.Cookies["Login"];
            //Session["LoginID"] = cookies["loginID"];

            if (Session["LoginID"] == null)
            {
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }


            String UserName = Session["LoginID"].ToString();
            lblUserName.Text = UserName.ToString();
            Session["LoginID"] = Session["LoginID"].ToString();
            
        }
    }
}