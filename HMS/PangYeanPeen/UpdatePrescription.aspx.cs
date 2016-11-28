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
    public partial class UpdatePrescription : System.Web.UI.Page
    {
        SqlConnection conHMS;
        static string currentQty = "";

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
            lblDisplay.Text = "";
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

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
           // txtlabel.Text = GridView1.Rows[e.NewEditIndex].Cells[3].Text;
            System.Web.UI.WebControls.Label currentQuantity = GridView1.Rows[e.NewEditIndex].FindControl("Qty") as System.Web.UI.WebControls.Label;
            currentQty = currentQuantity.Text;

            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            display();


            
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
          
         
            int drugTotalQty = 0;
            int drugStoreQty = 0;
            

            //currentQty = e.OldValues["Qty"].ToString();
           //Label currentQty = GridView1.SelectedRow.FindControl("Qty") as Label;
         
            //currentQty = e.OldValues["Qty"];
            //TextBox currentQty = GridView1.Rows[Convert.ToInt32(e.OldValues)].FindControl("Qty") as TextBox;
            System.Web.UI.WebControls.Label PrescriptionDetailsID = GridView1.Rows[e.RowIndex].FindControl("PrescriptionDetailsID") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label DrugID = GridView1.Rows[e.RowIndex].FindControl("DrugID") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.TextBox Qty = GridView1.Rows[e.RowIndex].FindControl("Qty") as System.Web.UI.WebControls.TextBox;
            System.Web.UI.WebControls.TextBox Times = GridView1.Rows[e.RowIndex].FindControl("Times") as System.Web.UI.WebControls.TextBox;
            System.Web.UI.WebControls.TextBox Tablet = GridView1.Rows[e.RowIndex].FindControl("Tablet") as System.Web.UI.WebControls.TextBox;
             
            /*Step2 : SQL Command object to retrieve data from table*/
            string strUpdatePreDetails;
            SqlCommand cmdUpdatePreDetails;
            /*strUpdatePreDetails = "Update PrescriptionDetails Set Qty = @Qty, Times = @Times, Tablet = @Tablet Where DrugID = @DrugID";*/
            strUpdatePreDetails = "Update PrescriptionDetails Set PrescriptionDetails.Qty = '" + Qty.Text + "', PrescriptionDetails.Times = '" + Times.Text + "', PrescriptionDetails.Tablet = '" + Tablet.Text + "'From Prescription, PrescriptionDetails, Drug WHERE Prescription.VisitationID = '" + txtID.Text + "'" +
                 "AND Prescription.PrescriptionDate = '" + txtDate.Text + "'" +
                 "AND Prescription.PrescriptionID = PrescriptionDetails.PrescriptionID AND PrescriptionDetails.PrescriptionDetailsID = '" +PrescriptionDetailsID.Text + "'" +
                 "AND PrescriptionDetails.DrugID = '" + DrugID.Text + "'";
            cmdUpdatePreDetails = new SqlCommand(strUpdatePreDetails, conHMS);

            /*cmdUpdatePreDetails.Parameters.AddWithValue("@DrugID", GridView1.Rows[e.RowIndex].FindControl("DrugID"));
            cmdUpdatePreDetails.Parameters.AddWithValue("@Qty", GridView1.Rows[e.RowIndex].FindControl("Qty"));
            cmdUpdatePreDetails.Parameters.AddWithValue("@Times", GridView1.Rows[e.RowIndex].FindControl("Times"));
            cmdUpdatePreDetails.Parameters.AddWithValue("@Tablet", GridView1.Rows[e.RowIndex].FindControl("Tablet"));


            /*Step 3: Execute command to update data*/

            int n = cmdUpdatePreDetails.ExecuteNonQuery();


            /*Step 4: Display update status*/
            if (n > 0)
                lblDisplay.Text = "Successful updated";
                //MessageBox.Show("Success");
            else
                lblDisplay.Text = "Failed updated";
                //MessageBox.Show("Failed");
         
            /*Step2 : SQL Command object to retrieve data from table*/

            string strDisplayDrug;
            SqlCommand cmdDisplayDrug;
            strDisplayDrug = "Select * From Drug Where DrugID = '" + DrugID.Text + "'";
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

           // newQty = Convert.ToInt32(Qty.Text);

            if (Convert.ToInt32(currentQty.ToString()) < Convert.ToInt32(Qty.Text))
            {
                drugTotalQty = (drugStoreQty - (Convert.ToInt32(Qty.Text) - Convert.ToInt32(currentQty.ToString())));
            }
            else if (Convert.ToInt32(currentQty.ToString()) > Convert.ToInt32(Qty.Text))
            {
                drugTotalQty = (drugStoreQty + (Convert.ToInt32(currentQty.ToString()) - Convert.ToInt32(Qty.Text)));
            }

           // txtlabel.Text = Convert.ToString(drugStoreQty);

            drDrug.Close();



            /*Step2 : SQL Command object to retrieve data from table*/

            string strInsertQty;
            SqlCommand cmdInsertQty;
            strInsertQty = "Update Drug Set DrugQty = '" + drugTotalQty + "'" + "WHERE DrugID = '" + DrugID.Text + "'";
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


            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            
            /*Step 5: Close SqlReader and Database connection*/   

            display();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            display();

            conHMS.Close();
            
        }  
       
    }
}