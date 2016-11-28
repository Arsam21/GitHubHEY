<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffGenerateReport.aspx.cs" Inherits="StaffManagement.StaffGenerateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 255px;
        }
        .auto-style2 {
            width: 304px;
        }
    </style>

    <div>
    <h1 style="color:darkblue">Hospital Department Staff Report</h1>
            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                            <asp:ListItem>--Please Choose One Department--</asp:ListItem>
                            <asp:ListItem Value="DP001">Human Resource</asp:ListItem>
                            <asp:ListItem Value="DP002">Maternity Department</asp:ListItem>
                            <asp:ListItem Value="DP003">General Disease</asp:ListItem>
                            <asp:ListItem Value="DP004">Pharmacy</asp:ListItem>
                        </asp:DropDownList>
                        <br />
        <br />
            <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Manager Name :
                    <asp:Label ID="lblManagerName" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Active :
                    <asp:Label ID="lblActive" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Resign/Retired/Get Fired :
                    <asp:Label ID="lblNonActive" runat="server"></asp:Label>
                </td>
                <td>Total :
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Doctor :
                    <asp:Label ID="lblDoctor" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Nurse :
                    <asp:Label ID="lblNurse" runat="server"></asp:Label>
                </td>
                <td>Clerk :
                    <asp:Label ID="lblClerk" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StaffID" DataSourceID="sdsStaffList">
            <Columns>
                <asp:BoundField DataField="StaffID" HeaderText="StaffID" ReadOnly="True" SortExpression="StaffID" />
                <asp:BoundField DataField="StaffName" HeaderText="StaffName" SortExpression="StaffName" />
                <asp:BoundField DataField="StaffGender" HeaderText="StaffGender" SortExpression="StaffGender" />
                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
                <asp:BoundField DataField="StaffStatus" HeaderText="StaffStatus" SortExpression="StaffStatus" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsStaffList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [StaffStatus] FROM [Staff] WHERE ([DepartmentID] = @DepartmentID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlDepartment" Name="DepartmentID" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="search" />
    
    
    </div>
</asp:Content>