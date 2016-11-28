using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class StaffList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                gvStaffList.DataSource = sdsAllStaff;
                gvStaffList.DataBind();
            }
        }

        protected void gvStaffList_SelectedIndexChanged(object sender, EventArgs e)
        {//to see staff Details
            Response.Redirect("~/TanAngie/StaffDetails.aspx?staffid="+gvStaffList.SelectedRow.Cells[0].Text);
        }
        protected void gvStaffList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {// onclick listener
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvStaffList, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//-----button Search
        {
            if (ddlSearch.SelectedItem.Value.Equals("Staff ID"))
            {
                gvStaffList.DataSource = sdsSearchID;
                gvStaffList.DataBind();
            }
            else if (ddlSearch.SelectedItem.Value.Equals("Staff Name"))
            {
                gvStaffList.DataSource = sdsSearchName;
                gvStaffList.DataBind();
            }
            else if (ddlSearch.SelectedItem.Value.Equals("Department"))
            {
                gvStaffList.DataSource = sdsSearchDepartment;
                gvStaffList.DataBind();
            }
            else if (ddlSearch.SelectedItem.Value.Equals("Position"))
            {
                gvStaffList.DataSource = sdsSearchPosition;
                gvStaffList.DataBind();
            }
        }

        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {// for department choose
            if (ddlSearch.SelectedItem.Value.Equals("Department"))
            {
                tbSearch.Visible = false;
                ddlDepartment.Visible = true;
                rfvdepartment.Visible = true;
            }
            else
            {
                tbSearch.Visible = true;
                ddlDepartment.Visible = false;
                rfvdepartment.Visible = false;
            }
        }
    }
}