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
    public partial class PatientCheckUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToShortDateString();

            if (txtMedicalCondition.Text != "")
            {               
                if (txtMedicalCondition.Text == "Fever")
                {
                    if (rblBloodPressure.SelectedIndex != -1 && rblHeartRate.SelectedIndex != -1 && rblTemperature.SelectedIndex != -1)
                    {
                        if (rblBloodPressure.SelectedIndex == 1 && rblHeartRate.SelectedIndex == 1 && rblTemperature.SelectedIndex == 1)
                        {
                            txtPatientCondition.Text = "Normal";
                        }
                        else
                        {
                            txtPatientCondition.Text = "Bad";
                        }
                    }                    
                }
                else if (txtMedicalCondition.Text == "Dengue")
                {
                    if (rblBloodPressure.SelectedIndex != -1 && rblHeartRate.SelectedIndex != -1 && rblPlatelet.SelectedIndex != -1)
                    {
                        if (rblBloodPressure.SelectedIndex == 1 && rblHeartRate.SelectedIndex == 1 && rblPlatelet.SelectedIndex == 1)
                        {
                            txtPatientCondition.Text = "Normal";
                        }
                        else
                        {
                            txtPatientCondition.Text = "Bad";
                        }
                    }
                }
                else
                {
                    if (rblBloodPressure.SelectedIndex != -1 && rblHeartRate.SelectedIndex != -1)
                    {
                        if (rblBloodPressure.SelectedIndex == 1 && rblHeartRate.SelectedIndex == 1)
                        {
                            txtPatientCondition.Text = "Normal";
                        }
                        else
                        {
                            txtPatientCondition.Text = "Bad";
                        }
                    }
                }                             
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            txtMedicalCondition.Text = "";
            txtWardNo.Text = "";
            txtBedNo.Text = "";
            rblBloodPressure.ClearSelection();
            rblHeartRate.ClearSelection();
            rblPlatelet.ClearSelection();
            rblTemperature.ClearSelection();
            lblPlatelet.ForeColor = System.Drawing.Color.Black;
            rblPlatelet.Enabled = true;
            rblPlatelet.ForeColor = System.Drawing.Color.Black;
            lblTemperature.ForeColor = System.Drawing.Color.Black;
            rblTemperature.Enabled = true;
            rblTemperature.ForeColor = System.Drawing.Color.Black;
            txtPatientCondition.Text = "";
        }
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "" || txtPatientID.Text == String.Empty)
            {
                MessageBox.Show("Patient ID cannot be null or empty!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlConnection conPatient;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conPatient = new SqlConnection(connStr);
                conPatient.Open();

                /////////////////////////get patient's data/////////////////////////
                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT PatientName, MedicalCondition,WardNo, BedNo FROM Visitation,"+
                    " Admission, Patient WHERE Visitation.VisitationID = Admission.VisitationID AND"+
                    " Patient.PatientID = Visitation.PatientID AND AdmissionStatus = 'Admitted' AND"+
                    " Admission.VisitationID = (SELECT DISTINCT VisitationID FROM Visitation WHERE"+
                    " Visitation.PatientID = @PatientID AND VisitationID = (SELECT max(VisitationID)"+
                    " FROM Visitation WHERE PatientID = @PatientID))";
                //----------------------------------------------------------------//
                cmdRetrieve = new SqlCommand(strRetrieve, conPatient);
                cmdRetrieve.Parameters.AddWithValue("@PatientID", txtPatientID.Text);
                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();
                if (dtr.HasRows)
                {
                    if (dtr.Read())
                    {
                        txtPatientName.Text = "" + dtr["PatientName"];
                        txtMedicalCondition.Text = "" + dtr["MedicalCondition"];
                        txtWardNo.Text = "" + dtr["WardNo"];
                        txtBedNo.Text = "" + dtr["BedNo"];
                        dtr.Close();
                        if (txtMedicalCondition.Text == "Dengue")
                        {
                            rblTemperature.Enabled = false;
                            lblTemperature.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblTemperature.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblPlatelet.Enabled = true;
                            lblPlatelet.ForeColor = System.Drawing.Color.Black;
                            rblPlatelet.ForeColor = System.Drawing.Color.Black;
                        }
                        else if (txtMedicalCondition.Text == "Fever")
                        {
                            rblPlatelet.Enabled = false;
                            lblPlatelet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblPlatelet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblTemperature.Enabled = true;
                            lblTemperature.ForeColor = System.Drawing.Color.Black;
                            rblTemperature.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            rblTemperature.Enabled = false;
                            lblTemperature.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblTemperature.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblPlatelet.Enabled = false;
                            lblPlatelet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                            rblPlatelet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#888888");                       
                        }
                    }
                }
                else
                {/////////////////clear all input///////////////////////
                    txtPatientID.Text = "";
                    txtPatientName.Text = "";
                    txtMedicalCondition.Text = "";
                    txtWardNo.Text = "";
                    txtBedNo.Text = "";
                 //----------------------------------------------------//

                 MessageBox.Show("Patient is not admitted.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                conPatient.Close();
            }           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string error = "false";
            if (txtPatientID.Text == "" || txtPatientID.Text == String.Empty)
            {
                MessageBox.Show("Patient ID cannot be null or empty!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (txtMedicalCondition.Text == "Dengue")
                {
                    if (rblBloodPressure.SelectedItem == null || rblHeartRate.SelectedItem == null || rblPlatelet.SelectedItem == null)
                    {
                        error = "true";
                        MessageBox.Show("Radiobutton is not completely checked!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (txtMedicalCondition.Text == "Fever")
                {
                    if (rblBloodPressure.SelectedItem == null || rblHeartRate.SelectedItem == null || rblTemperature.SelectedItem==null)
                    {
                        error = "true";
                        MessageBox.Show("Radiobutton is not completely checked!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (rblBloodPressure.SelectedItem == null || rblHeartRate.SelectedItem == null)
                    {
                        error = "true";
                        MessageBox.Show("Radiobutton is not completely checked!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (error.Equals("false"))
                {
                    SqlConnection conSymptomHistory;
                    string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                    conSymptomHistory = new SqlConnection(connStr);
                    conSymptomHistory.Open();
                    //////////////////////////get SymptomHistory last primary key////////////////////
                    string strRetrieve;
                    SqlCommand cmdRetrieve;
                    strRetrieve = "SELECT TOP 1 SymptomHistoryNo FROM SymptomHistory ORDER BY SymptomHistoryNo" +
                        " DESC";
                    //-----------------------------------------------------------------------------//
                    cmdRetrieve = new SqlCommand(strRetrieve, conSymptomHistory);

                    SqlDataReader dtr;
                    dtr = cmdRetrieve.ExecuteReader();
                    if (dtr.Read())
                    {
                        int id = Convert.ToInt32(dtr["SymptomHistoryNo"]);
                        id += 1;
                        dtr.Close();

                        //////////////////////////insert into SymptomHistory table////////////////////
                        string strInsert;
                        SqlCommand cmdInsert;
                        strInsert = "INSERT INTO SymptomHistory(SymptomHistoryNo, RecordDate," +
                            " SymptomHistoryDetails, PatientID) VALUES (@id, @date, @SymptomHistoryDetails," +
                            " @PatientID)";
                        //--------------------------------------------------------------------------//
                        cmdInsert = new SqlCommand(strInsert, conSymptomHistory);

                        cmdInsert.Parameters.AddWithValue("@id", id);
                        cmdInsert.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                        cmdInsert.Parameters.AddWithValue("@SymptomHistoryDetails", txtPatientCondition.Text);
                        cmdInsert.Parameters.AddWithValue("@PatientID", txtPatientID.Text);

                        int n = cmdInsert.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("Details is successfully recorded.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Details fail to be recorded.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    txtPatientID.Text = "";
                    txtPatientName.Text = "";
                    txtMedicalCondition.Text = "";
                    txtWardNo.Text = "";
                    txtBedNo.Text = "";
                    rblBloodPressure.ClearSelection();
                    rblHeartRate.ClearSelection();
                    rblPlatelet.ClearSelection();
                    rblTemperature.ClearSelection();
                    lblPlatelet.ForeColor = System.Drawing.Color.Black;
                    rblPlatelet.Enabled = true;
                    rblPlatelet.ForeColor = System.Drawing.Color.Black;
                    lblTemperature.ForeColor = System.Drawing.Color.Black;
                    rblTemperature.Enabled = true;
                    rblTemperature.ForeColor = System.Drawing.Color.Black;
                    txtPatientCondition.Text = "";
                }                
            }
        }       
    }
}