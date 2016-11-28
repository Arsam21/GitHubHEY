<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="StaffManagement.PatientList" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div>
    
            <h1 style="color:darkred">Patient List</h1>
            Search by
            <asp:DropDownList ID="ddlSearch" runat="server">
                <asp:ListItem>Patient ID</asp:ListItem>
                <asp:ListItem>Patient Name</asp:ListItem>
                <asp:ListItem>Patient IC</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvsearch" runat="server" ControlToValidate="tbSearch" ErrorMessage="Please insert a value." ForeColor="Red" ValidationGroup="search">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="Button1_Click" Text="Search" CausesValidation="true" ValidationGroup="search" />
            <br />
            <br />
    
        <asp:GridView ID="gvPatientList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvPatientList_OnRowDataBound" OnSelectedIndexChanged="gvPatientList_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" ReadOnly="True" SortExpression="PatientID" />
                <asp:BoundField DataField="PatientIC" HeaderText="PatientIC" SortExpression="PatientIC" />
                <asp:BoundField DataField="PatientName" HeaderText="PatientName" SortExpression="PatientName" />
                <asp:BoundField DataField="PatientGender" HeaderText="PatientGender" SortExpression="PatientGender" />
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
        <asp:SqlDataSource ID="sdsAllPatient" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PatientID], [PatientIC], [PatientName], [PatientGender] FROM [Patient]">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchID" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PatientID], [PatientIC], [PatientName], [PatientGender] FROM [Patient] WHERE ([PatientID] = @PatientID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="PatientID" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchName" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PatientID], [PatientIC], [PatientName], [PatientGender] FROM [Patient] WHERE ([PatientName] = @PatientName)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="PatientName" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSearchIC" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PatientIC], [PatientID], [PatientName], [PatientGender] FROM [Patient] WHERE ([PatientIC] = @PatientIC)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbSearch" Name="PatientIC" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="search" />
    
    
        </div>
    </div>
</asp:Content>