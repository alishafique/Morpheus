<%@ Page Title="" Language="C#" enableEventValidation="false" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="Morpheus.resetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
     <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                       Forgot password.</h1>
                        <%--<asp:Label ID="lblErrorMessage" runat="server" Font-Size="16" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
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
                           Forgot your password?</div>
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
                                <div style="width: 95%; padding: 0px 0px 0px 20px;" id="myDiv" runat="server">
                                    <form role="form">
                                    <div class="form-group" style="color: black; font-weight: 700;">
                                        <label>
                                            Email:</label><asp:Label ID="Label2" runat="server" Text="*" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        <asp:TextBox class="form-control" ID="txtbox_email" runat="server" ToolTip="Email"
                                            placeholder="Type your Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_email" runat="server" ErrorMessage="The email field is required." Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                  
                                        <asp:Button ID="btnAddCompany" type="submit" class="btn btn-primary" runat="server"
                                        Text="Submit" OnClick="btnAddCompany_Click"  />
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
