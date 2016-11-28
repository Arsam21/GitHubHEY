<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PharmacistView.aspx.cs" Inherits="HMS.PharmacistView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">

        .auto-style1 {
            text-align: center;
        }
        .auto-style13 {
            width: 254px;
        }
        .auto-style18 {
            width: 379px;
        }
        .auto-style5 {
            width: 183px;
        }
        .auto-style7 {
            width: 95px;
            height: 26px;
        }
        .auto-style8 {
            width: 183px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 128px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
            width: 95px;
        }
        .auto-style6 {
            height: 23px;
            width: 183px;
        }
        .auto-style10 {
            height: 23px;
            width: 128px;
        }
        .auto-style3 {
            width: 95px;
        }
        .auto-style11 {
            width: 128px;
        }
        .auto-style19 {
            height: 26px;
        }
        /*a {
	        color: #777;
	        width: 2em;
	        font-size: small;
	        border-radius: 10px;
	        border: 2px solid #ccc;
	        padding-left: 10px;
            text-align: right;
            padding-right: 5px;
            padding-top: 5px;
            padding-bottom: 5px;
        }*/
	</style>

    <div>
        <div class="auto-style1">
            <table style="width: 100%;">
            <tr>
                <td>
                    <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/PangYeanPeen/PrescriptionHomePage.aspx">Back to Home Page</asp:HyperLink>
                    <br />
                </td>
            </tr>
            </table>
            Retrieve Prescription<br />
            <br />
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style18"></td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
           
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">Visitation ID&nbsp;&nbsp; </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="search1" runat="server" Text="Search" OnClick="search1_Click"  />
                </td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style6"></td>
                <td class="auto-style10"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">Patient Name</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">Medical Condition</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCondition" runat="server"></asp:TextBox>
                </td>
            </tr>
   
            </table>
        <br />
        <hr />
    
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    
        <br />
    
    </div>
</asp:Content>
