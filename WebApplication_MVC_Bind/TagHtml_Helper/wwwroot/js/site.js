// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    $('.display-label').remove();
    $('.info-user').each(function(index) {
        $(this).children().first().remove();
    });
    $('.user').find('.editor-label').first().remove();
    $('.user').find('.editor-field').first().fadeOut();
})