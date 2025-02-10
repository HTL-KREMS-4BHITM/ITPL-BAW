window.initializeButtonClick = (dotNetHelper) => {
    const button = document.getElementById('interactiveButton');
    if (button) {
        button.addEventListener('click', () => {
            dotNetHelper.invokeMethodAsync('HandleButtonClick');
        });
    }
};


window.initializeLocationSuggestions = (dotNetHelper) => {
    window.dotNetHelper = dotNetHelper;  // Save the dotNetHelper to global scope
};

// Modified getLocationSuggestions function to use window.dotNetHelper
window.getLocationSuggestions = async (inputId) => {
    const apiKey = "65f0613505ff4799a40b3b62ead71e53"; // Replace with your actual API key
    let query = document.getElementById(inputId).value.trim();

    if (query.length < 3) return; // Only search after 3+ characters

    try {
        let response = await fetch(`https://api.geoapify.com/v1/geocode/autocomplete?text=${encodeURIComponent(query)}&country=AT&lang=de&apiKey=${apiKey}`);
        let data = await response.json();

        let suggestionsList = document.getElementById(inputId + "-suggestions");
        suggestionsList.innerHTML = ""; // Clear previous suggestions

        data.features.forEach(location => {
            let suggestionItem = document.createElement("li");
            suggestionItem.classList.add("list-group-item");
            suggestionItem.innerText = location.properties.formatted;

            suggestionItem.onclick = function () {
                document.getElementById(inputId).value = location.properties.formatted;
                suggestionsList.innerHTML = ""; // Clear suggestions on selection
                window.dotNetHelper.invokeMethodAsync("SetLocation", inputId, location.properties.formatted);
            };

            suggestionsList.appendChild(suggestionItem);
        });
    } catch (error) {
        console.error("Autocomplete Error:", error);
    }
};
