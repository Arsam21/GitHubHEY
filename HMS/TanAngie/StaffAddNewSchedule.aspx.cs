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
    public partial class StaffAddNewSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                String staffid = null;
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie["loginRole"].Equals("Admin"))
                {
                    staffid = Request.QueryString["staffid"];
                }
                else
                {
                    staffid = cookie["loginFieldID"];
                }

                int scheduleCheck = ScheduleCheck(staffid);
                if (scheduleCheck > 0)
                {
                    if (ddlFirstPeriod.SelectedItem.Value.Equals(ddlSecondPeriod.SelectedItem.Value) || ddlFirstPeriod.SelectedItem.Value.Equals(ddlThirdPeriod.SelectedItem.Value) || ddlSecondPeriod.SelectedItem.Value.Equals(ddlThirdPeriod.SelectedItem.Value))
                    {
                        MessageBox.Show("Cannot choose the same period in one time.");
                    }
                    else
                    {
                        if (MessageBox.Show("Confirm to Select this field?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlConnection conDatabase;
                            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                            conDatabase = new SqlConnection(connStr);
                            conDatabase.Open();

                            SqlCommand cmdCreate1stPeriod;
                            SqlCommand cmdCreate2ndPeriod;
                            SqlCommand cmdCreate3rdPeriod;
                            string strCreate1stPeriod;
                            string strCreate2ndPeriod;
                            string strCreate3rdPeriod;

                            strCreate1stPeriod = "Insert Into WorkingSchedule (WorkingScheduleID,WorkDay,StaffID,TimeID) Values (@WorkingScheduleID,@WorkDay,@StaffID,@TimeID)";
                            strCreate2ndPeriod = "Insert Into WorkingSchedule (WorkingScheduleID,WorkDay,StaffID,TimeID) Values (@WorkingScheduleID,@WorkDay,@StaffID,@TimeID)";
                            strCreate3rdPeriod = "Insert Into WorkingSchedule (WorkingScheduleID,WorkDay,StaffID,TimeID) Values (@WorkingScheduleID,@WorkDay,@StaffID,@TimeID)";
                            //1st Period
                            cmdCreate1stPeriod = new SqlCommand(strCreate1stPeriod, conDatabase);
                            cmdCreate1stPeriod.Parameters.AddWithValue("@WorkingScheduleID", AssignWorkingScheduleID());
                            cmdCreate1stPeriod.Parameters.AddWithValue("@WorkDay", ddlDay.SelectedItem.Value);
                            cmdCreate1stPeriod.Parameters.AddWithValue("@StaffID", staffid);
                            cmdCreate1stPeriod.Parameters.AddWithValue("@TimeID", ddlFirstPeriod.SelectedItem.Value);
                            cmdCreate1stPeriod.ExecuteNonQuery();
                            //2nd Period
                            cmdCreate2ndPeriod = new SqlCommand(strCreate2ndPeriod, conDatabase);
                            cmdCreate2ndPeriod.Parameters.AddWithValue("@WorkingScheduleID", AssignWorkingScheduleID());
                            cmdCreate2ndPeriod.Parameters.AddWithValue("@WorkDay", ddlDay.SelectedItem.Value);
                            cmdCreate2ndPeriod.Parameters.AddWithValue("@StaffID", staffid);
                            cmdCreate2ndPeriod.Parameters.AddWithValue("@TimeID", ddlSecondPeriod.SelectedItem.Value);
                            cmdCreate2ndPeriod.ExecuteNonQuery();
                            //3rd Period
                            cmdCreate3rdPeriod = new SqlCommand(strCreate3rdPeriod, conDatabase);
                            cmdCreate3rdPeriod.Parameters.AddWithValue("@WorkingScheduleID", AssignWorkingScheduleID());
                            cmdCreate3rdPeriod.Parameters.AddWithValue("@WorkDay", ddlDay.SelectedItem.Value);
                            cmdCreate3rdPeriod.Parameters.AddWithValue("@StaffID", staffid);
                            cmdCreate3rdPeriod.Parameters.AddWithValue("@TimeID", ddlThirdPeriod.SelectedItem.Value);
                            int n = cmdCreate3rdPeriod.ExecuteNonQuery();

                            if (n > 0)
                            {
                                MessageBox.Show("Schedule Created");
                                Response.Redirect("~/TanAngie/StaffHomePage.aspx");
                            }
                            else
                                MessageBox.Show("Error for add Schedule.");
                            conDatabase.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Please Login As Doctor First.");
            }
        }
        protected string AssignWorkingScheduleID(){
            String lastId;
            String convertId;
            Int32 idAdd1;
            String newId = null;

            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select TOP 1 WorkingScheduleID From dbo.WorkingSchedule Order By WorkingScheduleID DESC";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                lastId = "" + dtr["WorkingScheduleID".ToString()];
                convertId = lastId.Substring(2);
                idAdd1 = Convert.ToInt32(convertId);
                idAdd1 += 1;
                if (idAdd1 < 9)
                    newId = "WS00" + Convert.ToString(idAdd1);
                else if (idAdd1 < 99)
                    newId = "WS0" + Convert.ToString(idAdd1);
                else if (idAdd1 < 999)
                    newId = "WS" + Convert.ToString(idAdd1);
            }
            else
            {
                MessageBox.Show("data not found.");
            }
            conDatabase.Close();
            dtr.Close();
            return newId;
        }

        protected int ScheduleCheck(String staffid)
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From WorkingSchedule Where WorkDay = @WorkDay And StaffID = @StaffID";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@WorkDay", ddlDay.SelectedItem.Value);
            cmdCheck.Parameters.AddWithValue("@StaffID", staffid);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                MessageBox.Show("Your working day "+ddlDay.SelectedItem.Value+" had been selected before.\nPlease choose other working day.");
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