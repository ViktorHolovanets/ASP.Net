$(() => {
    let res = JSON.parse(localStorage.getItem("films"));;
    if (res) {
        for (const key in res) {
            let div = document.createElement('div');
            div.className = 'film';
            div.innerHTML = `
            <img src="${res[key].Poster}" alt="Poster">
            <p>${res[key].Title}</p>
            <p class="year">${res[key].Year}</p>
            <button onclick="detailsFilm(event)">
                Add BD
                <input type="hidden" value="${res[key].imdbID}">
            </buttonn>`;
            films.appendChild(div);
        }
        $("#result").fadeIn();
    }
});
class MovieService {
    constructor(title, type) {
        this._title = title;
        this._type = type;
        this._page = 1;
    }
    set title(title) {
        this._title = title
    }
    get title() {
        return this._title;
    }
    set type(type) {
        this._type = type
    }
    get type() {
        return this._type;
    }
    set page(page) {
        this._page = page
    }
    get page() {
        return this._page;
    }

    search() {
        $.ajax({
            method: 'GET',
            url: `https://www.omdbapi.com/?apikey=d87cdbca&s=${this._title}&type=${this._type}&page=${this._page}`,
            statusCode: {
                401: function () {
                    swal({
                        title: "Error!",
                        text: "Invalid API key!",
                        icon: "error",
                        button: "Ok!",
                        content: {
                            element: "a",
                            attributes: {
                                href: "https://www.omdbapi.com",
                                innerHTML: "More information",
                                target: "blank"
                            }
                        }
                    });
                    $("#result").fadeOut();
                    $("#API_key").css('background', 'red')
                }
            },
            beforeSend: function () {
                $('.load').fadeIn();

            },
            async: true,
            success: Result,
            complete: function (res) {
                $('.load').fadeOut();
                if (res.status !== 401)
                    $("#result").fadeIn();
            },
            error: function (e) {
                console.log(e);
            }
        });
    }
    getMovie(movieId) {
        $.ajax({
            method: 'GET',
            url: `https://www.omdbapi.com/?apikey=d87cdbca&i=${movieId}`,

            async: true,
            success: ResultDetailsFilm,
            complete: function () {
                $('#addFilm').click();
            },
            error: function (e) {
                console.log(e.statusText);
                alert("Invalid API key!");
            }
        });
    }
}
const m = new MovieService(title.value, type.value);
search.addEventListener('click', e => {
    films.innerHTML = '';
    $("#result").fadeOut();
    m.title = title.value;
    m.type = type.value;
    m.search();
});
moreFilms.addEventListener('click', e => {
    m.page++;
    m.search();
});
API_key.addEventListener('change', e => {
    if (e.target.style.backgroundColor == 'red')
        e.target.style.backgroundColor = 'white';
});
function Result(result) {
    let res = [];
    let i = 0;
    if ('Search' in result)
        for (const key in result.Search) {
            let div = document.createElement('div');
            div.className = 'film';
            div.innerHTML = `
            <img src="${result.Search[key].Poster}" alt="Poster">
            <p>${result.Search[key].Title}</p>
            <p class="year">${result.Search[key].Year}</p>
            <button onclick="detailsFilm(event)">
                Add BD
                <input type="hidden" value="${result.Search[key].imdbID}">
            </buttonn>`;
            films.appendChild(div);
            res[i] = {
                Poster: result.Search[key].Poster,
                Title: result.Search[key].Title,
                Year: result.Search[key].Year,
                imdbID: result.Search[key].imdbID
            };
            i++;
        }
    else
        films.innerHTML = `${result.Error}`;
    localStorage.setItem("films", JSON.stringify(res));
}
function detailsFilm(e) {
    let id = e.target.querySelector('input').value;
    m.getMovie(id);
}
function ResultDetailsFilm(result) {
    $("#film-poster").val(result.Poster);
    $("#film-title").val(result.Title);
    $("#film-released").val(result.Released);
    $("#film-genre").val(result.Genre);
    $("#film-country").val(result.Country);
    $("#film-director").val(result.Director);
    $("#film-writer").val(result.Writer);
    $("#film-actors").val(result.Actors);
    $("#film-award").val(result.Awards);
}
function closeModalWindow(event) {
    $('#modal-window').fadeOut();
    return false;
}