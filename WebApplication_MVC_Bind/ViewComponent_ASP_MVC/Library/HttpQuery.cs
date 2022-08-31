namespace ViewComponent_ASP_MVC.Library
{
    public class HttpQuery
    {
        public static string GetResponse(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            string result="";
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
