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
    public partial class PharmacistView : System.Web.UI.Page
    {
        SqlConnection conHMS;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            txtDate.Enabled = false;

            /*Step 1: Create and Open Connection*/

            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();
        }
        protected void search1_Click(object sender, EventArgs e)
        {
            display();

            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayPatDetails;
            SqlCommand cmdDisplayPatDetails;
            strDisplayPatDetails = "Select Patient.PatientName, Visitation.MedicalCondition From Patient, Visitation " +
                "WHERE Visitation.VisitationID = '" + txtID.Text + "'" +
                "AND Visitation.PatientID = Patient.PatientID";
            cmdDisplayPatDetails = new SqlCommand(strDisplayPatDetails, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drPatDetails;
            drPatDetails = cmdDisplayPatDetails.ExecuteReader();


            /*Step 4: Bind data*/
            if (drPatDetails.HasRows)
            {
                while (drPatDetails.Read())
                {
                    txtName.Text = drPatDetails["PatientName"].ToString();
                    txtCondition.Text = drPatDetails["MedicalCondition"].ToString();

                }
            }
            txtCondition.Enabled = false;
            txtName.Enabled = false;


            /*Step 5: Close SqlReader and Database connection*/
            drPatDetails.Close();

            conHMS.Close();
        }

        protected void display()
        {
            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayVitPreDetails;
            //SqlCommand cmdDisplayVitPreDetails;
            strDisplayVitPreDetails = "Select Drug.DrugID, Drug.DrugName, PrescriptionDetails.Qty, PrescriptionDetails.Tablet, PrescriptionDetails.Times From Prescription, PrescriptionDetails, Drug " +
                "WHERE Prescription.VisitationID = '" + txtID.Text + "'" +
                 "AND Prescription.PrescriptionDate = '" + txtDate.Text + "'" +
                 "AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.DrugID = Drug.DrugID";

            //cmdDisplayVitPreDetails = new SqlCommand(strDisplayVitPreDetails, conHMS);

            /*Step 3: Execute command to retrieve data

            SqlDataReader ;
            drVitPreDetails = cmdDisplayVitPreDetails.ExecuteReader();

            /*Step 4: Bind data

            GridView1.DataSource = drVitPreDetails;
            GridView1.DataBind();

            /*Step 5: Close SqlReader and Database connection
            drVitPreDetails.Close();

            conHMS.Close();*/

            try
            {
                SqlDataAdapter daVitPreDetails;
                daVitPreDetails = new SqlDataAdapter(strDisplayVitPreDetails, conHMS);
                DataSet dsVitPreDetails = new DataSet();
                daVitPreDetails.Fill(dsVitPreDetails);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(dsVitPreDetails.GetXml());
                xmlDoc.Save(MapPath("PrescriptionDetails.xml"));

                DataSet dsDisplayPreDetails = new DataSet();
                dsDisplayPreDetails.ReadXml(MapPath("PrescriptionDetails.xml"));
                GridView1.DataSource = dsDisplayPreDetails;
                GridView1.DataBind();
            }
            catch (Exception e)
            {
                MessageBox.Show("There is no record for this visitation ID.");
            }



            //exportXML(dsVitPreDetails, "PrescriptionDetails.xml");

        }
    }
}