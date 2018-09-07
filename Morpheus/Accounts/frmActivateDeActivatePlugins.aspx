<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmActivateDeActivatePlugins.aspx.cs" Inherits="Seguro.Accounts.frmActivateDeActivatePlugins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden-field {
            display: none;
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
                <h1 class="page-header">Manage Plugins</h1>
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
            <!-- /.panel -->
            <div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Manage Plugins
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="dtgridview_companies" Width="100%" class="table table-striped table-bordered table-hover"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="dtgridview_companies_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="CompanyID" HeaderText="Company ID">
                                            <%--  <ItemStyle CssClass="hidden-field" />
                                            <HeaderStyle CssClass="hidden-field" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserID" HeaderText="User ID">
                                            <ItemStyle CssClass="hidden-field" />
                                            <HeaderStyle CssClass="hidden-field" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="subContractor" HeaderText="Sub Contractor" />
                                        <asp:BoundField DataField="activity" HeaderText="Activity" />
                                        <asp:BoundField DataField="incident" HeaderText="Incident Rpt" />
                                        <asp:BoundField DataField="forms" HeaderText="Form Builder" />
                                        <asp:BoundField DataField="roster" HeaderText="Roster" />
                                        <asp:TemplateField HeaderText="Edit Rights">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lblEditRighhts" Text="Edit" CausesValidation="false" CommandName="EDITPLUGIN" CommandArgument='<%# Eval("CompanyID") %>'></asp:LinkButton>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                        
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
                            <!-- /.panel -->
                            <div>

                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">Enable/Disable Company's Plugins</div>
                                            <div class="panel-body">
                                                
                                                    <asp:Label ID="lblCompanyId" runat="server" Text="" Visible="false"></asp:Label>
                                                    <div class="form-group">
                                                        <label>Company Name</label>
                                                        <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Company Email</label>
                                                        <asp:TextBox ID="txtCompanyEmail" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                        <br />
                                                        <label>Please check or uncheck the plugins</label>
                                                        <br />

                                                        <asp:CheckBox ID="chksubContractor" CssClass="checkbox-inline" Text="sub-Contractor" runat="server" />
                                                        <asp:CheckBox ID="chkactivity" CssClass="checkbox-inline" Text="Activity" runat="server" />
                                                        <asp:CheckBox ID="chkincident" CssClass="checkbox-inline" Text="Incident Reports" runat="server" />
                                                        <asp:CheckBox ID="chkforms" CssClass="checkbox-inline" Text="Form Builder" runat="server" />
                                                        <asp:CheckBox ID="chkroster" CssClass="checkbox-inline" Text="Roster System" runat="server" />
                                                        <br />
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
                                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" />
                                                    </div>
                                                <!-- /.row (nested) -->
                                            </div>
                                            <!-- /.panel-bodygg -->
                                        </div>
                                        <!-- /.panel -->
                                    </div>
                                    <!-- /.col-lg-12 -->
                                </div>
                            </div>
                        </div>
        <!-- /#page-wrapper -->
    </div>
</asp:Content>
