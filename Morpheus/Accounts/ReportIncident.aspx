<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportIncident.aspx.cs" Inherits="Morpheus.ReportIncident" %>

<%@ Register Src="~/Accounts/UserControls/SideNavigationMenu.ascx" TagName="DashboardSideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Accounts/UserControls/compnaySideMenuControl.ascx" TagName="companySideMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Accounts/UserControls/rightTopMenu.ascx" TagName="rightTopMenu" TagPrefix="uc3" %>
<%@ Register Src="~/Accounts/UserControls/EmployeeSideMenu.ascx" TagName="employeeDashMenu" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Report Incident</title>

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


    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtbox_dateTimePicker.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%Y/%m/%d %H:%M",
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

        function getLocation() {
            if (navigator && navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                document.getElementById('<%=currentlocation.ClientID %>').value = "Geolocation is not supported by this browser.";
            }
        }
        function showPosition(position) {
            //x.innerHTML =  position.coords.latitude +"," + position.coords.longitude;
            document.getElementById('<%=currentlocation.ClientID %>').value = position.coords.latitude + "," + position.coords.longitude;
        }
    </script>

</head>
<body>
    <form id="form1" enctype="multipart/form-data" method="post" runat="server">

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
                        <h1 class="page-header">Report Incident</h1>
                        <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                        </div>
                        <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                        </div>
                    </div>
                    <button type="button" onclick="location.href='ViewIncidentReports.aspx';" style="float: right; margin: 5px;" class="btn btn-success">View Incidents <i class="fa fa-search-plus"></i></button>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <!-- /.row -->
                <!----/    ------>
                
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Report Incident
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">

                                        <div class="form-group" style="display: block;">
                                            <label>Current Location:</label>
                                            <asp:TextBox ID="currentlocation" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Reported By:</label>
                                            <asp:TextBox class="form-control" ID="txtbox_ReportedBy" runat="server" ToolTip="Reported By"
                                                placeholder="Reported By" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Date:</label>
                                            <asp:TextBox class="form-control" ID="txtbox_dateTimePicker" Style="width: 93%; float: left;" runat="server"
                                                ReadOnly="true" TextMode="DateTime"></asp:TextBox>
                                            <img src="images/calender.png" style="float: left; height: 23px; padding-left: 5px;" />
                                        </div>
                                        <div class="form-group" style="padding-top: 33px;">
                                            <label>Severity level:</label>
                                            <asp:DropDownList class="form-control" ID="dp_severityLevel" runat="server">
                                                <%--<asp:ListItem Value="1">Level 1 - Immediate response, threat of injury or death</asp:ListItem>
                                            <asp:ListItem Value="2">Level 2 – Within 1 hour, no physical danger, work has ceased</asp:ListItem>
                                            <asp:ListItem Value="3">Level 3 – Within 3 hours, no physical danger, work has been</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>
                                        <div style="display: none">
                                            <asp:TextBox ID="latitude" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="longitude" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Site Name:</label>
                                            <asp:TextBox ID="txtbox_siteName" class="form-control" ToolTip="Site Name" placeholder="Site Name" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_siteName" runat="server" ErrorMessage="Please enter Site Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Description:</label>
                                            <asp:TextBox ID="txtbox_Description" class="form-control" ToolTip="Description"
                                                runat="server" placeholder="Enter detail description of incident along with people who were involve in the incident." TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            <div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbox_Description" runat="server" ErrorMessage="Please enter description" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Action Taken:</label>
                                            <asp:TextBox ID="txtbox_actionTaken" class="form-control" Rows="2" ToolTip="Action Taken" placeholder="Please enter the Action Taken by you regarding the incident" TextMode="MultiLine" runat="server" Display="Dynamic"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Attach Images: (Max 2 Files)</label>
                                            <asp:FileUpload AllowMultiple="true" runat="server" ID="fUploadCtrl" />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fUploadCtrl" ErrorMessage="File Required!" Display="Dynamic" />--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only JPEG, PNG, & TIFF file is allowed!"
                                                ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg|.PNG|.JPG|.GIF|.JPEG)$" ControlToValidate="fUploadCtrl" Display="Dynamic" />
                                        </div>
                                        <asp:Button ID="btnSubmitReport" class="btn btn-primary btn-lg btn-block"
                                            runat="server" Text="Submit" OnClick="btnSubmitReport_Click" />

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



