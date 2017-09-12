<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createActivity.aspx.cs" Inherits="Morpheus.createActivity" %>


<%@ Register src="~/Accounts/UserControls/SideNavigationMenu.ascx" tagname="DashboardSideMenu" tagprefix="uc1" %>
<%@ Register Src="~/Accounts/UserControls/compnaySideMenuControl.ascx" TagName="companySideMenu" TagPrefix="uc2" %>
<%@ Register src="~/Accounts/UserControls/rightTopMenu.ascx" TagName="rightTopMenu" TagPrefix="uc3" %>
<%@ Register src="~/Accounts/UserControls/EmployeeSideMenu.ascx" TagName="employeeDashMenu" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>View Company</title>

     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- MetisMenu CSS -->
    <link href="" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet" type="text/css" />

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


    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
       $(document).ready(function () {
           $("#<%=startDateTime.ClientID %>").dynDateTime({
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

          $(document).ready(function () {
           $("#<%=txtfinishDateTime.ClientID %>").dynDateTime({
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
  <style type="text/css">
      .dateTimeDiv
      {
          float: left; margin-left:5px;
      }
      .tablePadding{
          padding-left:5px;
      }
  </style>
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
                       Create Activity</h1>
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
                                   Create Activity</div>
                               <div class="panel-body">

                                   <div class="form-group">
                                       <label>Activity Created By:</label>
                                       <asp:TextBox class="form-control" ID="textbox_createdBy" ReadOnly="true" ToolTip="created by" runat="server"></asp:TextBox>
                                   </div>
                                   <div class="form-group">
                                       <label>
                                           Activity Name:</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                       <asp:TextBox class="form-control" ID="txtbox_ActivityName" runat="server" placeholder="Activity Name" ToolTip="Activity Name"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_ActivityName" Display="Dynamic" runat="server" SetFocusOnError="true" ErrorMessage="Please enter Name of Activity"></asp:RequiredFieldValidator>
                                   </div>
                                   <div class="form-group">
                                       <table style="width: 100%;">
                                           <tr>
                                               <label>Activity Start Date</label><asp:Label ID="Label8" runat="server" Text=" (Time should be in 24-hours format)" Font-Bold="true" ForeColor="lightgray"></asp:Label>
                                           </tr>
                                           <thead>
                                               <tr>
                                                   <th>Date:<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">HH:<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">MM:<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">AM/PM:<asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                               </tr>
                                           </thead>
                                           <tbody>
                                               <tr>
                                                   <td>
                                                       <asp:TextBox class="form-control" ID="startDateTime" placeholder="DD/MM/YYYY" runat="server"
                                                           TextMode="DateTime"></asp:TextBox>
                                                       
                                                   </td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpHours" runat="server">
                                                           <asp:ListItem Value="0">HH</asp:ListItem>
                                                           <asp:ListItem>01</asp:ListItem>
                                                           <asp:ListItem>02</asp:ListItem>
                                                           <asp:ListItem>03</asp:ListItem>
                                                           <asp:ListItem>04</asp:ListItem>
                                                           <asp:ListItem>05</asp:ListItem>
                                                           <asp:ListItem>06</asp:ListItem>
                                                           <asp:ListItem>07</asp:ListItem>
                                                           <asp:ListItem>08</asp:ListItem>
                                                           <asp:ListItem>09</asp:ListItem>
                                                           <asp:ListItem>10</asp:ListItem>
                                                           <asp:ListItem>11</asp:ListItem>
                                                           <asp:ListItem>12</asp:ListItem>
                                                       </asp:DropDownList></td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpMinutes" runat="server"></asp:DropDownList></td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpAMPM" runat="server">
                                                           <asp:ListItem>AM</asp:ListItem>
                                                           <asp:ListItem>PM</asp:ListItem>
                                                       </asp:DropDownList>
                                                       
                                                   </td>
                                               
                                               </tr>
                                           </tbody>
                                       </table>
                                   </div>
                                   <div class="form-group">
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="startDateTime" Display="Dynamic" runat="server" SetFocusOnError="true" ErrorMessage="Please start enter date."></asp:RequiredFieldValidator>
                                       <asp:RequiredFieldValidator  ID="Req_ID"
                                           Display="Dynamic" runat="server"
                                           ControlToValidate="dpHours" SetFocusOnError="true"
                                           InitialValue="0" ErrorMessage="Please select Hours.">
                                       </asp:RequiredFieldValidator>
                                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator3"
                                           Display="Dynamic" runat="server"
                                           ControlToValidate="dpMinutes" SetFocusOnError="true"
                                           InitialValue="MM" ErrorMessage="Please select Minutes.">
                                       </asp:RequiredFieldValidator>
                                       
                                   </div>
                                    <div class="form-group">
                                       <table style="width: 100%;">
                                           <tr>
                                               <label>
                                                   Activity finish date:</label><asp:Label ID="Label4" runat="server" Text=" (Time should be in 24-hours format)" Font-Bold="true" ForeColor="lightgray"></asp:Label>
                                           </tr>
                                           <thead>
                                               <tr>
                                                   <th>Date:<asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">HH:<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">MM:<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                                   <th class="tablePadding">AM/PM:<asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label></th>
                                               </tr>
                                           </thead>
                                           <tbody>
                                               <tr>
                                                   <td>
                                                       <asp:TextBox class="form-control" ID="txtfinishDateTime" placeholder="DD/MM/YYYY" runat="server"
                                                           TextMode="DateTime"></asp:TextBox>
                                                   </td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpHoursFinish" runat="server">
                                                           <asp:ListItem Value="0">HH</asp:ListItem>
                                                           <asp:ListItem>01</asp:ListItem>
                                                           <asp:ListItem>02</asp:ListItem>
                                                           <asp:ListItem>03</asp:ListItem>
                                                           <asp:ListItem>04</asp:ListItem>
                                                           <asp:ListItem>05</asp:ListItem>
                                                           <asp:ListItem>06</asp:ListItem>
                                                           <asp:ListItem>07</asp:ListItem>
                                                           <asp:ListItem>08</asp:ListItem>
                                                           <asp:ListItem>09</asp:ListItem>
                                                           <asp:ListItem>10</asp:ListItem>
                                                           <asp:ListItem>11</asp:ListItem>
                                                           <asp:ListItem>12</asp:ListItem>
                                                       </asp:DropDownList></td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpMinutesFinish" runat="server"></asp:DropDownList></td>
                                                   <td class="tablePadding">
                                                       <asp:DropDownList CssClass="form-control" ID="dpAMPMFinsih" runat="server">
                                                           <asp:ListItem>AM</asp:ListItem>
                                                           <asp:ListItem>PM</asp:ListItem>
                                                       </asp:DropDownList></td>
                                               </tr>
                                           </tbody>
                                       </table>
                                   </div>
                                   <div class="form-group">
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtfinishDateTime" Display="Dynamic" runat="server" SetFocusOnError="true" ErrorMessage="Please start enter date."></asp:RequiredFieldValidator>
                                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator6"
                                           Display="Dynamic" runat="server"
                                           ControlToValidate="dpHoursFinish" SetFocusOnError="true"
                                           InitialValue="0" ErrorMessage="Please select Hours.">
                                       </asp:RequiredFieldValidator>
                                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator7"
                                           Display="Dynamic" runat="server"
                                           ControlToValidate="dpMinutesFinish" SetFocusOnError="true"
                                           InitialValue="MM" ErrorMessage="Please select Minutes.">
                                       </asp:RequiredFieldValidator>
                                       
                                   </div>
                                   <div class="form-group">
                                       <label>Site</label><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                       <asp:TextBox class="form-control" ID="TextBox_site" runat="server" placeholder="Site Name" ToolTip="Activity Site"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox_site" Display="Dynamic" runat="server" ErrorMessage="Please enter Site of Activity!!"></asp:RequiredFieldValidator>
                                   </div>
                                   <div class="form-group">
                                       <label>
                                           Activity Type</label>
                                       <asp:DropDownList class="form-control" ID="dp_ActivityType" runat="server">
                                           <asp:ListItem Value="Plumber">Plumber</asp:ListItem>
                                           <asp:ListItem Value="Electrician">Electrician</asp:ListItem>
                                           <asp:ListItem Value="Plasterer">Plasterer</asp:ListItem>
                                           <asp:ListItem Value="Glazier">Glazier</asp:ListItem>
                                           <asp:ListItem Value="Welder">Welder</asp:ListItem>
                                           <asp:ListItem Value="Mason">Mason</asp:ListItem>
                                       </asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>
                                           Description:</label>
                                       <asp:TextBox ID="TextBox_Description" class="form-control" placeholder="Description" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                   </div>
                                   <div class="form-group">
                                       <label>
                                           Assigned To Employee:</label>
                                       <asp:DropDownList class="form-control" ID="Dp_AssignTo" runat="server">
                                           <asp:ListItem Text="--Select Employee to Assign--" Value="0" />
                                       </asp:DropDownList>
                                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator8"
                                           Display="Dynamic" runat="server"
                                           ControlToValidate="Dp_AssignTo" SetFocusOnError="true"
                                           InitialValue="0" ErrorMessage="Please select Employee to assign Job.">
                                       </asp:RequiredFieldValidator>
                                   </div>
                                   <div class="form-group">
                                       <label>Status:</label>
                                       <asp:TextBox class="form-control" ID="textbox_Status" placeholder="Status" ToolTip="Status" runat="server"></asp:TextBox>
                                   </div>

                                   <asp:Button ID="btnAddActivity" type="submit" class="btn btn-primary btn-lg btn-block"
                                       runat="server" Text="Add" OnClick="btnAddActivity_Click" />

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
   </div>
    </form>
</body>
</html>


