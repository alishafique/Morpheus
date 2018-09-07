<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewEmployees.aspx.cs" Inherits="Seguro.Accounts.viewEmployees" %>

<%@ Register Assembly="Infragistics4.Web.jQuery.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics4.Web.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register src="~/Accounts/UserControls/SideNavigationMenu.ascx" tagname="DashboardSideMenu" tagprefix="uc1" %>
<%@ Register Src="~/Accounts/UserControls/compnaySideMenuControl.ascx" TagName="companySideMenu" TagPrefix="uc2" %>
<%@ Register src="~/Accounts/UserControls/rightTopMenu.ascx" TagName="rightTopMenu" TagPrefix="uc3" %>
<%@ Register src="~/Accounts/UserControls/EmployeeSideMenu.ascx" TagName="employeeDashMenu" TagPrefix="uc4" %>

<%@ Register assembly="Infragistics4.Web.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI" tagprefix="ig" %>

<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>View Company</title>

     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href=<%="'css/sb-admin-2.css?version="+ DateTime.Now.ToString("yyyyMMddhhmmss") +"'"%> rel="stylesheet" type="text/css" />

    <!-- Morris Charts CSS -->
    <link href="css/morris.css" rel="stylesheet" type="text/css" />

    <!-- Custom Fonts -->
    <link href="fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />

   <%-- datatable CSS--%>
    <link href="css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/dataTables.responsive.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

     <!-- jQuery -->
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
     <style type="text/css">
      .hidden-field {
            display: none;
        }
        
    </style>
   
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

         function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgprw.ClientID%>').prop('src', e.target.result)
                        
                };
                reader.readAsDataURL(input.files[0]);
                }
          }  
       </script>

   <script type="text/javascript" language="javascript">
       function myFunction() {
           var x = document.getElementById('myDIV');
           if (x.style.display === 'none') {
               x.style.display = 'block';
           } else {
               x.style.display = 'none';
           }
       }
      
</script>
    <!-- DataTables CSS -->
    <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="datatables-responsive/dataTables.responsive.css" rel="stylesheet" />
    <link id="link1" href="../ig_ui/css/themes/infragistics2012/infragistics.theme.css" rel="Stylesheet" type="text/css" />
    <link id="link2" href="../ig_ui/css/structure/infragistics.css" rel="Stylesheet" type="text/css" />

     <!-- DataTables JavaScript -->
    <script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="datatables-plugins/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script src="datatables-responsive/dataTables.responsive.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                responsive: true
            });
            
        });
    </script>  
    <script type="text/javascript">  
        jQuery.fn.extend({
            live: function (event, callback) {
                if (this.selector) {
                    jQuery(document).on(event, this.selector, callback);
                }
            }
        });
        function ShowProgress() {
            setTimeout(function () {
                var modal1 = $('<div />');
                modal1.addClass("modal1");
                $('body').append(modal1);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
          $(function () {
              $('.btn').on("click", function () {
               ShowProgress();
           });
          });
    </script>  
     
</head>
<body>
    
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     
         <div class="loading" align="center">
             Loading. Please wait.<br />
             <br />
             <img src="images/loader.gif" alt="" />
         </div>
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
                                <h1 class="page-header">View/Edit Employee's Profile</h1>

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
                            <div class="col-lg-12">
                                <div class="panel panel-default" runat="server" id="hideGrid">
                                    <div class="panel-heading">
                                        List of Employees
                                    </div>
                                
                                </div>
                                <!-- /.panel -->

                                <div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">Edit details.</div>
                                                <div class="panel-body">

                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div style="width: 100%; display: none;">
                                                                <div class="form-group" style="width: 50%; float: left; padding-right: 10px;">
                                                                    <label>Employee Id:</label>
                                                                    <asp:TextBox ID="TextBox_EmployeeId" class="form-control" ToolTip="Employee Id" ReadOnly="true" placeholder="Employee ID" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group" style="width: 50%; float: left;">
                                                                    <label>User Id:</label>
                                                                    <asp:TextBox ID="TextBox_userId" class="form-control" ToolTip="User Id" ReadOnly="true" placeholder="User Id" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group" runat="server">

                                                                <div class="">
                                                                    <asp:Image ID="imgprw" CssClass="preview-nodeCenter nodeCenter fadeChange" runat="server" />
                                                 
                                                                </div>
                                                                <div>

                                                                    <asp:FileUpload ID="profileUploadCtr" class="uploadFile form-group" onchange="ShowImagePreview(this);"  placeholder="Choose Images" runat="server" />
                                                                    <asp:LinkButton ID="btnRotat" OnClick="btnRotat_Click" runat="server" CausesValidation="false">Rotate</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton1" ValidationGroup="a" OnClientClick="showProgress()" CssClass="btn btn-outline btn-primary btn-xs" runat="server" OnClick="LinkButton1_Click">Upload Profile Image</asp:LinkButton>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="a" SetFocusOnError="true" runat="server" ErrorMessage="Only JPEG, PNG, & TIFF file is allowed!"
                                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg|.PNG|.JPG|.GIF|.JPEG)$" ControlToValidate="profileUploadCtr" Display="Dynamic" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Employee Name:</label>
                                                                <asp:TextBox ID="TextBox_EmployeeName" class="form-control" ToolTip="Employee Name" placeholder="Employee Name" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Employee Email:</label>
                                                                <asp:TextBox ID="TextBox1_EmployeeEmail" ReadOnly="true" class="form-control" ToolTip="Employee Email" placeholder="Employee Email" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Date of Birth:</label>

                                                                <div style="width: 100%;">
                                                                    <div style="">
                                                                        <asp:TextBox Style="float: left; width: 90%;" class="form-control" ID="txtbox_dateTimePicker_DOB" runat="server"
                                                                            TextMode="DateTime"></asp:TextBox>
                                                                        <img src="images/calender.png" style="float: right; height: 23px; padding-left: 5px;" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="form-group" style="margin-top: 50px;">
                                                                <label>Mobile Number:</label>
                                                                <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Driving License:</label>
                                                                <asp:TextBox ID="TextBox_License" CssClass="form-control" ToolTip="License" placeholder="Driving License" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group" id="hideEmployee" runat="server">
                                                                <label>Active Status</label>
                                                                <asp:DropDownList ID="DropDownList_activeStatus" CssClass="form-control" ToolTip="Status" runat="server">
                                                                    <asp:ListItem Value="0">Not-Active</asp:ListItem>
                                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Address:</label>
                                                                <asp:TextBox ID="TextBox_StreetName" class="form-control" ToolTip="Street Name" onFocus="geolocate()" placeholder="Street Name" runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="TextBox_Suburb" class="form-control" ToolTip="Suburb" placeholder="Suburb" runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="TextBox_State" class="form-control" ToolTip="State" placeholder="State" runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="TextBox_Postcode" class="form-control" ToolTip="Postcode" placeholder="Postcode" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>TFN:</label>
                                                                <asp:TextBox ID="TextBox_TFN" class="form-control" ToolTip="TFN" placeholder="TFN" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>ABN:</label>
                                                                <asp:TextBox ID="TextBox_ABN" class="form-control" ToolTip="ABN" placeholder="ABN" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:Button ID="btnUpdateEmployeeProfile" type="Update" ValidationGroup="a" class="btn btn-primary btn-lg btn-block"
                                                                runat="server" Text="Update Profile" OnClick="btnUpdateEmployeeProfile_Click" />
                                                        </div>

                                                        <div class="col-lg-6" style="">
                                                            <h1>Upload Your Documents</h1>



                                                            <div class="form-group" style="margin-top: 15px;">
                                                                <asp:GridView ID="grdViewDocuments" runat="server" Width="100%" class="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID">
                                                                            <ItemStyle CssClass="hidden-field" />
                                                                            <HeaderStyle CssClass="hidden-field" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName" />
                                                                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID">
                                                                            <ItemStyle CssClass="hidden-field" />
                                                                            <HeaderStyle CssClass="hidden-field" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DocumentURL" HeaderText="DocumentURL">
                                                                            <ItemStyle CssClass="hidden-field" />
                                                                            <HeaderStyle CssClass="hidden-field" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DocumentStatus" HeaderText="DocumentStatus" />
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="removeDocument" runat="server"
                                                                                    CommandArgument='<%# Eval("DocumentID")%>'
                                                                                    OnClientClick="return confirm('Do you want to delete?')"
                                                                                    Text="Delete" OnClick="removeDocument_Click" CausesValidation="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("DocumentURL") %>' CausesValidation="false" runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Name of document</label>


                                                                <asp:DropDownList ID="dpdDocuments" CssClass="form-control" runat="server">
                                                                    <asp:ListItem>White Card</asp:ListItem>
                                                                    <asp:ListItem>Blue Card</asp:ListItem>
                                                                    <asp:ListItem>High Risk Work</asp:ListItem>
                                                                    <asp:ListItem>Working at heights</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />

                                                                <asp:FileUpload ID="FtCdocuments" class="uploadFile form-group" placeholder="Choose Images" runat="server" />
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDocumentName" runat="server" Display="Dynamic" ErrorMessage="Enter document name." SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FtCdocuments" runat="server" Display="Dynamic" ErrorMessage="Select Document To Upload." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="aa" SetFocusOnError="true" runat="server" ErrorMessage="Only JPEG, PNG, & TIFF file is allowed!"
                                                                    ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg|.PNG|.JPG|.GIF|.JPEG)$" ControlToValidate="FtCdocuments" Display="Dynamic" />
                                                            </div>
                                                            <asp:Button ID="btnUploadDocuments" CssClass="btn btn-primary" runat="server" ValidationGroup="aa" Text="Upload Document" OnClick="btnUploadDocuments_Click" />
                                                        </div>

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

                            </div>
                            <!-- /.col-lg-12 -->
                        </div>

                        <!-- /#page-wrapper -->
                    </div>



                </div>
                   
    </form>
</body>
</html>
<script type="text/javascript">
        //$('.imgUpload').on('click', function () {
        //    $('.uploadFile').click();
    //});
    function chooseFile() {
        document.getElementById('<%= profileUploadCtr.ClientID %>').click();
    }
        function imagepreview(input) {
            if (input.files && input.files[0]) {
                var fildr = new FileReader();
                fildr.onload = function (e) {
                    $('#imgprw').attr('src', e.target.result);
                }
                fildr.readAsDataURL(input.files[0]);
            }
        }
    </script>

  <script type="text/javascript">
         var placeSearch, autocomplete;
     

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
          // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=TextBox_StreetName.ClientID %>')),
            { types: ['geocode'] });


        // When the user selects an address from the dropdown, populate the address
          // fields in the form.
          
          autocomplete.addListener('place_changed', fillInAddress);
          
      }

         function fillInAddress() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=TextBox_StreetName.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=TextBox_Suburb.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=TextBox_State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=TextBox_Postcode.ClientID%>').value = place.address_components[6].short_name;
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
