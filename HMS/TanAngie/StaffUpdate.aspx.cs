﻿using System;
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
    public partial class StaffUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    String staffid = null;
                    decimal salary = 0;
                    HttpCookie cookie = Request.Cookies["Login"];
                    if (cookie["loginRole"].Equals("Admin"))
                    {
                        staffid = Request.QueryString["staffid"];
                        if (string.IsNullOrEmpty(staffid))
                            staffid = cookie["loginFieldID"];
                    }
                    else //For Staff Personal Update
                    {
                        staffid = cookie["loginFieldID"];
                        tbSalary.Enabled = false;
                        ddlDepartment.Enabled = false;
                        ddlPosition.Enabled = false;
                        tbSalary.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                        ddlDepartment.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                        ddlPosition.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                    }
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
                        tbAddress.Text = dtr["StaffAddr"].ToString();
                        tbContactNum.Text = dtr["StaffContactNo"].ToString();
                        DepartmentRetrieve(dtr["DepartmentID"].ToString());
                        tbEmail.Text = dtr["EmailID"].ToString();
                        tbGender.Text = dtr["StaffGender"].ToString();
                        tbIC.Text = dtr["StaffIC"].ToString();
                        tbName.Text = dtr["StaffName"].ToString();
                        ddlPosition.ClearSelection();
                        ddlPosition.Items.FindByValue(dtr["Position"].ToString()).Selected = true;
                        salary = Convert.ToDecimal(dtr["Salary"].ToString());
                        tbSalary.Text = salary.ToString("n2");
                        tbStaffId.Text = dtr["StaffId"].ToString();
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
                    MessageBox.Show("Please Login First.");
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlPosition.SelectedItem.Value.Equals("Manager"))
            {
                if (DepartmentManagerCheck(DepartmentCheck()) > 0)
                    UpdateData();
            }
            else
                UpdateData();   
        }
        protected void UpdateData()
        {
            if (MessageBox.Show("Confirm to update the details?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strUpdate;
                SqlCommand cmdUpdate;
                strUpdate = "Update Staff Set StaffAddr=@Address, StaffContactNo=@contactNo, EmailID=@Email,"
                    + " DepartmentID=@DepartmentID, Position=@Position, Salary=@Salary Where StaffID = @ID";
                cmdUpdate = new SqlCommand(strUpdate, conDatabase);
                cmdUpdate.Parameters.AddWithValue("@ID", tbStaffId.Text);
                cmdUpdate.Parameters.AddWithValue("@Address", tbAddress.Text);
                cmdUpdate.Parameters.AddWithValue("@contactNo", tbContactNum.Text);
                cmdUpdate.Parameters.AddWithValue("@Email", tbEmail.Text);
                cmdUpdate.Parameters.AddWithValue("@DepartmentID", DepartmentCheck());
                cmdUpdate.Parameters.AddWithValue("@Position", ddlPosition.SelectedItem.Value);
                cmdUpdate.Parameters.AddWithValue("@Salary", tbSalary.Text);
                int n = cmdUpdate.ExecuteNonQuery();
                if (n > 0)
                    MessageBox.Show("Your Update already Success.");
                else
                    MessageBox.Show("Cannot be Update.");
            }
        }
        protected void DepartmentRetrieve(String departmentID)
        {
            if (departmentID.Equals("DP001"))
                ddlDepartment.Items.FindByValue("Human Resource").Selected = true;
            else if (departmentID.Equals("DP002"))
                ddlDepartment.Items.FindByValue("Maternity Department").Selected = true;
            else if (departmentID.Equals("DP003"))
                ddlDepartment.Items.FindByValue("General Disease").Selected = true;
            else if (departmentID.Equals("DP004"))
                ddlDepartment.Items.FindByValue("Pharmacy").Selected = true;
        }
        protected String DepartmentCheck()
        {
            String departmentId = null;

            if (ddlDepartment.SelectedItem.Value == "Human Resource")
            {
                departmentId = "DP001";
            }
            else if (ddlDepartment.SelectedItem.Value == "Maternity Department")
            {
                departmentId = "DP002";
            }
            else if (ddlDepartment.SelectedItem.Value == "General Disease")
            {
                departmentId = "DP003";
            }
            else if (ddlDepartment.SelectedItem.Value == "Pharmacy")
            {
                departmentId = "DP004";
            }
            return departmentId;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salary = 0;
                if (MessageBox.Show("Confirm to Reset All the details?", "Reset Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String staffid = null;
                    HttpCookie cookie = Request.Cookies["Login"];
                    if (cookie["loginRole"].Equals("Admin"))
                    {
                        staffid = Request.QueryString["staffid"];
                        if (string.IsNullOrEmpty(staffid))
                            staffid = cookie["loginFieldID"];
                    }
                    else //For Staff View or update
                    {
                        staffid = cookie["loginFieldID"];
                        tbSalary.Enabled = false;
                        ddlDepartment.Enabled = false;
                        ddlPosition.Enabled = false;
                        tbSalary.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                        ddlDepartment.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                        ddlPosition.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
                    }
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
                        tbAddress.Text = dtr["StaffAddr"].ToString();
                        tbContactNum.Text = dtr["StaffContactNo"].ToString();
                        DepartmentRetrieve(dtr["DepartmentID"].ToString());
                        tbEmail.Text = dtr["EmailID"].ToString();
                        tbGender.Text = dtr["StaffGender"].ToString();
                        tbIC.Text = dtr["StaffIC"].ToString();
                        tbName.Text = dtr["StaffName"].ToString();
                        ddlPosition.ClearSelection();
                        ddlPosition.Items.FindByValue(dtr["Position"].ToString()).Selected = true;
                        salary = Convert.ToDecimal(dtr["Salary"].ToString());
                        tbSalary.Text = salary.ToString("n2");
                        tbStaffId.Text = dtr["StaffId"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    conDatabase.Close();
                    dtr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please login first.");
            }
        }
        protected int DepartmentManagerCheck(string departmentid)
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Staff Where DepartmentID = '" + departmentid + "' AND Position='Manager' AND StaffStatus='Active'";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                MessageBox.Show("This department already have a Manager.\n");
                conDatabase.Close();
                dtr.Close();
                return 0;
            }
            else
            {
                conDatabase.Close();
                dtr.Close();
                return 1;
            }
        }
    }
}