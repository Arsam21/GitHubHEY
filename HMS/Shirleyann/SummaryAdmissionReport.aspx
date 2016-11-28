<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SummaryAdmissionReport.aspx.cs" Inherits="HMS.SummaryAdmissionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>

<body>

    <div style="margin-left:350px">
    <div style="font-size:2em"><strong>Generate Admission Report<br /></strong></div>
        <div style="border-style: dotted; border-color: inherit; border-width: medium; width: 593px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 94%;">
                    <tr>
                        <td>Generate Summary Admission Report for year</td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate report" />
                        </td>
                    </tr>
                </table>
            
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <p style="color:red">Generating report...please wait a moment...</p>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            
                <br /></div>
        
        </div>
    </div>
        <div style="margin-left:20px">
        <asp:Label ID="lblLineOne" runat="server"></asp:Label>
        <asp:Label ID="lblLineTwo" runat="server"></asp:Label>
        <asp:Label ID="lblLineThree" runat="server"></asp:Label>
        <asp:Label ID="lblLineFour" runat="server"></asp:Label>
        <asp:Label ID="lblLineFive" runat="server"></asp:Label>
        <asp:Label ID="lblLineSix" runat="server"></asp:Label>
        <asp:Label ID="lblLineSeven" runat="server"></asp:Label>
        <asp:Label ID="lblLineEight" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="545px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView><br />
            </div>
    </ContentTemplate>
        </asp:UpdatePanel>

</body>
</html>
</asp:Content>