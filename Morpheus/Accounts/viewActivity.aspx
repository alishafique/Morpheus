<%@ Page Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewActivity.aspx.cs" Inherits="Morpheus.Accounts.viewActivity" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function myFunction() {
            var x = document.getElementById('myDIV');
            if (x.style.display === 'none') {
                x.style.display = 'block';
            } else {
                x.style.display = 'none';
            }
        }

         $(document).ready(function () {
            $("#<%=TextBox_startDate.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%d/%m/%Y %H:%M",
               daFormat: "%l;%M %p, %e %m,  %Y",
               align: "BR",
               electric: false,
               singleClick: false,
               displayArea: ".siblings('.dtcDisplayArea')",
               button: ".next()"
           });
       });
    </script>
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
                <h1 class="page-header">View/Edit Activity</h1>
                <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                </div>
                <div class="alert alert-danger alert-dismissable" id="errorMsg" style="display: none;" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                </div>
                <button type="button" onclick="location.href='createActivity.aspx';" style="float:right; margin:5px;" class="btn btn-success">Add Activity <i class="fa fa-plus-circle"></i></button>
            </div>
            <!-- /.col-lg-12 -->
        </div>
         

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        List of Activities
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">

                        <label>Press the "Select" Link to view/edit activity</label>
                       
                        <asp:GridView ID="dtgridview_viewActivity" class="table table-striped table-bordered table-hover"
                            runat="server" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound" Width="100%"
                            OnSelectedIndexChanged="dtgridview_viewActivity_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_viewActivity_SelectedIndexChanging"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="ActivityID" HeaderText="Activity ID">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="email" HeaderText="Assigned To" />
                                <asp:BoundField DataField="Activity_Name" HeaderText="Name">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Activity_Location" HeaderText="Site" />
                                <asp:BoundField DataField="Activity_Type" HeaderText="Type">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Activity_Description" HeaderText="Description">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="startDate" HeaderText="StartDate" />
                                <asp:BoundField DataField="Activity_Status" HeaderText="Status" />

                                <asp:BoundField DataField="formsAttached" HeaderText="formsAttached">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>

                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                            </Columns>

                        </asp:GridView>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->


                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Edit Activity details
                            </div>
                            <div class="panel-body">
                                <div class="form-group hidden-field">
                                    <label>Activity ID:</label>
                                    <asp:TextBox ID="textbox_activityID" runat="server"></asp:TextBox>
                                </div>


                                <%--<div class="form-group">
                                               <label>Activity Created By:</label>
                                               <asp:TextBox class="form-control" ID="textbox_createdBy" ReadOnly="true" ToolTip="created by" runat="server"></asp:TextBox>
                                           </div>--%>
                                <div class="form-group">
                                    <label>
                                        Activity Name:</label>
                                    <asp:TextBox class="form-control" ID="txtbox_ActivityName" runat="server" ToolTip="Activity Name"
                                        placeholder="Activity Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_ActivityName" Display="Dynamic" runat="server" ErrorMessage="Please enter Name of Activity!!"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <label>Site</label>
                                    <asp:TextBox class="form-control" ID="TextBox_site" runat="server" ToolTip="Activity Site"
                                        placeholder="Activity Site"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox_site" Display="Dynamic" runat="server" ErrorMessage="Please enter Site of Activity!!"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Activity Type</label>
                                    <asp:DropDownList class="form-control" ID="dp_ActivityType" runat="server">
                                        <asp:ListItem Value="Plumber">Plumber</asp:ListItem>
                                        <asp:ListItem Value="Electrician">Electrician</asp:ListItem>
                                        <asp:ListItem Value="Plasterer">Plasterer</asp:ListItem>
                                        <asp:ListItem Value="Glazier">Glazier</asp:ListItem>
                                        <asp:ListItem Value="Welder">Welder</asp:ListItem>
                                        <asp:ListItem Value="Mason">Mason</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Description:</label>
                                    <asp:TextBox ID="TextBox_Description" class="form-control" placeholder="Description" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                </div>

                                <div class="form-group" style="margin-bottom: 15px;">
                                    <label>Assigned To Employee(s)</label>
                                    <asp:ListBox ID="listEmployees" class="form-control" Height="150px" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <label>Status:</label>
                                    <asp:TextBox class="form-control" ID="textbox_Status" placeholder="Status" ToolTip="Status" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Start Date:</label>
                                    <asp:TextBox ID="TextBox_startDate" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="">
                                    <label>Select forms to assign:</label>
                                    <div class="checkbox" style="margin-left: 25px;">
                                        <asp:CheckBoxList ID="cbFormsList" runat="server">
                                            <asp:ListItem Value="forms/SafetyFormQuestionair.aspx">SafetyFormQuestionair</asp:ListItem>
                                            <asp:ListItem Value="forms/Induction.aspx">Induction Form</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <asp:Button ID="btnUpdateActivity" type="submit" class="btn btn-primary btn-lg btn-block"
                                    runat="server" Text="Update" OnClick="btnUpdateActivity_Click" />
                            </div>

                            <!-- /.col-lg-6 (nested) -->

                            <!-- /.row (nested) -->
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
</asp:Content>
