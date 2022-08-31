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
            return $"Ip: {JsonSerializer.Deserialize<ResultMyIp>(HttpQuery.GetResponse("https://api.ipify.org/?format=json")).ip}";
        }
    }
}
