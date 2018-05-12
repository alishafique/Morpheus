<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="Morpheus.Accounts.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Change Password</title>
    <script type="text/javascript">
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6 && args.Value.length <= 15);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       Change Your Password</h1>
                    <asp:Label ID="lblErrorMessage" Font-Size="16" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
               </div>
               <!-- /.col-lg-12 -->
           </div>

          
           <div class="row">
               <!-- /.panel -->
               <div>
                   <div class="row">
                       <div class="col-lg-6">
                           <div class="panel panel-default">
                               <div class="panel-heading">
                                   Change Your Password</div>
                               <div class="panel-body">
                                   <div class="alert alert-success alert-dismissable" id ="successMsg" style="display:none;" runat="server">
                                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                       <asp:Label ID="lblsuccessmsg" runat="server" Text=""></asp:Label></a>.          
                                   </div>
                                   <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display:none;" runat="server">
                                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                       <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label></a>.                             
                                   </div>
                                   <div class="row">

                                       <div style="width: 95%; padding: 0px 0px 0px 20px;">
                                       <div class="form-group">
                                           <label>
                                               Old Password:</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                           <asp:TextBox class="form-control" ID="oldPassword" runat="server" type="password" ToolTip="Old Password"
                                               placeholder="Enter Old Password"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldPassword"
                                            ErrorMessage="Password is required!" SetFocusOnError="True" Display="Dynamic" />
                                       </div>
                                       <div class="form-group">
                                           <label>
                                               New Password:</label><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                           <asp:TextBox class="form-control" ID="newPassword" type="password" runat="server" ToolTip="New Password"
                                               placeholder="Enter New Password"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="passwordReq" runat="server" ControlToValidate="newPassword"
                                            ErrorMessage="Password is required!" SetFocusOnError="True" Display="Dynamic" />
                                        <asp:CustomValidator ID="customValidator" runat="server"
                                            ControlToValidate="newPassword"
                                            OnServerValidate="TextValidate"
                                            ErrorMessage="Password must be between 6 to 15 characters!"
                                            ClientValidationFunction="validateLength" SetFocusOnError="true" Display="Dynamic">

                                        </asp:CustomValidator>
                                       </div>
                                           <div class="form-group">
                                               <label>
                                                   Confirm New Password:
                                               </label><asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                               <asp:TextBox class="form-control" ID="confirmNewPassword" type="password" runat="server" ToolTip="Confirm New Password"
                                                   placeholder="Enter Confirm New Password"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="confirmNewPassword"
                                                   ErrorMessage="Password confirmation is required!" SetFocusOnError="True" Display="Dynamic" />
                                               <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="newPassword"
                                                   ControlToValidate="confirmNewPassword" ErrorMessage="Your passwords do not match up!"
                                                   Display="Dynamic" />
                                           </div>

                                            <asp:Button ID="btnUpdatePassword" type="submit" class="btn btn-primary btn-lg btn-block" runat="server"
                                        Text="Update" OnClick="btnUpdatePassword_Click" />
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
               <!-- /.col-lg-12 -->
           </div>
          
           <!-- /#page-wrapper -->
       </div>
</asp:Content>
