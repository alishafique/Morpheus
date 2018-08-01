<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmViewTimeSheetFull.aspx.cs" Inherits="Morpheus.Accounts.frmViewTimeSheetFull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Full Timesheets</title>
    <style type="text/css">
        .hidden-field {
            display: none;
        }
    </style>
    <!-- DataTables CSS -->
    <%--   <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

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
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">View TimeSheet of week</h1>
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


                                <br />
                                <div style="margin-left: 33%;">
                                    <asp:Button ID="btnPrevious" Style="float: left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text="<" OnClick="btnPrevious_Click" />
                                    <div style="float: left; text-align: center; padding-left: 5px;">
                                        <asp:Label ID="lblStartWeekDate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div style="padding-left: 5px; padding-right: 5px; float: left; text-align: center;">
                                        <label>-</label>
                                    </div>
                                    <div style="float: left; text-align: center; padding-right: 5px;">
                                        <asp:Label ID="lblEndWeekdate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button ID="bntNext" Style="float: left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text=">" OnClick="bntNext_Click" />
                                </div>
                                <br />
                                <br />

                                <div class="table-responsive">
                                    <label>Filter by client:</label>
                                    <asp:DropDownList ID="dpClients" DataTextField="ClientName" OnSelectedIndexChanged="dpClients_SelectedIndexChanged" AutoPostBack="true" DataValueField="clientId" runat="server"></asp:DropDownList>
                                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" Style="float: right; display: block;" OnClick="btnExportToExcel_Click" runat="server" Text="Export To Excel" />
                                    <br />
                                    <br />
                                    <asp:GridView ID="grdViewShifts" Width="100%" class="table table-striped table-bordered table-hover" ShowFooter="true"
                                        runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewShifts_RowCommand" OnRowDataBound="grdViewShifts_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="RosterID" HeaderText="RosterID">
                                                <ItemStyle CssClass="hidden-field" />
                                                <HeaderStyle CssClass="hidden-field" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="emp_name" HeaderText="Name"></asp:BoundField>
                                            <asp:BoundField DataField="RosterDate" HeaderText="RosterDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                            <asp:BoundField DataField="RosterStartTime" HeaderText="StartTime" />
                                            <asp:BoundField DataField="RosterEndTime" HeaderText="EndTime" />
                                            <asp:TemplateField HeaderText="TotalHours" HeaderStyle-Width="55px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalHours" runat="Server" Text='<%# Eval("TotalHours") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RosterSite" HeaderText="Site" />
                                            <asp:BoundField DataField="ClientName" HeaderText="Client" />
                                            <asp:BoundField DataField="RosterTask" HeaderText="Task">
                                                <ItemStyle CssClass="hidden-field" />
                                                <HeaderStyle CssClass="hidden-field" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RStatus" HeaderText="Status">
                                                <ItemStyle Font-Italic="true" />
                                            </asp:BoundField>
                                        </Columns>

                                    </asp:GridView>



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
