<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CancelAppointment.aspx.cs" Inherits="HMS.CancelAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px; margin-left:10px; margin-top:10px">
    
        <span class="auto-style1"><strong>Cancel Appointment</strong></span><br />

        <br />
        Mr./Ms.
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
        <br />
        <br />
        Please check the following details :<br />
        <br />
        <table style="border-spacing:10px">
            <tr>
                <td>Doctor Name :</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Appointment ID :</td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Appointment Type : </td>
                <td>
                    <asp:Label ID="lblType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Appointment Date :</td>
                <td>
                    <asp:Label ID="lblDate" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Appointment Time :</td>
                <td>
                    <asp:Label ID="lblTime" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Appointment Status :</td>
                <td class="auto-style2">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                </td>
            </tr>
            </table>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TanDingKang/EditAppointment.aspx">Back</asp:HyperLink>
        <br />
        <br />

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanDingKang/AppointmentHomePage.aspx">Back to home</asp:HyperLink>
    
    </div>
</asp:Content>