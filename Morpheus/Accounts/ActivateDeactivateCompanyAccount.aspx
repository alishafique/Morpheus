<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateDeactivateCompanyAccount.aspx.cs" Inherits="Morpheus.Accounts.ActivateDeactivateCompanyAccount" %>

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
    <title>Activate and De-Activate Company's Account</title>

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
                       Activate/Deactivate Company's Account</h1>
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
                           List of Companies
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                          
                           <asp:GridView ID="dtgridview_companies" class="table table-striped table-bordered table-hover"
                               runat="server" FooterStyle-BackColor="#FF3399" AutoGenerateColumns="False"
                               OnSelectedIndexChanged="dtgridview_companies_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_companies_SelectedIndexChanging"
                               AutoGenerateSelectButton="True" >
                               <Columns>
                                   <asp:BoundField DataField="CompanyID" HeaderText="CompanyID">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>

                                   <asp:BoundField DataField="UserID" HeaderText="UserID">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="CompanyName" HeaderText="CompanyName"/>
                                   <asp:BoundField  DataField="Email" HeaderText="Email"/>
                                   <asp:BoundField  DataField="MemberShip" HeaderText="MemberShip"/>
                                   <asp:BoundField  DataField="Type" HeaderText="Type"/>
                                   <asp:BoundField  DataField="Status" HeaderText="Status" >
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="active_status1" HeaderText="Status" />
                               </Columns>
                           </asp:GridView>
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                <div class="col-lg-6" id="myDiv">
                    <div class="panel panel-default">
                        <div class="panel-heading">Edit Company</div>
                        <div class="panel-body">
                            <div class="row">
                                <div style = " width: 98%; padding: 0px 0px 0px 20px; float:left;">
                                  
                                    <div class="form-group" style=" display:none;">
                                        <div style="width: 50%; float: left; padding-right: 10px;">
                                            <label>
                                                UserId:</label>
                                            <asp:TextBox ID="txtbox_UserId" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                        </div>
                                        <div style="width: 50%; float: left;">
                                            <label>
                                                CompanyId:</label>
                                            <asp:TextBox ID="txtbox_CompanyID" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Company Name:</label>
                                        <asp:TextBox class="form-control" ID="txtbox_CompanyName" runat="server" ReadOnly="true" ToolTip="Comapany Name"
                                            placeholder="Comapany Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                            <ContentTemplate>
                                                <label>
                                                    Email/Username:</label>
                                                <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_CompanyEmail" runat="server"
                                                    OnChange="CheckUserName(this)" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
                                                    ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                                <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Status</label>
                                        <asp:DropDownList class="form-control" ID="dp_CompanyAccountStatus" runat="server" >
                                            <asp:ListItem Value="0">De-Active</asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <asp:Button ID="btnUpdateCompanyDetails" type="submit" 
                                        class="btn btn-primary btn-lg btn-block" runat="server"
                                        Text="Update" onclick="btnUpdateCompanyDetails_Click" />
                                    
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
