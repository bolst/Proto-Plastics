export function load_map() {
    let raw = JSON.stringify([
        {
            type: "Feature",
            geometry: {
                type: "Point",
                coordinates: [
                    -82.9726200,
                    42.2342460
                ]
            },
            properties: {
                name: "Proto-Plastics Canada Ltd."
            }
        }
    ]);
    let map = L.map('map').setView({ lon: -82.9726200, lat: 42.2342460 }, 16);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
    var geojson_layer = L.geoJSON().addTo(map);
    var geojson_data = JSON.parse(String(raw));
    for (var geojson_item of geojson_data) {
        geojson_layer.addData(geojson_item);
        var marker = new L.marker(
            [geojson_item.geometry.coordinates[1],
            geojson_item.geometry.coordinates[0]],
            { opacity: 0.01 }
        );
        marker.bindTooltip(geojson_item.properties.name,
            {
                permanent: true,
                className: "my-label",
                offset: [0, 0]
            }
        );
        marker.addTo(map);
    }
    return "";
}