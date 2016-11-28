<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdmissionHomepage.aspx.cs" Inherits="HMS.AdmissionHomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>

<body>

        <div style="border: 1px solid #888888; border-radius:10px; box-shadow:10px 10px 5px #888888; border-spacing:5px; width: 272px;margin:auto;">
        <p><strong><i>
            Welcome,
            <asp:Label ID="lblStaff" runat="server"></asp:Label></i></strong>
        </p>
        <p>
            <asp:HyperLink ID="wardInfo" runat="server" NavigateUrl="~/Shirleyann/WardInfo.aspx">~ View Ward Info</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="wardStaff" runat="server" NavigateUrl="~/Shirleyann/WardStaff.aspx">~ View Ward Staff</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="createAdmission" runat="server" NavigateUrl="~/Shirleyann/CreateAdmission.aspx">~ Create Admission</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="todayAdmission" runat="server" NavigateUrl="~/Shirleyann/Today'sAdmission.aspx">~ Today&#39;s Admission</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="resourcesUsed" runat="server" NavigateUrl="~/Shirleyann/ResourcesUsed.aspx">~ Record Resources Used</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="patientCheckUp" runat="server" NavigateUrl="~/Shirleyann/PatientCheckUp.aspx">~ Check Up Patient</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="dischargeByDoctor" runat="server" NavigateUrl="~/Shirleyann/DichargeByDoctor.aspx">~ Approve Discharge</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="dischargeByNurse" runat="server" NavigateUrl="~/Shirleyann/DischargeByNurse.aspx">~ Discharge Patient</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="admissionReport" runat="server" NavigateUrl="~/Shirleyann/AdmissionReport.aspx">~View Summary Report</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="summaryAdmissionReport" runat="server" NavigateUrl="~/Shirleyann/SummaryAdmissionReport.aspx">~View Detailed Report</asp:HyperLink>
        </p>
         <p>
             <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
        </div>
    <br />
</body>
</html>
</asp:Content>