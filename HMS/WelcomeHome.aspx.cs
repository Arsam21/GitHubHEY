using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HMS
{
    public partial class WelcomeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["Login"];

            ////Session["LoginID"] = cookie["loginID"];
            //lblLogin.Text = cookie["loginID"];

            try
            {
                //HttpCookie cookie = Request.Cookies["Login"];
                //Session["LoginID"] = cookie["loginID"];
                lblLogin.Text = cookie["loginID"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First");
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }

            if(cookie["loginID"].Equals("")){
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }

        }
    }
}