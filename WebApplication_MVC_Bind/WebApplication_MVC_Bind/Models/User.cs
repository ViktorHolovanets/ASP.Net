using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication_MVC_Bind.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateTime Birthdate { get; set; }
    }
}
