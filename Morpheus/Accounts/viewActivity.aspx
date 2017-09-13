<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewActivity.aspx.cs" Inherits="Morpheus.Accounts.viewActivity" %>
<%@ Register src="~/Accounts/UserControls/SideNavigationMenu.ascx" tagname="DashboardSideMenu" tagprefix="uc1" %>
<%@ Register Src="~/Accounts/UserControls/compnaySideMenuControl.ascx" TagName="companySideMenu" TagPrefix="uc2" %>
<%@ Register src="~/Accounts/UserControls/rightTopMenu.ascx" TagName="rightTopMenu" TagPrefix="uc3" %>
<%@ Register src="~/Accounts/UserControls/EmployeeSideMenu.ascx" TagName="employeeDashMenu" TagPrefix="uc4" %>

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
    <style type="text/css">
      .hidden-field {
            display: none;
        }
    </style>
      <!-- DataTables CSS -->
    <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="datatables-responsive/dataTables.responsive.css" rel="stylesheet" />

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
                       View/Edit Activity</h1>
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
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           List of Activities
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                           
                           <asp:GridView ID="dtgridview_viewActivity" class="table table-striped table-bordered table-hover"
                               runat="server" AutoGenerateColumns="False" Width="100%"
                               OnSelectedIndexChanged="dtgridview_viewActivity_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_viewActivity_SelectedIndexChanging"
                               AutoGenerateSelectButton="True" AllowPaging="false">
                               <Columns>
                                   <asp:BoundField  DataField="ActivityID" HeaderText="Activity ID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="user_name" HeaderText="Assigned To" />
                                   <asp:BoundField  DataField="Activity_Name" HeaderText="Name"/>
                                   <asp:BoundField  DataField="Activity_Location" HeaderText="Site"/>
                                   <asp:BoundField  DataField="Activity_Type" HeaderText="Type"/>
                                   <asp:BoundField  DataField="Activity_Description" HeaderText="Description"/>
                                   <asp:BoundField  DataField="Activity_Status" HeaderText="Status"/>
                               </Columns>
                               <PagerSettings /><PagerStyle HorizontalAlign = "Right" CssClass = "dataTables_paginate paging_simple_numbers" />
                               <FooterStyle BackColor="#FF3399"></FooterStyle>
                           </asp:GridView>
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                <div class="col-lg-6">
                           <div class="panel panel-default">
                               <div class="panel-heading">
                                   Edit Activity details</div>
                               <div class="panel-body">
                                   <div class="row">
                                       <div style="width: 98%; padding: 0px 0px 0px 20px; float: left;">
                                           <asp:TextBox ID="textbox_activityID" runat="server" Visible="false"></asp:TextBox>
                                           <div class="form-group">
                                               <label>Activity Created By:</label>
                                               <asp:TextBox class="form-control" ID="textbox_createdBy" ReadOnly="true" ToolTip="created by" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group">
                                               <label>
                                                   Activity Name:</label>
                                               <asp:TextBox class="form-control" ID="txtbox_ActivityName" runat="server" ToolTip="Activity Name"
                                                   placeholder="Activity Name"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_ActivityName" Display="Dynamic" runat="server" ErrorMessage="Please enter Name of Activity!!"></asp:RequiredFieldValidator>
                                           </div>
                                           
                                           <div class="form-group">
                                               <label>Site</label>
                                               <asp:TextBox class="form-control" ID="TextBox_site" runat="server" ToolTip="Activity Site"
                                                   placeholder="Activity Site"></asp:TextBox>
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
                                               <asp:DropDownList class="form-control" ID="Dp_AssignTo" runat="server" >
                                                   <asp:ListItem Text="--Select Employee to Assign--" Value="0" />
                                               </asp:DropDownList>

                                           </div>
                                           <div class="form-group">
                                               <label>Status:</label>
                                               <asp:TextBox class="form-control" ID="textbox_Status" placeholder="Status" ToolTip="Status" runat="server"></asp:TextBox>
                                           </div>
                                           <asp:Button ID="btnUpdateActivity" type="submit" class="btn btn-primary btn-lg btn-block"
                                               runat="server" Text="Update" OnClick="btnUpdateActivity_Click" />
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

               </div>
               <!-- /.col-lg-12 -->
           </div>
          
           <!-- /#page-wrapper -->
       </div>
   </div>
    </form>
</body>
</html>