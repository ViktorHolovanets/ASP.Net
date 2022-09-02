using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ViewComponent_ASP_MVC.Library;
using ViewComponent_ASP_MVC.Models;

namespace ViewComponent_ASP_MVC.Componets
{
    public class MyIp : ViewComponent
    {
        public string Invoke()
        {
            var res = HttpQuery.GetResponse("https://api.ipify.org/?format=json");
            return $"Ip: {JsonSerializer.Deserialize<ResultMyIp>(res.Result).ip}";
        }
    }
}
