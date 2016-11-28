using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class StaffDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String staffid = null;
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie["loginRole"].Equals("Admin"))
                {
                    staffid = Request.QueryString["staffid"];
                    if (string.IsNullOrEmpty(staffid))
                        staffid = cookie["loginFieldID"];
                }
                else
                {
                    btnDelete.Visible = false;
                    btnChangePassword.Visible = true;
                    staffid = cookie["loginFieldID"];
                }
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Staff,Department Where StaffID = @ID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@ID", staffid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    tbAddress.Text = dtr["StaffAddr"].ToString();
                    tbContactNum.Text = dtr["StaffContactNo"].ToString();
                    tbDepartment.Text = dtr["DepartmentName"].ToString();
                    tbEmail.Text = dtr["EmailID"].ToString();
                    tbGender.Text = dtr["StaffGender"].ToString();
                    tbIC.Text = dtr["StaffIC"].ToString();
                    tbName.Text = dtr["StaffName"].ToString();
                    tbPosition.Text = dtr["Position"].ToString();
                    tbSalary.Text = dtr["Salary"].ToString();
                    tbStaffId.Text = dtr["StaffId"].ToString();
                    tbStatus.Text = dtr["StaffStatus"].ToString();
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
                MessageBox.Show("Please Login As Staff.");
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String staffid = tbStaffId.Text;
            Response.Redirect("~/TanAngie/StaffUpdate.aspx?staffid="+staffid);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String staffid = tbStaffId.Text;
            Response.Redirect("~/TanAngie/StaffDelete.aspx?staffid=" + staffid);
        }
    }
}