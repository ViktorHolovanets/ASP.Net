// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#select').on('change', function() {
    $('#category').submit();
})
function closeModalWindow(event) {
    $('#modal-window').fadeOut();
    return false;
}
$('button.user').on('click', function() {
    $('#modal-window').fadeIn();
})
//$('button.exit').on('click', function () {
//    document.cookie = "id=''";
//})
$('#sort input').on('change', function () {
    $('#sort').submit();
})
$('#show_filter').on('click', function() {
    $('#modal-window').fadeIn();
})