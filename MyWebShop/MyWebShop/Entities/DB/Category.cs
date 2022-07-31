using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebShop.Entities.DB
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
