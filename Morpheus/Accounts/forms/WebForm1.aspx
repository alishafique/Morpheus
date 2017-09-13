<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Morpheus.Accounts.forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 58px;
        }
        .auto-style2 {
            height: 58px;
            width: 181px;
        }
        .auto-style3 {
            width: 181px;
        }
        .auto-style4 {
            height: 58px;
            width: 869px;
            color: #666666;
            font-size: x-large;
        }
        .auto-style5 {
            width: 869px;
            text-align: left;
        }
    </style>
</head>
<body style="height: 459px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table style="width: 100%; height: 426px;">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style4"><strong>Please fill this form</strong></td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">Question 1: Are your wearing &quot;Gloves&quot;?<br />
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
