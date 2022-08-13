using MySinoptik.Lib;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.Run(async (context) =>
{
    var path = context.Request.Path;
    if (path == "/")
    {
        await context.Response.SendFileAsync("html/index.html");
    }
    else if(path == "/weather"|| path == "/forecast")
    {
        string url = "https://api.openweathermap.org/data/2.5" + context.Request.Path + context.Request.QueryString;
        await context.Response.WriteAsJsonAsync(Functions.GetJsonRespons(url));
    }
});
app.Run();
