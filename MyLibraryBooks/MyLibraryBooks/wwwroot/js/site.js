// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    var bookDiv;
    var index = document.getElementById('books');
    if ($('#books').length > 0) {
        $.ajax({
            url: "https://openlibrary.org/trending/daily.json",
            dataType: "json",
            beforeSend: function () {
                bookDiv = '';
                $('#books').fadeOut();
                $('.load').fadeIn();
            },
            complete: function (res) {
                $('#books').fadeIn();
                $('.load').fadeOut();
            }
        }).done(function (data) {
            if (data.ebook_count == 0) {
                $('#books').html('<h3>No books found</h3>');
                return false;
            }
            $.each(data.works, function (index, bookInfo) {
                var authors = '';
                console.log(bookInfo);
                if (bookInfo.author_name) {
                    if (bookInfo.author_name.length == 1) {
                        var authorsInfo = `Author: <a href="https://openlibrary.org/${bookInfo.author_key[0]}/">${bookInfo.author_name[0]}</a>`;
                        authors += bookInfo.author_name[0];
                    }
                    else {
                        var authorsInfo = 'Authors: ';
                        $.each(bookInfo.author_name, function (i, author) {
                            authorsInfo += `<a href="https://openlibrary.org/${bookInfo.author_key[i]}/">${author}</a>, `;
                            authors += author + ', ';
                        });
                        authorsInfo = authorsInfo.slice(0, -2);
                    }
                }
                var img_url = `https://covers.openlibrary.org/b/id/${bookInfo.cover_i}-M.jpg`;
                bookDiv += `<div class="book">
                <p class="book-title">${bookInfo.title.length < 50 ? bookInfo.title : bookInfo.title.slice(0, 60) + '...'}</p>
                <p class="book-author">${authorsInfo}</p>
                <div class="book-cover"><img  src="${img_url}"></div>
                 <form method="post" action="DetailsBook">
                    <input type="hidden" name="title" value="${bookInfo.title}"/>
                    <input type="hidden" name="authors" value="${authors}"/>
                    <input type="hidden" name="year" value="${bookInfo.first_publish_year}"/>
                    <input type="hidden" name="image" value="${img_url}"/>
                    <input type="hidden" name="key" value="${bookInfo.key}"/>
                    <input type="submit" value="Details" class="add-book"/>
                </form>
            </div>`;
            });
            $('#books').html(bookDiv);
        });
    }
    else if ($('#details-book').length > 0) {
        $.ajax({
            url: `https://openlibrary.org${$('#key-book').val()}.json`,
            dataType: "json",
            beforeSend: function () {
                $('#details-book').fadeOut();
                $('.load').fadeIn();
            }
            ,
            complete: function (res) {
                $('#details-book').fadeIn();
                $('.load').fadeOut();
            }
        }).done(function (data) {
            var c = '';
            if (data.covers)
                $.each(data.covers,
                    function(i, cover) {
                        if (parseInt(cover) > 0)
                            c += `<img src="https://covers.openlibrary.org/b/id/${cover}-M.jpg"> `;
                    });
            else {
                c += `<img src="${$('#img').val()}"> `
            }
            $('#covers').html(c);
            if (data.description)
                $('#details').text(data.description.value ?? data.description);
            console.log(data);
            console.log(data.description);
        });
    }
})