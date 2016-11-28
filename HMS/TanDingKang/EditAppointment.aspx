<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditAppointment.aspx.cs" Inherits="HMS.EditAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style=" border-spacing:5px; margin-left:300px">
    
        <span class="auto-style1"><strong>Edit Appointment</strong></span><br />
        <br />
        Mr./Ms <asp:Label ID="lblUserName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblMesage" runat="server"></asp:Label>
        <br />

        <asp:GridView ID="gridAppointment" runat="server" OnSelectedIndexChanged="gridAppointment_SelectedIndexChanged" BackColor="#ffff66" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>

                    <asp:TemplateField ShowHeader="False"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CausesValidation="False" CommandName="Select" Text="Update" OnClick="linkButtonUpdate" OnClientClick="javascript:alert('You are now redirect to schedule part.')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="false" CausesValidation="False" CommandName="Select" Text="Cancel" OnClick="linkButtonCancel" OnClientClick="javascript:alert('You are now redirect to cancel appointment part.')"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

            </Columns>

            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

        <br />

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanDingKang/AppointmentHomePage.aspx">Back to home</asp:HyperLink>
    
        <br />

        <asp:Label ID="lblDoctorName" runat="server"></asp:Label>

        <asp:Label ID="lblAppointmentID" runat="server"></asp:Label>
    
        <asp:Label ID="lblAppointmentType" runat="server"></asp:Label>
        <asp:Label ID="lblDate" runat="server"></asp:Label>
        <asp:Label ID="lblTime" runat="server"></asp:Label>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    
        <br />

    </div>
</asp:Content>