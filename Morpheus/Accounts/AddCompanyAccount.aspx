<%@ Page Language="C#" enableEventValidation="false" AutoEventWireup="true" CodeBehind="AddCompanyAccount.aspx.cs" Inherits="Seguro.Accounts.AddCompanyAccount" %>
<%@ Register src="~/Accounts/UserControls/SideNavigationMenu.ascx" tagname="DashboardSideMenu" tagprefix="uc1" %>
<%@ Register Src="~/Accounts/UserControls/compnaySideMenuControl.ascx" TagName="companySideMenu" TagPrefix="uc2" %>
<%@ Register src="~/Accounts/UserControls/rightTopMenu.ascx" TagName="rightTopMenu" TagPrefix="uc3" %>
<%@ Register src="~/Accounts/UserControls/EmployeeSideMenu.ascx" TagName="employeeDashMenu" TagPrefix="uc4" %>
<%@ Register Src="~/Accounts/UserControls/AddCompany.ascx" TagName="AddCompany" TagPrefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
   <title>Add Company</title>

     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet" type="text/css" />

    <!-- Morris Charts CSS -->
    <link href="css/morris.css" rel="stylesheet" type="text/css" />

    <!-- Custom Fonts -->
    <link href="fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
    #btnLogOut
    { 
      background-color:#1A0006 !important;
      color:#fff; 
    } 
    #btnLogOut:hover 
    { 
      background-color:Blue !important;
      color:#1A0006; 
    } 
    
    #AddCompanyDiv
    {
        display:block;
    }
    .newboxes
    {
        display:none;
    }
  </style> 

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

     <!-- jQuery -->
   <%-- <script src="js/js.js" type="text/javascript"></script>
    <script type="text/javascript">
    google.maps.event.addDomListener(window, 'load', function () {
        var options = {
            types: ['(cities)'],
            componentRestrictions: { country: "aus" }
        };

        var input = document.getElementById('txtbox_Address1Street');
        var places = new google.maps.places.Autocomplete(input, options);


    });  
    </script>--%>
    <script src="js/jquery.min.js" type="text/javascript"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js" type="text/javascript"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Morris Charts JavaScript -->
    <script src="js/raphael.min.js" type="text/javascript"></script>
    <script src="js/morris.min.js" type="text/javascript"></script>
    <script src="js/morris-data.js" type="text/javascript"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.min.js" type="text/javascript"></script>
   

   <script type="text/javascript" language="javascript">
       function myshowHide(id) {
           HideAll();
           var div = document.getElementById(id);
           div.style.display = "block";
       }


       function HideAll() {
           for (var i = 1; i <= 2; i++) {
               var name = 'd';
               var allname = name.concat(i);
               var newdiv = document.getElementById(allname);
               if (newdiv.getAttribute("id") == allname) {
                   newdiv.style.display = 'none';
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

  
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand"><asp:Label ID="lblUserName" runat="server"></asp:Label>
                </a>
            &nbsp;</div>
            <!-- /.navbar-header -->

            <uc3:rightTopMenu ID="rightTopMenu1" runat="server" visible ="true"/>
            <!-- /.navbar-top-links -->
             <uc1:DashboardSideMenu ID = "dashboardmenu1"  runat="server" Visible ="false"  />
             <uc2:companySideMenu ID = "companySideMenu1" runat="server" Visible="false" />
             <uc4:employeeDashMenu ID= "employeeDashMenu1" runat="server" Visible="false" />
             
            
            <!-- /.navbar-static-side -->
        </nav>
        <div id="page-wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Add Company</h1>
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
                            Add Company</div>
                        <div class="panel-body">
                            <div class="row">
                                <div style="width: 95%; padding: 0px 0px 0px 20px;">
                                    <form role="form">
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
                                                    Email/Username:</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_CompanyEmail" runat="server"
                                                    OnChange="CheckUserName(this)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
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
                                        <div class="form-group" style="color: black;">
                                            <label>Mobile Number:</label><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Mobile"
                                                    ErrorMessage="Please Enter Mobile Number!!:" SetFocusOnError="True" Display="Dynamic" />
                                        </div>
                                            <div class="form-group" style="color: black; font-weight: 700;">
                                            <label>Landline Number:</label>
                                            <asp:TextBox ID="TextBox_landline" CssClass="form-control" ToolTip="landline" placeholder="Landline" runat="server"></asp:TextBox>
                                        </div>
                                    <div class="form-group">
                                        <label>
                                            Address 1:</label>
                                        <asp:TextBox class="form-control" placeholder="Street Name" onFocus="geolocate()" ID="txtbox_Address1Street"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address1Suburb"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                        <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address1Postcode"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <a href="javascript:myFunction()">Add more address</a> (Optional)
                                        <div id="myDIV" style="display: none;">
                                            <label>
                                                Address 2:</label>
                                            <asp:TextBox class="form-control" placeholder="Street Name" onFocus="geolocate()" ID="txtbox_Address2Street"
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address2Suburb"
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address2State" runat="server"></asp:TextBox>
                                            <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address2Postcode"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Select Company Type:</label><asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:DropDownList class="form-control" ID="dp_CompanyType" runat="server">
                                            <asp:ListItem Text="--Select--" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Select Membership Plan:</label><asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:DropDownList class="form-control" ID="Dp_MemberShipPlan" runat="server">
                                            <asp:ListItem Text="--Select Membership Plan--" Value="0" />
                                        </asp:DropDownList>
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
    </form>
</body>
</html>

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
          document.getElementById('<%=txtbox_Address1Suburb.ClientID%>').value = place.address_components[2].long_name;
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
