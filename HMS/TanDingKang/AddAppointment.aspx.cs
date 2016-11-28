using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMS
{
    public partial class AddAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("~/TanAngie/LoginPage.aspx");
            }

            String UserName = Session["LoginID"].ToString();
            lblUserName.Text = UserName;
            Session["LoginID"] = Session["LoginID"].ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem i in Repeater1.Items)
            {
                //Retrieve the state of the CheckBox
                CheckBox cb = (CheckBox)i.FindControl("selectDoctor");
                if (cb.Checked)
                {
                    //Retrieve the value associated with that CheckBox
                    HiddenField hiddenDoctor = (HiddenField)i.FindControl("hiddenDoctor");

                    Session["DoctorName"] = hiddenDoctor.Value;
                    Session["AppointmentType"] = ddlType.SelectedItem.Text;

                    //lblDoctorName.Text = hiddenDoctor.Value;

                    Response.Redirect("~/TanDingKang/AddAppointment2.aspx");
                    
                    //lblStaffName.Text = hiddenDoctor.Value;
                    //txtStaffName.Text = hiddenDoctor.Value;
                    //Now we can use that value to do whatever we want
                    //SendWelcomeMessage(hiddenDoctor.Value);
                }
            }
        }


    }
}