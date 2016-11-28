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
    public partial class LoginChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                tbLoginId.Text = cookie["loginID"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
            }
        }
        protected void btnConfirmReset_Click(object sender, EventArgs e)
        {
            int check = PasswordCheck();
            if (check > 0)
            {
                if (MessageBox.Show("Confirm Reset the Password?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conDatabase;
                    string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                    conDatabase = new SqlConnection(connStr);
                    conDatabase.Open();
                    string strCheck;
                    SqlCommand cmdCheck;
                    strCheck = "Select * From dbo.Login Where LoginID = @LoginID";
                    cmdCheck = new SqlCommand(strCheck, conDatabase);
                    cmdCheck.Parameters.AddWithValue("@LoginID", tbLoginId.Text);
                    SqlDataReader dtr;
                    dtr = cmdCheck.ExecuteReader();
                    if (dtr.Read())
                    {
                        if (pwOldPassword.Value.Equals(dtr["LoginPW"].ToString()))
                        {
                            dtr.Close();
                            string strUpdate;
                            SqlCommand cmdUpdate;
                            strUpdate = "Update Login Set LoginPW = @LoginPW Where LoginID = @ID";
                            cmdUpdate = new SqlCommand(strUpdate, conDatabase);
                            cmdUpdate.Parameters.AddWithValue("@ID", tbLoginId.Text);
                            cmdUpdate.Parameters.AddWithValue("@LoginPW", pwPassword.Value);
                            int n = cmdUpdate.ExecuteNonQuery();
                            if (n > 0)
                            {
                                MessageBox.Show("Your reset already Success.");
                                Response.Redirect("~/TanAngie/StaffHomePage.aspx");
                            }
                            else
                                MessageBox.Show("Reset Failed.");
                        }
                        else
                        {
                            MessageBox.Show("Your Original Password is wrong.Please insert again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid LoginID. You have not registered yet.");
                    }
                }
            }
        }
        protected int PasswordCheck()
        {
            if (pwPassword.Value.Equals(pwConfirm.Value))
            {
                return 1;
            }
            else
            {
                MessageBox.Show("Please Check that Password must Same with Confirm Password.");
                return 0;
            }
        }
    }
}