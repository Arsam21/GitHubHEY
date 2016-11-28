<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportAppointment.aspx.cs" Inherits="HMS.ReportAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px;margin:auto;">
    
        <span class="auto-style1"></span><br />
        <br />
        <table style="width:100%;">
            <tr style="text-align:center;">
                <td class="auto-style5"></td>
                <td class="auto-style7">
                    <strong>Report 1</strong><br />
                    Total Appointment in which month in a year.</td>
                <td class="auto-style6"></td>
            </tr>
            <tr style="text-align:center;">
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">
        <table style="width:99%;">
            <tr style="text-align:center;">
                <td>&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">
                    Month :
                     <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
                    Year : 
                    <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                    &nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click1" Text="Generate" />
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                   
                </td>
            </tr>
        </table>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr style="text-align:center;">
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style9">
        
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <br /><br />
        <asp:GridView ID="gridViewReport" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" style="margin-left: 300px;">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    
                    <br />
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
        <br />
        <br />
    
    </div>
</asp:Content>
