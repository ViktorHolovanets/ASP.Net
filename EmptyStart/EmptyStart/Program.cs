using EmptyStart.Lib;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run(async (context) =>
{
    var path=context.Request.Path;
    context.Response.ContentType = "text/html; charset=utf-8";
    var response = context.Response;
    switch (path)
    {
        case "/":
            await context.Response.SendFileAsync("html/index.html");
            break;
        case "/task1":
            await response.WriteAsync($"<a href=\" / \">Home</a><h2>{DateAndTime.Now.DayOfYear}</h2>");
            break;
        case "/task2":
            await response.WriteAsync($"<a href=\" / \">Home</a><h2>{MyFunct.GetRandomChar()}</h2>");
            break;
        case "/task3":
            await MyFunct.GetRestorans(context);
            break;
        case "/task5":
            await context.Response.SendFileAsync("html/country.html");
            break;
    }
});
app.Run();
