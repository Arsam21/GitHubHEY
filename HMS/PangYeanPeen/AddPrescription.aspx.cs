using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace HMS
{
    public partial class Prescription : System.Web.UI.Page
    {
        SqlConnection conHMS;
        static string tempPrescriptionID = "";

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

            /*Step2 : SQL Command object to retrieve data from table*/

            string strSelectDrugCat;
            SqlCommand cmdSelectDrugCat;
            strSelectDrugCat = "Select CategoryID, CategoryType From Category";
            cmdSelectDrugCat = new SqlCommand(strSelectDrugCat, conHMS);
         
            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drDrugCat;
            drDrugCat = cmdSelectDrugCat.ExecuteReader();

            if (!IsPostBack)
            {
                /*Step 4: Bind data*/
                ddlDrugCat.DataSource = drDrugCat;
                ddlDrugCat.DataTextField = "CategoryType";
                ddlDrugCat.DataValueField = "CategoryID";
                ddlDrugCat.DataBind();
            }

            /*Step 5: Close SqlReader and Database connection*/
            drDrugCat.Close();


        }

        protected void search1_Click(object sender, EventArgs e)
        {
            search1.Enabled = false;

            /*Step2 : SQL Command object to retrieve data from table*/

            string strSelectPrescriptionID;
            SqlCommand cmdSelectPrescriptionID;
            strSelectPrescriptionID = "Select MAX(PrescriptionID) AS LastPrescriptionID FROM Prescription";
            cmdSelectPrescriptionID = new SqlCommand(strSelectPrescriptionID, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drSelectPrescriptionID;
            drSelectPrescriptionID = cmdSelectPrescriptionID.ExecuteReader();

            /*Step 4: Read Data*/

            drSelectPrescriptionID.Read();
            string tempPrescriptionIDFront = drSelectPrescriptionID["LastPrescriptionID"].ToString().Substring(0, 3);
            int tempPrescriptionIDBack = Convert.ToInt32(drSelectPrescriptionID["LastPrescriptionID"].ToString().Substring(3, 5)) + 1;
            tempPrescriptionID = tempPrescriptionIDFront + Convert.ToString(tempPrescriptionIDBack);
            
            /*Step 5: Close SqlReader and Database connection*/

            drSelectPrescriptionID.Close();


            /*Step2 : SQL Command object to retrieve data from table*/

            string strInsertPrescription;
            SqlCommand cmdInsertPrescription;
            strInsertPrescription = "Insert Into Prescription (PrescriptionID, PrescriptionDate, VisitationID ) Values (@PrescriptionID, @PrescriptionDate, @VisitationID )";
            cmdInsertPrescription = new SqlCommand(strInsertPrescription, conHMS);

            cmdInsertPrescription.Parameters.AddWithValue("@PrescriptionID", tempPrescriptionID);
            cmdInsertPrescription.Parameters.AddWithValue("@PrescriptionDate", txtDate.Text);
            cmdInsertPrescription.Parameters.AddWithValue("@VisitationID", txtID.Text);

            /*Step 3: Execute command to update data

            int n = */cmdInsertPrescription.ExecuteNonQuery();

            /*Step 4: Display update status

            if (n > 0)
                MessageBox.Show("Success");
            else     
                MessageBox.Show("Failed");*/

            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayPatDetails;
            SqlCommand cmdDisplayPatDetails;
            strDisplayPatDetails = "Select Patient.PatientName, Visitation.MedicalCondition From Patient, Visitation " +
                "WHERE Visitation.VisitationID = '" +txtID.Text + "'" +
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

            search2.Enabled = true;
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            search1.Enabled = false;
            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayDrug;
            SqlCommand cmdDisplayDrug;
            strDisplayDrug = "Select DrugID, DrugName, Convert(numeric(10,2),UnitPrice) As [UnitPrice (RM)], DrugQty, Dosage As [Dosage (mg)], DrugStatus From Drug Where CategoryID = '" +ddlDrugCat.SelectedValue +"'";
            cmdDisplayDrug = new SqlCommand(strDisplayDrug, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drDrug;
            drDrug = cmdDisplayDrug.ExecuteReader();

       
            /*Step 4: Bind data*/
            GridView1.DataSource = drDrug;
            GridView1.DataBind();

            /*Step 5: Close SqlReader and Database connection*/
            drDrug.Close();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            search1.Enabled = false;

            if (Convert.ToInt32(GridView1.SelectedRow.Cells[4].Text) <= 0)
            {
                MessageBox.Show("The drug is out of stock.");
            }
            else if (GridView1.SelectedRow.Cells[6].Text == "Unavailable")
            {
                MessageBox.Show("There is unavailable for this type of drug.");
            }
            else
            {
                display();
         
            }         
        }

        protected void display()
        {
            Table1.Visible = true;
            Table2.Visible = true;

            /*Step2 : SQL Command object to retrieve data from table*/

            string strSelectDrug;
            SqlCommand cmdSelectDrug;
            strSelectDrug = "Select DrugID, DrugName From Drug Where DrugID = '" + GridView1.SelectedRow.Cells[1].Text + "'";
            cmdSelectDrug = new SqlCommand(strSelectDrug, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drSelectDrug;
            drSelectDrug = cmdSelectDrug.ExecuteReader();


            /*Step 4: Read Data*/
            drSelectDrug.Read();
            txtDrugID.Text = drSelectDrug["DrugID"].ToString();
            txtDrugName.Text = drSelectDrug["DrugName"].ToString();
            txtDrugID.Enabled = false;
            txtDrugName.Enabled = false;
          
            /*Step 5: Close SqlReader and Database connection*/
            drSelectDrug.Close();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            search1.Enabled = false;

            int drugTotalQty = 0;
            int drugStoreQty = 0;
            
            /*Step2 : SQL Command object to retrieve data from table*/

            string strSelectPrescriptionDetailsID;
            SqlCommand cmdSelectPrescriptionDetailsID;
            strSelectPrescriptionDetailsID = "Select MAX(PrescriptionDetailsID) AS LastPrescriptionDetailsID FROM PrescriptionDetails";
            cmdSelectPrescriptionDetailsID = new SqlCommand(strSelectPrescriptionDetailsID, conHMS);

            /*Step 3: Execute command to retrieve data*/

            SqlDataReader drSelectPrescriptionDetailsID;
            drSelectPrescriptionDetailsID = cmdSelectPrescriptionDetailsID.ExecuteReader();


            /*Step 4: Read Data*/
            drSelectPrescriptionDetailsID.Read();


            string tempPrescriptionDetailsIDFront = drSelectPrescriptionDetailsID["LastPrescriptionDetailsID"].ToString().Substring(0, 3);
            int tempPrescriptionDetailsIDBack = Convert.ToInt32(drSelectPrescriptionDetailsID["LastPrescriptionDetailsID"].ToString().Substring(3, 5)) + 1;
            String tempPrescriptionDetailsID = tempPrescriptionDetailsIDFront + Convert.ToString(tempPrescriptionDetailsIDBack);

            /*Step 5: Close SqlReader and Database connection*/
            drSelectPrescriptionDetailsID.Close();

            /*Step2 : SQL Command object to retrieve data from table*/

            string strInsertPrescriptionDetails;
            SqlCommand cmdInsertPrescriptionDetails;
            strInsertPrescriptionDetails = "Insert Into PrescriptionDetails (PrescriptionDetailsID, Qty, Tablet, Times, PrescriptionID, DrugID) Values (@PrescriptionDetailsID, @Qty, @Tablet, @Times, @PrescriptionID, @DrugID) ";
            cmdInsertPrescriptionDetails = new SqlCommand(strInsertPrescriptionDetails, conHMS);
    

            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@PrescriptionDetailsID", tempPrescriptionDetailsID);
            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@Qty", int.Parse(txtQty.Text));
            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@Tablet", int.Parse(txtTablet.Text));
            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@Times", int.Parse(txtTimes.Text));
            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@PrescriptionID", tempPrescriptionID);
            cmdInsertPrescriptionDetails.Parameters.AddWithValue("@DrugID", txtDrugID.Text);

            /*Step 3: Execute command to update data*/

            int n = cmdInsertPrescriptionDetails.ExecuteNonQuery();

            /*Step 4: Display update status*/

            if (n > 0)
                MessageBox.Show("Successful Added");
            else
                MessageBox.Show("Failed Added");




            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayDrug;
            SqlCommand cmdDisplayDrug;
            strDisplayDrug = "Select * From Drug Where DrugID = '" + txtDrugID.Text + "'";
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

                }
            }

            drugTotalQty = drugStoreQty - Convert.ToInt32(txtQty.Text);

            drDrug.Close();



            /*Step2 : SQL Command object to retrieve data from table*/

            string strInsertQty;
            SqlCommand cmdInsertQty;
            strInsertQty = "Update Drug Set DrugQty = '" + drugTotalQty + "'" + "WHERE DrugID = '" + txtDrugID.Text + "'";
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