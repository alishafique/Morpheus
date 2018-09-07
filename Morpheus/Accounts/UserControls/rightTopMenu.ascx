<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rightTopMenu.ascx.cs" Inherits="Seguro.Accounts.UserControls.rightTopMenu" %>
<style type="text/css"> 
    #btnLogOut
    { 
      background-color:#1A0006; 
      color:#fff; 
    } 
    #btnLogOut:hover 
    { 
      background-color:Blue; 
      color:#1A0006; 
    } 
  </style> 
   
  
<ul class="nav navbar-top-links navbar-right" style="float:right;">
                <%--<li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-envelope fa-fw"></i> <i class="fa fa-caret-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-messages">
                        <li>
                            <a href="#">
                                <div>
                                    <strong>John Smith</strong>
                                    <span class="pull-right text-muted">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <strong>John Smith</strong>
                                    <span class="pull-right text-muted">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <strong>John Smith</strong>
                                    <span class="pull-right text-muted">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a class="text-center" href="#">
                                <strong>Read All Messages</strong>
                                <i class="fa fa-angle-right"></i>
                            </a>
                        </li>
                    </ul>
                    <!-- /.dropdown-messages -->
                </li>
                <!-- /.dropdown -->--%>
              
                <!-- /.dropdown -->
                <li class="dropdown" >
                    
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-bell fa-fw"></i> <asp:Label ID="lblNotification" runat="server" Text=""></asp:Label> <i class="fa fa-caret-down"></i>
                        
                    </a>
                    <ul class="dropdown-menu dropdown-alerts" id ="tbl">
                       <%-- <li>
                            <a href="#">
                                <div>
                                    <i class="fa fa-comment fa-fw"></i> New Comment
                                    <span class="pull-right text-muted small">4 minutes ago</span>
                                </div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <i class="fa fa-twitter fa-fw"></i> 3 New Followers
                                    <span class="pull-right text-muted small">12 minutes ago</span>
                                </div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <i class="fa fa-envelope fa-fw"></i> Message Sent
                                    <span class="pull-right text-muted small">4 minutes ago</span>
                                </div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <i class="fa fa-tasks fa-fw"></i> New Task
                                    <span class="pull-right text-muted small">4 minutes ago</span>
                                </div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">
                                <div>
                                    <i class="fa fa-upload fa-fw"></i> Server Rebooted
                                    <span class="pull-right text-muted small">4 minutes ago</span>
                                </div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a class="text-center" href="#">
                                <strong>See All Alerts</strong>
                                <i class="fa fa-angle-right"></i>
                            </a>
                        </li>--%>
                       
                    </ul>
                    <!-- /.dropdown-alerts -->
                </li>
                <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-user">
                        <li>
                            <asp:LinkButton ID="LinkButton_profile"  CausesValidation="false" runat="server" 
                                onclick="LinkButton_Profile_Click"><i class="fa fa-user fa-fw"></i> Profile</asp:LinkButton>
                            <a>
                            <asp:LinkButton ID="LinkButton_EmployeeProfile"  CausesValidation="false" runat="server" 
                                onclick="LinkButton_EmployeeProfile_Click"><i class="fa fa-user fa-fw"></i> Profile</asp:LinkButton></a>
                        </li>
                        <li>
                            <%--<a href="changePassword.aspx"><i class="fa fa-gear fa-fw"></i> Change Password</a>--%>
                            <asp:LinkButton ID="changePassword" CausesValidation="false" runat="server" OnClick="changePassword_Click"><i class="fa fa-gear fa-fw"></i> Change Password</asp:LinkButton>
                        </li>
                        <li class="divider"></li>
                        <li>
                        <asp:LinkButton ID="btnLogOut" runat="server" onClick="btnLogOut_Click"  CausesValidation="false"><i class="fa fa-sign-out fa-fw"></i> Log Out </asp:LinkButton>
                        </li>
                    </ul>
                    <!-- /.dropdown-user -->
                </li>
                <!-- /.dropdown -->
            </ul>