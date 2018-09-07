<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUpload.aspx.cs" Inherits="Seguro.Accounts.TestUpload" %>

<%@ Register Assembly="Infragistics4.Web.jQuery.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link id="link1" href="../ig_ui/css/themes/infragistics2012/infragistics.theme.css" rel="Stylesheet" type="text/css" />
    <link id="link2" href="../ig_ui/css/structure/infragistics.css" rel="Stylesheet" type="text/css" />
    <script src="../ig_ui/js/infragistics.js" type="text/javascript" id="igClientScript"></script>
</head>
<body>
   
    <form id="form1" runat="server">
    <div>
        <ig:WebUpload ID="WebUpload1" runat="server"></ig:WebUpload>
    </div>
    </form>
</body>
</html>
