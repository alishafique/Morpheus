<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Morpheus.Accounts.AdminDashboard" %>

<%@ Register Assembly="Infragistics4.Web.jQuery.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">  
          function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=impPrev.ClientID%>').prop('src', e.target.result)
                        .width(240);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>  --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="page-wrapper">
         <%--<table id="tbl"></table>--%>
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       <asp:Label ID="lblDashmsg" runat="server" Text=""></asp:Label> Dashboard</h1>
                     <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                   </div>
                   <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
               </div>
               
                <%-- <div style="float:right;">
                <asp:Image ID="impPrev" runat="server" Height="150px" />
            <asp:FileUpload ID="fUpLogo" runat="server" class="uploadFile form-group" onchange="ShowImagePreview(this);"  placeholder="Choose Logo" />  
            <asp:Button ID="btnUploadLogo" runat="server" CssClass="btn btn-primary btn-xs" Text="Upload" OnClick="btnUploadLogo_Click"></asp:Button>
             <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </div>--%>
               <div class="col-lg-12">
                   <div class="col-lg-3 col-md-6">
                       <div class="panel panel-green" id="EmployeeCount" runat="server">
                           <div class="panel-heading">
                               <div class="row">
                                   <div class="col-xs-3">
                                       <i class="fa fa-male fa-5x"></i>
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
                           <a href="ViewEmployeeList.aspx">
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
                                       <i class="fa fa-ambulance fa-5x"></i>
                                   </div>
                                   <div class="col-xs-9 text-right">
                                       <div class="huge">
                                           <asp:Label ID="lblIncidentReportCount" runat="server" Text=""></asp:Label>
                                       </div>
                                       <div>Incident Reports</div>
                                   </div>
                               </div>
                           </div>
                           <a href="viewEditCompanyIncidentReports.aspx">
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
