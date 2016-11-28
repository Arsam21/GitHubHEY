using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffManagement
{
    public partial class PatientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                gvPatientList.DataSource = sdsAllPatient;
                gvPatientList.DataBind();
            }
        }
        protected void gvPatientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/TanAngie/PatientDetails.aspx?patientid=" + gvPatientList.SelectedRow.Cells[0].Text);
        }
        protected void gvPatientList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvPatientList, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlSearch.SelectedItem.Value.Equals("Patient IC"))
            {
                gvPatientList.DataSource = sdsSearchIC;
                gvPatientList.DataBind();
            }
            else if (ddlSearch.SelectedItem.Value.Equals("Patient ID"))
            {
                gvPatientList.DataSource = sdsSearchID;
                gvPatientList.DataBind();
            }
            else if (ddlSearch.SelectedItem.Value.Equals("Patient Name"))
            {
                gvPatientList.DataSource = sdsSearchName;
                gvPatientList.DataBind();
            }
        }
    }
}