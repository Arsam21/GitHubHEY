<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePrescription.aspx.cs" Inherits="HMS.UpdatePrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 95px;
        }
        .auto-style5 {
            width: 183px;
        }
        .auto-style7 {
            width: 95px;
            height: 26px;
        }
        .auto-style8 {
            width: 183px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 128px;
        }
        .auto-style11 {
            width: 128px;
        }
        .auto-style13 {
            width: 254px;
        }
        .auto-style18 {
            width: 379px;
        }
              
        .auto-style19 {
            height: 24px;
            width: 95px;
        }
        .auto-style20 {
            height: 24px;
            width: 183px;
        }
        .auto-style21 {
            height: 24px;
            width: 128px;
        }
        .auto-style22 {
            height: 24px;
        }
              
        /*a {
	        color: #777;
	        width: 2em;
	        font-size: small;
	        border-radius: 10px;
	        border: 2px solid #ccc;
	        padding-left: 10px;
            text-align: right;
            padding-right: 5px;
            padding-top: 5px;
            padding-bottom: 5px;
        }*/
	                  
    </style>
    <script type="text/javascript">
        function validateAndConfirm(message) {
            var validated = Page_ClientValidate('group1');
            if (validated) {
                return confirm(message);
            }
        }
    </script>

    <div>
        <div class="auto-style1">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/PangYeanPeen/PrescriptionHomePage.aspx">Back to Home Page</asp:HyperLink>
                    <br />
                </td>
            </tr>
        </table>
            Update Prescription<br />
            <br />
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style18"></td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
           
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">Visitation ID&nbsp;&nbsp; </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtID" runat="server" Enabled ="false"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="search1" runat="server" Text="Search" OnClick="Button1_Click" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style20"></td>
                <td class="auto-style21"></td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style3">Patient Name</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">Medical Condition</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCondition" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    
        <br />
        <hr />
    
        <br />

   
        <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />    
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" ValidationGroup="group1" OnClientClick="return validateAndConfirm('Are you sure you want to update prescription?');"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate> 
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Prescription Details ID">  
                    <ItemTemplate>  
                        <asp:Label ID="PrescriptionDetailsID" runat="server" Text='<%#Eval("PrescriptionDetailsID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Drug ID">  
                    <ItemTemplate>  
                        <asp:Label ID="DrugID" runat="server" Text='<%#Eval("DrugID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Drug Name">  
                    <ItemTemplate>  
                        <asp:Label ID="DrugName" runat="server" Text='<%#Eval("DrugName") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Quantity">  
                    <ItemTemplate>  
                        <asp:Label ID="Qty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Qty" runat="server" Text='<%#Eval("Qty") %>'></asp:TextBox>
                        <br /> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="group1" runat="server" ControlToValidate="Qty" ErrorMessage="Value must required" ForeColor="Red">*Value must required</asp:RequiredFieldValidator>         
                        <br /> 
                        <asp:RangeValidator ID="RangeValidator1" ValidationGroup="group1" runat="server" ControlToValidate="Qty" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Tablet of having per times">  
                    <ItemTemplate>  
                        <asp:Label ID="Tablet" runat="server" Text='<%#Eval("Tablet") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Tablet" runat="server" Text='<%#Eval("Tablet") %>'></asp:TextBox>  
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="group1" runat="server" ControlToValidate="Tablet" ErrorMessage="Value must required" ForeColor="Red">*Value must required</asp:RequiredFieldValidator>
                        <br />
                        <asp:RangeValidator ID="RangeValidator2" ValidationGroup="group1" runat="server" ControlToValidate="Tablet" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Times of having per day">  
                    <ItemTemplate>  
                        <asp:Label ID="Times" runat="server" Text='<%#Eval("Times") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Times" runat="server" Text='<%#Eval("Times") %>'></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="group1" runat="server" ControlToValidate="Times" ErrorMessage="Value must required" ForeColor="Red">*Value must required</asp:RequiredFieldValidator>  
                        <br />
                        <asp:RangeValidator ID="RangeValidator3" ValidationGroup="group1" runat="server" ControlToValidate="Times" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                    </EditItemTemplate>  
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
        <br />
        <asp:Label ID="lblDisplay" runat="server" Text="[lblDisplay]"></asp:Label>
        <br />
        <br />
        <br />
        </div>
</asp:Content>