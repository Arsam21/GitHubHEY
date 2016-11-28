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
    public partial class DischargeByNurse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conDischarge;
                string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
                conDischarge = new SqlConnection(connStr);
                conDischarge.Open();

                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT AdmissionDate as 'Admission Date', AdmissionNo as 'Admission No.',"+
                    " Visitation.PatientID as 'Patient ID', PatientName as 'Patient Name',"+
                    " MedicalCondition as 'Medical Condition', WardNo as 'Ward No.', BedNo as 'Bed No.',"+
                    " ApprovalStatus as 'Approval Status',ApprovalNo as 'Approval No.' FROM Admission, Visitation, Patient, Approval,"+
                    " SymptomHistory WHERE Admission.VisitationID = Visitation.VisitationID AND"+
                    " Visitation.PatientID = Patient.PatientID AND SymptomHistory.PatientID = "+
                    " Patient.PatientID AND Approval.SymptomHistoryNo = SymptomHistory.SymptomHistoryNo"+
                    " AND AdmissionStatus = 'Admitted' AND"+
                    " convert(varchar(10),DATEADD(day, NoOfDaysStay+ISNULL(ExtraDaysStay,0),"+
                    " convert(datetime,AdmissionDate,103)),103) = convert(varchar(10),getdate(),103) AND"+
                    " ApprovalStatus = 'Approved' AND SymptomHistory.SymptomHistoryNo = (SELECT"+
                    " max(SymptomHistoryNo) FROM SymptomHistory WHERE PatientID = Visitation.PatientID)";

                cmdRetrieve = new SqlCommand(strRetrieve, conDischarge);
                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();
                if (dtr.HasRows)
                {                 
                    GridView1.DataSource = dtr;
                    GridView1.DataBind();
                }
                else
                {
                    lblDisplay.Text = "There are no more list of discharge for today.";
                    btnDischarge.Visible = false;
                }
                dtr.Close();
                conDischarge.Close();
            }
        }

        protected void btnDischarge_Click(object sender, EventArgs e)
        {
            int i = GridView1.Rows.Count;
            int x = 0, n, n2, n3, n4;
            SqlConnection conDischarge;
            string connStr = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
            conDischarge = new SqlConnection(connStr);
            conDischarge.Open();

            do
            {
                ////////get last CheckOutNo primary key
                string strRetrieve5 = "";
                SqlCommand cmdRetrieve5;
                strRetrieve5 = "SELECT TOP 1 CheckOutNo FROM CheckOut ORDER BY CheckOutNo DESC";
                cmdRetrieve5 = new SqlCommand(strRetrieve5, conDischarge);
                SqlDataReader dtr5;
                dtr5 = cmdRetrieve5.ExecuteReader();
                int id=0;
                if (dtr5.Read())
                {
                    id = Convert.ToInt32(dtr5["CheckOutNo"]);
                    id += 1;
                    dtr5.Close();
                }
                
                    /////////insert into checkout table//////////
                    string strInsert5;
                    SqlCommand cmdInsert5;
                    strInsert5 = "INSERT INTO CheckOut(CheckOutNo,CheckOutDate,ApprovalNo,AdmissionNo)" +
                        " VALUES(@Id, @date,@approvalNo, @admissionNo)";
                    cmdInsert5 = new SqlCommand(strInsert5, conDischarge);

                    cmdInsert5.Parameters.AddWithValue("@Id", id);
                    cmdInsert5.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    cmdInsert5.Parameters.AddWithValue("@approvalNo", GridView1.Rows[x].Cells[8].Text);
                    cmdInsert5.Parameters.AddWithValue("@admissionNo", GridView1.Rows[x].Cells[1].Text);

                    n4 = cmdInsert5.ExecuteNonQuery();
                
                ///////////update bed status////////////
                string strUpdate = "";
                SqlCommand cmdUpdate;
                strUpdate = "UPDATE Bed SET BedStatus = 'Available' WHERE BedNo =" +
                    " '" + GridView1.Rows[x].Cells[6].Text + "' ";

                cmdUpdate = new SqlCommand(strUpdate, conDischarge);
                n = cmdUpdate.ExecuteNonQuery();                
                //-----------------------------------//
                ////////update patient status//////////
                string strUpdate2 = "";
                SqlCommand cmdUpdate2;
                strUpdate2 = "UPDATE Patient SET PatientStatus = 'Discharged' WHERE PatientID =" +
                    " '" + GridView1.Rows[x].Cells[2].Text + "' ";

                cmdUpdate2 = new SqlCommand(strUpdate2, conDischarge);
                n2 = cmdUpdate2.ExecuteNonQuery();               
                //-----------------------------------//
                ////////update admission status//////////
                string strUpdate3 = "";
                SqlCommand cmdUpdate3;
                strUpdate3 = "UPDATE Admission SET AdmissionStatus = 'Discharged' WHERE AdmissionNo =" +
                    " '" + GridView1.Rows[x].Cells[1].Text + "' ";

                cmdUpdate3 = new SqlCommand(strUpdate3, conDischarge);
                n3 = cmdUpdate3.ExecuteNonQuery();                
                //-----------------------------------//
                
                ////////check if any equipment is used/////////
                string strRetrieve = "";
                SqlCommand cmdRetrieve;
                strRetrieve = "SELECT EquipmentID FROM EquipmentUtilized WHERE AdmissionNo = " + 
                    " '"+GridView1.Rows[x].Cells[1].Text+"'";
                cmdRetrieve = new SqlCommand(strRetrieve, conDischarge);
                SqlDataReader dtr;
                dtr = cmdRetrieve.ExecuteReader();
                if (dtr.Read())
                {
                    dtr.Close();
                    string strRetrieve2 = "";
                    SqlCommand cmdRetrieve2;
                    strRetrieve2 = "SELECT COUNT(EquipmentID) as count FROM EquipmentUtilized WHERE"+
                            " EquipmentID = 'EQU10001' AND AdmissionNo = '"+GridView1.Rows[x].Cells[1].Text+"'";
                    cmdRetrieve2 = new SqlCommand(strRetrieve2, conDischarge);
                    SqlDataReader dtr2;
                    dtr2 = cmdRetrieve2.ExecuteReader();
                    if (dtr2.Read())
                    {
                        int count = Convert.ToInt32(dtr2["count"]);
                        string strUpdate4 = "";
                        SqlCommand cmdUpdate4;
                        strUpdate4 = "UPDATE Equipment SET EquipmentQty =  CONVERT(INT,EquipmentQty) +'" + count + "'" +
                                " WHERE EquipmentID = 'EQU10001'";                           
                        dtr2.Close();
                        cmdUpdate4 = new SqlCommand(strUpdate4, conDischarge);
                        cmdUpdate4.ExecuteNonQuery();
                    }

                    string strRetrieve3 = "";
                    SqlCommand cmdRetrieve3;
                    strRetrieve3 = "SELECT COUNT(EquipmentID) as count FROM EquipmentUtilized WHERE"+
                            " EquipmentID = 'EQU10002' AND AdmissionNo = '"+GridView1.Rows[x].Cells[1].Text+"'";
                    cmdRetrieve3 = new SqlCommand(strRetrieve3, conDischarge);
                    SqlDataReader dtr3;
                    dtr3 = cmdRetrieve3.ExecuteReader();
                    if (dtr3.Read())
                    {
                        int count = Convert.ToInt32(dtr3["count"]);
                        string strUpdate4 = "";
                        SqlCommand cmdUpdate4;
                        strUpdate4 = "UPDATE Equipment SET EquipmentQty = CONVERT(INT,EquipmentQty) +'" + count + "'" +
                                " WHERE EquipmentID = 'EQU10002'";
                        dtr3.Close();
                        cmdUpdate4 = new SqlCommand(strUpdate4, conDischarge);
                        cmdUpdate4.ExecuteNonQuery();
                    }

                    string strRetrieve4 = "";
                    SqlCommand cmdRetrieve4;
                    strRetrieve4 = "SELECT COUNT(EquipmentID) as count FROM EquipmentUtilized WHERE" +
                            " EquipmentID = 'EQU10003' AND AdmissionNo = '" + GridView1.Rows[x].Cells[1].Text + "'";
                    cmdRetrieve4 = new SqlCommand(strRetrieve4, conDischarge);
                    SqlDataReader dtr4;
                    dtr4 = cmdRetrieve4.ExecuteReader();
                    if (dtr4.Read())
                    {
                        int count = Convert.ToInt32(dtr4["count"]);
                        string strUpdate4 = "";
                        SqlCommand cmdUpdate4;
                        strUpdate4 = "UPDATE Equipment SET EquipmentQty = CONVERT(INT,EquipmentQty) +'" + count + "'" +
                                " WHERE EquipmentID = 'EQU10003'";
                        dtr4.Close();
                        cmdUpdate4 = new SqlCommand(strUpdate4, conDischarge);
                        cmdUpdate4.ExecuteNonQuery();
                    }
                } dtr.Close();
                i--;
                x++;
            } while (x != GridView1.Rows.Count);

            if (n4 > 0)
            {
                MessageBox.Show("Checkout recorded.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Checkout fail to be recorded.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (n > 0)
            {
                MessageBox.Show("Bed status updated.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bed status fail to be updated.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (n2 > 0)
            {
                MessageBox.Show("Patient status updated.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Patient status fail to be updated.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (n3 > 0)
            {
                MessageBox.Show("Admission status updated.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Admission status fail to be updated.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GridView1.DataSource = null;
            GridView1.DataBind();
            lblDisplay.Text = "There are no more list of discharge for today.";
            btnDischarge.Visible = false;
            conDischarge.Close();
        }
    }
}