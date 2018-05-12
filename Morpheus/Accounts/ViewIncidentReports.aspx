<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewIncidentReports.aspx.cs" Inherits="Morpheus.Accounts.viewIncidentReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Incident Reports</title>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">View/Edit Reports</h1>
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

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default" runat="server" id="hideGrid">
                    <div class="panel-heading">
                        List of Reports
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">

                        <asp:GridView ID="dtgridview_IncidentReports" class="table table-striped table-bordered table-hover" Width="100%"
                            runat="server" AutoGenerateColumns="False"
                            OnSelectedIndexChanged="dtgridview_IncidentReports_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_IncidentReports_SelectedIndexChanging"
                            AutoGenerateSelectButton="True" AllowPaging="false" OnPageIndexChanging="dtgridview_IncidentReports_PageIndexChanging" OnRowDeleting="dtgridview_IncidentReports_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Report Id" Visible="true">
                                  <%--  <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />--%>
                                </asp:BoundField>
                                <asp:BoundField DataField="reportedBy" HeaderText="reportedBy" Visible="true">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField AccessibleHeaderText="reportedTo" DataField="reportedTo" HeaderText="reportedTo">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="severitylevel" HeaderText="Severity Level">
                                    <%-- <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />--%>
                                </asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Description">
                                      <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                                <asp:BoundField DataField="dateTime" HeaderText="Date Time" />
                                <asp:BoundField DataField="location" HeaderText="Location" />
                                <asp:BoundField DataField="actionTaken" HeaderText="Action Taken">
                                      <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                            
                            </Columns>

          
                        </asp:GridView>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Edit details of Report.</div>
                            <div class="panel-body">

                                <div class="row" style="padding: 0 15px 15px 15px">
                                    <div style="width: 100%; display: none;">
                                        <div class="form-group" style="width: 50%; float: left; padding-right: 10px;">
                                            <label>Report Id:</label>
                                            <asp:TextBox ID="TextBox_ReportId" class="form-control" ToolTip="ReportId" ReadOnly="true" placeholder="ReportId" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 50%; float: left;">
                                            <label>reportedBy:</label>
                                            <asp:TextBox ID="TextBox_reportedBy" class="form-control" ToolTip="reportedBy" ReadOnly="true" placeholder="reportedBy" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox_reportedTo" class="form-control" ToolTip="reportedTo" ReadOnly="true" placeholder="reportedTo" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label>Severity level:</label>
                                        <asp:DropDownList class="form-control" ID="dp_severityLevel" runat="server">
                                            <asp:ListItem Value="1">Level 1 - Immediate response, threat of injury or death</asp:ListItem>
                                            <asp:ListItem Value="2">Level 2 – Within 1 hour, no physical danger, work has ceased</asp:ListItem>
                                            <asp:ListItem Value="3">Level 3 – Within 3 hours, no physical danger, work has been</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Site Name:</label>
                                        <asp:TextBox ID="txtbox_siteName" class="form-control" ToolTip="Site Name" placeholder="Site Name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_siteName" runat="server" ErrorMessage="Please enter Site Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Description:</label>
                                        <asp:TextBox ID="txtbox_Description" class="form-control" ToolTip="Description"
                                            runat="server" placeholder="Enter detail description of incident along with people who were involve in the incident." TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        <div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbox_Description" runat="server" ErrorMessage="Please enter description" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Action Taken:</label>
                                        <asp:TextBox ID="txtbox_actionTaken" class="form-control" Rows="2" ToolTip="Action Taken" placeholder="Please enter the Action Taken by you regarding the incident" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>

                                    <asp:Button ID="btnUpdateReport" type="Update" class="btn btn-primary btn-lg btn-block"
                                        runat="server" Text="Update" OnClick="btnUpdateReport_Click" />

                                    
                                    <div class="form-group" style="margin-top:15px;">
                                        <asp:Panel ID="pnlDisplayImage" runat="server"></asp:Panel>
                                        <%--<asp:Image ID="Image2" runat="server" Width="484px" />--%>
                                    </div>
                                </div>
                                <!-- /.row (nested) -->
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
            </div>
        </div>

    </div>
</asp:Content>
