using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Data;
using System.Windows.Forms;

namespace HMS
{
    public partial class Report1 : System.Web.UI.Page
    {
        SqlConnection conHMS;
        static string month = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            txtDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            txtDate.Enabled = false;

            DataSet dsDDlMonth = new DataSet();
            dsDDlMonth.ReadXml(MapPath("~/PangYeanPeen/HardCodeMonthDisplay.xml"));

            if (!IsPostBack)
            {
                ddlMonth.DataSource = dsDDlMonth;
                ddlMonth.DataTextField = "Month";
                ddlMonth.DataBind();
            }

            if(ddlMonth.SelectedValue.Equals("January")){
                month = "01";
            }else if(ddlMonth.SelectedValue.Equals("February")){
                month = "02";
            }else if(ddlMonth.SelectedValue.Equals("March")){
                month = "03";
            }else if(ddlMonth.SelectedValue.Equals("April")){
                month = "04";
            }else if(ddlMonth.SelectedValue.Equals("May")){
                month = "05";
            }else if(ddlMonth.SelectedValue.Equals("June")){
                month = "06";
            }else if(ddlMonth.SelectedValue.Equals("July")){
                month = "07";
            }else if(ddlMonth.SelectedValue.Equals("August")){
                month = "08";
            }else if(ddlMonth.SelectedValue.Equals("September")){
                month = "09";
            }else if(ddlMonth.SelectedValue.Equals("October")){
                month = "10";
            }else if(ddlMonth.SelectedValue.Equals("November")){
                month = "11";
            }else if(ddlMonth.SelectedValue.Equals("December")){
                month = "12";
            }
             
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            display();
            lblLabel.Text = ddlMonth.SelectedValue;
        }

        protected void display()
        {
            /*Step 1: Create and Open Connection*/

            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();

            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayReportDetails;
            //SqlCommand cmdDisplayReportDetails;
            strDisplayReportDetails = "Select Prescription.PrescriptionDate, Drug.DrugID, Drug.DrugName, PrescriptionDetails.Qty, Convert(numeric(10,2),Drug.UnitPrice) As [UnitPrice (RM)], Convert(numeric(10,2),(Drug.UnitPrice * PrescriptionDetails.Qty)) As [TotalPrice (RM)], Prescription.VisitationID, Patient.PatientName From Prescription, PrescriptionDetails, Drug, Patient, Visitation WHERE Prescription.PrescriptionDate LIKE '%/" +month + "/%'" +
                 "AND Prescription.VisitationID = Visitation.VisitationID AND Visitation.PatientID = Patient.PatientID AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.DrugID = Drug.DrugID";


            //cmdDisplayReportDetails = new SqlCommand(strDisplayReportDetails, conHMS);

            /*Step 3: Execute command to retrieve data*/

            //SqlDataReader drDisplayReportDetails;
            //drDisplayReportDetails = cmdDisplayReportDetails.ExecuteReader();

            /*Step 4: Bind data*/

            // GridView1.DataSource = drDisplayReportDetails;
            // GridView1.DataBind();

            /*Step 5: Close SqlReader and Database connection*/
            // drDisplayReportDetails.Close();

            try
            {
                SqlDataAdapter daDisplayReportDetails;
                daDisplayReportDetails = new SqlDataAdapter(strDisplayReportDetails, conHMS);
                DataSet dsDisplayReportDetails = new DataSet();
                daDisplayReportDetails.Fill(dsDisplayReportDetails);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(dsDisplayReportDetails.GetXml());
                xmlDoc.Save(MapPath("DispensedDrug.xml"));

                DataSet dsDisplayReportDetails1 = new DataSet();
                dsDisplayReportDetails1.ReadXml(MapPath("DispensedDrug.xml"));
                GridView1.DataSource = dsDisplayReportDetails1;
                GridView1.DataBind();
            }
            catch (Exception e)
            {
                MessageBox.Show("There is no record for selected month.");
            }
            

           
            conHMS.Close();

        }

    }
}