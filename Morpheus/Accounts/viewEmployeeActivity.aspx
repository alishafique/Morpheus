<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewEmployeeActivity.aspx.cs" Inherits="Morpheus.Accounts.viewEmployeeActivity" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <style type="text/css">

        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 80%;
            height: 80%;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }

    </style>
    <style type="text/css">
        .btnRound {
            display: block;
            height: 200px;
            width: 200px;
            border-radius: 50%;
            
        }
    </style>

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
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">

</asp:ScriptManager>--%>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Start Activity</h1>
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
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           List of Companies
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                           <asp:GridView ID="dtViewEmployeeActivity" runat="server" AutoGenerateSelectButton="True"  class="table table-striped table-bordered table-hover" Width="100%" AutoGenerateColumns = "false" OnSelectedIndexChanged="dtViewEmployeeActivity_SelectedIndexChanged" OnSelectedIndexChanging="dtViewEmployeeActivity_SelectedIndexChanging">
                               <Columns>
                                   <asp:BoundField DataField="ActivityID" HeaderText="ActivityID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="CreatedByCompanyID" HeaderText="CreatedByCompanyID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="Activity_Name" HeaderText="Activity_Name" />
                                   <asp:BoundField DataField="Activity_Location" HeaderText="Activity Location" />
                                   <asp:BoundField DataField="Activity_Type" HeaderText="Activity Type" />
                                  <asp:BoundField DataField="startDate" HeaderText="ToStartDate" />
                                   <asp:BoundField DataField="Activity_Description" HeaderText="Description">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>                               
                                    <asp:BoundField DataField="ActivityStartedDate" HeaderText="ActivityStartedDate" />
                                   <asp:BoundField DataField="Activity_Status" HeaderText="Status" >
                                   </asp:BoundField>
                               </Columns>
                           </asp:GridView>

                           </div>
                       </div>
                   </div>

            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                      View Detail of Activity and Start
                    </div>
                    <div class="panel-body">

                        <div class="form-group hidden-field">
                            <label>ActivityID</label>
                            <asp:Label ID="lblActivityID" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group  hidden-field">
                            <label>CreatedByCompanyID</label>
                            <asp:Label ID="lblCreatedByCompanyID" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Activity Name:</label><br />
                            <asp:Label ID="lblActivity_Name" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Activity Location:</label><br />
                            <asp:Label ID="lblActivity_Location" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="form-group">
                            <label>Activity Type:</label><br />
                            <asp:Label ID="lblActivity_Type" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="form-group">
                            <label>Activity Description:</label><br />
                            <asp:Label ID="lblActivity_Description" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="form-group  hidden-field">
                            <label>Activity Status:</label><br />
                            <asp:Label ID="lblActivity_Status" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="form-group">
                            <label>Start Date:</label><br />
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                        </div>

                        <asp:Button ID="btnStart" class="btn btn-success btn-lg btnRound" runat="server" Text="Start Activity" OnClick="btnStart_Click"/>
                    </div>



                 <%--   <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnStart"
                        CancelControlID="btnSubmitSurvey" BackgroundCssClass="Background">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe style="width: 100%; height: 100%;" id="irm1" src="survey.aspx" runat="server"></iframe>
                        <br />
                        <asp:Button ID="btnSubmitSurvey" runat="server" Text="Submit" OnClick="btnSubmitSurvey_Click" />
                    </asp:Panel>--%>


                </div>
            </div>

            </div>
        </div>
       
    
</asp:Content>
