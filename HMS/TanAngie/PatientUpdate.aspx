<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientUpdate.aspx.cs" Inherits="StaffManagement.PatientUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">


        .auto-style1 {
            width: 158px;
        }

        </style>

    <div class="background">
        
        <div>
            <h1 style="color:darkred">Patient Update Details</h1>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">Patient ID :</td>
                    <td>
                        <asp:TextBox ID="tbPatientId" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Name :</td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">IC Number :</td>
                    <td>
                        <asp:TextBox ID="tbIC" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                        &nbsp;&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Gender :</td>
                    <td>
                        <asp:TextBox ID="tbGender" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Home Address :</td>
                    <td>
                        <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbAddress" ErrorMessage="Please insert Address" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Contact Number :</td>
                    <td>
                        <asp:TextBox ID="tbContactNum" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbContactNum" ErrorMessage="Please insert Contact Number" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbContactNum" ErrorMessage="Invalid Contact Number. (exp: 0168528999)" ForeColor="Red" ValidationExpression="\d{10}" ValidationGroup="Submit">*</asp:RegularExpressionValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Email Address :</td>
                    <td>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbEmail" ErrorMessage="Please insert Email" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbEmail" ErrorMessage="Invalid Email Address. (exp: abc@hotmail.com)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Submit">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" HeaderText="Please Check Again:" ValidationGroup="Submit" />
</asp:Content>