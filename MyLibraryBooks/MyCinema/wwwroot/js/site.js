// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    $('.select-film-details').on('click',
        function() {
            let parent = $(this).closest('div');
            $("#poster").attr("src", parent.find('.select_film_poster').val());
            $("#titli").html(`${parent.find('.select_film_title').val()}`);
            $("#released").html(`${parent.find('.select_film_released').val()}`);
            $("#genre").html(`${parent.find('.select_film_genre').val()}`);
            $("#country").html(`${parent.find('.select_film_country').val()}`);
            $("#director").html(`${parent.find('.select_film_director').val()}`);
            $("#writer").html(`${parent.find('.select_film_writer').val()}`);
            $("#actors").html(`${parent.find('.select_film_actors').val()}`);
            $("#award").html(`${parent.find('.select_film_awards').val()}`);
            $('#modal-window').fadeIn();
        });
    $('#close').on('click',
        function() {
            $('#modal-window').fadeOut();
            return false;
        });
    $('.isDelete').on('click',
        function () {
            console.log($(this).next('div.delete-window'));
            $(this).next('div.delete-window').fadeIn();
            return false;
        });
    $('.no-delete').on('click',
        function () {
            $(this ).closest('div.delete-window').fadeOut();
            return false;
        });
    
})