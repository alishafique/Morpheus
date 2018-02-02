<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewEditCompanyIncidentReports.aspx.cs" Inherits="Morpheus.Accounts.viewEditCompanyIncidentReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">      
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
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

    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click',function () {
            HidePopup();
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
                        List of Reports by Employees
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <label>Please select any Report To view the description and Action taken on incident Report.</label>
                        <br />
                        <asp:GridView ID="dtgridview_IncidentReports" class="table table-striped table-bordered table-hover"
                            runat="server"  width="100%" AutoGenerateColumns="False" 
                            OnSelectedIndexChanged="dtgridview_IncidentReports_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_IncidentReports_SelectedIndexChanging"
                            AutoGenerateSelectButton="True" OnRowDeleting="dtgridview_IncidentReports_RowDeleting" OnRowDataBound="dtgridview_IncidentReports_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Report Id" Visible="true">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                    
                                </asp:BoundField>
                                <asp:BoundField AccessibleHeaderText="user_id" DataField="user_id" HeaderText="user_id">
                                    <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_name" HeaderText="Reported By">
                                      
                                </asp:BoundField>
                                <asp:BoundField DataField="severitylevel" HeaderText="severitylevel">
                                    <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                     <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />                    
                                </asp:BoundField>
                                <asp:BoundField DataField="dateTime" HeaderText="DateTime" />
                                <asp:BoundField DataField="location" HeaderText="Location" />
                                <asp:BoundField DataField="actionTaken" HeaderText="ActionTaken">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UpdatedDateTime" HeaderText="Updated DateTime"></asp:BoundField>
                                <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                                <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />--%>
                            </Columns>
                            <PagerSettings />                        
                        </asp:GridView>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>

                 <div class="panel panel-default" runat="server" id="Div1">
                    <div class="panel-heading">
                        List of Reports by Employees Of Sub-Contractors
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <label>Please select any Report To view the description and Action taken on incident Report.</label>
                        <br />
                        <asp:GridView ID="gdIncidentSubcontractor" class="table table-striped table-bordered table-hover"
                            runat="server"  width="100%" AutoGenerateColumns="False" 
                            OnSelectedIndexChanged="gdIncidentSubcontractor_SelectedIndexChanged" OnSelectedIndexChanging="gdIncidentSubcontractor_SelectedIndexChanging"
                            AutoGenerateSelectButton="True" OnRowDataBound="gdIncidentSubcontractor_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Report Id" Visible="true">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                    
                                </asp:BoundField>
                                <asp:BoundField AccessibleHeaderText="user_id" DataField="user_id" HeaderText="user_id">
                                    <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_name" HeaderText="Reported By">
                                      
                                </asp:BoundField>
                                <asp:BoundField DataField="severitylevel" HeaderText="severitylevel">
                                    <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                     <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />                    
                                </asp:BoundField>
                                <asp:BoundField DataField="dateTime" HeaderText="DateTime" />
                                <asp:BoundField DataField="location" HeaderText="Location" />
                                <asp:BoundField DataField="actionTaken" HeaderText="ActionTaken">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UpdatedDateTime" HeaderText="Updated DateTime"></asp:BoundField>
                                <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                                <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />--%>
                            </Columns>
                            <PagerSettings />                        
                        </asp:GridView>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                
                <asp:Panel ID="pnlpopup" runat="server" BackColor="Gray" Height="100%"
                    Width="90%" Style="z-index: 111; background-color: White; position: absolute; top: 0%; display: none">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Edit details of Report.</div>
                            <div class="panel-body">

                               
                                    <div style="width: 100%; display: none;">
                                        <div class="form-group" style="width: 50%; float: left; padding-right: 10px;">
                                            <label>Report Id:</label>
                                            <asp:TextBox ID="TextBox_ReportId" class="form-control" ToolTip="ReportId" ReadOnly="true" placeholder="ReportId" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 50%; float: left;">
                                            <label>user_id:</label>
                                            <asp:TextBox ID="TextBox_user_id" class="form-control" ToolTip="user_id" ReadOnly="true" placeholder="user_id" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%-- <div class="form-group">
                                        <label>
                                            Date:</label>
                                        <asp:TextBox class="form-control" ID="txtbox_dateTimePicker" style="width:93%;float:left;" runat="server" 
                                            ReadOnly="true" TextMode="DateTime"></asp:TextBox>
                                        <img src="images/calender.png" style="float: left; height: 23px; padding-left: 5px;" />
                                    </div>--%>
                                    <div class="form-group">
                                        <label>Reported by:</label>
                                        <asp:TextBox ID="TextBox_Reportedby" class="form-control" ToolTip="Reportedby" ReadOnly="true" placeholder="Reportedby" runat="server"></asp:TextBox>
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
                                        <label>Description:</label>
                                        <asp:TextBox ID="txtbox_Description" class="form-control" ToolTip="Description"
                                            runat="server" placeholder="Enter detail description of incident along with people who were involve in the incident." TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        <div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbox_Description" runat="server" ErrorMessage="Please enter description" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Site Name:</label>
                                        <asp:TextBox ID="txtbox_siteName" class="form-control" ToolTip="Site Name" placeholder="Site Name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_siteName" runat="server" ErrorMessage="Please enter Site Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <label>Action Taken:</label>
                                        <asp:TextBox ID="txtbox_actionTaken" class="form-control" Rows="2" ToolTip="Action Taken" placeholder="Please enter the Action Taken by you regarding the incident" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                <div class="form-group" style="margin-top:15px;">
                                        <asp:Panel ID="pnlDisplayImage" runat="server"></asp:Panel>
                                    </div>
                                    <asp:Button ID="btnUpdateReport" type="Update" class="btn btn-primary"
                                        runat="server" Text="Update" OnClick="btnUpdateReport_Click" />
                                    <asp:Button ID="btnClose" CssClass="btn btn-primary" runat="server" Text="Close" OnClick="btnClose_Click" />
                                    
                         
                                <!-- /.row (nested) -->
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                 </asp:Panel>
            </div>
        </div>
             
    </div>
</asp:Content>
