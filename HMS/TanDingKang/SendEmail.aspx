<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="HMS.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div >
        <div style="text-align:center">
        <span class="auto-style1"><strong>Doctor Approval</strong></span><br />
        
        <br />
        <span style="text-align:center">Doctor</span>
       
        <asp:Label ID="lblDoctorName" runat="server"></asp:Label>
         </div>
        <br />
        <br />
    
        <table style="height:auto; width:auto; margin-left: 300px;">
            <tr>
                <td class="auto-style5">
                    <asp:Repeater ID="rptPaging" runat="server" OnItemDataBound="Repeater_ItemDataBound">
                        <ItemTemplate>
                            <asp:HyperLink ID="hyperLink" runat="server">
                                <table border="1">
                                    <tr>
                                        <%--; '<%#DataBinder.Eval(Container.DataItem, "AppointmentStatus").ToString() == "Approved" ? "#e7ebf6" : "#ffffff" %>;''--%>
                                        <%--class="<%#setClass(DataBinder.Eval(Container.DataItem, "AppointmentStatus").ToString()) %>"--%>
                                        <td style="width:300px;"  >
                                            <asp:LinkButton ID="sendEmail" runat="server" Font-Underline="false" OnClick="clickEmail" CommandName="SendEmail" ForeColor="Black">

                                            <asp:HiddenField ID="hiddenAppointmentID" runat="server" Value=' <%#DataBinder.Eval(Container.DataItem, "AppointmentID" ) %> ' />
                                            <asp:HiddenField ID="findEmail" runat="server" Value=' <%#DataBinder.Eval(Container.DataItem, "PatientEmail" ) %> ' />
                                            <asp:HiddenField ID="hiddenEmail" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "EmailID").ToString() %>'/>
                                            <asp:HiddenField ID="hiddenPW" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "EmailPW").ToString() %>'/>
                                            <asp:HiddenField ID="hiddenAppointmentStatus" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "AppointmentStatus").ToString() %>'/>
                                            
                                                Name              : <%#DataBinder.Eval(Container.DataItem, "PatientName" ) %><br />
                                                IC                : <%#DataBinder.Eval(Container.DataItem, "PatientIC" ) %><br/>
                                                Appointment Date  : <%#DataBinder.Eval(Container.DataItem, "AppointmentDate" ) %><br/>
                                                Appointment Time  : <%#DataBinder.Eval(Container.DataItem, "AppointmentTime" ) %><br/>
                                                Appointment Status: <%#DataBinder.Eval(Container.DataItem, "AppointmentStatus" ) %><br/>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:HyperLink>
                        </ItemTemplate>
                            <FooterTemplate>
                                <%-- Label used for showing Error Message --%>
                                <asp:Label ID="ErrorMessage" runat="server" Text="Sorry!! No Records Found." Visible="false">
                                </asp:Label>
                            </FooterTemplate>
                     </asp:Repeater>
                    <br />

                    
                    <input id="txtHidden" style="width: 28px" type="hidden" value="0" runat="server" />
                    <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click" Font-Underline="false" > << Prev </asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp&nbsp&nbsp
                    <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click" Font-Underline="false" >Next >></asp:LinkButton>
                            
                    <br />
                </td>

                <td class="auto-style6">

                    <table style="width:100%; ">
                        <tr>
                            <td class="auto-style3">To :</td>
                            <td>
                                <asp:TextBox ID="txtTo" runat="server" Enabled="False"></asp:TextBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Subject :</td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Appointment :</td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Body:</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>File Attachment :</td>
                            <td>
                                <asp:FileUpload ID="fuAttachment" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtEmail" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblAppointmentID" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblAppointmentStatus" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TanDingKang/AppointmentHomePage.aspx">Back to home</asp:HyperLink>
    
    </div>
</asp:Content>