<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="EditQuestionairForm.aspx.cs" Inherits="Morpheus.Accounts.forms.EditQuestionairForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">View/Edit Questionair Form</h1>
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
                        Edit Questionaire Form
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <asp:Label ID="lblformID" Visible="false" runat="server" Text=""></asp:Label>
                            <div class="form-group formControlbox">
                                <label>Question 1</label>
                                <asp:TextBox ID="txtQuestion1" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q1VisibleYes" CssClass="radio-inline" GroupName="Q1" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q1VisibleNo" CssClass="radio-inline" GroupName="Q1" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible:</label>
                                <asp:CheckBox ID="chkboxQ1" CssClass="checkbox-inline" Text="Visible" runat="server" />
                            </div>

                            <div class="form-group formControlbox">
                                <label>Question 2</label>
                                <asp:TextBox ID="txtQuestion2" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q2VisibleYes" CssClass="radio-inline" GroupName="Q2" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q2VisibleNo" CssClass="radio-inline" GroupName="Q2" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible:</label>
                                <asp:CheckBox ID="chkboxQ2" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 3</label>
                                <asp:TextBox ID="txtQuestion3" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q3VisibleYes" CssClass="radio-inline" GroupName="Q3" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q3VisibleNo" CssClass="radio-inline" GroupName="Q3" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ3" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 4</label>
                                <asp:TextBox ID="txtQuestion4" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q4VisibleYes" CssClass="radio-inline" Text="Yes" GroupName="Q4" runat="server" />
                                <asp:RadioButton ID="Q4VisibleNo" CssClass="radio-inline" Text="No" GroupName="Q4" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ4" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 5</label>
                                <asp:TextBox ID="txtQuestion5" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q5VisibleYes" CssClass="radio-inline" GroupName="Q5" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q5VisibleNo" CssClass="radio-inline" GroupName="Q5" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ5" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 6</label>
                                <asp:TextBox ID="txtQuestion6" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q6VisibleYes" CssClass="radio-inline" GroupName="Q6" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q6VisibleNo" CssClass="radio-inline" Text="No" GroupName="Q6" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ6" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 7</label>
                                <asp:TextBox ID="txtQuestion7" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer</label>
                                <asp:RadioButton ID="Q7VisibleYes" CssClass="radio-inline" GroupName="Q7" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q7VisibleNo" CssClass="radio-inline" Text="No" GroupName="Q7" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ7" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 8</label>
                                <asp:TextBox ID="txtQuestion8" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer:</label>
                                <asp:RadioButton ID="Q8VisibleYes" CssClass="radio-inline" GroupName="Q8" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q8VisibleNo" CssClass="radio-inline" GroupName="Q8" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ8" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 9</label>
                                <asp:TextBox ID="txtQuestion9" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer</label>
                                <asp:RadioButton ID="Q9VisibleYes" CssClass="radio-inline" GroupName="Q9" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q9VisibleNo" CssClass="radio-inline" GroupName="Q9" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ9" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                            <div class="form-group formControlbox">
                                <label>Question 10</label>
                                <asp:TextBox ID="txtQuestion10" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer</label>
                                <asp:RadioButton ID="Q10VisibleYes" CssClass="radio-inline" GroupName="Q10" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q10VisibleNo" CssClass="radio-inline" GroupName="Q10" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ10" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                             <div class="form-group formControlbox">
                                <label>Question 11</label>
                                <asp:TextBox ID="txtQuestion11" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer</label>
                                <asp:RadioButton ID="Q11VisibleYes" CssClass="radio-inline" GroupName="Q11" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q11VisibleNo" CssClass="radio-inline" GroupName="Q11" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ11" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>
                             <div class="form-group formControlbox">
                                <label>Question 12</label>
                                <asp:TextBox ID="txtQuestion12" CssClass="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <label>Expected Answer</label>
                                <asp:RadioButton ID="Q12VisibleYes" CssClass="radio-inline" GroupName="Q12" Text="Yes" runat="server" />
                                <asp:RadioButton ID="Q12VisibleNo" CssClass="radio-inline" GroupName="Q12" Text="No" runat="server" />
                                <br />
                                <label>Add Attributes:</label>
                                <br />
                                <label>Visible</label>
                                <asp:CheckBox ID="chkboxQ12" class="checkbox-inline" Text="Visible" runat="server" />
                            </div>

                            <asp:Button ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" runat="server" Text="Save" />
                            <!-- /.table-responsive -->
                        </div>

                    </asp:PlaceHolder>
                    <!-- /.panel-body -->
                </div>

            </div>
        </div>

    </div>
</asp:Content>
