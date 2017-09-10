<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewEmployees.aspx.cs" Inherits="Morpheus.Accounts.viewEmployees" %>

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
     <style type="text/css">
      .hidden-field {
            display: none;
        }
    </style>

    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.16/css/jquery.dataTables.css" />
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.16/js/jquery.dataTables.js"></script>

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
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
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
                       View/Edit Employee's Profile</h1>
                   
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
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                         
                           <asp:GridView ID="dtgridview_Employees" class="table table-striped table-bordered table-hover"
                               runat="server" FooterStyle-BackColor="#FF3399" AutoGenerateColumns="False"
                               OnSelectedIndexChanged="dtgridview_Employees_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_Employees_SelectedIndexChanging"
                               AutoGenerateSelectButton="True" OnRowDeleting="dtgridview_Employees_RowDeleting" >
                               <Columns>
                                   <asp:BoundField DataField="EmployeeId" HeaderText="Emp Id" Visible="true">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="UserId" HeaderText="UserId" Visible="true">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField AccessibleHeaderText="Name" DataField="Name" HeaderText="Name" />
                                   <asp:BoundField DataField="email" HeaderText="email">
                                   </asp:BoundField>
                                   <asp:BoundField DataField="created_dateTime" HeaderText="Created dateTime" />
                                   <asp:BoundField DataField="date_of_birth" HeaderText="Date of birth" DataFormatString="{0:dd/MM/yyyy}" ></asp:BoundField>
                                   <asp:BoundField DataField="ABN" HeaderText="ABN" />
                                   <asp:BoundField DataField="TFN" HeaderText="TFN" />
                                   <asp:BoundField DataField="active_status" HeaderText="Status" />
                                   <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />--%>
                                         
                               </Columns>
                               
                               <PagerSettings />
                               <PagerStyle HorizontalAlign="Left" CssClass="dataTables_paginate paging_simple_numbers" />
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
                               <div class="panel-heading">Edit details.</div>
                               <div class="panel-body">
                    
                                   <div class="row" style="padding: 0 15px 15px 15px">
                                       <div style="width: 100%; display:none;">
                                           <div class="form-group" style="width: 50%; float: left; padding-right: 10px;">
                                               <label>Employee Id:</label>
                                               <asp:TextBox ID="TextBox_EmployeeId" class="form-control" ToolTip="Employee Id" ReadOnly="true" placeholder="Employee ID" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group" style="width: 50%; float: left;">
                                               <label>User Id:</label>
                                               <asp:TextBox ID="TextBox_userId" class="form-control" ToolTip="User Id" ReadOnly="true" placeholder="User Id" runat="server"></asp:TextBox>
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

                                           <label>
                                               Date of Birth:</label>
                                           <asp:TextBox class="form-control" ID="txtbox_dateTimePicker_DOB" Style="width: 93%; float: left;" runat="server"
                                               TextMode="DateTime"></asp:TextBox>
                                           <img src="images/calender.png" style="float: left; height: 23px; padding-left: 5px;" />
                                       </div>
                                        <div class="form-group" style="margin-top: 51px;">
                                        <label>Mobile Number:</label>
                                        <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Driving License:</label>
                                        <asp:TextBox ID="TextBox_License" CssClass="form-control" ToolTip="License" placeholder="Driving License" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="form-group" id ="hideEmployee" runat="server">
                                           <label>Active Status</label>
                                           <asp:DropDownList ID="DropDownList_activeStatus" CssClass="form-control" ToolTip="Status" runat="server">
                                               <asp:ListItem Value="0">Not-Active</asp:ListItem>
                                               <asp:ListItem Value="1">Active</asp:ListItem>
                                           </asp:DropDownList>
                                       </div>
                                        <div class="form-group">
                                            <label>Address:</label>
                                            <asp:TextBox ID="TextBox_StreetName" class="form-control" ToolTip="Street Name" placeholder="Street Name" runat="server"></asp:TextBox>
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
                                       <asp:Button ID="btnUpdateEmployeeProfile" type="Update" class="btn btn-primary btn-lg btn-block"
                                           runat="server" Text="Update" OnClick="btnUpdateEmployeeProfile_Click" />
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

