<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPrescriptionHomePage.aspx.cs" Inherits="HMS.ViewPrescriptionHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style3 {
            width: 285px;
        }
        .auto-style4 {
            width: 345px;
        }
    </style>

    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <img alt="View Prescription" src="../images/Retrieve.png" /><br />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="View" runat="server" NavigateUrl="~/PangYeanPeen/PharmacistView.aspx">View Prescription</asp:HyperLink>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:Content>