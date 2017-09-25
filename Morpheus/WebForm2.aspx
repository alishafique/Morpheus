<%@ Page Title="" Language="C#" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Morpheus.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

function setText(val, e) {
    document.getElementById(e).value = val;
}

function insertText(val, e) {
    document.getElementById(e).value += val;
}

var nav = null; 

function requestPosition() {
  if (nav == null) {
      nav = window.navigator;
  }
  if (nav != null) {
      var geoloc = nav.geolocation;
      if (geoloc != null) {
          geoloc.getCurrentPosition(successCallback);
      }
      else {
          alert("geolocation not supported");
      }
  }
  else {
      alert("Navigator not found");
  }
}



function successCallback(position)
{
   setText(position.coords.latitude, "latitude");
   setText(position.coords.longitude, "longitude");
}



</script>
</head>
<body>
<label for="latitude">Latitude: </label><input id="latitude" /> <br />
<label for="longitude">Longitude: </label><input id="longitude" /> <br />
<input type="button"  onclick="requestPosition()" value="Get Latitude and Longitude"  /> 
    <div class="panel-body">
        <!-- Button trigger modal -->
        <button class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
            Launch Demo Modal
                           
        </button>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                    </div>
                    <div class="modal-body">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                       
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
      <!-- Page-Level Demo Scripts - Notifications - Use for reference -->
    <script type="text/javascript">
    // tooltip demo
    $('.tooltip-demo').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    })
    // popover demo
    $("[data-toggle=popover]")
        .popover()
    </script>
</asp:Content>
