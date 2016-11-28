<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="HMS.AddAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px; width: 272px;margin:auto;">
    
        <strong>Add New Appointment</strong><br />
        <br />
        Mr./Ms.
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
        <br />
        <br />
    
        Appointment Type :
        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True">
            <asp:ListItem Value="DP003">General</asp:ListItem>
            <asp:ListItem Value="DP002">Checkup</asp:ListItem>
        </asp:DropDownList>

        <br />
        <br />

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
             <ItemTemplate>
                <table border="1">
                    <tr>
                        <td>
                            <asp:CheckBox ID="selectDoctor" runat="server"/>
                            <asp:HiddenField ID="hiddenDoctor" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "StaffName").ToString() %>'/>
                        </td>
                        <td style="width:500px">
                            Doctor Name : <%#DataBinder.Eval(Container.DataItem, "StaffName" ) %><br />
                            Gender      : <%#DataBinder.Eval(Container.DataItem, "StaffGender" ) %><br/>
                            Contact No  : <%#DataBinder.Eval(Container.DataItem, "StaffContactNo" ) %><br/>
                            Email       : <%#DataBinder.Eval(Container.DataItem, "EmailID" ) %><br/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>

        <br />
        <asp:Button ID="btnConfirm" runat="server" Text="Continue" OnClientClick="javascript:alert('You are now redirect to schedule part.')" OnClick="btnConfirm_Click" />
        <br />
        <br />
        <asp:Label ID="lblDoctorName" runat="server"></asp:Label>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HMS %>" SelectCommand="SELECT [StaffID], [StaffName], [StaffGender], [StaffContactNo], [Position], [StaffStatus], [EmailID] FROM [Staff] WHERE (([DepartmentID] = @DepartmentID) AND ([Position] = @Position))">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlType" Name="DepartmentID" PropertyName="SelectedValue" Type="String" />
                <asp:QueryStringParameter DefaultValue="Doctor" Name="Position" QueryStringField="Doctor" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanDingKang/AppointmentHomePage.aspx">Back to home</asp:HyperLink>
        <br />
    
    </div>
</asp:Content>

<%--OnClientClick="return confirm('You are now redirect to schedule part.');"--%>