<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubContractorSideMenu.ascx.cs" Inherits="Seguro.Accounts.UserControls.SubContractorSideMenu" %>
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
                            <a href="#"><i class="fa fa-male fa-fw"></i>Employees<span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level">
                                <li><a href="AddEmployeeAccount.aspx"> Add Employee</a></li>
                                <li> <a href="ViewEmployeeList.aspx">View Employees</a> </li>
                            </ul>
                            </li>
                       
                            <!-- /.nav-second-level -->
                   
                        <li><a href="#"><i class="fa fa-wrench fa-fw"></i>Activity<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li> <a href="createActivity.aspx">Create Activity</a> </li>
                                <li><a href="viewActivity.aspx">View Activities</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li><a href="#"><i class="fa fa-sitemap fa-fw"></i>Incident<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <%--<li><a href="#">Report Incident</a> </li>--%>
                                <li><a href="viewEditCompanyIncidentReports.aspx">View Incidents</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li><a href="#"><i class="fa fa-files-o fa-fw"></i>Forms<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="#">View Forms</a> </li>
                                <li><a href="FormBuilder.aspx">Form Builder</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>