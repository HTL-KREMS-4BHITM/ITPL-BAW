window.initializeMap = (dotNetHelper) => {
    const map = L.map('map').setView([48.210033, 16.363449], 13);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);

    map.on('click', function(event) {
        const lat = event.latlng.lat;
        const lng = event.latlng.lng;

        // Reverse-Geocoding API call
        const GEOAPIFY_API_KEY = "65f0613505ff4799a40b3b62ead71e53";
        const geocodeUrl = `https://api.geoapify.com/v1/geocode/reverse?lat=${lat}&lon=${lng}&apiKey=${GEOAPIFY_API_KEY}`;

        fetch(geocodeUrl)
            .then(response => response.json())
            .then(data => {
                if (data.features.length === 0) {
                    alert("Keine Adresse für diese Koordinaten gefunden.");
                    return;
                }

                const address = data.features[0]?.properties.formatted || `Unbekannte Adresse (${lat.toFixed(4)}, ${lng.toFixed(4)})`;

                // Call Blazor method to add the waypoint
                dotNetHelper.invokeMethodAsync('AddWaypoint', lat, lng, address);

                // Add a marker to the map
                L.marker([lat, lng]).addTo(map).bindPopup(`Waypoint: ${address}`).openPopup();
            })
            .catch(err => {
                console.error('Fehler beim Abrufen der Adresse:', err);
                alert('Fehler beim Abrufen der Adresse. Bitte prüfen Sie die Konsole.');
            });
    });
};

window.fetchRoute = (waypoints, mode) => {
    const waypointStrings = waypoints.join('|');
    const url = `https://api.geoapify.com/v1/routing?waypoints=${waypointStrings}&mode=${mode}&details=instruction_details&apiKey=65f0613505ff4799a40b3b62ead71e53`;

    fetch(url)
        .then(response => response.json())
        .then(result => {
            L.geoJSON(result, {
                style: () => ({ color: "#FF0000", weight: 5 })
            }).bindPopup((layer) => {
                const { distance, distance_units, time } = layer.feature.properties;
                return `${distance} ${distance_units}, ${time}`;
            }).addTo(map);
        })
        .catch(error => {
            console.error("Fehler beim Abrufen der Route:", error);
            alert("Fehler beim Abrufen der Route. Prüfen Sie die Konsole für Details.");
        });
};
