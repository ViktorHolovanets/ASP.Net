// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    $('.accordion-header').on('click',
        function () {
            $(this).toggleClass('active')
            $(this).next().slideToggle(300);
        });
    let now = new Date();
    let day = ("0" + now.getDate()).slice(-2);
    let month = ("0" + (now.getMonth() + 1)).slice(-2);
    let today = now.getFullYear() + "-" + (month) + "-" + (day);
    $('input[type = date]').val(today);
    let hours = ("0" + (now.getHours())).slice(-2);
    let minute = ("0" + (now.getMinutes())).slice(-2);
    let time = `${hours}:${minute}`;
    $('input[type = time]').val(time);
})