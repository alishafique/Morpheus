<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideNavigationMenu.ascx.cs" Inherits="Morpheus.Accounts.UserControls.SideNavigationMenu" %>
<div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <ul class="nav" id="side-menu">
                        <li class="sidebar-search">
                            <div class="input-group custom-search-form">
                                <input type="text" class="form-control" placeholder="Search...">
                                <span class="input-group-btn">
                                <button class="btn btn-default" type="button">
                                    <i class="fa fa-search"></i>
                                </button>
                            </span>
                            </div>
                            <!-- /input-group -->
                        </li>
                        <li>
                            <a href="/Accounts/dashboard.aspx"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
                        </li>
                        <li>
                            <a href=""><i class="fa fa-bar-chart-o fa-fw"></i>Company<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <asp:LinkButton ID="LinkButton_ActivateCompany" runat="server" 
                                        onclick="LinkButton_ActivateCompany_Click" CausesValidation="false">Activate Company</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkBtn_VeiwCompany" runat="server" OnClick="lnkBtn_VeiwCompany_Click"
                                        CausesValidation="false">View Companies</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkbtn_Addcompany" runat="server" OnClick="lnkbtn_Addcompany_Click"
                                        CausesValidation="false">Add Company</asp:LinkButton></li>
                            </ul>
                            </li>
                            <!-- /.nav-second-level -->
                   
                        <li><a href="#"><i class="fa fa-bullhorn fa-fw"></i>Activity<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="#">Create Activity</a> </li>
                                <li><a href="#">View Activities</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                       
                     <li><a href="#"><i class="fa fa-comments fa-fw"></i>Messages<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="frmViewMessages.aspx">View Messages</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li><a href="#"><i class="fa fa-files-o fa-fw"></i>Forms<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="#">View Forms</a> </li>
                                <li><a href="#">Form Builder</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                         <li><a href="#"><i class="fa fa-wrench fa-fw"></i>Settings<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="addUpdateNews.aspx">Add/Update News</a> </li>
                                <li><a href="frmManageCompanyTypes.aspx">Manage Company types</a> </li>
                                <li><a href="frmManageincidentReportTypes.aspx">Manage Incidents types</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>