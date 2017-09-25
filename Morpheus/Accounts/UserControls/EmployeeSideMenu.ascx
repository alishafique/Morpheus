<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSideMenu.ascx.cs" Inherits="Morpheus.Accounts.UserControls.EmployeeSideMenu" %>
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
                            <a href="/Accounts/dashboard.aspx" ><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
                        </li>
                        <li>
                            <a href=""><i class="fa fa-bar-chart-o fa-fw"></i>Activity<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li> <asp:LinkButton ID="LinkButton_StartActivity" runat="server">Start Activity</asp:LinkButton> </li>
                                <li> <asp:LinkButton ID="LinkButton_ViewActivity" runat="server" OnClick="LinkButton_ViewActivity_Click">View Activity</asp:LinkButton> </li>
                            </ul>
                        </li>
                            <!-- /.nav-second-level -->
                   
                        <li><a href="viewEmployees.aspx"><i class="fa fa-wrench fa-fw"></i>Profile</a>
                            <!-- /.nav-second-level -->
                        </li>
                        <li><a href="#"><i class="fa fa-sitemap fa-fw"></i>Incident<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li> 
                                    <asp:LinkButton ID="LinkButton_ReportIncident" runat="server" 
                                        onclick="LinkButton_ReportIncident_Click" CausesValidation="false">Report Incident</asp:LinkButton></li>
                                <li><a href="ViewIncidentReports.aspx">View Incidents</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>