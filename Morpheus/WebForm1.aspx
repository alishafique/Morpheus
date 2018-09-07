<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Seguro.WebForm1" %>

<html>
<head>
<title>Geolocation API Example</title>
<meta http-equiv="X-UA-Compatible" content="IE=9" />
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
<input type="button" onclick="requestPosition()" value="Get Latitude and Longitude"  /> 


    <h2>Register for an Account</h2>

<form method="get" target="_new">
  <label for="name">Name</label>
  <input type="text" id="name" name="name">
    
  <label for="address1">Address</label>
  <input type="search" id="address_line_1" name="address_line_1" placeholder="Enter address here" class="address-field"><br>
  <input type="text" id="address_line_2" name="address_line_2" class="address-field">

  <label for="suburb">Suburb</label>
  <input type="text" id="suburb" name="suburb" class="address-field">

  <label for="state">State</label>
  <input type="text" id="state" name="state" class="address-field">
    
  <label for="postcode">Postcode</label>
  <input type="text" id="postcode" name="postcode" class="address-field">
    
  <p>
    <input type="submit" name="submit" value="Register">
  </p>
</form>

<script>
(function(){
  var widget, initAF = function(){
    widget = new AddressFinder.Widget(
      document.getElementById('address_line_1'),
      'BALJQFKT6MRYUX7HV3C8',
      'AU',
      {
      }
    );

    widget.on("result:select", function(fullAddress, metaData) {
      document.getElementById('address_line_1').value = metaData.address_line_1;
      document.getElementById('address_line_2').value = metaData.address_line_2;
      document.getElementById('suburb').value = metaData.locality_name;
      document.getElementById('state').value = metaData.state_territory;
      document.getElementById('postcode').value = metaData.postcode;
    });
  };

  function downloadAF(f){
    var script = document.createElement('script');
    script.src = 'https://api.addressfinder.io/assets/v3/widget.js';
    script.async = true;
    script.onload=f;
    document.body.appendChild(script);
  };

  document.addEventListener("DOMContentLoaded", function () {
    downloadAF(initAF);
  });

})();
</script>

</body>
</html>
