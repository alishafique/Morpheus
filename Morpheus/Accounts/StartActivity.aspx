<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="StartActivity.aspx.cs" Inherits="Morpheus.Accounts.StartActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .btnRound {
            display: block;
            height: 200px;
            width: 200px;
            border-radius: 50%;
            margin: 0px auto;
            
        }
    </style>

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


            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Start Activity
                    </div>
                    <div class="panel-body">

                        <div class="col-lg-12">
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
                                        <asp:Button ID="btnStart" runat="server" Text="Start" CommandName="Start" CommandArgument='<%# Eval("ActivityID") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </div>
                        <br />


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
                </div>
            </div>

            </div>
</asp:Content>
