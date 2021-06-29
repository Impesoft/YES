
//function initialize(address) {

//    console.log(address.city);
//    console.log(address.street);
//    var latlng = new google.maps.LatLng(40.716948, -74.003563);
//    var options = {
//        zoom: 14, center: latlng,
//        mapTypeId: google.maps.MapTypeId.ROADMAP
//    };
//    var map = new google.maps.Map(document.getElementById("map"), options);
//}

function initialize(address) {

    console.log(address.city);
    console.log(address.street);
    var geocoder = new google.maps.Geocoder();
    var address = "Bergmannstraße 2, Berlin, Germany";

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            resultsMap.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location
            });
        }
        else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });

}



