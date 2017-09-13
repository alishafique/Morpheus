<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Morpheus.Accounts.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Morpheus Log In</title>
     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet" type="text/css" />

    <!-- Custom Fonts -->
    <link href="fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <!-- jQuery -->
    <script src="js/jquery.min.js" type="text/javascript"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js" type="text/javascript"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
         <%--function autoHide()
        {  //hide after 5 seconds   
            setTimeout(function() { document.getlementById('<%=errorMsg.ClientID%>').style.display = 'none'; },5000);
        }--%>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
               
                <div class="login-panel panel panel-default">
                    <div>
                        <a href="../Home.aspx">
                            <img src="../img/logo.png" alt="Segura" />
                        </a>
                    </div>
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                        
                    </div>
                    <div class="panel-body">
                       
                        <form role="form">
                        <div>
                         
                             <div class="alert alert-success alert-dismissable" id="successMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblsuccessmsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.          
                   </div>
                   <div class="alert alert-danger alert-dismissable" clientidmode="static" id="errorMsg" style="display: none;" runat="server">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                       <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="true" Font-Size="14"></asp:Label>.                             
                   </div>
                            
                            </div>
                            <fieldset>
                                <div class="form-group">
                                   
                                    <asp:TextBox ID="txtbox_userName" runat="server" class = "form-control" 
                                        placeholder="E-mail" name="email" type="email" autofocus="true" 
                                        ToolTip="User Name"></asp:TextBox>
                                          <div style="float=right"><asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtbox_userName" errormessage="Enter Username!" Display="Dynamic"/></div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox
                                        ID="txtbox_Password" runat="server"  class="form-control" 
                                        placeholder="Password" name="password" type="password" value=""></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" id="reqPass" controltovalidate="txtbox_Password" errormessage="Enter Password!" Display="Dynamic" />
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" style="color:blue;" value="Remember Me">Remember Me
                                    </label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <div class="form-group">
                                    <a href="../SignUp.aspx" style="color:blue;">Create New Account</a>
                                 </div>
                                <asp:Button ID="btn_logIn" runat="server" Text="log In" 
                                    class="btn btn-primary btn-lg btn-block" onclick="btn_logIn_Click" />
                                 <div class="form-group" style="margin-top: 15px;">
                                    <a href="../resetPassword.aspx" style="color:blue;">Forgot password?</a>
                                </div>
                            </fieldset>
                            
                        </form>
                        
                    </div>
                    <a href="../Home.aspx" style="float:right; color:blue;">Go to Home Page</a>
                </div>
            </div>
        </div>
    </div>

    
    </div>
    </form>
</body>
</html>
