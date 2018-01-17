<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="Morpheus.Accounts.survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Start Card</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

      <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet" />

    <!-- DataTables CSS -->
    <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="datatables-responsive/dataTables.responsive.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->

    <link href="fonts/font-awesome.min.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .auto-style1 {
            width: 20%;
        }
        .questionWidth{
            width:80%;
        }

        @media screen and (max-width: 767px)
         {
            .table-responsive > .table > tbody > tr > td, .table-responsive > .table > tbody > tr > th, .table-responsive > .table > tfoot > tr > td, .table-responsive > .table > tfoot > tr > th, .table-responsive > .table > thead > tr > td, .table-responsive > .table > thead > tr > th
            {
                    white-space: unset;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>


        <div class="panel-body">
            <div class="table-responsive table-bordered">
                <table class="table" style="width:100%;">
                    <tr>
                        <td class="questionWidth"><label>Easy Start Card</label></td>
                        <td class="auto-style1"><label>Yes/No</label></td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Reuired!" ControlToValidate="rdYesQ1"></asp:RequiredFieldValidator>
                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ1" runat="server" Text="I have attended a Pre-Start meeting today and have been briefed on the task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ1" runat="server" Text="Yes" GroupName="Q1" />
                            <asp:RadioButton ID="rdNoQ1" runat="server" Text="No" GroupName="Q1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ2" runat="server" Text="Appropiate Permits and Approvals are in place and I understand their conditions"></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ2" runat="server" Text="Yes" GroupName="Q2" />
                            <asp:RadioButton ID="rdNoQ2" runat="server" Text="No"  GroupName="Q2"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ3" runat="server" Text="I am trained and competent to undertake this task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ3" runat="server" Text="Yes" GroupName="Q3"/>
                            <asp:RadioButton ID="rdNoQ3" runat="server" Text="No" GroupName="Q3"/>
                        </td>

                    </tr>
                     <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ4" runat="server" Text="I have appropriate PPE to use for the task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ4" runat="server" Text="Yes" GroupName="Q4" />
                            <asp:RadioButton ID="rdNoQ4" runat="server" Text="No" GroupName="Q4"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ5" runat="server" Text="The work area is clean, tidy, has adequate lighting, waste bins and spill kits for the task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ5" runat="server" Text="Yes" GroupName="Q5"/>
                            <asp:RadioButton ID="rdNoQ5" runat="server" Text="No" GroupName="Q5"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ6" runat="server" Text="There is a safe access and egressto the work area."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ6" runat="server" Text="Yes" GroupName="Q6"/>
                            <asp:RadioButton ID="rdNoQ6" runat="server" Text="No" GroupName="Q6" />
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ7" runat="server" Text="Appropiate controls to work at height are in place."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ7" runat="server" Text="Yes" GroupName="Q7"/>
                            <asp:RadioButton ID="rdNoQ7" runat="server" Text="No" GroupName="Q7"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ8" runat="server" Text="I know what assistance I may need to lift materials."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ8" runat="server" Text="Yes" GroupName="Q8"/>
                            <asp:RadioButton ID="rdNoQ8" runat="server" Text="No" GroupName="Q8"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ9" runat="server" Text="The weather conditions will not impact on the environment or quality of my works of my task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ9" runat="server" Text="Yes" GroupName="Q9"/>
                            <asp:RadioButton ID="rdNoQ9" runat="server" Text="No" GroupName="Q9"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ10" runat="server" Text="Equipment for the task is tested/tagged & safe for use."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ10" runat="server" Text="Yes" GroupName="Q10"/>
                            <asp:RadioButton ID="rdNoQ10" runat="server" Text="No" GroupName="Q10"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ11" runat="server" Text="The controls in place are appropiate to protect others around me, the environment, and the work itself."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ11" runat="server" Text="Yes" GroupName="Q11"/>
                            <asp:RadioButton ID="rdNoQ11" runat="server" Text="No" GroupName="Q11"/>
                        </td>

                    </tr>
                    <tr>
                        <td class="questionWidth">
                            <asp:Label ID="lblQ12" runat="server" Text="I feel that it is safe to conduct this task."></asp:Label></td>
                        <td class="auto-style1">
                            <asp:RadioButton ID="rdYesQ12" runat="server" Text="Yes" GroupName="Q12"/>
                            <asp:RadioButton ID="rdNoQ12" runat="server" Text="No" GroupName="Q12"/>
                        </td>

                    </tr>
                </table>

            </div>
            <asp:Button ID="btnSubmitSurvey" CssClass="btn btn-outline btn-primary btn-lg" runat="server" Text="Submit" />
        </div>
      
    
    </div>
    </form>
</body>
</html>
