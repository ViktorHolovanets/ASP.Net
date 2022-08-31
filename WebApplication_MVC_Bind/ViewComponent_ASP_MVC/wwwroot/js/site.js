// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {

    $('.image-dog').on('mouseover',
        function() {
            $(this).next('#edit').fadeIn();
        });
    $('#edit').on('mouseover',
        function () {
            $(this).fadeIn();
        });
    $('.image-dog').on('mouseout',
        function () {
            $(this).next('#edit').fadeOut();
        });
    $('#edit').on('click',
        function () {
            $('#edit-user').fadeToggle();
            $('table').fadeToggle();
        });
});
