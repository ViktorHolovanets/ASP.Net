using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MVC_Bind.Models
{
    public class Account
    {
        public string? Id { get; set; }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public User? Client { get; set; }
        public DateTime CreateAcountDate{ get; set; }
    }
}
