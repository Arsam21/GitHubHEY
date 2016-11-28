<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginChangePassword.aspx.cs" Inherits="StaffManagement.LoginChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">

        .auto-style1 {
            width: 168px;
        }
    </style>

    <div>
    <h1>Change Password</h1>
        <table style="width:100%;">
        <tr>
            <td class="auto-style1">Login ID :</td>
            <td>
                <asp:TextBox ID="tbLoginId" runat="server" Width="119px" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
            </td>
        </tr>
            <tr>
                <td class="auto-style1">Old Password :</td>
                <td>
                    <input id="pwOldPassword" type="password" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pwOldPassword" ErrorMessage="Old Password Cannot be Blank." ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblPassword" runat="server" Text="Reset New Password :"></asp:Label>
                </td>
                <td>
                    <input id="pwPassword" type="password" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pwPassword" ErrorMessage="New Password Cannot be Blank." ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblConfirmPw" runat="server" Text="Confirm New Password :"></asp:Label>
                </td>
                <td>
                    <input id="pwConfirm" type="password" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pwConfirm" ErrorMessage="Confirm Password Cannot be Blank." ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:Button ID="btnConfirmReset" runat="server" OnClick="btnConfirmReset_Click" Text="Confirm" CausesValidation="true" />
                </td>
            </tr>
        </table>
        

    </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Submit" />
</asp:Content>