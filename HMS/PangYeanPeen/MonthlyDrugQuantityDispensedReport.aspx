<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MonthlyDrugQuantityDispensedReport.aspx.cs" Inherits="HMS.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">

        .auto-style9 {
            height: 23px;
            width: 138px;
        }
        .auto-style10 {
            height: 23px;
            width: 120px;
            text-align: center;
        }
        .auto-style1 {
            height: 23px;
        }
        .auto-style7 {
            height: 23px;
            width: 251px;
        }
        .auto-style4 {
            height: 23px;
            width: 445px;
            text-align: center;
        }
        .auto-style8 {
            width: 251px;
        }
        .auto-style6 {
            width: 445px;
            text-align: right;
        }
        .auto-style5 {
            width: 285px;
        }
        .auto-style11 {
            width: 305px;
        }
        </style>

    <div>
        <div class="auto-style1">
        <table style="width: 100%;">
            <tr>
                <td style="font-size: small">
                    <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/PangYeanPeen/PrescriptionHomePage.aspx">Back to Home Page</asp:HyperLink>
                    <br />
                </td>
            </tr>
        </table>
    
        </div>
        <table style="width:100%;">
             <tr>
                <td class="auto-style9">Selected by Month</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="ddlMonth" runat="server" style="text-align: left">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Generate Report" />
                 </td>
            </tr>
       </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style4">Monthly Drug Quantity Dispensed Report for&nbsp;<asp:Label ID="lblLabel" runat="server" Text="[Label]"></asp:Label>
&nbsp;2015</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style6">Print Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>
                </td>
              
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="GridView1" runat="server" style="margin-left: 9px; text-align: left;" CellPadding="4" ForeColor="#333333" GridLines="None" Width="248px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:Content>