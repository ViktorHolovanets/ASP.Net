using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebShop.Entities.DB
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
