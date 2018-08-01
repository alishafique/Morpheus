<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmViewTimeSheet.aspx.cs" Inherits="Morpheus.Accounts.frmViewTimeSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Timesheets</title>
     <style type="text/css">
        .hidden-field {
            display: none;
        }
         .auto-style1 {
             width: 674px;
         }
         .auto-style2 {
             width: 267px;
         }
    </style>
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
            $(".table1").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                responsive: true
            });
        });

       
        function FetchData(button) {
            var row = button.parentNode.parentNode;
            var label = GetChildControl(row, "txtQuantity").value;
            var label1 = GetChildControl(row, "txtprice").value;
            var Multi = parseFloat(label) * parseFloat(label1);

            GetChildControl(row, "lblTotal").value = Multi;

            return false;
        };

        function GetChildControl(element, id) {
            var child_elements = element.getElementsByTagName("*");
            for (var i = 0; i < child_elements.length; i++) {
                if (child_elements[i].id.indexOf(id) != -1) {
                    return child_elements[i];
                }
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        View Employee's TimeSheet</h1>
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
                           View TimeSheet of Employees
                    </div>

                   
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:GridView ID="dtgridview_Employees" Width="100%" class="table1 table table-striped table-bordered table-hover"
                               runat="server" FooterStyle-BackColor="#FF3399" AutoGenerateColumns="False"  OnRowCommand="dtgridview_Employees_RowCommand" OnRowDataBound="dtgridview_Employees_RowDataBound"
                               OnRowDeleting="dtgridview_Employees_RowDeleting" >
                               <Columns>
                                   <asp:BoundField DataField="EmployeeId" HeaderText="Emp Id" Visible="true">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="UserId" HeaderText="UserId" Visible="true">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField AccessibleHeaderText="Name" DataField="Name" HeaderText="Name" />
                                   <asp:BoundField DataField="email" HeaderText="Email">
                                   </asp:BoundField>
                                   <asp:BoundField DataField="mobile" HeaderText="Phone No."/>

                           
                                   <asp:TemplateField HeaderText="View">
                                       <ItemTemplate>
                                           <asp:LinkButton runat="server" ID="lbView" Text="TimeSheet" CommandName="TimeSheet" CausesValidation="false" CommandArgument='<%# Eval("EmployeeId") %>'></asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>                                         
                               </Columns>
                               
                               <PagerSettings />
                               <PagerStyle HorizontalAlign="Left" CssClass="dataTables_paginate paging_simple_numbers" />
                               <FooterStyle BackColor="#FF3399"></FooterStyle>
                           </asp:GridView>

                                <br />
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
                               
                                <div class="table-responsive">
                                    <label>Filter by client:</label> <asp:DropDownList ID="dpClients" DataTextField="ClientName" OnSelectedIndexChanged="dpClients_SelectedIndexChanged" DataValueField="clientId" runat="server"></asp:DropDownList>
                                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" style="float:right; display:none;" OnClick="btnExportToExcel_Click" runat="server" Text="Export To Excel" />
                                    <br />
                                    <br />
                                <asp:GridView ID="grdViewShifts" Width="100%" class="table table-striped table-bordered table-hover" ShowFooter="true"
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
                           
                                        <asp:TemplateField HeaderText="TotalHours" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                               <asp:Label ID="lblTotalHours" runat="Server" Text='<%# Eval("TotalHours") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pay/Hour" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPayAmount"  Width="46px" CausesValidation="false" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Pay" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                               <asp:Label ID="lblTotalPay" runat="Server" Text="0" ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RosterSite" HeaderText="Site" />
                                        <asp:BoundField DataField="ClientName" HeaderText="Client" />
                                        <asp:BoundField DataField="RosterTask" HeaderText="Task" >
                                            <ItemStyle CssClass="hidden-field" />
                                            <HeaderStyle CssClass="hidden-field" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RStatus" HeaderText="Status" >
                                            <ItemStyle Font-Italic="true" />
                                            </asp:BoundField>                                      
                                    </Columns>

                                </asp:GridView>
                                    <asp:Button ID="btnSendRosterEmail" runat="server" CssClass="btn btn-primary" Text="Send Roster Email" OnClick="btnSendRosterEmail_Click" />
                               
                                 <%--   <table style="width: 135px; float: right;">
                                        <tr>
                                            <td>
                                                <label>Total Hours:</label></td>
                                            <td>
                                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>

                                    </table>--%>
                                </div>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        

      
            <!-- /.row -->
            <!-- /#page-wrapper -->
        </div>
</asp:Content>
