<%@ Page Title="Add Employee" EnableEventValidation="false" Language="C#" MasterPageFile="~/Accounts/CompanyDesign.Master" AutoEventWireup="true" CodeBehind="AddEmployeeAccount.aspx.cs" Inherits="Morpheus.Accounts.AddEmployeeAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
       $(document).ready(function () {
           $("#<%=txtbox_dateTimePicker_DOB.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%d/%m/%Y",
               daFormat: "%l;%M %p, %e %m,  %Y",
               align: "BR",
               electric: false,
               singleClick: false,
               displayArea: ".siblings('.dtcDisplayArea')",
               button: ".next()"
           });
       });
</script>
    <script type="text/javascript">
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6 && args.Value.length <= 15);
        }
    </script>

   <script type="text/javascript" language="javascript">

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Create Employee Account</h1>
                       <%-- <asp:Label ID="lblErrorMessage" Font-Size="16" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
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
            <!-- /.row -->
            <!-- /.row -->
            <!----/    ------>
            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Enter Details of Employee</div>
                        <div class="panel-body">
                            <div class="row">
                                <div style="width: 95%; padding: 0px 0px 0px 20px;">
                                    <form role="form">
                                    <div class="form-group">
                                        <label>
                                            Employee Name:</label>
                                        <asp:TextBox class="form-control" ID="txtbox_EmpName" runat="server" ToolTip="Comapany Name"
                                            placeholder="Comapany Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                            <ContentTemplate>
                                                <label>
                                                    Email/Username:</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_EmployeeEmail" runat="server"
                                                   OnChange="CheckUserName(this)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_EmployeeEmail"
                                                    ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                                <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Password:</label><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:TextBox class="form-control" placeholder="Password" ID="txtbox_CompanyPassword"
                                            type="password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="passwordReq" runat="server" ControlToValidate="txtbox_CompanyPassword"
                                            ErrorMessage="Password is required!" SetFocusOnError="True" Display="Dynamic" />
                                        <asp:CustomValidator ID="customValidator" runat="server"
                                            ControlToValidate="txtbox_CompanyPassword"
                                            OnServerValidate="TextValidate"
                                            ErrorMessage="Password must be between 6 to 15 characters!"
                                            ClientValidationFunction="validateLength" SetFocusOnError="true" Display="Dynamic">
                                        </asp:CustomValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Re-Enter Password:</label><asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:TextBox class="form-control" placeholder="Password" ID="txtbox_CompanyRePassword"
                                            type="password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="txtbox_CompanyRePassword"
                                            ErrorMessage="Password confirmation is required!" SetFocusOnError="True" Display="Dynamic" />
                                        <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtbox_CompanyPassword"
                                            ControlToValidate="txtbox_CompanyRePassword" ErrorMessage="Your passwords do not match up!"
                                            Display="Dynamic" />
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Address:</label>
                                        <asp:TextBox class="form-control" placeholder="Street Name" ID="txtbox_Address1Street"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address1Suburb"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address1Postcode"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group" >
                                        <label>Mobile Number:</label>
                                        <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Driving License:</label>
                                        <asp:TextBox ID="TextBox_License" CssClass="form-control" ToolTip="License" placeholder="Driving License" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                     
                                        <label>
                                            Date of Birth:</label><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:TextBox class="form-control" ID="txtbox_dateTimePicker_DOB" style="width:92%;float:left;" runat="server" 
                                             TextMode="DateTime"></asp:TextBox>
                                        <img src="images/calender.png" style="float: left; height: 23px; padding-left: 5px;" />
                                        
                                    </div>
                                        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbox_dateTimePicker_DOB" ErrorMessage="Enter Date of birth!" Display ="Dynamic"></asp:RequiredFieldValidator></div>
                                        <div class="form-group" style="padding-top:30px;">
                                            <label>TFN:</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox_TFN" ToolTip="TFN" placeholder="TFN" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>ABN:</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox_ABN" ToolTip="ABN" placeholder="ABN" runat="server"></asp:TextBox>
                                        </div>
                                    <asp:Button ID="btnAddCompany" type="submit" class="btn btn-primary btn-lg btn-block" runat="server"
                                        Text="Submit" OnClick="btnAddCompany_Click" />
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
</asp:Content>
