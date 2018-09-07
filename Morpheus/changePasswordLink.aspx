<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="changePasswordLink.aspx.cs" Inherits="Seguro.changePasswordLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6 && args.Value.length <= 15);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
     <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                       Set New Password.</h1>
                        <asp:Label ID="lblErrorMessage" runat="server" Font-Size="16" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
                <!-- /.col-lg-12 -->
                
            </div>
            <!-- /.row -->
            <!-- /.row -->
            <!----/    ------>
            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           Enter Your Password</div>
                        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                        <div class="panel-body">
                            <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                               <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                               <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label></a>.          
                           </div>
                           <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                               <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                               <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label></a>.                             
                           </div>
                            <div class="row">
                                
                                <div style="width: 95%; padding: 0px 0px 0px 20px;" runat="server" id="divID">
                                    <form role="form">
                                    <div class="form-group" style="color: black; font-weight: 700;">
                                        <label>
                                            New Password:</label>
                                        <asp:TextBox ID="txtNewPassword" CssClass="form-control" TextMode="Password" placeholder="Enter your Password"
                                            runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword"
                                            runat="server" ErrorMessage="New Password required"
                                            Text="Password Required" ControlToValidate="txtNewPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true">
                                        </asp:RequiredFieldValidator>
                                         <asp:CustomValidator ID="customValidator" runat="server"
                                            ControlToValidate="txtNewPassword"
                                            OnServerValidate="TextValidate"
                                            ErrorMessage="Password must be between 6 to 15 characters!"
                                            ClientValidationFunction="validateLength" SetFocusOnError="true" Display="Dynamic">
                                        </asp:CustomValidator>
                                    </div>
                                        <div class="form-group" style="color: black; font-weight: 700;">
                                            <label>Confirm Password:</label>
                                            <asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" placeholder="Re-Enter your Password" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmNewPassword" SetFocusOnError="true"
                                                runat="server" ErrorMessage="Confirm New Password required" Text="Password Required"
                                                ControlToValidate="txtConfirmNewPassword"
                                                ForeColor="Red" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                                ErrorMessage="New Password and Confirm New Password must match"
                                                ControlToValidate="txtConfirmNewPassword" ForeColor="Red" 
                                                ControlToCompare="txtNewPassword"
                                                Display="Dynamic" Type="String" Operator="Equal" Text="Password does not matched!" SetFocusOnError="true">
                                            </asp:CompareValidator>
                                        </div>
                                  
                                        <asp:Button ID="btnChangePassword" type="submit" class="btn btn-primary" runat="server"
                                        Text="Submit" OnClick="btnChangePassword_Click"/>
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
            <!-- /.row -->
            <!-- /#page-wrapper -->
        </div>
        </div>
</asp:Content>
