<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmCreateRoaster.aspx.cs" Inherits="Morpheus.Accounts.frmCreateRoaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .dpControl
        {
            width:45%; 
            float:left;
        }
    </style>

     <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript" language="javascript">

         
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

         $(function () {
              $("#<%= txtSearchEmployeeName.ClientID %>").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       url: 'checkEmployeeName.asmx/GetEmployeeName',
                       data: "{'empName': '" + request.term + "' }",
                       dataType: "json",
                       success: function (data) {
                           response(data.d);
                       },
                       error: function (result) {
                           alert("No Match");
                       }
                   });
               },

           });
         });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Create Roster</h1>
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
            <!-- /.row -->
            <!-- /.row -->
            <!----/    ------>

          <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Roster
                    </div>

                    <div class="form-group">
                        <label>Select Employee Name To Create Roster</label>
                        <asp:TextBox ID="txtSearchEmployeeName" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                
                                <div style="text-align: center;">
                                    <asp:Button ID="btnPrevious" style="float:left;" class="btn btn-outline btn-primary btn-xs" runat="server" Text="Prev" />
                                    <div style="float: left;text-align: center; padding-left:5px;">
                                        <asp:Label ID="lblStartWeekDate" runat="server" Text=""></asp:Label></div>
                                    <div style="padding-left: 5px; padding-right:5px; float: left;text-align: center;">
                                        <label>-</label>
                                    </div>
                                    <div style="float: left;text-align: center; padding-right:5px;">
                                        <asp:Label ID="lblEndWeekdate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button ID="bntNext" style="float:left;" class="btn btn-outline btn-primary btn-xs" runat="server" Text="Next" />
                                </div>
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
        <div class="row">


            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Roster's Detail
                    </div>

                   
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                

                                <div class="form-group">
                                    <label>Date & Day:</label>
                                    <asp:TextBox class="form-control" ID="txtbox_dateTimePicker_DOB" runat="server"
                                        TextMode="DateTime"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Division/Site:</label>
                                    <asp:DropDownList ID="dpAddSite" CssClass="form-control" DataTextField="LocationtoName" DataValueField="LocationtoId" runat="server"></asp:DropDownList>
                                    <a href="AddLocationForm.aspx">Add Site</a>
                                </div>
                                <div class="form-group">
                                    <label>Task:</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Start Time:</label>
                                    <div>
                                        <asp:DropDownList ID="dpStartHours" CssClass="form-control dpControl" runat="server"></asp:DropDownList>
                                        <div style="float: left; padding: 5px;">
                                            <label>:</label></div>
                                        <asp:DropDownList ID="dpStartMinutes" CssClass="form-control dpControl" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="form-group">
                                    <label>End Time:</label>
                                    <div>
                                        <asp:DropDownList ID="dpEndHours" CssClass="form-control dpControl" runat="server"></asp:DropDownList>
                                        <div style="float: left; padding: 5px;">
                                            <label>:</label></div>
                                        <asp:DropDownList ID="dpEndMinutes" CssClass="form-control dpControl" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group" style="margin-bottom: 15px;">
                                    <label>Assigned To Employee(s)</label>
                                    <asp:ListBox ID="listEmployees" class="form-control" Height="150px" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </div>
                                <asp:Button ID="btnCreateRoster" class="btn btn-primary btn-lg btn-block" runat="server" Text="Create" />
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

      
            <!-- /.row -->
            <!-- /#page-wrapper -->
        </div>
</asp:Content>
