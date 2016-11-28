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
    public partial class WardInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conWard;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conWard = new SqlConnection(connStr);
                conWard.Open();

                string strRetrieve;
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT DISTINCT WardPic, WardType, NoOfBedPerRoom, convert(decimal(10,2),RatePerDay)"+
                " as 'RatePerDay', Facilities FROM Ward ORDER BY NoOfBedPerRoom desc";

                cmdRetrieve = new SqlCommand(strRetrieve, conWard);

                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();

                DataList1.DataSource = dtr;
                DataList1.DataBind();

                conWard.Close();
                dtr.Close();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection conBed;
            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conBed = new SqlConnection(connStr);
            conBed.Open();

            string strRetrieve="";
            SqlCommand cmdRetrieve;

            if (Convert.ToInt32(e.CommandArgument) == 4)
            {               
                strRetrieve = "SELECT WardDetails as 'Ward Details', BedNo as 'Bed No.', BedStatus as" +
                " 'Bed Status' FROM Ward, Bed WHERE Bed.WardNo = Ward.WardNo AND WardType = 'Standard'";
            }
            else if (Convert.ToInt32(e.CommandArgument) == 2)
            {
                strRetrieve = "SELECT WardDetails as 'Ward Details', BedNo as 'Bed No.', BedStatus as" +
                " 'Bed Status' FROM Ward, Bed WHERE Bed.WardNo = Ward.WardNo AND WardType = 'Semi Private'";
            }
            else
            {
                strRetrieve = "SELECT WardDetails as 'Ward Details', BedNo as 'Bed No.', BedStatus as" +
                " 'Bed Status' FROM Ward, Bed WHERE Bed.WardNo = Ward.WardNo AND WardType = 'Private'";
            }

            cmdRetrieve = new SqlCommand(strRetrieve, conBed);
            SqlDataReader dtr;
            dtr = cmdRetrieve.ExecuteReader();
            GridView1.DataSource = dtr;
            GridView1.DataBind();

            conBed.Close();
            dtr.Close();
        }
    }
}