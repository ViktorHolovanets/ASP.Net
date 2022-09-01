using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using ViewComponent_ASP_MVC.Library;

namespace ViewComponent_ASP_MVC.Models
{
    public class ResultUser
    {
        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [RegularExpression(@"^(female|male)$", ErrorMessage = "female / male")]
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

        public static ResultUser CreateUser()
        {
            try
            {
                var res = HttpQuery.GetResponse("https://randomuser.me/api/");
                JObject js = JObject.Parse(res);
                var user = new ResultUser()
                {
                    Age = Int16.Parse(js["results"][0]["dob"]["age"].ToString()),
                    Email = js["results"][0]["email"].ToString(),
                    Gender = js["results"][0]["gender"].ToString(),
                    FirstName = js["results"][0]["name"]["first"].ToString(),
                    LastName = js["results"][0]["name"]["last"].ToString(),
                    Phone = js["results"][0]["phone"].ToString(),
                    Image = js["results"][0]["picture"]["large"].ToString()
                };
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
