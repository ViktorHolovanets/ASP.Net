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
$('#sort input').on('change', function () {
    $('#sort').submit();
})
$('#show_filter').on('click', function() {
    $('#modal-window').fadeIn();
})
$('#edit-name').on('input',function() {
    $('#view-name').html($(this).val());
})
$('#edit-price').on('input', function () {
    $('#view-price').html($(this).val());
})
$('#edit-details').on('input', function () {
    $('#view-details').html($(this).val());
})
$('#edit-image').on('focusout', function () {
    $('#view-image').attr('src',$(this).val());
})