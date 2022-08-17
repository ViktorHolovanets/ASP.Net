using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_App.Models.DB
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
