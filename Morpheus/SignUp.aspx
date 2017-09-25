<%@ Page EnableEventValidation="false" Title="SignUp" Language="C#" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Morpheus.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link type="text/css" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500">
    
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

        function myFunction() {
            var x = document.getElementById('myDIV');
            if (x.style.display === 'none') {
                x.style.display = 'block';
            } else {
                x.style.display = 'none';
            }
        }
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6 && args.Value.length <= 15);
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="bread_area">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <ol class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Sign Up</li>
                    </ol>                    
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header" style="color: rgb(64, 64, 64);">Sign Up</h1>
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
                            Sign Up as Company
                        </div>
                        <%--<asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>--%>
                        <div class="panel-body">

                            <div class="row">
                                <div style="width: 95%; padding: 0px 0px 0px 20px;">
                                    <form role="form">
                                         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                                <ContentTemplate>
                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Company Name:</label>
                                            <asp:TextBox class="form-control" ID="txtbox_CompanyName" runat="server" ToolTip="Comapany Name"
                                                placeholder="Company Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="color: black;">
                                           
                                                
                                                    <label>
                                                        Email/Username:</label><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label><asp:Label ID="Label3" runat="server" Text="    (Email should be valid)" Font-Bold="true" ForeColor="lightgray"></asp:Label>
                                                    <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_CompanyEmail" runat="server"
                                                        OnChange="CheckUserName(this)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
                                                        ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                                    <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                                
                                        </div>
                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Password:</label><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label><asp:Label ID="Label5" runat="server" Text="    (Password Should be between 6 to 15 characters)" Font-Bold="true" ForeColor="lightgray"></asp:Label>

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
                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Re-Enter Password:</label><asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <asp:TextBox class="form-control" placeholder="Password" ID="txtbox_CompanyRePassword"
                                                type="password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="txtbox_CompanyRePassword"
                                                ErrorMessage="Password confirmation is required!" SetFocusOnError="True" Display="Dynamic" />
                                            <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtbox_CompanyPassword"
                                                ControlToValidate="txtbox_CompanyRePassword" ErrorMessage="Your passwords do not match up!"
                                                Display="Dynamic" />
                                        </div>
                                        <div class="form-group" style="color: black;">
                                            <label>Mobile Number:</label><asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Mobile"
                                                ErrorMessage="Please Enter Mobile Number!!:" SetFocusOnError="True" Display="Dynamic" />
                                        </div>
                                        <div class="form-group" style="color: black; font-weight: 700;">
                                            <label>Landline Number:</label>
                                            <asp:TextBox ID="TextBox_landline" CssClass="form-control" ToolTip="landline" placeholder="Landline" runat="server"></asp:TextBox>
                                        </div>
                                
                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Address 1:</label>
                                            <asp:TextBox class="form-control" placeholder="Street Name" ID="txtbox_Address1Street"
                                                runat="server" onFocus="geolocate()" ></asp:TextBox>
                                            
                                            <div style="display:block;">
                                            <asp:TextBox class="form-control" placeholder="Suburb" ID="locality" 
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address1Postcode"
                                                runat="server"></asp:TextBox>
                                                </div>
                                        </div>
                                        <div class="form-group" style="color: black;">
                                            <a href="javascript:myFunction()" style="font-size: large;">Click to Add more address</a> (Optional)
                                        <div id="myDIV" style="display: none;">
                                            <label>
                                                Address 2:</label>
                                            <asp:TextBox class="form-control" placeholder="Street Name" ID="txtbox_Address2Street" onFocus="geolocate()"
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address2Suburb"
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address2State" runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address2Postcode"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        </div>
                                               </ContentTemplate>
                                            </asp:UpdatePanel>

                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Select Company Type:</label><asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <asp:DropDownList class="form-control" ID="dp_CompanyType" runat="server">
                                                <asp:ListItem Text="--Select--" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group" style="color: black;">
                                            <label>
                                                Select Membership Plan:</label><asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <asp:DropDownList class="form-control" ID="Dp_MemberShipPlan" runat="server">
                                                <asp:ListItem Text="--Select Membership Plan--" Value="0" />
                                            </asp:DropDownList>
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
    </div>
     <script type="text/javascript">
         var placeSearch, autocomplete, autocomplete2;
       

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
        // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=txtbox_Address1Street.ClientID %>')),
            { types: ['geocode'] });

           autocomplete2 = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=txtbox_Address2Street.ClientID %>')),
            { types: ['geocode'] });


        // When the user selects an address from the dropdown, populate the address
          // fields in the form.
          
          autocomplete.addListener('place_changed', fillInAddress);
          autocomplete2.addListener('place_changed', fillInAddress2);
          
      }

         function fillInAddress() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=txtbox_Address1Street.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=locality.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=txtbox_Address1State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=txtbox_Address1Postcode.ClientID%>').value = place.address_components[6].short_name;
         }
          function fillInAddress2() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete2.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=txtbox_Address2Street.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=txtbox_Address2Suburb.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=txtbox_Address2State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=txtbox_Address2Postcode.ClientID%>').value = place.address_components[6].short_name;
      }

      // Bias the autocomplete object to the user's geographical location,
      // as supplied by the browser's 'navigator.geolocation' object.
      function geolocate() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
            var geolocation = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
              center: geolocation,
              radius: position.coords.accuracy
            });
            autocomplete.setBounds(circle.getBounds());
          });
        }
      }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB3_CGfJ3ebusaEsHfvc_6DUsIKehea6OU&libraries=places&callback=initAutocomplete" type="text/javascript"></script>
</asp:Content>
