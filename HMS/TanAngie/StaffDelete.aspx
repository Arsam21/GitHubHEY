<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffDelete.aspx.cs" Inherits="StaffManagement.StaffDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 141px;
        }
    </style>

    <div>
    
        <h1 style="color:darkblue">Staff Resign or Retire</h1><br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Staff ID :</td>
                <td>
                        <asp:TextBox ID="tbStaffId" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style1">Staff Name :</td>
                <td>
                        <asp:TextBox ID="tbStaffName" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style1">Reason :</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem>--Please Choose One--</asp:ListItem>
                        <asp:ListItem>Retire</asp:ListItem>
                        <asp:ListItem>Resign</asp:ListItem>
                        <asp:ListItem>Get Fired</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Please Select Position" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Admin Password :</td>
                <td>
                    <input id="pwAdmin" type="password" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
</asp:Content>