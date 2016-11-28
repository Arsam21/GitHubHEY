<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="StaffManagement.StaffList" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
    <h1 style="color:darkblue">Staff List</h1>
            Search by
            <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">
                <asp:ListItem>Staff ID</asp:ListItem>
                <asp:ListItem>Staff Name</asp:ListItem>
                <asp:ListItem>Department</asp:ListItem>
                <asp:ListItem>Position</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvsearch" runat="server" ControlToValidate="tbSearch" ErrorMessage="Please insert a value." ForeColor="Red" ValidationGroup="search">*</asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlDepartment" runat="server" Visible="False">
                            <asp:ListItem>--Please Choose One--</asp:ListItem>
                            <asp:ListItem Value="DP001">Human Resource</asp:ListItem>
                            <asp:ListItem Value="DP002">Maternity Department</asp:ListItem>
                            <asp:ListItem Value="DP003">General Disease</asp:ListItem>
                            <asp:ListItem Value="DP004">Pharmacy</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvdepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please Select a Department" ForeColor="Red" InitialValue="--Please Choose One--" ValidationGroup="search" Visible="False">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="Button1_Click" Text="Search" CausesValidation="true" ValidationGroup="search" />
            <br />
            <br />
    
        <asp:GridView ID="gvStaffList" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="StaffID" ForeColor="#333333" GridLines="None" OnRowDataBound="gvStaffList_OnRowDataBound" OnSelectedIndexChanged="gvStaffList_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="StaffID" HeaderText="StaffID" ReadOnly="True" SortExpression="StaffID" />
                <asp:BoundField DataField="StaffName" HeaderText="StaffName" SortExpression="StaffName" />
                <asp:BoundField DataField="StaffGender" HeaderText="StaffGender" SortExpression="StaffGender" />
                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
                <asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" SortExpression="DepartmentID" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="sdsAllStaff" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [DepartmentID] FROM [Staff] WHERE ([StaffStatus] = @StaffStatus)">
            <SelectParameters>
                <asp:Parameter DefaultValue="Active" Name="StaffStatus" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>
    
    
            <asp:SqlDataSource ID="sdsSearchID" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [DepartmentID] FROM [Staff] WHERE ([StaffID] = @StaffID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="StaffID" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchName" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [DepartmentID] FROM [Staff] WHERE ([StaffName] = @StaffName)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="StaffName" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchPosition" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [DepartmentID] FROM [Staff] WHERE ([Position] = @Position)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="Position" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [Position], [DepartmentID] FROM [Staff] WHERE ([DepartmentID] = @DepartmentID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlDepartment" Name="DepartmentID" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    
    
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="search" />
        </div>
</asp:Content>