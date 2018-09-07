<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/CompanyDesign.Master" AutoEventWireup="true" CodeBehind="FormBuilder.aspx.cs" Inherits="Seguro.Accounts.FormBuilder" %>

<%@ Register Assembly="Infragistics4.Web.jQuery.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link id="link1" href="../ig_ui/css/themes/infragistics2012/infragistics.theme.css" rel="Stylesheet" type="text/css" />
    <link id="link2" href="../ig_ui/css/structure/infragistics.css" rel="Stylesheet" type="text/css" />
    <script src="../ig_ui/js/infragistics.js" type="text/javascript" id="igClientScript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
   <ig:WebUpload ID="WebUpload2" runat="server"></ig:WebUpload>
</asp:Content>
