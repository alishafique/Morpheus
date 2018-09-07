<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmManageCompanyTypes.aspx.cs" Inherits="Seguro.Accounts.frmManageCompanyTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Company's Types</title>
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
                        <h1 class="page-header">Manage Company Types</h1>
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
                                        View Company Types
                                    </div>
                                    <div class="panel-body">
                                        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" GridLines="none"  class="table table-striped table-bordered table-hover"
                                            OnRowCommand="gvMaster_RowCommand" OnRowDataBound="gvMaster_RowDataBound"
                                            OnRowDeleting="gvMaster_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="company_Type_id" HeaderText="company_Type_id">
                                                    <ItemStyle CssClass="hidden-field" />
                                                    <HeaderStyle CssClass="hidden-field" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="type_name" HeaderText="Type Name">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="description" HeaderText="description">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="EditRow" CausesValidation="false" CommandArgument='<%# Eval("company_Type_id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CausesValidation="false" CommandName="Delete" CommandArgument='<%# Eval("company_Type_id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
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
                                    <div class="panel-heading">
                                        Add Company type
                                    </div>
                                    <div class="panel-body">
                                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                                        <div class="form-group">
                                            <label>Company Type:</label>
                                            <asp:TextBox class="form-control" ID="txtName" ToolTip="Enter Site/location Name"  runat="server"></asp:TextBox>                                    
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Display="Dynamic"
                                                ErrorMessage="*" Font-Bold="True" Font-Size="Small">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                             <label>Description:</label>
                                            <asp:TextBox class="form-control" ID="txtDesc" ToolTip="Enter description"  runat="server"></asp:TextBox>
                                        </div>
                                     
                                        <asp:Button ID="btnAddLocation" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />

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

        

                <!-- /#page-wrapper -->
            </div>
</asp:Content>
