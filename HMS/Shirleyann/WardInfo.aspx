<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WardInfo.aspx.cs" Inherits="HMS.WardInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <style>
        #tbl tr td{height:50px;}
        .label{width:100px;}
        .color{background-color:#D1D5D5;}
        .radius{border-radius:20px;margin:10px;}
        .left{float:left;padding:5px;}
    </style>
    <title></title>

<body>

    <div style="margin:auto" class="left"> 
        
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
            <HeaderStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
            <ItemStyle Width="300px" />
            <HeaderTemplate><strong>WARD DETAILS</strong></HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" height="300px" width="300px" CssClass="radius" ImageUrl='<%# Bind("WardPic", "~/Pic/{0}") %>'/>
            
                <table id="tbl">
                    <tr class="color">
                        <td class="label"><strong>Ward Type:</strong></td>
                        <td><%#Eval("WardType") %></td>
                    </tr>
                    <tr>
                        <td class="label"><strong>No. of Beds per Room:</strong></td>
                        <td><%#Eval("NoOfBedPerRoom") %></td>
                    </tr>
                    <tr class="color">
                        <td class="label"><strong>Room Rate per Day:</strong></td>
                        <td><%#Eval("RatePerDay") %></td>
                    </tr>
                    <tr>
                        <td class="label"><strong>Facilities:</strong> </td>
                        <td><%#Eval("Facilities") %></td>
                    </tr>
                </table>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="view" CommandArgument='<%#Eval("NoOfBedPerRoom") %>'>View</asp:LinkButton>
            </ItemTemplate> 
            <FooterStyle BackColor="#1C5E55" ForeColor="#1C5E55" />
            <FooterTemplate>WARD DETAILS</FooterTemplate>
        </asp:DataList> 
        <br />  
    </div>
    <div class="left">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
    
</body>
</html>
</asp:Content>