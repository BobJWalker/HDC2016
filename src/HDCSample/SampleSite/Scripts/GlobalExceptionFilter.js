$(document).ready(function () {
    $('#throw-error').click(function () {
        $.ajax({
            url: "/Api/ExceptionFilter/",
            success: function (result) {
                $("#error-results").html(result);
            },
            error: function(result) {
                $("#error-results").html(result.responseText);
            }
        });
    });
});