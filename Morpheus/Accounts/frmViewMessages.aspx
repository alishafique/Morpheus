<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" EnableViewState="true" CodeBehind="frmViewMessages.aspx.cs" Inherits="Morpheus.Accounts.frmViewMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
      .hidden-field {
            display: none;
        }
      #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
   <!-- DataTables CSS -->
    <link href="datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="datatables-responsive/dataTables.responsive.css" rel="stylesheet" />

     <!-- DataTables JavaScript -->
    <script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="datatables-plugins/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script src="datatables-responsive/dataTables.responsive.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                responsive: true
            });  
        });
        jQuery.fn.extend({
            live: function (event, callback) {
                if (this.selector) {
                    jQuery(document).on(event, this.selector, callback);
                }
            }
        });
    </script>
    
     <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
         $(".btn").on('click', function () {
            HidePopup();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        

    <div id="page-wrapper">
        
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       View Messages</h1>
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
        <div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:Panel ID="pnlpopup" runat="server" BackColor="White"
                        Style="z-index: 111; background-color: White; position: absolute; border: outset 2px gray; width: 92%; padding: 5px; display: none">
                        <asp:TextBox ID="txtbox_ID" runat="server" Visible="false"></asp:TextBox>
                        <div class="form-group">
                            <label>Name:</label>
                            <asp:TextBox CssClass="form-control" placeholder="Enter Full Name" ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="nameReq" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Name Required" SetFocusOnError="True" Display="Dynamic" />
                        </div>

                        <div class="form-group">
                            <label>Email:</label>
                            <asp:TextBox CssClass="form-control" placeholder="Enter Email Address" ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email Required" SetFocusOnError="True" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <label>Phone:</label>
                            <asp:TextBox CssClass="form-control" placeholder="Enter Phone Number" ID="txtPhone" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Your Message:</label>
                            <asp:TextBox CssClass="form-control" placeholder="Enter Your Message" TextMode="MultiLine" Rows="6" ID="txtMessage" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label>Date Time:</label>
                            <asp:TextBox ID="txtbox_DateTime" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Close" value="Cancel" />
                    </asp:Panel>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
        <div id="mask">
        </div>
           <div class="row">
               <div class="col-lg-12">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           List of Messages
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                           <asp:GridView ID="gridView_ContactUsMessages" runat="server" class="table table-striped table-bordered table-hover" 
                               OnRowCommand="gridViewContactUsMessages_RowCommand" DataKeyNames="ID" AutoGenerateColumns="False" >
                               <Columns>

                                   <asp:TemplateField HeaderText="" SortExpression="">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="btnShow" CausesValidation="false" runat="server" CommandName="ShowPopup"
                                               CommandArgument='<%#Eval("ID") %>'>Select</asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField  DataField="ID" HeaderText="ID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>

                                   <asp:BoundField  DataField="name" HeaderText="Name" />
                                   <asp:BoundField  DataField="email" HeaderText="Email"/>
                                   <asp:BoundField  DataField="phone" HeaderText="Phone"/>
                                   <asp:BoundField  DataField="message" HeaderText="Message">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="DateTime" HeaderText="DateTime"/>
                               </Columns>

                           </asp:GridView>
                           
                          
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                  

               </div>
               <!-- /.col-lg-12 -->
           </div>
          
           <!-- /#page-wrapper -->
       </div>
</asp:Content>
