<%@ Page Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="createActivity.aspx.cs" Inherits="Morpheus.createActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Activity</title>
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=startDateTime.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
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
        .dateTimeDiv {
            float: left;
            margin-left: 5px;
        }

        .tablePadding {
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Create Activity</h1>
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
            <button type="button" onclick="location.href='viewActivity.aspx';" style="float: right; margin: 5px;" class="btn btn-success">View Activities <i class="fa fa-search-plus"></i></button>
        </div>


        <div class="row">
            <!-- /.panel -->
            <div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Create Activity
                            </div>
                            <div class="panel-body">

                                <div class="form-group" style="display:none;">
                                    <label>Activity Created By:</label>
                                    <asp:TextBox class="form-control" ID="textbox_createdBy" ReadOnly="true" ToolTip="created by" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Activity Name:</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtbox_ActivityName" runat="server" placeholder="Activity Name / Job Name" ToolTip="Activity Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbox_ActivityName" ValidationGroup="c" Display="Dynamic" runat="server" SetFocusOnError="true" ErrorMessage="Please enter Name of Activity"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <div class="form-group">
                                        <label>Start Date:</label><asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:TextBox ID="startDateTime" class="form-control" placeholder="e.g. 08/05/2018 18:30" runat="server"
                                            TextMode="DateTime"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="c" ControlToValidate="startDateTime" Display="Dynamic" runat="server" SetFocusOnError="true" ErrorMessage="Please enter Start Date of Job/Activity."></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Site</label><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <asp:TextBox class="form-control" ID="TextBox_site" runat="server" placeholder="Site Name" ToolTip="Activity Site"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="c" ControlToValidate="TextBox_site" Display="Dynamic" runat="server" ErrorMessage="Please enter Site of Activity!!"></asp:RequiredFieldValidator>
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
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
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
                                    <asp:TextBox class="form-control" ID="textbox_Status" placeholder="Status" ReadOnly="true" ToolTip="Status" runat="server"></asp:TextBox>
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
                                <asp:Button ID="btnAddActivity" type="submit" ValidationGroup="c" class="btn btn-primary"
                                    runat="server" Text="Add" OnClick="btnAddActivity_Click" />
                                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />

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

