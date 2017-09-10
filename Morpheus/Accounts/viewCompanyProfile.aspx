<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/CompanyDesign.Master" AutoEventWireup="true" CodeBehind="viewCompanyProfile.aspx.cs" Inherits="Morpheus.Accounts.viewCompanyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       View/Edit Profile</h1>
                     <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                   </div>
                   <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
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
                                   Company Profile</div>
                               <div class="panel-body">
                                   <div class="row">
                                       <div style="width: 98%; padding: 0px 0px 0px 20px; float: left;">
                                           <div class="form-group" style="display:none;">
                                               <div style="width: 50%; float: left; padding-right: 10px;">
                                                   <label>
                                                       UserId:</label>
                                                   <asp:TextBox ID="txtbox_UserId" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                               </div>
                                               <div style="width: 50%; float: left;">
                                                   <label>
                                                       CompanyId:</label>
                                                   <asp:TextBox ID="txtbox_CompanyID" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                               </div>
                                           </div>
                                           <div class="form-group">
                                               <label>
                                                   Company Name:</label>
                                               <asp:TextBox class="form-control" ID="txtbox_CompanyName" runat="server" ToolTip="Comapany Name"
                                                   placeholder="Comapany Name"></asp:TextBox>
                                           </div>
                                           <div class="form-group">
                                               <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                               </asp:ScriptManager>
                                               <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                                   <ContentTemplate>
                                                       <label>
                                                           Email/Username:</label>
                                                       <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_CompanyEmail" runat="server"
                                                           OnChange="CheckUserName(this)" ReadOnly="True"></asp:TextBox>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
                                                           ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                                       <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>
                                           </div>
                                           <div class="form-group" style="display: none;">
                                               <label>
                                                   Status</label>
                                               <asp:DropDownList class="form-control" ID="dp_CompanyAccountStatus" runat="server">
                                                   <asp:ListItem Value="0">Not Active</asp:ListItem>
                                                   <asp:ListItem Value="1">Active</asp:ListItem>
                                               </asp:DropDownList>
                                           </div>
                                           <div class="form-group">
                                               <label>
                                                   Company Type:</label>
                                                <asp:TextBox ID="TextBox_CompanyType" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group" style="color: black;">
                                               <label>Mobile Number:</label>
                                               <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group">
                                               <label>Landline Number:</label>
                                               <asp:TextBox ID="TextBox_landline" CssClass="form-control" ToolTip="landline" placeholder="Landline" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group">
                                               <label>
                                                   Select Membership Plan:</label>
                                               <asp:DropDownList class="form-control" ID="Dp_MemberShipPlan" runat="server">
                                                   <asp:ListItem Text="--Select Membership Plan--" Value="0" />
                                               </asp:DropDownList>
                                           </div>

                                           <div class="form-group">
                                               <div>
                                                   <asp:TextBox ID="TextBox_addressID1" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>
                                                   <label>
                                                       Address 1:</label>
                                                   <asp:TextBox class="form-control" placeholder="Street Name" ID="txtbox_Address1Street"
                                                       runat="server"></asp:TextBox>
                                               </div>
                                               <div style="width: 100%">
                                                   <div style="width: 50%; float: left; padding: 10px 10px 10px 0px;">
                                                       <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address1Suburb"
                                                           runat="server"></asp:TextBox>
                                                   </div>
                                                   <div style="width: 50%; float: left; padding: 10px 0px 10px 0px;">
                                                       <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                                   </div>
                                               </div>
                                               <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address1Postcode"
                                                   runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group">
                                               <div id="myDIV">
                                                   <asp:TextBox ID="TextBox_addressID2" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>
                                                   <label>
                                                       Address 2:</label>
                                                   <asp:TextBox class="form-control" placeholder="Street Name" ID="txtbox_Address2Street"
                                                       runat="server"></asp:TextBox>
                                                   <div style="width: 100%">
                                                       <div style="width: 50%; float: left; padding: 10px 10px 10px 0px;">
                                                           <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address2Suburb"
                                                               runat="server"></asp:TextBox>
                                                       </div>
                                                       <div style="width: 50%; float: left; padding: 10px 0px 10px 0px;">
                                                           <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address2State" runat="server"></asp:TextBox>
                                                       </div>
                                                   </div>
                                                   <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address2Postcode"
                                                       runat="server"></asp:TextBox>
                                               </div>
                                           </div>
                                           <asp:Button ID="btnUpdateCompanyDetails" type="submit" class="btn btn-primary btn-lg btn-block"
                                               runat="server" Text="Update" OnClick="btnUpdateCompanyDetails_Click" />
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
