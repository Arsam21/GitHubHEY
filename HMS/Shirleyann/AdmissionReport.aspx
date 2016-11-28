<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdmissionReport.aspx.cs" Inherits="HMS.AdmissionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <style>
        #lineOne,#lineTwo,#lineThree,#lineFour{padding:0;margin:0;margin-left:150px}
        #lineThree{margin-left:220px}
        #lineFour{margin-left:125px;font-weight:bold}
        table tr th{text-align:left}
        #Title{font-size:2em;margin-left:60px;font-weight:bold}
        .auto-style1 {
            width: 74px;
        }
    </style>
    <title></title>

<body>

    <div style="margin-left:300px">
        <div style="font-size:2em"><strong>Generate Admission Report</strong><br /></div>
            <div style="border-style:dotted; width: 781px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width:99%;">
                        <tr>
                            <td class="auto-style1">Start Date:</td>
                            <td>
                                <asp:Calendar ID="cldStartDate" runat="server" OnSelectionChanged="cldStartDate_SelectionChanged"></asp:Calendar>
                            </td>
                            <td>End Date:</td>
                            <td>
                                <asp:Calendar ID="cldEndDate" runat="server" OnSelectionChanged="cldEndDate_SelectionChanged"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Medical Condition:</td>
                            <td>
                                <asp:DropDownList ID="ddlMedicalCondition" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate report" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
                            </td>
                        </tr>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <p style="color:red">Generating report...please wait a moment...</p>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
        <div style="margin-left:110px">
        <asp:Label ID="lblLineOne" runat="server"></asp:Label>
        <asp:Label ID="lblLineTwo" runat="server"></asp:Label>
        <asp:Label ID="lblLineThree" runat="server"></asp:Label>
        <asp:Label ID="lblLineFour" runat="server"></asp:Label>
        <asp:Label ID="lblLineFive" runat="server"></asp:Label>
        <asp:Label ID="lblLineSix" runat="server"></asp:Label>
        <asp:Label ID="lblLineSeven" runat="server"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br /></div>
        
    </div>
   <br />

</body>
</html>
</asp:Content>