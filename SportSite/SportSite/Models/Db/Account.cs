using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models.Db
{
    public enum Role
    {
        Client,
        Trainer,
        Manager, 
        Admin
    }
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [Remote(action: "IsLogin", controller: "Home", ErrorMessage = "Incorrect login")]
        public string? Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public User? Client { get; set; }
        public Role Role { get; set; } = Role.Client;
    }
}
