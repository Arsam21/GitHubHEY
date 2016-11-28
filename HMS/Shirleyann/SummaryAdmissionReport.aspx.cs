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
    public partial class SummaryAdmissionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlYear.AppendDataBoundItems = true;
                ddlYear.Items.Add(new ListItem("--please select--", "-1"));

                SqlConnection conReport;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conReport = new SqlConnection(connStr);
                conReport.Open();

                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT DISTINCT YEAR(convert(datetime,AdmissionDate,103)) as year FROM"+
                    " Admission";
                cmdRetrieve = new SqlCommand(strRetrieve, conReport);

                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();

                if (dtr.HasRows)
                {
                    ddlYear.DataSource = dtr;
                    ddlYear.DataTextField = "year";
                    ddlYear.DataBind();
                }
                dtr.Close();
                conReport.Close();
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            if (ddlYear.SelectedItem.Text.Equals("--please select--"))
            {
                MessageBox.Show("You have not selected the year!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                SqlConnection conReport;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conReport = new SqlConnection(connStr);
                conReport.Open();

                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "select b.Month, b.Fever, b.Dengue, b.Pregnant from (select a.Month, '1' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select "+
                              "  'January' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 1 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '2' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  " +
                              "  'February' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 2 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '3' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'March' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 3 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '4' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'April' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 4 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '5' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'May' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 5 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '6' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'June' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 6 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '7' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'July' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 7 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '8' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'August' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 8 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '9' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'September' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 9 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '10' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'October' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 10 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '11' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'November' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 11 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select a.Month, '12' as 'm', sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'December' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission "+
                              "  where month(convert(datetime,Admission.AdmissionDate,103)) = 12 and YEAR(convert(datetime,AdmissionDate,103))='" + ddlYear.SelectedValue + "' " +
                              "  ) a "+
                              "  group by a.Month "+

                              "  union "+

                              "  select 'Total' as 'Month', '13' as 'm',sum(a.Fever) as 'Fever', sum(a.Dengue) as 'Dengue', sum(a.Pregnant) as 'Pregnant' from ( "+
                              "  select  "+
                              "  'December' as 'Month', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Fever'),0) as 'Fever', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Dengue'),0) as 'Dengue', "+
                              "  isnull((select count(v.VisitationID) from Visitation v where v.VisitationID=Admission.VisitationID and v.MedicalCondition='Pregnant'),0) as 'Pregnant' "+
                              "  from Admission, Visitation "+
                              "  where Visitation.VisitationID=Admission.VisitationID and YEAR(convert(datetime,AdmissionDate,103))='"+ddlYear.SelectedValue+"' " +
                              "  ) a " +
                              "  ) b "+
                              "  order by cast(b.m as int) asc ";
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
                    lblLineSeven.Text = "<p style ='font-size:2em;padding:0;;margin:0;margin-left:20px;font-weight:bold'>Summary Admission Report for year </p>";
                    lblLineEight.Text = "<p style ='padding:0;margin:0;margin-left:245px;font-size:2em;font-weight:bold'>" + ddlYear.SelectedItem.Text + "</p>";

                    GridView1.DataSource = dtr;
                    GridView1.DataBind();
                }
                dtr.Close();
                conReport.Close();
            }
        }
    }
}