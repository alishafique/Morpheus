<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/main.Master" AutoEventWireup="true" CodeBehind="viewCompanies.aspx.cs" Inherits="Morpheus.Accounts.viewCompanies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
      .hidden-field {
            display: none;
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
</script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
           <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">
                       View/Edit Company</h1>
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
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           List of Companies
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                           <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
                           <asp:GridView ID="dtgridview_companies" Width="100%" class="table table-striped table-bordered table-hover"
                               runat="server" AutoGenerateColumns="False"
                               OnSelectedIndexChanged="dtgridview_companies_SelectedIndexChanged" OnSelectedIndexChanging="dtgridview_companies_SelectedIndexChanging"
                               AutoGenerateSelectButton="True">
                               <Columns>
                                   <asp:BoundField  DataField="CompanyID" HeaderText="Company ID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="UserID" HeaderText="User ID">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="CompanyName" HeaderText="CompanyName"/>
                                   <asp:BoundField  DataField="Email" HeaderText="Email"/>
                                   <asp:BoundField  DataField="MemberShip" HeaderText="MemberShip"/>
                                   <asp:BoundField  DataField="Type" HeaderText="Type"/>
                                   <asp:BoundField  DataField="Status" HeaderText="Status">
                                        <ItemStyle CssClass="hidden-field" />
                                       <HeaderStyle CssClass="hidden-field" />
                                   </asp:BoundField>
                                   <asp:BoundField  DataField="Status1" HeaderText="Status"/>
                               </Columns>
                               <PagerSettings /><PagerStyle HorizontalAlign = "left" CssClass = "dataTables_paginate paging_simple_numbers" />
                               <FooterStyle BackColor="#FF3399"></FooterStyle>
                           </asp:GridView>
                           <!-- /.table-responsive -->
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->

                   <div>
                   <div class="row" >
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">Edit Company</div>
                        <div class="panel-body">
                            <div class="row">
                                <div style = " width: 95%;padding: 0px 0px 0px 20px; float:left;">
                                  
                                    <div class="form-group" style=" display:none;">
                                        <div style="width: 50%; float: left; padding-right: 10px;">
                                            <label>
                                                UserId:</label>
                                            <asp:TextBox ID="txtbox_UserId" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div style="width: 50%; float: left;">
                                            <label>
                                                CompanyId:</label>
                                            <asp:TextBox ID="txtbox_CompanyID" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Company Name:</label>
                                        <asp:TextBox class="form-control" ID="txtbox_CompanyName" runat="server" ToolTip="Comapany Name"
                                            placeholder="Comapany Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel runat="server" ID="usernameupdatepanel">
                                            <ContentTemplate>
                                                <label>
                                                    Email/Username:</label>
                                                <asp:TextBox class="form-control" placeholder="Email" ID="txtbox_CompanyEmail" runat="server"
                                                    OnChange="CheckUserName(this)" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_CompanyEmail"
                                                    ErrorMessage="Please Enter Email:" SetFocusOnError="True" Display="Dynamic" />
                                                <asp:Label ID="lbl_error_message" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                      <div class="form-group" style="display:none;">
                                        <label>
                                            Status</label>
                                        <asp:DropDownList class="form-control" ID="dp_CompanyAccountStatus" runat="server" >
                                            <asp:ListItem Value="0">Not Active</asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Select Company Type:</label>
                                        <asp:DropDownList class="form-control" ID="dp_CompanyType" runat="server">
                                            <asp:ListItem Text="--Select--" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Select Membership Plan:</label>
                                        <asp:DropDownList class="form-control" ID="Dp_MemberShipPlan" runat="server">
                                            <asp:ListItem Text="--Select Membership Plan--" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group" >
                                        <label>Mobile Number:</label>
                                        <asp:TextBox ID="TextBox_Mobile" CssClass="form-control" ToolTip="Mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Landline Number:</label>
                                        <asp:TextBox ID="TextBox_landline" CssClass="form-control" ToolTip="landline" placeholder="Landline" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                    <div>
                                        <asp:TextBox ID="TextBox_addressID1" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>
                                        <label>
                                            Address 1:</label>
                                        <asp:TextBox class="form-control" placeholder="Street Name" onFocus="geolocate()" ID="txtbox_Address1Street"
                                            runat="server"></asp:TextBox>
                                            </div>
                                        <div style="width: 100%">
                                            <div style="width:50%; float:left; padding:10px 10px 10px 0px;">
                                                <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address1Suburb"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div style="width:50%; float:left; padding:10px 0px 10px 0px;">
                                                <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address1State" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address1Postcode"
                                            runat="server"></asp:TextBox>
                                            
                                    </div>
                                    <div class="form-group">
                                       
                                        <div id="myDIV" >
                                        <asp:TextBox ID="TextBox_addressID2" runat="server" Visible="false"  ReadOnly="true"></asp:TextBox>
                                            <label>
                                                Address 2:</label>
                                            <asp:TextBox class="form-control" placeholder="Street Name" onFocus="geolocate()" ID="txtbox_Address2Street"
                                                runat="server"></asp:TextBox>
                                            <div style="width: 100%">
                                                <div style="width:50%; float:left; padding:10px 10px 10px 0px;">
                                                    <asp:TextBox class="form-control" placeholder="Suburb" ID="txtbox_Address2Suburb"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div style="width:50%; float:left; padding:10px 0px 10px 0px;">
                                                    <asp:TextBox class="form-control" placeholder="State" ID="txtbox_Address2State" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <asp:TextBox class="form-control" placeholder="poste code" ID="txtbox_Address2Postcode"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnUpdateCompanyDetails" type="submit" 
                                        class="btn btn-primary btn-lg btn-block" runat="server"
                                        Text="Update" onclick="btnUpdateCompanyDetails_Click" />
                                    
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
         var placeSearch, autocomplete, autocomplete2;
       

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
        // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=txtbox_Address1Street.ClientID %>')),
            { types: ['geocode'] });

           autocomplete2 = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('<%=txtbox_Address2Street.ClientID %>')),
            { types: ['geocode'] });


        // When the user selects an address from the dropdown, populate the address
          // fields in the form.
          
          autocomplete.addListener('place_changed', fillInAddress);
          autocomplete2.addListener('place_changed', fillInAddress2);
          
      }

         function fillInAddress() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=txtbox_Address1Street.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=txtbox_Address1Suburb.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=txtbox_Address1State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=txtbox_Address1Postcode.ClientID%>').value = place.address_components[6].short_name;
         }
          function fillInAddress2() {
            
          // Get the place details from the autocomplete object.
          var place = autocomplete2.getPlace();
            // Get each component of the address from the place details
             // and fill the corresponding field on the form.
          document.getElementById('<%=txtbox_Address2Street.ClientID%>').value = place.address_components[0].long_name +" " +place.address_components[1].short_name;
          document.getElementById('<%=txtbox_Address2Suburb.ClientID%>').value = place.address_components[2].long_name;
          document.getElementById('<%=txtbox_Address2State.ClientID%>').value = place.address_components[4].short_name;
          document.getElementById('<%=txtbox_Address2Postcode.ClientID%>').value = place.address_components[6].short_name;
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
