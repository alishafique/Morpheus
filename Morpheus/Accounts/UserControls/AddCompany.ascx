<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCompany.ascx.cs" Inherits="Morpheus.Accounts.UserControls.AddCompany" %>

<script type="text/javascript">
    function CheckUserName(oName) {
        PageMethods.UserNameChecker(oName.value, OnSucceeded);
    }

    function OnSucceeded(result, userContext, methodName) {
        lbl = document.getElementById('<%=lbl_error_message.ClientID %>');
        if (methodName == "UserNameChecker") {
            if (result == true) {
                lbl.innerHTML = 'username not available';
                lbl.style.color = "red";
            }
            else {
                lbl.innerHTML = 'username available';
                lbl.style.color = "green";
            }
        }
    } 
</script>

<div class="newboxes">
    <div class="row" >
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">Add Company</div>
                        <div class="panel-body">
                            <div class="row">
                                <div style = "    width: 95%; padding: 0px 0px 0px 20px;">
                                    <form role="form">
                                        <div class="form-group">
                                            <label>Company Name:</label>
                                            <asp:TextBox class="form-control" ID="txtbox_CompanyName" runat="server" ToolTip="Comapany Name"
                                                placeholder="Comapany Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
                                        <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                        <ContentTemplate>
                                            <label>Email/Username:</label>
                                            <asp:TextBox class="form-control" placeholder="Email"
                                                    ID="txtbox_CompanyEmail" runat="server" 
                                                 OnChange="CheckUserName(this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
                                                ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                            <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                            
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
           
                                        </div>
                                        <div class="form-group">
                                           <label>Password:</label>
                                             <asp:TextBox class="form-control" placeholder="Password"
                                                    ID="txtbox_CompanyPassword" type="password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="passwordReq" runat="server" ControlToValidate="txtbox_CompanyPassword"
                                                ErrorMessage="Password is required!" SetFocusOnError="True" Display="Dynamic" />
                                        </div>
                                        <div class="form-group">
                                            <label>Re-Enter Password:</label>
                                            <asp:TextBox class="form-control" placeholder="Password"
                                                    ID="txtbox_CompanyRePassword" type="password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="txtbox_CompanyRePassword"
                                                ErrorMessage="Password confirmation is required!" SetFocusOnError="True" Display="Dynamic" />
                                            <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtbox_CompanyPassword"
                                                ControlToValidate="txtbox_CompanyRePassword" ErrorMessage="Your passwords do not match up!"
                                                Display="Dynamic" />
                                        </div>
                                        <div class="form-group">
                                            <label>Address 1:</label>
                                            <asp:TextBox class="form-control" placeholder="Street Name"
                                                    ID="txtbox_Address1Street" runat="server"></asp:TextBox>
                                                     <asp:TextBox class="form-control" placeholder="Suburb"
                                                    ID="txtbox_Address1Suburb" runat="server"></asp:TextBox>
                                                    <asp:TextBox class="form-control" placeholder="State"
                                                    ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                                     <asp:TextBox class="form-control" placeholder="poste code"
                                                    ID="txtbox_Address1Postcode" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                       <a href="javascript:myFunction()">Add more address</a>  (Optional)
                                        <div id="myDIV" style="display:none;">
                                           <label>Address 2:</label>
                                              <asp:TextBox class="form-control" placeholder="Street Name"
                                                    ID="txtbox_Address2Street" runat="server"></asp:TextBox>
                                                     <asp:TextBox class="form-control" placeholder="Suburb"
                                                    ID="txtbox_Address2Suburb" runat="server"></asp:TextBox>
                                                    <asp:TextBox class="form-control" placeholder="State"
                                                    ID="txtbox_Address2State" runat="server"></asp:TextBox>
                                                     <asp:TextBox class="form-control" placeholder="poste code"
                                                    ID="txtbox_Address2Postcode" runat="server"></asp:TextBox>
                                         </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Select Company Type:</label>
                                            <asp:DropDownList class="form-control" ID="dp_CompanyType" runat="server">
                                            <asp:ListItem Text="--Select--" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Select Membership Plan:</label>
                                            <asp:DropDownList class="form-control" ID="Dp_MemberShipPlan" runat="server">
                                            <asp:ListItem Text="--Select Membership Plan--" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                        
                                        <asp:Button ID="btnAddCompany" type="submit" class = "btn btn-default"
                                            runat="server" Text="Submit" onclick="btnAddCompany_Click" />
                                    </form>
                                </div>
                                <!-- /.col-lg-6 (nested) -->                 
                              
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
             </div>
    </div>