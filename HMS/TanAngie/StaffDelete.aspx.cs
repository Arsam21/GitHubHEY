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
    public partial class StaffDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    String staffid = Request.QueryString["staffid"];
                    SqlConnection conDatabase;
                    string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                    conDatabase = new SqlConnection(connStr);
                    conDatabase.Open();
                    string strGet;
                    SqlCommand cmdGet;
                    strGet = "Select * From Staff Where StaffID = @ID";
                    cmdGet = new SqlCommand(strGet, conDatabase);
                    cmdGet.Parameters.AddWithValue("@ID", staffid);
                    SqlDataReader dtr;
                    dtr = cmdGet.ExecuteReader();
                    if (dtr.Read())
                    {
                        tbStaffId.Text = dtr["StaffID"].ToString();
                        tbStaffName.Text = dtr["StaffName"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    conDatabase.Close();
                    dtr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Login As Admin");
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int passwordCheck = AdminPasswordCheck();
            if (passwordCheck > 0)
            {
                if (MessageBox.Show("Confirm to Delete the Staff?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteStaff();
                    Response.Redirect("~/TanAngie/StaffList.aspx");
                }
            }
        }
        protected int AdminPasswordCheck()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                String staffid = cookie["loginFieldID"];

                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Staff,Login Where Login.LoginID = Staff.LoginID And Staff.StaffID = @ID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@ID", staffid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    if (pwAdmin.Value.Equals(dtr["LoginPW"].ToString()))
                    {
                        conDatabase.Close();
                        dtr.Close();
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Your Password is incorrect.\nPlease try again.");
                        conDatabase.Close();
                        dtr.Close();
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                    conDatabase.Close();
                    dtr.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login As Admin");
                return 0;
            }
        }
        protected void DeleteStaff()
        {
            String staffid = tbStaffId.Text;
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strDelete;
            SqlCommand cmdDelete;
            strDelete = "Update Staff Set StaffStatus = @status Where StaffID = @ID";

            cmdDelete = new SqlCommand(strDelete, conDatabase);

            cmdDelete.Parameters.AddWithValue("@ID", staffid);
            cmdDelete.Parameters.AddWithValue("@status", ddlStatus.SelectedItem.Value);

            int n = cmdDelete.ExecuteNonQuery();

            if (n > 0)
                MessageBox.Show("Record status had been change.\nYou may retrieve back by searching from Staff list.");
            else
                MessageBox.Show("Error.Delete failed.");

            conDatabase.Close();
        }
    }
}