<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="StartActivity.aspx.cs" Inherits="Morpheus.Accounts.StartActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Start Job</title>
    <!-- DataTables CSS -->
    <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="datatables-responsive/dataTables.responsive.css" rel="stylesheet" />

    <!-- DataTables JavaScript -->
    <script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="datatables-plugins/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script src="datatables-responsive/dataTables.responsive.js" type="text/javascript"></script>
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
     <style type="text/css">
        .btnRound {
            display: block;
            height: 200px;
            width: 200px;
            border-radius: 50%;
            margin: 0px auto;
            
        }

    </style>
     <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $("#btnClose").live('click',function () {
            HidePopup();
        });
       

    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


            <div class="col-lg-9">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Start Activity
                    </div>
                    <br />
                    <label style="text-align: left; padding:5px;">Following are the Today's Jobs you have to do.</label>
                    <div class="panel-body">
                        <div class="form-group" style="display:none;">
                            <label>Current Location:</label>
                            <asp:TextBox ID="currentlocation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <asp:GridView ID="dgvLoadTodaysActivity" class="table table-striped table-bordered table-hover"
                            runat="server" AutoGenerateColumns="false" OnRowCommand="dgvLoadTodaysActivity_RowCommand" OnRowDataBound="dgvLoadTodaysActivity_RowDataBound"
                                  OnRowDeleting="dgvLoadTodaysActivity_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="ActivityID" HeaderText="Activity ID">
                                    <ItemStyle CssClass="hidden-field" />
                                    <HeaderStyle CssClass="hidden-field" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Activity_Name" HeaderText="Name">
                                </asp:BoundField>
                                <asp:BoundField DataField="startDate" HeaderText="StartDate" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Activity_Status" HeaderText="Status" />
                                <asp:TemplateField HeaderText="Start">
                                    <ItemTemplate>
                                        <asp:Button ID="btnStart" runat="server" CssClass="btn btn-success" Text="Start" CommandName="Start" CommandArgument='<%# Eval("ActivityID") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEnd" runat="server" Text="End" CssClass="btn btn-danger" CommandName="End" CommandArgument='<%# Eval("ActivityID") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                      
                    </div>
                </div>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="Gray"
               Width="90%" Style="z-index: 111; padding-top:10px; background-color: White; position: absolute; top: 0%; display: none">
               <div id="jobDetails" class="col-lg-12" runat="server">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           Start Activity
                           <button type="button" style="float: right;" class="btnClose btn btn-danger btn-circle" onclick="HidePopup();">
                               <i class="fa fa-times"></i>
                           </button>
                       </div>
                       
                       <div class="panel-body">
                           <div class="col-lg-12">
                               
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
                               <asp:Button ID="btnStart" class="btn btn-success btn-lg btnRound" runat="server" Text="Start Activity" OnClick="btnStart_Click" />
                           </div>
                       </div>
                   </div>
               </div>
           </asp:Panel>
            </div>

           

            </div>

    <script type="text/javascript">

        function getLocation() {
            if (navigator && navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                document.getElementById('<%=currentlocation.ClientID %>').value = "Geolocation is not supported by this browser.";
            }
        }
        function showPosition(position) {
            //x.innerHTML =  position.coords.latitude +"," + position.coords.longitude;
            document.getElementById('<%=currentlocation.ClientID %>').value = position.coords.latitude + "," + position.coords.longitude;
        }
    </script>
</asp:Content>
