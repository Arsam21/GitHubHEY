<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AppointmentHomePage.aspx.cs" Inherits="HMS.AppointmentHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px; width: 272px;margin:auto;">
    
        <br />
        <strong>Welcome Mr./Ms.
            <asp:Label ID="lblUserName" runat="server"></asp:Label>
        </strong>
        <p>
            <asp:HyperLink ID="addAppointment" runat="server" NavigateUrl="~/TanDingKang/AddAppointment.aspx">Add Apointment</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="editAppointment" runat="server" NavigateUrl="~/TanDingKang/EditAppointment.aspx">Edit Appointment</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="sendEmail" runat="server" NavigateUrl="~/TanDingKang/SendEmail.aspx">Send Email</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="report1" runat="server" NavigateUrl="~/TanDingKang/ReportAppointment.aspx">Monthly Appointment</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="report2" runat="server" NavigateUrl="~/TanDingKang/ReportAppointment2.aspx">Summary Appointment</asp:HyperLink>
        </p>
        <br />
        <br />
    
    </div>
</asp:Content>
