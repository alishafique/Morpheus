<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/forms/formMain.Master" AutoEventWireup="true" CodeBehind="Induction.aspx.cs" Inherits="Morpheus.Accounts.forms.Induction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">
                Create Activity
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label>Question 1: <br />
                    </label><asp:Label ID="lblQuestion1" runat="server" Text="Are you wearing the high visibility VEST?"></asp:Label>
                    <br />
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" />
                    <br />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="No" />
                </div>
                  <div class="form-group">
                    <label>Question 1: <br />
                    </label><asp:Label ID="lblQuestion2" runat="server" Text="Are you wearing steel toe boots?"></asp:Label>
                    <br />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Yes" />
                    <br />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="No" />
                </div>
                  <div class="form-group">
                    <label>Question 1: <br />
                    </label><asp:Label ID="lblQuestion3" runat="server" Text="Are you wearing gloves?"></asp:Label>
                    <br />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="Yes" />
                    <br />
                    <asp:RadioButton ID="RadioButton6" runat="server" Text="No" />
                </div>
                  <div class="form-group">
                    <label>Question 1: <br />
                    </label><asp:Label ID="lblQuestion4" runat="server" Text="Are you wearing Protection glasses?"></asp:Label>
                    <br />
                    <asp:RadioButton ID="RadioButton7" runat="server" Text="Yes" />
                    <br />
                    <asp:RadioButton ID="RadioButton8" runat="server" Text="No" />
                </div>
                
                <asp:Button ID="BtnSubmit" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Button" />

                </div>
            </div>
           </div>
</asp:Content>
