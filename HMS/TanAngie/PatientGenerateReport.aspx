<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientGenerateReport.aspx.cs" Inherits="StaffManagement.PatientGenerateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <h1 style="color:darkblue">Hospital Monthly Patient Visitation Report</h1>
        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
            <asp:ListItem>--Please Select A Year--</asp:ListItem>
            <asp:ListItem>2015</asp:ListItem>
            <asp:ListItem>2016</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
            <asp:ListItem>--Please Select a Month--</asp:ListItem>
            <asp:ListItem Value="01/">January</asp:ListItem>
            <asp:ListItem Value="02/">February</asp:ListItem>
            <asp:ListItem Value="03/">March</asp:ListItem>
            <asp:ListItem Value="04/">April</asp:ListItem>
            <asp:ListItem Value="05/">May</asp:ListItem>
            <asp:ListItem Value="06/">June</asp:ListItem>
            <asp:ListItem Value="07/">July</asp:ListItem>
            <asp:ListItem Value="08/">August</asp:ListItem>
            <asp:ListItem Value="09/">September</asp:ListItem>
            <asp:ListItem Value="10/">October</asp:ListItem>
            <asp:ListItem Value="11/">November</asp:ListItem>
            <asp:ListItem Value="12/">December</asp:ListItem>
        </asp:DropDownList>
        <p>
        Total Visitation For This Year :
            <asp:Label ID="lblCountByYear" runat="server"></asp:Label>
        </p>
        <p>
            Total Visitation For <asp:Label ID="lblMonth" runat="server"></asp:Label>
                    &nbsp;: <asp:Label ID="lblCountByMonth" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblMonthYear" runat="server" Visible="False"></asp:Label>
        </p>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="VisitationDate" HeaderText="VisitationDate" SortExpression="VisitationDate" />
                                <asp:BoundField DataField="PatientName" HeaderText="PatientName" SortExpression="PatientName" />
                                <asp:BoundField DataField="MedicalCondition" HeaderText="MedicalCondition" SortExpression="MedicalCondition" />
                                <asp:BoundField DataField="StaffName" HeaderText="DoctorIncharge" SortExpression="StaffName" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Visitation.VisitationDate, Patient.PatientName, Visitation.MedicalCondition, Staff.StaffName FROM Visitation INNER JOIN Staff ON Visitation.StaffID = Staff.StaffID INNER JOIN Patient ON Visitation.PatientID = Patient.PatientID WHERE (SUBSTRING(Visitation.VisitationDate, 4, 7) = @VisitationDate)" OnSelecting="SqlDataSource1_Selecting">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblMonthYear" Name="VisitationDate" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
    </div>
</asp:Content>