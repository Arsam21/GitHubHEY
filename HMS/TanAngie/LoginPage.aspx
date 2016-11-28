<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="StaffManagement.LoginPage" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:680px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    The time now is
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    <div style="border: 1px solid #888888; border-radius:10px; border-spacing:5px; width:30%; margin:auto;">
        <h1>Welcome to Hospital Management System</h1>
        <div>
            <h4> Please insert your Login ID and Password below. </h4>
            
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">Login ID :</td>
                    <td>
                        <asp:TextBox ID="tbLoginId" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLoginId" ErrorMessage="Please insert your Login ID" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Password :</td>
                    <td>
                        <input id="pwPassword" type="password" runat="server"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pwPassword" ErrorMessage="Please insert your Password" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btLogin" runat="server" OnClick="BtLogin_Click" Text="login" />&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanAngie/LoginForgetPassword.aspx">(forgot password?)</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <h5 style="color:red">If you haven't registered, Please find our staff to Get Help.
            </h5>
            &nbsp<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TanAngie/PatientVisitation.aspx" Font-Underline="false">Patient Visitation</asp:HyperLink>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please double check:" ShowMessageBox="True" ShowSummary="False" />
        </div>

    </div>
    </form>
</body>
</html>
