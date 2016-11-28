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
using System.IO;
using System.Windows.Forms;


namespace HMS
{
    public partial class RetrievePrescription : System.Web.UI.Page
    {
        SqlConnection conHMS;

        protected void Page_Load(object sender, EventArgs e)
        {
            search1.Enabled = true;

            HttpCookie cookies = Request.Cookies["Visitation"];
            txtID.Text = cookies["VisitationID"];

            txtDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            txtDate.Enabled = false;
            
            /*Step 1: Create and Open Connection*/

            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();
        }

        protected void search1_Click(object sender, EventArgs e)
        {
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

            search1.Enabled = false;

            btnPrevious.Enabled = true;
            btnToday.Enabled = true;

            /*Step 5: Close SqlReader and Database connection*/
            drPatDetails.Close();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            search1.Enabled = false;

            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayPreviousPreDetails;
            SqlCommand cmdDisplayPreviousPreDetails;
            strDisplayPreviousPreDetails = "Select Prescription.PrescriptionDate, Drug.DrugID, Drug.DrugName, PrescriptionDetails.Qty, PrescriptionDetails.Tablet, PrescriptionDetails.Times From Prescription, PrescriptionDetails, Drug " +
                "WHERE Prescription.VisitationID = '" + txtID.Text + "'" +
                 "AND Prescription.PrescriptionDate <> '" + txtDate.Text + "'" +
                 "AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.DrugID = Drug.DrugID";

            cmdDisplayPreviousPreDetails = new SqlCommand(strDisplayPreviousPreDetails, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drDisplayPreviousPreDetail;
            drDisplayPreviousPreDetail = cmdDisplayPreviousPreDetails.ExecuteReader();

            /*Step 4: Bind data*/
            if (drDisplayPreviousPreDetail.HasRows)
            {
                GridView1.DataSource = drDisplayPreviousPreDetail;
                GridView1.DataBind();
            }
            else
            {
                MessageBox.Show("There is no record for this visitation ID.");
            }
           
        }

        protected void btnToday_Click(object sender, EventArgs e)
        {
            search1.Enabled = false;

            display();

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


        /*public void exportXML(DataSet dsVitPreDetails, string path)
        {
            try
            {
                string filename = Server.MapPath(path);
                FileStream fsout = new FileStream(filename, FileMode.Create, FileAccess.Write);
                XmlTextWriter xtw = new XmlTextWriter(fsout, Encoding.Unicode);
                dsVitPreDetails.WriteXml(xtw, XmlWriteMode.WriteSchema);
                xtw.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Successful...');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Failed...');", true);
            }
        }*/

    }
}