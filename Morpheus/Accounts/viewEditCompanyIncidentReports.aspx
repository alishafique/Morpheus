﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewEditCompanyIncidentReports.aspx.cs" Inherits="Morpheus.Accounts.viewEditCompanyIncidentReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/dataTables.responsive.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.16/css/jquery.dataTables.css" />
    <style type="text/css">
        .testOverFlow
        {
           
            word-break:break-all;
           
        }
    </style>
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.16/js/jquery.dataTables.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
                        <label>Please select any Report To view the description and Action taken on incident Report.</label>
                        <br />
                        <asp:GridView ID="dtgridview_IncidentReports" class="table table-striped table-bordered table-hover dataTable no-footer dtr-inline"
                            runat="server"  FooterStyle-BackColor="#FF3399" AutoGenerateColumns="False" 
                            OnSelectedIndexChanged="dtgridview_IncidentReports_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_IncidentReports_SelectedIndexChanging"
                            AutoGenerateSelectButton="True" OnRowDeleting="dtgridview_IncidentReports_RowDeleting">
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
                                    <ItemStyle CssClass="testOverFlow"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                      <ItemStyle Wrap="true" Width="200px" Height="50px" CssClass="testOverFlow" />
                                       
                                </asp:BoundField>
                                <asp:BoundField DataField="dateTime" HeaderText="DateTime" />
                                <asp:BoundField DataField="location" HeaderText="Location" />
                                <asp:BoundField DataField="actionTaken" HeaderText="ActionTaken">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UpdatedDateTime" HeaderText="Updated DateTime"></asp:BoundField>
                                <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />--%>
                            </Columns>
                            <PagerSettings />                        
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

                                    <asp:Button ID="btnUpdateReport" type="Update" class="btn btn-primary btn-lg btn-block"
                                        runat="server" Text="Update" OnClick="btnUpdateReport_Click" />


                                    <div class="form-group" style="margin-top:15px;">
                                        <asp:Panel ID="pnlDisplayImage" runat="server"></asp:Panel>

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
