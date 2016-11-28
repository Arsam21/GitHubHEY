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
    public partial class LoginPage : System.Web.UI.Page
    {
        HttpCookie cookie = new HttpCookie("Login");
        static Int32 passwordErrorCount = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Clear();
            //HttpContext.Current.Request.Cookies.Clear();
            //cookie = new HttpCookie("Login");
            //Session["LoginID"] = null;
            //cookie["Login"] = null;

            //string[] cookies = Request.Cookies.AllKeys;
            //foreach (string cookie in cookies)
            //{
            //    BulletedList1.Items.Add("Deleting " + cookie);
            //    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            //}

            HttpCookie allCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                allCookie = new HttpCookie(cookieName);
                allCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(allCookie);
            }

        }

        protected void BtLogin_Click(object sender, EventArgs e)
        {
            MemberCheck();
        }
        protected void MemberCheck()
        {
            String dPassword = null;
            String insertPassword = pwPassword.Value;
            int checkpoint;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Login Where LoginID = @ID";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@ID", tbLoginId.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                dPassword = dtr["LoginPW"].ToString();
                if (insertPassword.Equals(dPassword))
                {
                    checkpoint = StaffCheck();
                    if (checkpoint == 1)
                    {
                        checkpoint = PatientCheck();
                        if (checkpoint == 1)
                        {
                            MessageBox.Show("No data found.");
                        }
                        else
                        {
                            //cookie["loginID"] = tbLoginId.Text;
                            HomePage();
                        }
                    }
                    else
                    {
                        //cookie["loginID"] = tbLoginId.Text;
                        HomePage();
                    }
                }
                else
                {
                    passwordErrorCount -= 1;
                    if (passwordErrorCount > 0)
                        MessageBox.Show("Invalid Password. Please insert again.\nYou still have "
                        + passwordErrorCount + " more chance.");
                    else
                    {
                        Response.Redirect("~/TanAngie/LoginPage.aspx"); //------------------------Main Home page link---------------
                        passwordErrorCount = 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Register at the Hospital Reception Counter.");
            }
            conDatabase.Close();
            dtr.Close();
        }
        protected int StaffCheck()
        {
            int check = 0;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Staff Where LoginID = @ID";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@ID", tbLoginId.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                cookie["loginRole"] = dtr["Position"].ToString();
                cookie["loginFieldID"] = dtr["StaffID"].ToString();
                cookie["loginName"] = dtr["StaffName"].ToString();
                cookie["loginID"] = tbLoginId.Text;
                Response.Cookies.Add(cookie);
                cookie.Expires = DateTime.Now.AddHours(1);
            }
            else
            {
                check = 1;
            }
            conDatabase.Close();
            dtr.Close();
            return check;
        }
        protected int PatientCheck()
        {
            int check = 0;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Patient Where LoginID = @ID";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@ID", tbLoginId.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                cookie["loginRole"] = "Patient";
                cookie["loginFieldID"] = dtr["PatientID"].ToString();
                cookie["loginName"] = dtr["PatientName"].ToString();
                cookie["loginID"] = tbLoginId.Text;
                Response.Cookies.Add(cookie);
                cookie.Expires = DateTime.Now.AddHours(1);
            }
            else
            {
                check = 1;
            }
            conDatabase.Close();
            dtr.Close();

            return check;
        }
        protected void HomePage()
        {
            HttpCookie cookie = Request.Cookies["Login"];
            
            if (cookie["loginRole"].Equals("Patient"))
            {
                Response.Redirect("~/WelcomeHome.aspx");
                //------------Home Page for Patient login---------------
            }
            else
            {
                Response.Redirect("~/WelcomeHome.aspx");
                //------------Home Page for Staff and Admin--------------
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}