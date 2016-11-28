<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientCheckUp.aspx.cs" Inherits="HMS.PatientCheckUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
        #one,#two,#three,#four,#five,#six{background-color:#C5BBAF;border-radius:3px;}
        #tbl{border-style:solid;border-radius:10px;border-width:1px;border-spacing:5px;box-shadow:10px 10px 5px #888888;border-color:#888888}
        #tbl tr td:first-child{padding-left:5px;}
    </style>

<body>

    <div style="margin-left:500px">
    <div style="font-size:2em"><strong>Patient Check-Up</strong></div>
        <table id="tbl" style="width:79%;">
            <tr>
                <td id="one">Date:</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Patient ID:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPatientID" runat="server"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
                </td>
            </tr>
            <tr>
                <td id="two">Patient Name:</td>
                <td>
                    <asp:TextBox ID="txtPatientName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Medical Condition:</td>
                <td>
                    <asp:TextBox ID="txtMedicalCondition" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td id="three">Ward No.:</td>
                <td>
                    <asp:TextBox ID="txtWardNo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bed No.:</td>
                <td>
                    <asp:TextBox ID="txtBedNo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td id="four">Blood pressure:</td>
                <td>
                    <asp:RadioButtonList ID="rblBloodPressure" runat="server" AutoPostBack="true">
                        <asp:ListItem>&lt; 80 or &gt;120 (bad)</asp:ListItem>
                        <asp:ListItem>80 - 120 (normal)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Heart Rate:</td>
                <td>
                    <asp:RadioButtonList ID="rblHeartRate" runat="server" AutoPostBack="true">
                        <asp:ListItem>&lt;60 or &gt;100 (bad)</asp:ListItem>
                        <asp:ListItem>60 - 100 (normal)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td id="five">
                    <asp:Label ID="lblPlatelet" runat="server" Text="Platelet:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblPlatelet" runat="server" AutoPostBack="True">
                        <asp:ListItem>&lt; 70 000 (bad)</asp:ListItem>
                        <asp:ListItem>&gt; 70 000 (normal)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTemperature" runat="server" Text="Temperature:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblTemperature" runat="server" AutoPostBack="True">
                        <asp:ListItem>&gt; 37°C (bad)</asp:ListItem>
                        <asp:ListItem>37°C (normal)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td id="six">Patient Condition:</td>
                <td>
                    <asp:TextBox ID="txtPatientCondition" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    <br />
</body>
</html>
</asp:Content>