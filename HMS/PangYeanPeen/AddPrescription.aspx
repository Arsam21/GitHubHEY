<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master"  AutoEventWireup="true" CodeBehind="AddPrescription.aspx.cs" Inherits="HMS.Prescription" %>

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
        .auto-style4 {
            height: 23px;
            width: 95px;
        }
        .auto-style5 {
            width: 183px;
        }
        .auto-style6 {
            height: 23px;
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
        .auto-style10 {
            height: 23px;
            width: 128px;
        }
        .auto-style11 {
            width: 128px;
        }
        .auto-style13 {
            width: 254px;
        }
        .auto-style16 {
            height: 26px;
        }
        .auto-style17 {
            height: 26px;
            width: 119px;
        }
        .auto-style18 {
            width: 379px;
        }
        .auto-style19 {
            width: 354px;
        }
        .auto-style20 {
            width: 111px;
            height: 26px;
        }
      
        .auto-style23 {
            height: 23px;
            width: 155px;
        }
        .auto-style24 {
            width: 155px;
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
	    a[type=number]::-webkit-inner-spin-button {
	        -webkit-appearance: none;
	         cursor: pointer;
	         display: block;
	        width: 10px;
	         text-align: center;
	        position: relative;
	        background: transparent;
	    }
	    a[type=number]::-webkit-inner-spin-button::before,
	    a[type=number]::-webkit-inner-spin-button::after {
	        content: "";
	        position: absolute;
	        right: 0;
	        width: 0;
	        height: 0;
	        border-left: 7px solid transparent;
	        border-right: 7px solid transparent;
	        border-bottom: 10px solid #777;
	    }
	    a[type=number]::-webkit-inner-spin-button::before {
	        top: 7px;
	    }
	    a[type=number]::-webkit-inner-spin-button::after {
	        bottom: 7px;
	        transform: rotate(180deg);
	    }
      
        .auto-style26 {
            width: 155px;
            height: 26px;
        }
      
        .auto-style27 {
            text-align: left;
        }
      
        .auto-style28 {
            height: 23px;
            width: 158px;
        }
        .auto-style29 {
            width: 158px;
            height: 26px;
        }
        .auto-style30 {
            width: 158px;
        }
      
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
            Add Prescription<br />
            <br />
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style18"></td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>
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
                    <asp:Button ID="search1" runat="server" Text="Search" OnClick="search1_Click"  />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style6"></td>
                <td class="auto-style10"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">Patient Name</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style11">Medical Condition</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCondition" runat="server" ></asp:TextBox>
                </td>
            </tr>
             </table>
    
        <br />
        <hr />
    
        <br />
    
        <table style="width: 100%;">
            <tr>
                <td class="auto-style20">Drug Category</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlDrugCat" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style16">
                    <asp:Button ID="search2" runat="server" OnClick="Button2_Click" Text="Search" Enabled="false"/>
                </td>
            </tr>
       
        </table>
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style19">
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

            </tr>
        </table>
        <br />
        <table style="width: 100%;">
            <tr>
                <td >
                    <table runat ="server" id ="Table1" style="width:100%; " visible="false">
                        <tr>
                            <td class="auto-style27">Add Record<br />
                            </td>
                    
                        </tr>
                    </table>
                    <table runat ="server" id ="Table2" style="width:100%;" visible="false" >
              
                        <tr>
                            <td class="auto-style28">Drug ID</td>
                            <td class="auto-style23">
                                <asp:TextBox ID="txtDrugID" runat="server" ></asp:TextBox>
                            </td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style29">Drug Name</td>
                            <td class="auto-style26">
                                <asp:TextBox ID="txtDrugName" runat="server" ></asp:TextBox>
                            </td>
                            <td class="auto-style16"></td>
                        </tr>
                            <tr>
                            <td class="auto-style30">Quantity</td>
                            <td class="auto-style24" >
                                <asp:TextBox runat="server" name="a" ID="txtQty" type="number" value="1" style="width: 30px" min="1" max="5"/>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="group1" runat="server" ControlToValidate="txtQty" ErrorMessage="Quantity must required" ForeColor="Red">*Quantity must required</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" ValidationGroup="group1" runat="server" ControlToValidate="txtQty" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style30">Tablet of having per times</td>
                            <td class="auto-style24"> 
                                <asp:TextBox runat="server" name="a" id="txtTablet" type="number"  value="1" style="width: 30px" min="1" max="5"/>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="group1" runat="server" ControlToValidate="txtTablet" Display="Dynamic" ErrorMessage="Tablet of having per times must required" ForeColor="Red">*Tablet of having per times must required</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator2" ValidationGroup="group1" runat="server" ControlToValidate="txtTablet" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                            </td>
                        </tr>
                            <tr>
                            <td class="auto-style30">Times of having per day</td>
                            <td class="auto-style24">
                                 <asp:TextBox runat="server" name="a" id="txtTimes" type="number"  value="1" style="width: 30px" min="1" max="5"/>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="group1" runat="server" ControlToValidate="txtTimes" ErrorMessage="Times of having per day must required" ForeColor="Red">*Times of having per day must required</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator3" ValidationGroup="group1" runat="server" ControlToValidate="txtTimes" ErrorMessage="Must be a number between 1-5" ForeColor="Red" MaximumValue="5" MinimumValue="1">*Must be a number between 1-5</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style28"></td>
                            <td class="auto-style23"></td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td class="auto-style24">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="Confirm" ValidationGroup="group1" OnClientClick="return validateAndConfirm('Are you sure you want to add prescription?');" OnClick="btnAdd_Click"  />
                            </td>
                            <td></td>
                        </tr>
               
                    </table>
                  
                    <br />
                  
                </td>

            </tr>
        </table>
        <br />
    </div>
</asp:Content>