function initializeButtonEvents(dotNetHelper) {
    document.getElementById('textBtn').addEventListener('click', function () {
        dotNetHelper.invokeMethodAsync('ButtonClicked')
            .then(data => {
                console.log('Blazor Methode aufgerufen');
            });
    });
}