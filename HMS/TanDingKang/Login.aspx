<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HMS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <span class="auto-style1"><strong>Login Page
        </strong></span>
        <br />
        <br />
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"/>
                    <%--<asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please enter Username" ControlToValidate="txtUserName" runat="server" ForeColor="Red" />--%>
                </td>
             </tr>
             
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPw" runat="server" TextMode="Password"/>
                    <%--<asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="txtPWD" ErrorMessage="Please enter Password" ForeColor="Red"/>--%>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        
        <br />

        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomePage.aspx">Go to Homepage</asp:HyperLink>

    </div>
</asp:Content>