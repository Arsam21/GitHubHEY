<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PrescriptionHomePage.aspx.cs" Inherits="HMS.PrescriptionHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 232px;
        }
        .auto-style2 {
            width: 316px;
        }
    </style>

    <div>
        <table style="width:100%;" align="center">
            <tr>
                <td></td>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>  
                                <ItemTemplate>  
                                    <asp:Button ID="btn_Select" runat="server" Text="Select" CommandName="Select" />  
                                </ItemTemplate>  
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td></td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1"><img src="../images/Add.png" alt="Add Prescription" /><br />
                    <asp:HyperLink ID="Add" runat="server" NavigateUrl="~/PangYeanPeen/AddPrescription.aspx" Enabled ="False">Add Prescription</asp:HyperLink>
                </td>

                <td><img src="../images/Update.png" alt="Update Prescription" /><br /> 
                    <asp:HyperLink ID="Update" runat="server" NavigateUrl="~/PangYeanPeen/UpdatePrescription.aspx" Enabled ="False" >Update Prescription</asp:HyperLink>
                </td>

                <td><img src="../images/Report.png" alt="Monthly Dispensed Drug Details Report" /><br />
                    <asp:HyperLink ID="Report1" runat="server" NavigateUrl="~/PangYeanPeen/MonthlyDispensedDrugsReport.aspx">Monthly Dispensed Drug Details Report</asp:HyperLink>
                </td>
              
            </tr>
            <tr>
                <td class="auto-style1"><img src="../images/Retrieve.png" alt="View Prescription" /><br />
                    <asp:HyperLink ID="View" runat="server" NavigateUrl="~/PangYeanPeen/RetrievePrescription.aspx" Enabled ="False" >View Prescription</asp:HyperLink>
                </td>

                <td><img src="../images/Delete.png" alt="Delete Prescription" /><br />
                     <asp:HyperLink ID="Delete" runat="server" NavigateUrl="~/PangYeanPeen/DeletePrescription.aspx" Enabled ="False">Delete Prescription</asp:HyperLink>
                </td>

                <td><img src="../images/Report.png" alt="Monthly Drug Quantity Dispensed Report" /><br />
                    <asp:HyperLink ID="Report2" runat="server" NavigateUrl="~/PangYeanPeen/MonthlyDrugQuantityDispensedReport.aspx" >Monthly Drug Quantity Dispensed Report</asp:HyperLink>
                </td>

            </tr>
            <tr>
                <td class="auto-style1"><br /> </td>

                <td></td>

                <td>
                    <img alt="View Prescription" src="../images/Retrieve.png" /><br />
                    <asp:HyperLink ID="StaffView" runat="server" NavigateUrl="~/PangYeanPeen/PharmacistView.aspx">View Prescription</asp:HyperLink>
                </td>

            </tr>
        </table>
    
    </div>
</asp:Content>