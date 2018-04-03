<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmCreateRoaster.aspx.cs" Inherits="Morpheus.Accounts.frmCreateRoaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </style>
     <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />

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

        <%-- $(document).ready(function () {
             $('#btnCreateRoster').click(function () {
                 var Roster = {};
                 Roster.CreatedByID = '<%= Session["userid"] %>';
                 Roster.AssignedToEomployeeID = $('#txtGender').val();
                 Roster.Salary = $('#txtSalary').val();

                 $.ajax({
                     url: 'EmployeeService.asmx/AddEmployee',
                     method: 'post',
                     data: '{emp: ' + JSON.stringify(employee) + '}',
                     contentType: "application/json; charset=utf-8",
                     success: function () {
                         getAllEmployees();
                     },
                     error: function (err) {
                         alert(err);
                     }
                 });
             });--%>


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
                        Enter Roster's Detail
                    </div>
                   

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                              
                                <div class="form-group">
                                    <asp:Label ID="lblROster" runat="server" Text="" Visible="false"></asp:Label>
                                    <label>Select Employee Name To Create Roster</label>
                                    <asp:TextBox ID="txtSearchEmployeeName" CssClass="form-control" runat="server" style="width:50%;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchEmployeeName" Display="Dynamic" ErrorMessage="Please select Employee"></asp:RequiredFieldValidator>
                                </div>
                                  <div class="form-group">
                                    <label>Select Week of Roster:</label>
                                    <asp:DropDownList ID="DateDropDown" CssClass="form-control" CausesValidation="false" style="width:50%;" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DateDropDown_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                               
                              
                           
                                <table style="width: 100%;" class="table table-striped table-bordered table-hover">
                                     <thead>
                                    <tr>
                                        <th>Select Days</th>
                                        <th>Division/Site</th>
                                        <th>Task</th>
                                        <th class="auto-style2">Start Time</th>
                                        <th>End Time</th>
                                    </tr>
                                </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="dpSelectDay" CssClass="form-control" runat="server" >
                                                  
                                                </asp:DropDownList>
                                                </td>
                                            <td><asp:DropDownList ID="dpSiteMonday" CssClass="form-control" DataTextField="LocationtoName" DataValueField="LocationtoId" runat="server"></asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtTaskMonday" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTaskMonday" Display="Dynamic" ErrorMessage="Enter Task"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:DropDownList ID="dpStartHoursMonday" runat="server"></asp:DropDownList>
                                                <strong><span class="auto-style1">:</span></strong>
                                                <asp:DropDownList ID="dpStartMinutesMonday" runat="server"></asp:DropDownList></td>
                                            <td class="auto-style2">
                                                <asp:DropDownList ID="dpEndHoursMonday" runat="server"></asp:DropDownList>
                                                <strong><span class="auto-style1">:</span></strong>
                                                <asp:DropDownList ID="dpEndMinutesMonday" runat="server"></asp:DropDownList></td>
                                        </tr>
                                    </tbody>
                                </table>


                                <asp:Button ID="btnCreateRoster" class="btn btn-primary" runat="server" Text="Create" OnClick="btnCreateRoster_Click" />
                                <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="UpDate" OnClick="btnUpdate_Click"/>
                                <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" CausesValidation="false" Text="Clear" OnClick="btnCancel_Click" />
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
                       
                           <div style="text-align: center;">
                                    <asp:Button ID="btnPrevious" style="float:left;" class="btn btn-outline btn-primary btn-xs" runat="server" Text="Prev" OnClick="btnPrevious_Click" />
                                    <div style="float: left;text-align: center; padding-left:5px;">
                                        <asp:Label ID="lblStartWeekDate" runat="server" Text=""></asp:Label></div>
                                    <div style="padding-left: 5px; padding-right:5px; float: left;text-align: center;">
                                        <label>-</label>
                                    </div>
                                    <div style="float: left;text-align: center; padding-right:5px;">
                                        <asp:Label ID="lblEndWeekdate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button ID="bntNext" style="float:left;" class="btn btn-outline btn-primary btn-xs" runat="server" Text="Next" OnClick="bntNext_Click"/>
                                    <br />
                                    
                                    
                                </div>
                    </div>

                   
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnAll" CausesValidation="false" CssClass="btn btn-primary"  runat="server" Text="All" OnClick="btnAll_Click" />
                                <asp:Button ID="btnMon" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Monday" />
                                <asp:Button ID="btnTue" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Tuesday" />
                                <asp:Button ID="btnWed" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Wednesday" />
                                <asp:Button ID="btnThur" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Thursday" />
                                <asp:Button ID="btnFri" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Friday" />
                                <asp:Button ID="btnSat" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Saturday" />
                                <asp:Button ID="btnSun" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Sunday" />
                                <br />
                                <br />
                                <asp:GridView ID="grdViewShifts" Width="100%" class="table table-striped table-bordered table-hover"
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
                                        <asp:BoundField DataField="RosterSite" HeaderText="Site" />
                                        <asp:BoundField DataField="RosterTask" HeaderText="Task" />

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
