
function initialize(address) {

    console.log(address.city);
    console.log(address.street);

    mapboxgl.accessToken = 'pk.eyJ1IjoieW91cmV2ZW50c2VydmljZSIsImEiOiJja3FodWViZ2cwZWprMm5xanZidGpxcDczIn0.pWZhZF15SwNTSfAcKZHjWw';
    var mapboxClient = mapboxSdk({ accessToken: mapboxgl.accessToken });
    mapboxClient.geocoding
        .forwardGeocode({
            query: `${address.street}, ${address.city}`,
            autocomplete: false,
            limit: 1
        })
        .send()
        .then(function (response) {
            if (
                response &&
                response.body &&
                response.body.features &&
                response.body.features.length
            ) {
                var feature = response.body.features[0];

                var map = new mapboxgl.Map({
                    container: 'map',
                    style: 'mapbox://styles/youreventservice/ckqi4infi0ahu17n3q9u8razd',
                    center: feature.center,
                    zoom: 10
                });

                // Create a marker and add it to the map.
                new mapboxgl.Marker().setLngLat(feature.center).addTo(map);
            }
        });
   
}
