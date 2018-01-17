<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Morpheus.Accounts.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
         <%--<table id="tbl"></table>--%>
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       Dashboard</h1>
                     <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                   </div>
                   <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
               </div>

               <div class="col-lg-12">
                   <div class="col-lg-3 col-md-6">
                       <div class="panel panel-green" id="EmployeeCount" runat="server">
                           <div class="panel-heading">
                               <div class="row">
                                   <div class="col-xs-3">
                                       <i class="fa fa-user fa-5x"></i>
                                   </div>
                                   <div class="col-xs-9 text-right">
                                       <div class="huge">
                                           <asp:Label ID="lblEmployeeCount" runat="server" Text=""></asp:Label>
                                       </div>
                                       <div>
                                           Employee(s)
                                       </div>
                                   </div>
                               </div>
                           </div>
                           <a href="#">
                               <div class="panel-footer">
                                   <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                   <div class="clearfix">
                                   </div>
                               </div>
                           </a>
                       </div>
                   </div>
                   <div class="col-lg-3 col-md-6">
                       <div class="panel panel-red" id="incidentReportPanel" runat="server">
                           <div class="panel-heading">
                               <div class="row">
                                   <div class="col-xs-3">
                                       <i class="fa fa-support fa-5x"></i>
                                   </div>
                                   <div class="col-xs-9 text-right">
                                       <div class="huge">
                                           <asp:Label ID="lblIncidentReportCount" runat="server" Text=""></asp:Label>
                                       </div>
                                       <div>Incident Reports</div>
                                   </div>
                               </div>
                           </div>
                           <a href="#">
                               <div class="panel-footer">
                                   <span class="pull-left">View Details</span>
                                   <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                   <div class="clearfix"></div>
                               </div>
                           </a>
                       </div>
                   </div>
                   <div style="float:right;">
                   <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                       <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                       <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                       <OtherMonthDayStyle ForeColor="#999999" />
                       <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                       <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" BorderStyle="None" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                       <TodayDayStyle BackColor="#CCCCCC" />
                   </asp:Calendar>
                       </div>
               </div>
               <!-- /.col-lg-12 -->
           </div>
         </div>
</asp:Content>
