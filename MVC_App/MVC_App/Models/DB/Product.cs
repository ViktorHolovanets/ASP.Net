using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_App.Models.DB
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public Category? category { get; set; }
        public string? Details { get; set; }
    }
}
