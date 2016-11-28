<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffHomePage.aspx.cs" Inherits="StaffManagement.StaffHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>

    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
    
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="153px" ImageUrl="~/images/PatientRegister.png" Width="164px" PostBackUrl="~/TanAngie/PatientCreate.aspx" />
                </td>
                <td>
                    <asp:ImageButton ID="ibPatientList" runat="server" Height="138px" ImageUrl="~/images/List.png" Width="159px" PostBackUrl="~/TanAngie/PatientList.aspx" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:HyperLink ID="hlPatientRegistration" runat="server" NavigateUrl="~/TanAngie/PatientCreate.aspx">Patient Registration</asp:HyperLink>
                </td>
                <td class="auto-style1">
                    <asp:HyperLink ID="hlPatientList" runat="server" NavigateUrl="~/TanAngie/PatientList.aspx">Patient List</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ibPersonalDetails" runat="server" Height="150px" ImageUrl="~/images/Personal Details.png" Width="165px" PostBackUrl="~/TanAngie/StaffDetails.aspx" />
                </td>
                <td>
                    <asp:ImageButton ID="ibSchedule" runat="server" Height="142px" ImageUrl="~/images/schedule.png" Width="158px" PostBackUrl="~/TanAngie/StaffAddNewSchedule.aspx" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hlPersonalDetails" runat="server" NavigateUrl="~/TanAngie/StaffDetails.aspx">Your Personal Details</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hlSchedule" runat="server" NavigateUrl="~/TanAngie/StaffAddNewSchedule.aspx" Visible="False">Create Schedule</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ibVisitation" runat="server" Height="149px" ImageUrl="~/images/Visitation icon.jpg" PostBackUrl="~/TanAngie/PatientDoctorVisit.aspx" Visible="False" Width="165px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hlVisitation" runat="server" NavigateUrl="~/TanAngie/PatientDoctorVisit.aspx" Visible="False">Visitation</asp:HyperLink>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ibStaffRegistration" runat="server" Height="153px" ImageUrl="~/images/StaffRegister.png" PostBackUrl="~/TanAngie/StaffCreate.aspx" Width="164px" Visible="False" />
                </td>
                <td>
                    <asp:ImageButton ID="ibStaffList" runat="server" Height="138px" ImageUrl="~/images/List.png" Width="159px" PostBackUrl="~/TanAngie/StaffList.aspx" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hlStaffRegistration" runat="server" NavigateUrl="~/TanAngie/StaffCreate.aspx" Visible="False">Staff Registration</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hlStaffList" runat="server" NavigateUrl="~/TanAngie/StaffList.aspx" Visible="False">Staff List</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ibDepartmentStaffReport" runat="server" Height="146px" ImageUrl="~/images/report.ico" PostBackUrl="~/TanAngie/StaffGenerateReport.aspx" Visible="False" Width="164px" />
                </td>
                <td>
                    <asp:ImageButton ID="ibPatientVisitationReport" runat="server" Height="146px" ImageUrl="~/images/report.ico" PostBackUrl="~/TanAngie/PatientGenerateReport.aspx" Visible="False" Width="164px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hlStaffReport" runat="server" NavigateUrl="~/TanAngie/StaffGenerateReport.aspx" Visible="False">Department Staff Report</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hlPatientReport" runat="server" NavigateUrl="~/TanAngie/PatientGenerateReport.aspx" Visible="False">Monthly Visitation Report</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>