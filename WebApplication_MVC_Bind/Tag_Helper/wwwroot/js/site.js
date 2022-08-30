// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    $('#details').on('click', HiddenModalWindow);
    $('.modal-window').before().on('click', HiddenModalWindow);

    function HiddenModalWindow() {
        $('.modal-window').fadeOut();
    }
})