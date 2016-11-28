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
    public partial class DeletePrescription : System.Web.UI.Page
    {
        SqlConnection conHMS;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookies = Request.Cookies["Visitation"];
            txtID.Text = cookies["VisitationID"];

            txtDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            txtDate.Enabled = false;
            
            /*Step 1: Create and Open Connection*/

            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conHMS = new SqlConnection(connStr);
            conHMS.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
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
        }

        protected void display()
        {
            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayPreDetails;
            SqlCommand cmdDisplayPreDetails;
            strDisplayPreDetails = "Select PrescriptionDetails.PrescriptionDetailsID, Drug.DrugID, Drug.DrugName, PrescriptionDetails.Qty, PrescriptionDetails.Tablet, PrescriptionDetails.Times From Prescription, PrescriptionDetails, Drug " +
                "WHERE Prescription.VisitationID = '" + txtID.Text + "'" +
                 "AND Prescription.PrescriptionDate = '" + txtDate.Text + "'" +
                 "AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.DrugID = Drug.DrugID";

            cmdDisplayPreDetails = new SqlCommand(strDisplayPreDetails, conHMS);

        

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drPreDetails;
            drPreDetails = cmdDisplayPreDetails.ExecuteReader();

            /*Step 4: Bind data*/
            if (drPreDetails.HasRows)
            {
                GridView1.DataSource = drPreDetails;
                GridView1.DataBind();
            }
            else
            {
                MessageBox.Show("There is no record for this visitation ID.");
            }
                
            /*Step 5: Close SqlReader and Database connection*/
            drPreDetails.Close();
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int drugTotalQty = 0;
            int drugStoreQty = 0;

            System.Web.UI.WebControls.Label PrescriptionDetailsID = GridView1.Rows[e.RowIndex].FindControl("PrescriptionDetailsID") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label drugID = GridView1.Rows[e.RowIndex].FindControl("DrugID") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label qtyDeleted = GridView1.Rows[e.RowIndex].FindControl("Qty") as System.Web.UI.WebControls.Label;
        

            /*Step2 : SQL Command object to retrieve data from table*/
            string strDeletePreDetails;
            SqlCommand cmdDeletePreDetails;
            strDeletePreDetails = "Delete PrescriptionDetails From Prescription, PrescriptionDetails, Drug WHERE Prescription.VisitationID = '" + txtID.Text + "'" +
                 "AND Prescription.PrescriptionDate = '" + txtDate.Text + "'" +
                 "AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.PrescriptionDetailsID = '" +PrescriptionDetailsID.Text + "'" + 
                 "AND PrescriptionDetails.DrugID = '" + drugID.Text + "'";
            cmdDeletePreDetails = new SqlCommand(strDeletePreDetails, conHMS);


            /*Step 3: Execute command to update data*/

            int n = cmdDeletePreDetails.ExecuteNonQuery();


            /*Step 4: Display update status*/
            if (n > 0)
                lblDisplay.Text = "Successful deleted";
                //MessageBox.Show("Success");
            else
                lblDisplay.Text = "Failed deleted";
                //MessageBox.Show("Failed");

            /*Step 5: Close SqlReader and Database connection*/
            

            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayDrug;
            SqlCommand cmdDisplayDrug;
            strDisplayDrug = "Select * From Drug Where DrugID = '" +drugID.Text +"'" ;
            cmdDisplayDrug = new SqlCommand(strDisplayDrug, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drDrug;
            drDrug = cmdDisplayDrug.ExecuteReader();


            /*Step 4: Bind data*/
            if (drDrug.HasRows)
            {
                while (drDrug.Read())
                {

                    drugStoreQty = Convert.ToInt32(drDrug["DrugQty"].ToString());
                   // drugID1 = drDrug["DrugID"].ToString();
                   // drugName =  drDrug["DrugName"].ToString();
                   // UnitPrice = drDrug["UnitPrice"].ToString();
                   // dosage = Convert.ToInt32(drDrug["Dosage"].ToString());
                   // status = drDrug["DrugStatus"].ToString();
                   // catID = drDrug["CategoryID"].ToString();
                }
            }

            drugTotalQty = drugStoreQty + Convert.ToInt32(qtyDeleted.Text);

            drDrug.Close();

            /*Step2 : SQL Command object to retrieve data from table*/

            string strInsertQty;
            SqlCommand cmdInsertQty;
            strInsertQty = "Update Drug Set DrugQty = '" + drugTotalQty + "'" + "WHERE DrugID = '" + drugID.Text + "'";
            cmdInsertQty = new SqlCommand(strInsertQty, conHMS);


            /*Step 3: Execute command to update data

            int n = */
            cmdInsertQty.ExecuteNonQuery();

            /*Step 4: Display update status

            if (n > 0)
                MessageBox.Show("Success");
            else     
                MessageBox.Show("Failed");*/

            /*Step 5: Close SqlReader and Database connection*/

            conHMS.Close();
        }

  

    }
}