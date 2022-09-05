using System.ComponentModel.DataAnnotations.Schema;

namespace PaginationSortingFiltering.Models.DB
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public string? Image { get; set; }
        public string? Information { get; set; }
        public Categories? Categori { get; set; }
    }
}
