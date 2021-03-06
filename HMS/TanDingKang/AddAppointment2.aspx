﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddAppointment2.aspx.cs" Inherits="HMS.AddAppointment2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px; margin-left:10px; margin-top:10px">
    
        Add New Appointment<br />
        <br />
        Mr./Ms.
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
        <br />
        <br />
    
        Doctor Name :
        <asp:Label ID="lblDoctorName" runat="server"></asp:Label>
        <br />
        <br />
        <table>
            <tr  style="width:20%;">
                <td>Working Schedule :</td>
                <td>
                    <asp:GridView ID="ScheduleTime" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
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
                        <EmptyDataTemplate>No Working Schedule.</EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr style="width=30%">
                <td>Schedule Date for Appointment :</td>
                <td class="auto-style2">
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" 
                        ondayrender="Calendar1_DayRender"  BackColor="White" BorderColor="#999999" CellPadding="4" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <br />
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtDate" >*Required Field</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Select Time for Appointment</td>
                <td>
                    <asp:DropDownList ID="ddlTime" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTime" ForeColor="Red" >*Required Field</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
                </td>
            </tr>
        </table>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TanDingKang/AddAppointment.aspx">Back</asp:HyperLink>
        <br />
        <asp:DropDownList ID="ddlWSTime" runat="server" Visible="False">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlWSDay" runat="server" Visible="False">
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanDingKang/AppointmentHomePage.aspx">Back to home</asp:HyperLink>
    
    </div>
</asp:Content>