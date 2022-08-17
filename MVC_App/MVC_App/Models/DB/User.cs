using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_App.Models.DB
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
