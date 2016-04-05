var MapTools;
var geoLoc;

function initMap() {
   var mapDiv = $("#map");
   var bounds = new google.maps.LatLngBounds();
   var infoWindow;
   var map = new google.maps.Map(mapDiv, {
     center: {
        lat: 0,
        lng:0
     },
      zoom:8
   });

   MapTools = {
      findMe: function() {
         if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function(position) {
               geoLoc = {
                  lat: position.coords.latitude,
                  lng: position.coords.longitude
               };
               infoWindow = new google.maps.InfoWindow({ map: map });
               infoWindow.setPosition(geoLoc);
               infoWindow.setContent('You are here.');
               return true;
            }, function() {
               handleLocationError(true, infoWindow, map.getCenter());
               return false;
            });
         } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
            return false;
         }
         return false;
      },
      addMarker: function(lat, lng, title) {
         var latlng = new google.maps.LatLng(lat, lng);
         bounds.extend(latlng);
         map.fitBounds(bounds);
         var marker = new google.maps.Marker({
            position: {
               lat: lat,
               lng: lng
            },
            map: map,
            title: title
         });
      },
      geoCode: function(street, city, state, zipcode) {
         var geocoder = new google.maps.Geocoder();
         var pos;
         geocoder.geocode({ 'address': street + " " + city + " " + state + " " + zipcode },
            function(results, status) {
               if (status == google.maps.GeocoderStatus.OK) {
                  pos = results[0].geometry.location;
               } else {
                  $("#MapError").html("Geocode was not successful for the following reason: " + status);
               }
            });
         return pos;
      },
      focusMap: function(lat, lng) {
            var pos = {
               lat: lat,
               lng: lng
            };
            infoWindow = new google.maps.InfoWindow({ map: map });
            infoWindow.setPosition(pos);
            infoWindow.setContent('Search');
            map.setZoom(17);
            map.setCenter(pos);
         }
   };

   function handleLocationError(browserHasGeolocation, infoWindow, pos) {
      $("#geoLocOption").addClass("collapse");
      infoWindow.setPosition(pos);
      infoWindow.setContent(browserHasGeolocation ?
         'Error: The Geolocation service failed.' :
         'Error: Your browser doesn\'t support geolocation.');
   }

}