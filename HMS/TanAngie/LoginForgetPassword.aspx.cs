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
    public partial class LoginForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblWelcome.Text = "";
                lblConfirmPw.Visible = false;
                lblPassword.Visible = false;
                lblConfirmPw.Visible = false;
                btnConfirmReset.Visible = false;
                pwConfirm.Visible = false;
                pwPassword.Visible = false;
                
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
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
                if (ddlSecurityQuestion.SelectedItem.Value.Equals(dtr["SecurityQ"].ToString()))
                {
                    if (tbSecurityPw.Text.Equals(dtr["SecurityPW"].ToString()))
                    {
                        lblWelcome.Text = "Welcome back, Please Reset Your Password Here";
                        lblConfirmPw.Visible = true;
                        lblPassword.Visible = true;
                        lblConfirmPw.Visible = true;
                        btnConfirmReset.Visible = true;
                        pwConfirm.Visible = true;
                        pwPassword.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Security Answer.");
                        lblWelcome.Text = "";
                        lblConfirmPw.Visible = false;
                        lblPassword.Visible = false;
                        lblConfirmPw.Visible = false;
                        btnConfirmReset.Visible = false;
                        pwConfirm.Visible = false;
                        pwPassword.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Security Question.");
                    lblConfirmPw.Visible = false;
                    lblPassword.Visible = false;
                    lblConfirmPw.Visible = false;
                    btnConfirmReset.Visible = false;
                    lblWelcome.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid LoginID. You have not registered yet.");
            }
        }//Check user and security check

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
                        Response.Redirect("~/TanAngie/LoginPage.aspx");
                    }
                    else
                        MessageBox.Show("Reset Failed.");
                    conDatabase.Close();
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