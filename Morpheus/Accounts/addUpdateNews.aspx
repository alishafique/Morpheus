<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="addUpdateNews.aspx.cs" Inherits="Morpheus.Accounts.addUpdateNews" %>

<%@ Register Assembly="Infragistics4.Web.jQuery.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add/Update News Panel</title>
    <style type="text/css">
        .imgSize
        {
            min-height:200px;
        }
    </style>  
    <script type="text/javascript">  
          function ShowImagePreview1(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgNews1.ClientID%>').prop('src', e.target.result)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
          }
           function ShowImagePreview2(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgNews2.ClientID%>').prop('src', e.target.result)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
           }
           function ShowImagePreview3(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgNews3.ClientID%>').prop('src', e.target.result)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
           }
           function ShowImagePreview4(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgNews4.ClientID%>').prop('src', e.target.result)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       Add/Edit News</h1>
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
               <div class="col-lg-6">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                         Edit News 1
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">

                           <asp:Image ID="imgNews1" Width="262px" CssClass="imgSize" Height="200px" runat="server" />
                           <asp:FileUpload ID="fctrNews1" runat="server" onchange="ShowImagePreview1(this);" />

                         <div class="form-group">
                             <label>News Title:</label>
                             <asp:TextBox ID="lblNews1PostTitle" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                           <div class="form-group">
                               <label>News Description:</label>
                               <textarea id="lblNewsDetail1" runat="server" cols="20" class="form-control" rows="4"></textarea>
                           </div>
                         
                          <asp:Button ID="btnNews1" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnNews1_Click" runat="server" Text="Update" />
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                
                <!-- /.col-lg-12 -->
             </div>
                   </div>

               </div>
               <div class="col-lg-6">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                          Edit News 2
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                            <asp:Image ID="imgNews2" Width="262px" Height="200px" runat="server" />
                           <asp:FileUpload ID="fctrNews2" runat="server" onchange="ShowImagePreview2(this);" />
                         <div class="form-group">
                             <label>News Title:</label>
                             <asp:TextBox ID="lblNews2PostTitle" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                           <div class="form-group">
                               <label>News Description:</label>
                               <textarea id="lblNewsDetail2" cols="20" class="form-control" runat="server" rows="4"></textarea>
                           </div>
                          <asp:Button ID="btnNews2" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnNews2_Click" runat="server" Text="Update" />
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                
                <!-- /.col-lg-12 -->
             </div>
                   </div>

               </div>
               <div class="col-lg-6">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                          Edit News 3
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                            <asp:Image ID="imgNews3" Width="262px" Height="200px" runat="server" />
                           <asp:FileUpload ID="fctrNews3" runat="server" onchange="ShowImagePreview3(this);" />
                         <div class="form-group">
                             <label>News Title:</label>
                             <asp:TextBox ID="lblNews3PostTitle" CssClass="form-control"  runat="server"></asp:TextBox>
                         </div>
                           <div class="form-group">
                               <label>News Description:</label>
                               <textarea id="lblNewsDetail3" cols="20" runat="server" class="form-control" rows="4"></textarea>
                           </div>
                          <asp:Button ID="btnNews3" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnNews3_Click" runat="server" Text="Update" />
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                
                <!-- /.col-lg-12 -->
             </div>
                   </div>

               </div>
               <div class="col-lg-6">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                          Edit News 4
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                            <asp:Image ID="imgNews4" Width="262px" Height="200px" runat="server" />
                           <asp:FileUpload ID="fctrNews4" runat="server" onchange="ShowImagePreview4(this);"/>
                         <div class="form-group">
                             <label>News Title:</label>
                             <asp:TextBox ID="lblNews4PostTitle" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                           <div class="form-group">
                               <label>News Description:</label>
                               <textarea id="lblNewsDetail4" cols="20" runat="server" class="form-control" rows="4"></textarea>
                           </div>
                          <asp:Button ID="btnNews4" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnNews4_Click" runat="server" Text="Update" />
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                
                <!-- /.col-lg-12 -->
             </div>
                   </div>

               </div>
               <!-- /.col-lg-12 -->
           </div>
          
           <!-- /#page-wrapper -->
       </div>
</asp:Content>
