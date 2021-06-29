
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

    mapboxgl.accessToken = 'pk.eyJ1IjoieW91cmV2ZW50c2VydmljZSIsImEiOiJja3FodWViZ2cwZWprMm5xanZidGpxcDczIn0.pWZhZF15SwNTSfAcKZHjWw';
    var map = new mapboxgl.Map({
        container: 'map', // container ID
        style: 'mapbox://styles/youreventservice/ckqhunikm1i4m17pfij2t3ubi', // style URL
        center: [-74.5, 40], // starting position [lng, lat]
        zoom: 9 // starting zoom
    });

}



