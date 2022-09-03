using System.ComponentModel.DataAnnotations.Schema;

namespace Filters.Models.DB
{
    public class Visitor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Ip { get; set; }
        public string? Host { get; set; }
        public string? Url { get; set; }
        public DateTime Date { get; set; }
    }
}
