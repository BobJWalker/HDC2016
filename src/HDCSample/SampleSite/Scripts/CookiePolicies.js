$(document)
    .ready(function () {
        $('#cookie-contents')
            .click(function () {
                loadCookies();
            });        
    });

function loadCookies() {    
    alert(document.cookie);        
}