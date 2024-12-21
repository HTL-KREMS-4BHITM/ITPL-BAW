// Initialize the groupmap
window.InitializeMap = function(){
    console.log("in the script!!!!DSÖLFKJS");
    const map = L.map('groupmap').setView([48.1500327, 11.5753989], 10);
    
    // Retina displays require different groupmap tiles quality
    const isRetina = L.Browser.retina;
    
    const baseUrl = "https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}.png?apiKey=65f0613505ff4799a40b3b62ead71e53";
    const retinaUrl = "https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}@2x.png?apiKey=65f0613505ff4799a40b3b62ead71e53";
    
    // Add groupmap tiles layer
    L.tileLayer(isRetina ? retinaUrl : baseUrl, {
        attribution: 'Powered by <a href="https://www.geoapify.com/" target="_blank">Geoapify</a> | <a href="https://openmaptiles.org/" target="_blank">© OpenMapTiles</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">© OpenStreetMap</a>',
        maxZoom: 20,
    }).addTo(groupmap);
}
