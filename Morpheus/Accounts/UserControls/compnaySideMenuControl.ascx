<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="compnaySideMenuControl.ascx.cs" Inherits="Morpheus.Accounts.UserControls.compnaySideMenuControl" %>
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
                                <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false"> Add Employee</asp:LinkButton></li>
                                <li> <asp:LinkButton ID="LinkButton_ViewEmployees" runat="server" OnClick="LinkButton_ViewEmployees_Click" CausesValidation="false">View Employees</asp:LinkButton> </li>
                            </ul>
                            </li>
                        <li runat="server" id="SubContractorShowhide">
                            <a href="#"><i class="fa fa fa-user fa-fw"></i>Sub-Contractor<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                 <li><a href="AddSubcontractor.aspx">Add Sub-Contractor</a></li>
                                <li><a href="ViewSub-Contractor.aspx">View Sub-Contractor</a></li>
                            </ul>
                        </li>
                            <!-- /.nav-second-level -->
                   
                        <li runat="server" id="ActivityPlugin">
                            <a href="#"><i class="fa fa-wrench fa-fw"></i>Activity<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li> <asp:LinkButton ID="LinkButton_CreateActivity" runat="server" CausesValidation="false" OnClick="LinkButton_CreateActivity_Click">Create Activity</asp:LinkButton> </li>
                                <li><asp:LinkButton ID="LinkButton_ViewActivities" runat="server" CausesValidation="false" OnClick="LinkButton_ViewActivities_Click">View Activities</asp:LinkButton> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li id="IncidentPlugin" runat="server">
                            <a href="#">
                            <i class="fa fa-sitemap fa-fw"></i>Incident<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <%--<li><a href="#">Report Incident</a> </li>--%>
                                <li><a href="viewEditCompanyIncidentReports.aspx">View Incidents</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li id="FormBuilderPlugin" runat="server"><a href="#"><i class="fa fa-files-o fa-fw"></i>Forms<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="#">View Forms</a> </li>
                                <li><a href="EditQuestionairForm.aspx">Form Builder</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li id="RosterPlugin" runat="server"><a href="#"><i class="fa fa-flash fa-fw"></i>Roster<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li><a href="frmManageClient.aspx">Manage Clients</a></li>
                                <li><a href="AddLocationForm.aspx">Manage Location/Site(s)</a></li>
                                <li><a href="frmCreateRoaster.aspx">Manage/Create Roster</a> </li>
                                <li><a href="frmViewTimeSheet.aspx">View Employee's TimeSheets</a> </li>
                                <li><a href="frmViewTimeSheetFull.aspx">View Full TimeSheets</a> </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>