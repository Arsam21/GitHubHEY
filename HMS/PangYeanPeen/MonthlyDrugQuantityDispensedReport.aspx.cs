using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HMS
{
    public partial class Report : System.Web.UI.Page
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
            SqlCommand cmdDisplayReportDetails;
            strDisplayReportDetails = "SELECT a.CategoryType, b.DrugName, Sum(ISNULL(c.Qty,0)) AS [QuantityDispensed] FROM Category a " +
                                        "INNER JOIN Drug b ON a.CategoryID = b.CategoryID "+
                                        "LEFT OUTER JOIN (SELECT y.PrescriptionDate, x.DrugID, x.Qty FROM PrescriptionDetails x " +
                                        "INNER JOIN Prescription y ON x.PrescriptionID = y.PrescriptionID WHERE y.PrescriptionDate LIKE '%/" + month + "/%') AS c ON b.DrugID = c.DrugID " +
                                        "GROUP BY a.CategoryType, b.DrugName ORDER BY a.CategoryType, b.DrugName";

            try
            {
                cmdDisplayReportDetails = new SqlCommand(strDisplayReportDetails, conHMS);

                /*Step 3: Execute command to retrieve data*/

                SqlDataReader drDisplayReportDetails;
                drDisplayReportDetails = cmdDisplayReportDetails.ExecuteReader();

                /*Step 4: Bind data*/

                GridView1.DataSource = drDisplayReportDetails;
                GridView1.DataBind();

                /*Step 5: Close SqlReader and Database connection*/
                drDisplayReportDetails.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is no record for selected month.");
            }

            conHMS.Close();

        }
    }
}