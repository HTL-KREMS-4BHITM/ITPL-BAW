let map;
let markerLayer;

window.initializeMap = (latitude, longitude, zoomLevel) => {
    map = L.map('map').setView([latitude, longitude], zoomLevel);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 20,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    markerLayer = L.layerGroup().addTo(map);
};

window.addMarker = (latitude, longitude, popupText) => {
    if (markerLayer) {
        const marker = L.marker([latitude, longitude]).addTo(markerLayer);
        if (popupText) {
            marker.bindPopup(popupText);
        }
    }
};

window.clearMarkers = () => {
    if (markerLayer) {
        markerLayer.clearLayers();
    }
};
