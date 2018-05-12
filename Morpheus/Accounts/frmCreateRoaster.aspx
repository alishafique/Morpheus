<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmCreateRoaster.aspx.cs" Inherits="Morpheus.Accounts.frmCreateRoaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Roster</title>
    <style type="text/css">
        .dpControl
        {
            width:45%; 
            float:left;
        }
        .auto-style1 {
            font-size: large;
        }
        .auto-style2 {
            width: 178px;
        }
        .hidden-field {
            display: none;
        }
        .myStyle{
             margin: 0 auto;
        }
    </style>
     <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />

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

    <script type="text/javascript" language="javascript">
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
                        Create/Manage Roster</h1>
                     <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                   </div>
                   <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
                    <div class="alert alert-warning alert-dismissable" id="AlertDiv" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblAlert" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
                </div>
                <!-- /.col-lg-12 -->
                
            </div>
            <!-- /.row -->
            <!-- /.row -->
            <!----/    ------>
       
        <div class="row">
           
            <div class="col-lg-12" >
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Roster's Detail                     
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                              <asp:Label ID="lblROster" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="col-lg-6">
                                <div class="form-group">
                                    
                                    <label>Select Employee Name:</label>
                                    <asp:TextBox ID="txtSearchEmployeeName" CssClass="form-control" placeholder="Type Employee's Name to search" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchEmployeeName" Display="Dynamic" ErrorMessage="Please select Employee"></asp:RequiredFieldValidator>
                                </div>
                                  <div class="form-group">
                                    <label>Select Week of Roster:</label>
                                    <asp:DropDownList ID="DateDropDown" CssClass="form-control" CausesValidation="false" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DateDropDown_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                              
                              <div class="form-group">
                                  <label>Select day(s):</label> <br />
                                  <asp:CheckBox ID="chkMon" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkTue" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkWed" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkThu" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkFri" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkSat" CssClass="checkbox-inline" runat="server" />
                                  <asp:CheckBox ID="chkSun" CssClass="checkbox-inline" runat="server" />
                              </div>
                                 </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Select Division/Site</label>
                                        <asp:DropDownList ID="dpSiteMonday" CssClass="form-control" DataTextField="LocationtoName" DataValueField="LocationtoId" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Enter Task</label>
                                        <asp:TextBox ID="txtTaskMonday" CssClass="form-control" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTaskMonday" Display="Dynamic" ErrorMessage="Enter Task"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Start Time</label>
                                        <asp:DropDownList ID="dpStartHoursMonday" runat="server"></asp:DropDownList>
                                        <strong><span class="auto-style1">:</span></strong>
                                        <asp:DropDownList ID="dpStartMinutesMonday" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>End Time</label>
                                        <asp:DropDownList ID="dpEndHoursMonday" runat="server"></asp:DropDownList>
                                        <strong><span class="auto-style1">:</span></strong>
                                        <asp:DropDownList ID="dpEndMinutesMonday" runat="server"></asp:DropDownList>
                                    </div>
                                    <br/>
                                </div>
                              
                                <asp:Button ID="btnCreateRoster" class="btn btn-primary" runat="server" Text="Create" OnClick="btnCreateRoster_Click" />
                                <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="UpDate" OnClick="btnUpdate_Click"/>
                                <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" CausesValidation="false" Text="Clear" OnClick="btnCancel_Click" />
                               
                            </div>

                            <div class="col-lg-3">

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
                           View/Edit Roster Shifts
                    </div>

                   
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                   <div style="margin-left: 33%;">
                                    <asp:Button ID="btnPrevious" style="float:left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text="<" OnClick="btnPrevious_Click" />
                                    <div style="float: left;text-align: center; padding-left:5px;">
                                        <asp:Label ID="lblStartWeekDate" runat="server" Text=""></asp:Label></div>
                                    <div style="padding-left: 5px; padding-right:5px; float: left;text-align: center;">
                                        <label>-</label>
                                    </div>
                                    <div style="float: left;text-align: center; padding-right:5px;">
                                        <asp:Label ID="lblEndWeekdate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button ID="bntNext" style="float:left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text=">" OnClick="bntNext_Click"/>                                  
                                </div>
                                <br />
                                <br />
                                <asp:Button ID="btnAll" CausesValidation="false" CssClass="btn btn-primary"  runat="server" Text="All" OnClick="btnAll_Click" />
                                <asp:Button ID="btnMon" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Monday" OnClick="btnMon_Click" />
                                <asp:Button ID="btnTue" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Tuesday" OnClick="btnTue_Click" />
                                <asp:Button ID="btnWed" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Wednesday" OnClick="btnWed_Click" />
                                <asp:Button ID="btnThur" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Thursday" OnClick="btnThur_Click"/>
                                <asp:Button ID="btnFri" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Friday" OnClick="btnFri_Click"/>
                                <asp:Button ID="btnSat" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Saturday" OnClick="btnSat_Click"/>
                                <asp:Button ID="btnSun" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Sunday" OnClick="btnSun_Click"/>
                                <br />
                                <br />
                                <asp:GridView ID="grdViewShifts" Width="100%" class="table table-striped table-bordered table-hover" AllowPaging="false"
                                     runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewShifts_RowCommand" OnRowDataBound="grdViewShifts_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RosterID" HeaderText="RosterID">
                                            <ItemStyle CssClass="hidden-field" />
                                            <HeaderStyle CssClass="hidden-field" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="emp_name" HeaderText="Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RosterDate" HeaderText="RosterDate" DataFormatString="{0:dd/MMM/yyyy}"/>
                                        <asp:BoundField DataField="RosterStartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="RosterEndTime" HeaderText="EndTime" />
                                        <asp:BoundField DataField="TotalHours" HeaderText="TotalHours" DataFormatString="" />
                                        <asp:BoundField DataField="RosterSite" HeaderText="Site" />
                                        <asp:BoundField DataField="RosterTask" HeaderText="Task" />
                                        <asp:BoundField DataField="RStatus" HeaderText="Status" >
                                            <ItemStyle Font-Italic="true" />
                                            </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="EditRow" CausesValidation="false" CommandArgument='<%# Eval("RosterID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CausesValidation="false" CommandName="DeleteRow" CommandArgument='<%# Eval("RosterID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <div class="form-group" style="margin-left:35%" >
                                   <label>Total Hours:</label>
                                    <asp:Label ID="lblTotal" runat="server" CssClass="myStyle" Font-Bold="true" Font-Italic="true" Text=""></asp:Label>
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
        

      
            <!-- /.row -->
            <!-- /#page-wrapper -->
        </div>

</asp:Content>
