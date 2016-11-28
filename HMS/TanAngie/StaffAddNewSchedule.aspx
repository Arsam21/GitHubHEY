<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffAddNewSchedule.aspx.cs" Inherits="StaffManagement.StaffAddNewSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <h1 style="color:darkblue">Doctor Create Appoinment Schedule</h1>
        <table style="width:100%;">
            <tr>
                <td>Choose A Day : </td>
                <td>
                    <asp:DropDownList ID="ddlDay" runat="server">
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Period Time :</td>
                <td>Must Choose only 3 period time.</td>
            </tr>
            <tr>
                <td>First :</td>
                <td>
                    <asp:DropDownList ID="ddlFirstPeriod" runat="server" DataSourceID="SqlDataSource1" DataTextField="ShiftTime" DataValueField="TimeID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Second :</td>
                <td>
                    <asp:DropDownList ID="ddlSecondPeriod" runat="server" DataSourceID="SqlDataSource1" DataTextField="ShiftTime" DataValueField="TimeID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Third :</td>
                <td>
                    <asp:DropDownList ID="ddlThirdPeriod" runat="server" DataSourceID="SqlDataSource1" DataTextField="ShiftTime" DataValueField="TimeID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Time]"></asp:SqlDataSource>
</asp:Content>