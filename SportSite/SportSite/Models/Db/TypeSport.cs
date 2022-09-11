using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models.Db
{
    public class TypeSport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public List<Trainer>? trainers { get; set; } = new ();
        public string? Image { get; set; }
        
    }
}
