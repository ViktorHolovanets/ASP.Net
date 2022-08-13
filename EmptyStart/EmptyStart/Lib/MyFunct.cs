using System.Text;

namespace EmptyStart.Lib
{
    public class MyFunct
    {
       static Random r = new Random();
        public static char GetRandomChar() => Convert.ToChar(r.Next(-1, 1) == 0 ? r.Next(65, 90) : r.Next(97, 122));

        public static List<Restoran> restorans = new List<Restoran>()
        {
            new Restoran("Restoran1", "type1", 15){Id=1},
            new Restoran("Restoran2", "type2", 15){Id=2},
            new Restoran("Restoran3", "type3", 6){Id=3},
            new Restoran("Restoran4", "type4", 7){Id=4},
            new Restoran("Restoran5", "type5", 157){Id=5},
            new Restoran("Restoran6", "type6", 8){Id=6}
        };

        public static async Task GetRestorans(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            var builder = new StringBuilder();
            builder.Append("<a href=\" / \">Home</a>");
            string q = context.Request.Query["id"];
            if (!String.IsNullOrEmpty(q))
            {
                try
                {
                    var res = restorans.FirstOrDefault(r =>
                        r.Id == Int32.Parse(q));
                    builder.Append("<br/><a href=\" /task3 \">Back</a>");
                    builder.Append($"<p>Name restoran: {res.Name}</p>");
                    builder.Append($"<p>Number of seats: {res.Number_of_Seats}</p>");
                    builder.Append($"<p>Type restoran: {res.Type}</p>");
                }
                catch
                { }
            }
            else
            {
                builder.Append("<p>Restorans:</p>");
                builder.Append("<ul>");
                foreach (var res in restorans)
                {
                    builder.Append($"<li><a href=\" /task3?id={res.Id} \">{res.Name}</a></li>");
                }
                builder.Append("</ul>");
            }
            await  context.Response.WriteAsync(builder.ToString());
        }
    }
}
