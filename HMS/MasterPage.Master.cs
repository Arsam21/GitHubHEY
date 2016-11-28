using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //{
            //   // LogoImage.ImageUrl = "Resources/samplelogo2.png";
            //    var year = DateTime.Now.Year;
            //    if (year != 2015)
            //    {
            //        footerlbl.Text = "Copyright @2015-" + year + " MyTransaction. All right reserved.";
            //    }
            //    else
            //    {
            //        footerlbl.Text = "Copyright @" + year + " MyTransaction. All right reserved.";
            //    }

            //}
        }
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TanAngie/StaffHomePage.aspx");
        }
        protected void logoutClick(object sender, EventArgs e)
        {
            Response.Redirect("~/TanAngie/LoginPage.aspx");
           
            //HttpCookie cookie = Request.Cookies["Login"];
            //cookie = new HttpCookie("Login");
            //Session["LoginID"] = null;
            //Session.Clear();

            //string[] myCookies = Request.Cookies.AllKeys;
            //foreach (string cookie in myCookies)
            //{
            //  Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            //}
            //Session.Abandon();
        }
        protected void changePwClick(object sender, EventArgs e)
        {
            Response.Redirect("~/TanAngie/LoginChangePassword.aspx");
        }

        protected void RegistraionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PangYeanPeen/PrescriptionHomePage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shirleyann/AdmissionHomepage.aspx");
        }

        protected void appointmentClick(object sender, EventArgs e)
        {
            Response.Redirect("~/TanDingKang/AppointmentHomepage.aspx");
        }

        protected void Welcome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WelcomeHome.aspx");
        }
    }
}