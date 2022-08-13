let btn = document.getElementById('search');
let res = document.getElementById('Result');
btn.addEventListener('click', e => {
    res.innerHTML = '';

    QueryUser(`/weather?q=${nameCity.value}&appid=${API_key.value}&units=metric`, data => {

        data = JSON.parse(data);
        if (data.cod == '200') {
            res.appendChild(CreateDivWeather(data));
            QueryUser(`/forecast?q=${nameCity.value}&appid=${API_key.value}&units=metric`, forecast => {
                forecast = JSON.parse(forecast);
                res.appendChild(CreateDivForecast(forecast));
            });
        }
        else if (data.cod == '404') {
            res.appendChild(CreateDiv404());
        }
        else {
            alert(data.message)
        }
    });


});
function QueryUser(url, data) {
    fetch(url).then(function (response) {
        response.json().then(data)
    });

}
function CreateDivWeather(data) {
    let d = document.createElement('div');
    d.className = 'weatherCity';
    d.innerHTML = `
    <div id="header">
                <p id="city">${data.name}</p>
                <p id="date">${new Date().toLocaleDateString()}</p>
            </div>
            <div class="content">
                <div class="weather">
                    <p>${data.weather[0].main}</p>
                    <img src=" http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png" alt="">
                </div>
                <p class="temperature">${data.main.temp}<sup>o</sup> C</p>
                <div class="temperature_details">
                    <p>Min temperature: ${data.main.temp_min}</p>
                    <p>Max temperature: ${data.main.temp_max}</p>
                    <p>Wind speed(km/h): ${data.wind.speed}</p>
                </div>
            </div>`;
    return d;
}
function CreateDivForecast(data) {
    let d = document.createElement('div');
    d.className = 'weatherCity';
    d.innerHTML = `
    <table>
                <caption>Hourly</caption>
                <thead>
                    <tr>
                        <th>${GetDays()}</th>
                        <th>${data.list[0].dt_txt.split(' ')[1]}</th>
                        <th>${data.list[1].dt_txt.split(' ')[1]}</th>
                        <th>${data.list[2].dt_txt.split(' ')[1]}</th>
                        <th>${data.list[3].dt_txt.split(' ')[1]}</th>
                        <th>${data.list[4].dt_txt.split(' ')[1]}</th>
                        <th>${data.list[5].dt_txt.split(' ')[1]}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td></td> 
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[0].weather[0].icon}@2x.png" alt=""></td> 
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[1].weather[0].icon}@2x.png" alt=""></td>
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[2].weather[0].icon}@2x.png" alt=""></td>
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[3].weather[0].icon}@2x.png" alt=""></td> 
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[4].weather[0].icon}@2x.png" alt=""></td>
                        <td><img src=" http://openweathermap.org/img/wn/${data.list[5].weather[0].icon}@2x.png" alt=""></td> 
                    </tr>
                    <tr>
                        <td>Forecast</td> 
                        <td>${data.list[0].weather[0].main}</td> 
                        <td>${data.list[1].weather[0].main}</td>
                        <td>${data.list[2].weather[0].main}</td> 
                        <td>${data.list[3].weather[0].main}</td>
                        <td>${data.list[4].weather[0].main}</td>
                        <td>${data.list[5].weather[0].main}</td> 
                    </tr>
                    <tr>
                        <td>Temp(<sup>o</sup> C)</td>
                        <td>${data.list[0].main.temp}</td>
                        <td>${data.list[1].main.temp}</td>
                        <td>${data.list[2].main.temp}</td>
                        <td>${data.list[3].main.temp}</td>
                        <td>${data.list[4].main.temp}</td>
                        <td>${data.list[5].main.temp}</td> 
                    </tr>
                    <tr>
                        <td>Wind (km/h)</td>
                        <td>${data.list[0].wind.speed}</td>
                        <td>${data.list[1].wind.speed}</td>
                        <td>${data.list[2].wind.speed}</td>
                        <td>${data.list[3].wind.speed}</td>
                        <td>${data.list[4].wind.speed}</td>
                        <td>${data.list[5].wind.speed}</td> 
                    </tr>
                </tbody>
            </table>`;
    return d;
}
function CreateDiv404() {
    let d = document.createElement('div');
    d.className = 'class404';
    d.innerHTML = `
        <p class="color_orange">404</p>
        <p>NOT FOUND</p>
        <p>Please enter different city</p>`;
    return d;
}
function GetDays() {
    var days = [
        'Sunday',
        'Monday',
        'Tuesday',
        'Wednesday',
        'Thursday',
        'Friday',
        'Saturday'
    ];
    var d = new Date();
    var n = d.getDay();
    return days[n];
}