using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HMS
{
    public partial class AdmissionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMedicalCondition.AppendDataBoundItems = true;
                ddlMedicalCondition.Items.Add(new ListItem("--please select--", "-1"));

                SqlConnection conReport;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conReport = new SqlConnection(connStr);
                conReport.Open();
                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT DISTINCT MedicalCondition FROM Visitation";
                cmdRetrieve = new SqlCommand(strRetrieve, conReport);

                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();

                ddlMedicalCondition.DataSource = dtr;
                ddlMedicalCondition.DataTextField = "MedicalCondition";
                ddlMedicalCondition.DataBind();

                dtr.Close();
                conReport.Close();
            }
        }

        protected void cldStartDate_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = cldStartDate.SelectedDate.ToShortDateString();
        }

        protected void cldEndDate_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = cldEndDate.SelectedDate.ToShortDateString();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            cldStartDate.SelectedDates.Clear();
            cldEndDate.SelectedDates.Clear();
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            ddlMedicalCondition.SelectedIndex = 0;
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblLineOne.Text = "";
            lblLineTwo.Text = "";
            lblLineThree.Text = "";
            lblLineFour.Text = "";
            lblLineFive.Text = "";
            lblLineSix.Text = "";
            lblLineSeven.Text = "";
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            if(ddlMedicalCondition.SelectedItem.Text.Equals("--please select--")){
                MessageBox.Show("You have not selected any Medical Condition!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                MessageBox.Show("You have not selected the date!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);             
            }
            else
            {
                DateTime startDate= DateTime.Parse(txtStartDate.Text);
                DateTime endDate= DateTime.Parse(txtEndDate.Text);

               if(endDate.CompareTo(startDate)<0)
               {
                   MessageBox.Show("End date cannot be earlier than start date!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }else
               {
                   SqlConnection conReport;
                    string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                    conReport = new SqlConnection(connStr);
                    conReport.Open();

                    string strRetrieve = "";
                    SqlCommand cmdRetrieve;
                    strRetrieve = "SELECT AdmissionDate as 'Admission Date', convert(varchar(10),DATEADD(day,NoOfDaysStay,"+
                        " convert(datetime,AdmissionDate,103)),103) as 'Discharge Date', Visitation.PatientID as 'Patient ID',"+
                        " PatientName as 'Patient Name', Admission.WardNo as 'Ward No', Admission.BedNo as 'Bed No' FROM"+
                        " Admission, Patient, Visitation WHERE Admission.VisitationID = Visitation.VisitationID AND"+
                        " Visitation.PatientID = Patient.PatientID AND MedicalCondition = '"+ddlMedicalCondition.SelectedItem.Text+"'"+
                        " AND convert(date,AdmissionDate,103) BETWEEN convert(date,'"+txtStartDate.Text+"',103) AND"+
                        " convert(date,'"+txtEndDate.Text+"',103)";
                    cmdRetrieve = new SqlCommand(strRetrieve, conReport);

                    SqlDataReader dtr;
                    dtr = cmdRetrieve.ExecuteReader();
                    if (dtr.HasRows)
                    {
                        lblLineOne.Text = "<p style ='font-size:2em'>HOSPITAL MANAGEMENT SYSTEM</p>";
                        lblLineTwo.Text = "<p style ='padding:0;margin:0;margin-left:150px'>Jalan Pahang, 50586 Kuala Lumpur,</p>";
                        lblLineThree.Text = "<p style ='padding:0;margin:0;margin-left:150px'>Federal Territory of Kuala Lumpur,</p>";
                        lblLineFour.Text = "<p style = 'padding:0;margin:0;margin-left:230px'>Malaysia</p>";
                        lblLineFive.Text = "<p style = 'padding:0;margin:0;margin-left:125px;font-weight:bold'>Tel : 603-26155555 Fax : 603-26989845</p>";
                        lblLineSix.Text = "<p style ='font-size:smaller;margin-left:410px;font-weight:bold'><i>DATE: '" + DateTime.Now.ToShortDateString() + "'</i></p>";
                        lblLineSeven.Text = "<p style ='font-size:2em;padding:0;;margin:0;margin-left:20px;font-weight:bold'>Detailed Admission Report of HMS</p>";

                        GridView1.DataSource = dtr;
                        GridView1.DataBind();
                    }
                    else
                    {                    
                        MessageBox.Show("No records found for this medical condition within the selected dates.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lblLineOne.Text = "";
                        lblLineTwo.Text = "";
                        lblLineThree.Text = "";
                        lblLineFour.Text = "";
                        lblLineFive.Text = "";
                        lblLineSix.Text = "";
                        lblLineSeven.Text = "";
                        cldStartDate.SelectedDates.Clear();
                        cldEndDate.SelectedDates.Clear();
                        txtStartDate.Text = "";
                        txtEndDate.Text = "";
                        ddlMedicalCondition.SelectedIndex = 0;
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }               

                    dtr.Close();
                    conReport.Close();
               }
            }           
        }
    }
}