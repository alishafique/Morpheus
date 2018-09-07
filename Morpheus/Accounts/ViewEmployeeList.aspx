<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeList.aspx.cs" ValidateRequest="false" Inherits="Seguro.Accounts.ViewEmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Employees List</title>
      <style type="text/css">
      .hidden-field {
            display: none;
        }
    </style>

   

     <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript">
       $(document).ready(function () {
           $("#<%=txtbox_dateTimePicker_DOB.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%d/%m/%Y",
               daFormat: "%l;%M %p, %e %m,  %Y",
               align: "BR",
               electric: false,
               singleClick: false,
               displayArea: ".siblings('.dtcDisplayArea')",
               button: ".next()"
           });
       });
       </script>
    <script type="text/javascript" language="javascript">
       function myFunction() {
           var x = document.getElementById('myDIV');
           if (x.style.display === 'none') {
               x.style.display = 'block';
           } else {
               x.style.display = 'none';
           }
       }

          function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgprw.ClientID%>').prop('src', e.target.result)
                        
                };
                reader.readAsDataURL(input.files[0]);
                }
          }  
      
</script>
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
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       View/Edit Employee's Profile</h1>
                   
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
                           List of Employees
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                         
                           <asp:GridView ID="dtgridview_Employees" Width="100%" class="table table-striped table-bordered table-hover"
                               runat="server" FooterStyle-BackColor="#FF3399" AutoGenerateColumns="False"
                               OnSelectedIndexChanged="dtgridview_Employees_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_Employees_SelectedIndexChanging"
                               AutoGenerateSelectButton="True" OnRowDeleting="dtgridview_Employees_RowDeleting" >
                               <Columns>
                                   <asp:BoundField DataField="EmployeeId" HeaderText="Emp Id" Visible="true">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="UserId" HeaderText="UserId" Visible="true">
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField AccessibleHeaderText="Name" DataField="Name" HeaderText="Name" />
                                   <asp:BoundField DataField="email" HeaderText="email">
                                   </asp:BoundField>
                                   <asp:BoundField DataField="created_dateTime" HeaderText="Created dateTime" />
                                   <asp:BoundField DataField="date_of_birth" HeaderText="Date of birth" DataFormatString="{0:dd/MM/yyyy}" ></asp:BoundField>
                                   <asp:BoundField DataField="mobile" HeaderText="Mobile"></asp:BoundField>
                                   <asp:BoundField DataField="ABN" HeaderText="ABN" />
                                   <asp:BoundField DataField="TFN" HeaderText="TFN" />
                                   <asp:BoundField DataField="active_status" HeaderText="Status" >
                                       <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField DataField="active_status1" HeaderText="Status" />
                                   <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />--%>
                                         
                               </Columns>
                               
                               <PagerSettings />
                               <PagerStyle HorizontalAlign="Left" CssClass="dataTables_paginate paging_simple_numbers" />
                               <FooterStyle BackColor="#FF3399"></FooterStyle>
                           </asp:GridView>
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                       <div class="col-lg-12">
                           <div class="panel panel-default">
                               <div class="panel-heading">Edit details.</div>
                               <div class="panel-body">
                    
                                   <div class="row">
                                       <div class="col-lg-6">
                                          

                                       <div style="width: 100%; display:none;">
                                           <div class="form-group" style="width: 50%; float: left; padding-right: 10px;">
                                               <label>Employee Id:</label>
                                               <asp:TextBox ID="TextBox_EmployeeId" class="form-control" ToolTip="Employee Id" ReadOnly="true" placeholder="Employee ID" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="form-group" style="width: 50%; float: left;">
                                               <label>User Id:</label>
                                               <asp:TextBox ID="TextBox_userId" class="form-control" ToolTip="User Id" ReadOnly="true" placeholder="User Id" runat="server"></asp:TextBox>
                                           </div>
                                       </div>
                                           <div class="form-group" runat ="server" >

                                               <div>
                                                   <asp:Image ID="imgprw" CssClass="preview-nodeCenter nodeCenter fadeChange" runat="server" />
                                                  
                                               </div>
                                               <div>
                                                   <asp:FileUpload ID="profileUploadCtr"  class="uploadFile form-group" onchange="ShowImagePreview(this);" placeholder="Choose Images" runat="server" />                                                                   
                                                   <asp:LinkButton ID="LinkButton1" ValidationGroup="a" CssClass="btn btn-outline btn-primary btn-xs" runat="server" OnClick="LinkButton1_Click">Upload Profile Image</asp:LinkButton>
                                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" ValidationGroup="a" SetFocusOnError="true" runat="server" ErrorMessage="Only JPEG, PNG, & TIFF file is allowed!"
                                            ValidationExpression ="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg|.PNG|.JPG|.GIF|.JPEG)$" ControlToValidate="profileUploadCtr" Display="Dynamic" />
                                                       </div>
                                           </div>
                                       <div class="form-group">
                                           <label>Employee Name:</label>
                                           <asp:TextBox ID="TextBox_EmployeeName" class="form-control" ToolTip="Employee Name" placeholder="Employee Name" runat="server"></asp:TextBox>
                                       </div>
                                       <div class="form-group">
                                           <label>Employee Email:</label>
                                           <asp:TextBox ID="TextBox1_EmployeeEmail" ReadOnly="true" class="form-control" ToolTip="Employee Email" placeholder="Employee Email" runat="server"></asp:TextBox>
                                       </div>                                   
                                       <div class="form-group">
                                           <label>Date of Birth:</label>

                                           <div style="width:100%;">
                                               <div style="">
                                               <asp:TextBox style="float:left; width:90%;" class="form-control" ID="txtbox_dateTimePicker_DOB"  runat="server"
                                               TextMode="DateTime"></asp:TextBox>
                                               <img src="images/calender.png" style="float: right; height: 23px; padding-left: 5px;" /></div>
                                           </div>
                                                                                                                              
                                       </div>
                                        <div class="form-group" style="margin-top: 50px;">
                                        <label>Mobile Number:</label>
                                        <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Driving License:</label>
                                        <asp:TextBox ID="TextBox_License" CssClass="form-control" ToolTip="License" placeholder="Driving License" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="form-group" id ="hideEmployee" runat="server">
                                           <label>Active Status</label>
                                           <asp:DropDownList ID="DropDownList_activeStatus" CssClass="form-control" ToolTip="Status" runat="server">
                                               <asp:ListItem Value="0">Not-Active</asp:ListItem>
                                               <asp:ListItem Value="1">Active</asp:ListItem>
                                           </asp:DropDownList>
                                       </div>
                                        <div class="form-group">
                                            <label>Address:</label>
                                            <asp:TextBox ID="TextBox_StreetName" class="form-control" ToolTip="Street Name" onFocus="geolocate()" placeholder="Street Name" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox_Suburb" class="form-control" ToolTip="Suburb" placeholder="Suburb" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox_State" class="form-control" ToolTip="State" placeholder="State" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox_Postcode" class="form-control" ToolTip="Postcode" placeholder="Postcode" runat="server"></asp:TextBox>
                                       </div>
                                       <div class="form-group">
                                           <label>TFN:</label>
                                           <asp:TextBox ID="TextBox_TFN" class="form-control" ToolTip="TFN" placeholder="TFN" runat="server"></asp:TextBox>
                                       </div>
                                       <div class="form-group">
                                           <label>ABN:</label>
                                           <asp:TextBox ID="TextBox_ABN" class="form-control" ToolTip="ABN" placeholder="ABN" runat="server"></asp:TextBox>
                                       </div>
                                       <asp:Button ID="btnUpdateEmployeeProfile" type="Update" ValidationGroup="a" class="btn btn-primary btn-lg btn-block"
                                           runat="server" Text="Update Profile" OnClick="btnUpdateEmployeeProfile_Click" />
                                           </div>

                                       <div class="col-lg-6">
                                           <h1>Employee's Documents</h1>
 
                                           <div class="form-group" style="margin-top: 15px;">
                                                 <asp:GridView ID="grdViewDocuments" runat="server" Width="100%" class="table1 table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                                   <Columns>
                                                       <asp:BoundField DataField="DocumentID" HeaderText="DocumentID">
                                                           <ItemStyle CssClass="hidden-field" />
                                                           <HeaderStyle CssClass="hidden-field" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="DocumentName" HeaderText="DocumentName" />
                                                       <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID">
                                                           <ItemStyle CssClass="hidden-field" />
                                                           <HeaderStyle CssClass="hidden-field" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="DocumentURL" HeaderText="DocumentURL" >
                                                           <ItemStyle CssClass="hidden-field" />
                                                           <HeaderStyle CssClass="hidden-field" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="DocumentStatus" HeaderText="DocumentStatus" />
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="removeDocument" runat="server"
                                                                   CommandArgument='<%# Eval("DocumentID")%>'
                                                                   OnClientClick="return confirm('Do you want to delete?')"
                                                                   Text="Delete" OnClick="removeDocument_Click" CausesValidation="false"></asp:LinkButton>
                                                           </ItemTemplate>
                                                           <ItemStyle CssClass="hidden-field" />
                                                           <HeaderStyle CssClass="hidden-field" />
                                                       </asp:TemplateField>
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="lnkDownload" Text="View" CommandArgument='<%# Eval("DocumentURL") %>' CausesValidation="false" runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnApprove" Text="Approve" CssClass="btn btn-primary btn-xs" CommandArgument='<%# Eval("DocumentID") %>' CausesValidation="false" runat="server" OnClick="btnApprove_Click" >
                                       
                                                               </asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnReject" Text="Reject" CssClass="btn btn-primary btn-xs" CommandArgument='<%# Eval("DocumentID") %>' CausesValidation="false" runat="server" OnClick="btnReject_Click" >
                                       
                                                               </asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                  
                                                   </Columns>
                                               </asp:GridView>
                                           </div>

                                            <div class="form-group" style="display:none;">
                                               <label>Name of document</label>
                                               <asp:TextBox ID="txtDocumentName" CssClass="form-control" placeholder="Enter document name. e.g. White Card" ToolTip="Document Name" runat="server"></asp:TextBox>                             
                                               <asp:FileUpload ID="FtCdocuments"  class="uploadFile form-group"  placeholder="Choose Images" runat="server" />
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDocumentName" runat="server" Display="Dynamic" ErrorMessage="Enter document name." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FtCdocuments" runat="server" Display="Dynamic" ErrorMessage="Select Document To Upload." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                           </div>
                                        <asp:Button ID="btnUploadDocuments" CssClass="btn btn-primary" Visible="false" runat="server" Text="Upload Documents" OnClick="btnUploadDocuments_Click" />
                                       </div>

                                   </div>
                            
                                   <!-- /.row (nested) -->
                               </div>
                               <!-- /.panel-body -->
                           </div>
                           <!-- /.panel -->
                       </div>
                <!-- /.col-lg-12 -->
             </div>
                   </div>

               </div>
               <!-- /.col-lg-12 -->
           </div>
          
           <!-- /#page-wrapper -->
       </div>

    
<script type="text/javascript">
        //$('.imgUpload').on('click', function () {
        //    $('.uploadFile').click();
    //});
    function chooseFile() {
        document.getElementById('<%= profileUploadCtr.ClientID %>').click();
    }
        function imagepreview(input) {
            if (input.files && input.files[0]) {
                var fildr = new FileReader();
                fildr.onload = function (e) {
                    $('#imgprw').attr('src', e.target.result);
                }
                fildr.readAsDataURL(input.files[0]);
            }
        }
    </script>

  <script type="text/javascript">
         var placeSearch, autocomplete;
     

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
          // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=TextBox_StreetName.ClientID %>')),
            { types: ['geocode'] });


        // When the user selects an address from the dropdown, populate the address
          // fields in the form.
          
          autocomplete.addListener('place_changed', fillInAddress);
          
      }

         function fillInAddress() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=TextBox_StreetName.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=TextBox_Suburb.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=TextBox_State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=TextBox_Postcode.ClientID%>').value = place.address_components[6].short_name;
      }

      // Bias the autocomplete object to the user's geographical location,
      // as supplied by the browser's 'navigator.geolocation' object.
      function geolocate() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
            var geolocation = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
              center: geolocation,
              radius: position.coords.accuracy
            });
            autocomplete.setBounds(circle.getBounds());
          });
        }
      }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB3_CGfJ3ebusaEsHfvc_6DUsIKehea6OU&libraries=places&callback=initAutocomplete" type="text/javascript"></script>
</asp:Content>
