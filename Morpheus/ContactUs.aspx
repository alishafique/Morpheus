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
                            Contact Us</div>
                        <%--<asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
                        <div class="panel-body">
                             
                          
                                
                                    <form role="form">
                                       
                                            <div class="form-group">
                                                <label>Name:</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Enter Full Name" ID="txtName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="nameReq" runat="server" ControlToValidate="txtName"
                                                ErrorMessage="Name Required" SetFocusOnError="True" Display="Dynamic" />
                                            </div>
                                                                                  
                                           <div class="form-group">
                                               <label>Email:</label>
                                               <asp:TextBox CssClass="form-control" placeholder="Enter Email Address" ID="txtEmail" runat="server"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="Email Required" SetFocusOnError="True" Display="Dynamic" />
                                           </div>
                                        <div class="form-group">
                                            <label>Phone:</label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Phone Number" ID="txtPhone" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Your Message:</label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Your Message" TextMode="MultiLine" Rows="6" ID="txtMessage" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMessage"
                                                ErrorMessage="Comments Required" SetFocusOnError="True" Display="Dynamic" />
                                        </div>
                                        <p>
                                            <label for="CaptchaCodeTextBox">
                                                Retype the characters from the picture:</label><asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        </p>
                                        <BotDetect:WebFormsCaptcha runat="server" ID="ExampleCaptcha"
                                            UserInputControlID="CaptchaCodeTextBox" />
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CaptchaCodeTextBox"
                                                ErrorMessage="Please enter Captcha!!!!" SetFocusOnError="True" Display="Dynamic" />
                                            <%--<asp:Button ID="ValidateCaptchaButton" runat="server" />--%>
                                            <asp:Label ID="CaptchaCorrectLabel" runat="server" Font-Size="16" ForeColor="Green"></asp:Label>
                                            <asp:Label ID="CaptchaIncorrectLabel" Font-Size="16" ForeColor="Red" runat="server"
                                                CssClass="incorrect"></asp:Label>
                                        </div>
                                         <asp:Button ID="btnContactUs" type="submit" class="btn btn-primary btn-lg btn-block"
                                       runat="server" Text="Submit" OnClick="btnContactUs_Click"/>
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
