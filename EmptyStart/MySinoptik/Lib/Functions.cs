using Newtonsoft.Json.Linq;
using RestSharp;

namespace MySinoptik.Lib
{
    public class Functions
    {
        public static string GetJsonRespons(string url)
        {
            RestClient client = new RestClient(url);
            RestRequest req = new RestRequest();
            var restRespons = client.Execute(req);
            var cod = restRespons.StatusCode;
            return restRespons.Content;
            //return JObject.Parse(restRespons.Content);
        }
    }

}
