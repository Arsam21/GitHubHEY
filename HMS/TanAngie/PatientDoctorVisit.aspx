<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientDoctorVisit.aspx.cs" Inherits="StaffManagement.PatientDoctorVisit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }
        .auto-style2 {
            width: 214px;
        }
        .auto-style3 {
            width: 112px;
        }
    </style>

    <div>
    <h1 style="color:darkblue">Patient Visitation (Doctor)</h1>

        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Visitation ID :</td>
                <td class="auto-style2">
                    <asp:Label ID="lbVisitationID" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">Visitation Date : </td>
                <td>
                    <asp:Label ID="lbVisitationDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Patient ID :</td>
                <td class="auto-style2">
                    <asp:Label ID="lbPatientID" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">Patient Name : </td>
                <td>
                    <asp:Label ID="lbPatientName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Service : </td>
                <td class="auto-style2">
                    <asp:Label ID="lbService" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">Appointment ID : </td>
                <td>
                    <asp:Label ID="lbAppointmentId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Medical Condition : </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbMedicalCondition" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbMedicalCondition" ErrorMessage="Please insert Medical Condition" ForeColor="Red" ValidationGroup="submit">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="submit" CausesValidation="true" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
        <br />

    </div>
</asp:Content>