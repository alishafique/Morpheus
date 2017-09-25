<%@ Page Title="" Language="C#" MasterPageFile="~/defualt.Master"  enableEventValidation="false" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Morpheus.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="bread_area">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <ol class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Contact Us</li>
                    </ol>                    
                </div>
            </div>
        </div>
    </div>
    <div class="container">
     <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header" style="color:rgb(64, 64, 64);">
                        Contact Us</h1>
                        <%--<asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" Font-Size="14" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
                      <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                               <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                               <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label></a>.          
                           </div>
                           <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                               <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                               <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label></a>.                             
                           </div>
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
                            Sign Up as Company</div>
                        <%--<asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
                        <div class="panel-body">
                             
                          
                                
                                    <form role="form">
                                       
                                            <div class="form-group">
                                                <label>First Name:</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Enter First Name" ID="TextBox1" runat="server"></asp:TextBox>
                                            </div>
                                        <div class="form-group">
                                            <label>Last Name:</label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Last Name" ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                             
                                           <div class="form-group">
                                               <label>Email:</label>
                                               <asp:TextBox CssClass="form-control" placeholder="Enter Email Address" ID="TextBox3" runat="server"></asp:TextBox>
                                           </div>
                                        <div class="form-group">
                                            <label>Phone:</label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Phone Number" ID="TextBox4" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Your Message:</label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Your Message" TextMode="MultiLine" Rows="6" ID="TextBox5" runat="server"></asp:TextBox>
                                        </div>
                                         <asp:Button ID="btnAddActivity" type="submit" class="btn btn-primary btn-lg btn-block"
                                       runat="server" Text="Submit"/>
                                    </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                           
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
