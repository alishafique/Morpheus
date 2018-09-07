<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="frmViewRoster.aspx.cs" Inherits="Seguro.Accounts.frmViewRoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">View Roster</h1>
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
                        View Roster/Shifts
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div style="margin-left: 33%;">
                                    <asp:Button ID="btnPrevious" style="float:left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text="<" OnClick="btnPrevious_Click" />
                                    <div style="float: left;text-align: center; padding-left:5px;">
                                        <asp:Label ID="lblStartWeekDate" runat="server" Text=""></asp:Label></div>
                                    <div style="padding-left: 5px; padding-right:5px; float: left;text-align: center;">
                                        <label>-</label>
                                    </div>
                                    <div style="float: left;text-align: center; padding-right:5px;">
                                        <asp:Label ID="lblEndWeekdate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button ID="bntNext" style="float:left;" CausesValidation="false" class="btn btn-outline btn-primary btn-xs" runat="server" Text=">" OnClick="bntNext_Click"/>                                  
                                </div>
                                <br />
                                <br />
                            <asp:GridView ID="grdViewShifts" Width="100%" class="table table-striped table-bordered table-hover" ShowFooter="true"
                                     runat="server" AutoGenerateColumns="False" OnRowCommand="grdViewShifts_RowCommand" OnRowDataBound="grdViewShifts_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RosterID" HeaderText="RosterID">
                                            <ItemStyle CssClass="hidden-field" />
                                            <HeaderStyle CssClass="hidden-field" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RosterDate" HeaderText="RosterDate" DataFormatString="{0:dddd, dd/MMM/yyyy}"/>
                                        <asp:BoundField DataField="RosterStartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="RosterEndTime" HeaderText="EndTime" />
                                        <asp:BoundField DataField="TotalHours" HeaderText="Total Hours" />
                                        <asp:BoundField DataField="RosterSite" HeaderText="Site" />
                                        <asp:BoundField DataField="RosterTask" HeaderText="Task" />
                                        <asp:BoundField DataField="RStatus" HeaderText="Status" >
                                            <ItemStyle Font-Italic="true" />
                                            </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lbAccept" Text="Accept" CommandName="AcceptShift" CausesValidation="false" CommandArgument='<%# Eval("RosterID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lbReject" Text="Reject" CausesValidation="false" CommandName="RejectShift" CommandArgument='<%# Eval("RosterID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
      

    </div>
</asp:Content>
