// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    $('#date-page').html(`Date:${new Date().toLocaleDateString()}`);
    setInterval(function (parameters) {
        var time = new Date().toLocaleTimeString();
        if (time == '00:00:00')
            $('#date-page').html(`Date:${new Date().toLocaleDateString()}`);
        $('#time-page').html(`Time: ${time}`);

    },
        1000);
    $('#nextQuote').on('click',
        function() {
            $.ajax({
                url: "https://api.quotable.io/random",
                dataType: "json"
            }).done(function(data) {
                $('#content-quote').text(`${data.content}`);
                $('#autor').text(`${data.author}`);
                console.log(data);
            });
        });
    $('#nextQuote').click();
});
