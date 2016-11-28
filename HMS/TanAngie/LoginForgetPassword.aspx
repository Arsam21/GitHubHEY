<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginForgetPassword.aspx.cs" Inherits="StaffManagement.LoginForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 168px;
        }
    </style>

    <div>
    <h1>Forgot Password(Reset Password)</h1>
        <table style="width:100%;">
        <tr>
            <td class="auto-style1">Login ID :</td>
            <td>
                <asp:TextBox ID="tbLoginId" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbLoginId" ErrorMessage="Please insert LoginID" ForeColor="Red" ValidationGroup="security">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Your Security Question :</td>
            <td>
                        <asp:DropDownList ID="ddlSecurityQuestion" runat="server" Width="160px">
                            <asp:ListItem Value="0">--Please Choose One--</asp:ListItem>
                            <asp:ListItem>What is your pet&#39;s name?</asp:ListItem>
                            <asp:ListItem>Where you born?</asp:ListItem>
                            <asp:ListItem>Who is your idol?</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSecurityQuestion" ErrorMessage="Please Select a Security Question" ForeColor="Red" InitialValue="0" ValidationGroup="security">*</asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td class="auto-style1">Your Security Answer :</td>
            <td>
                        <asp:TextBox ID="tbSecurityPw" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbSecurityPw" ErrorMessage="Please insert Security Answer" ForeColor="Red" ValidationGroup="security">*</asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" CausesValidation="true" ValidationGroup="security" />
            </td>
        </tr>
            <tr>
                <td class="auto-style1"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblWelcome" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblPassword" runat="server" Text="Reset New Password :"></asp:Label>
                </td>
                <td>
                    <input id="pwPassword" type="password" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pwPassword" ErrorMessage="Please insert New Password" ForeColor="Red" ValidationGroup="changePw">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblConfirmPw" runat="server" Text="Confirm New Password :"></asp:Label>
                </td>
                <td>
                    <input id="pwConfirm" type="password" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pwConfirm" ErrorMessage="Please insert Confirm Password" ForeColor="Red" ValidationGroup="changePw">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnConfirmReset" runat="server" OnClick="btnConfirmReset_Click" Text="Confirm" ValidationGroup="changePw" CausesValidation="true" />
                </td>
            </tr>
        </table>
        

    </div>
</asp:Content>