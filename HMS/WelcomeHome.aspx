<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WelcomeHome.aspx.cs" Inherits="HMS.WelcomeHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <strong>Welcome To Hospital Management System<br />
        <br />
        Login ID :
        <asp:Label ID="lblLogin" runat="server"></asp:Label>
&nbsp; </strong>&nbsp;<br />
        <br />
        
    </div>

</asp:Content>
