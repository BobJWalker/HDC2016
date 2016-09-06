$(document).ready(function () {
    $('#get-demo').click(function () {
        $.ajax({
            url: "/Api/Demo/",
            method: "POST",
            data: {
                Data: "<button onclick='alert(1);'>Click Me</button>"
            },
            success: function (result) {
                $("#demo-results").html(result.Data);
            },
            error: function(result) {
                $("#demo-results").html(result.responseText);
            }
        });
    });
});