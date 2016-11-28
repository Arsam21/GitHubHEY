<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientVisitation.aspx.cs" Inherits="StaffManagement.PatientVisitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    
        <h1 style="color:darkred">Welcome to Hospital.</h1>
        <br />
        Please insert Your IC number :
        <asp:TextBox ID="tbIc" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbIC" ErrorMessage="Please insert Staff IC Number." ForeColor="Red" ValidationGroup="IcCheck">*</asp:RequiredFieldValidator>
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbIC" ErrorMessage="Invalid IC Number. (exp: 951213148888)" ForeColor="Red" ValidationExpression="\d{12}" ValidationGroup="IcCheck">*</asp:RegularExpressionValidator>
                    
&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="true" ValidationGroup="IcCheck" />
        <br />
        <br />
        <asp:Label ID="lblWelcome" runat="server">If you are first visit to our hospital, please go to Hospital Reception Counter for Register. Thank You.</asp:Label>
        <br />
        <asp:Label ID="lblSelection" runat="server" Text="Please Select a service here : " Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlServiceChoose" runat="server" Visible="False">
            <asp:ListItem Value="0">--Please Choose One--</asp:ListItem>
            <asp:ListItem>General</asp:ListItem>
            <asp:ListItem>Checkup</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlServiceChoose" ErrorMessage="Please Choose a service" ForeColor="Red" InitialValue="--Please Choose One--" ValidationGroup="ok">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblAppointment" runat="server" Text="Had You Make Appoinment ?" Visible="False"></asp:Label>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblAppointment" ErrorMessage="Please Select Yes/No for Appoinment" ForeColor="Red" ValidationGroup="ok">*</asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="rblAppointment" runat="server" RepeatDirection="Horizontal" Visible="False">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Ok" Visible="False" ValidationGroup="ok" CausesValidation="true" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="true" ShowSummary="false" runat="server" HeaderText="Please Check Again:" ValidationGroup="IcCheck" />
        <br />
    
    </div>
</asp:Content>