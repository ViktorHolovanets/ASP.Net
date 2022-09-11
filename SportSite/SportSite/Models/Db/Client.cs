using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models.Db
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Account Account { get; set; }
        public List<TimeOfWork> dateOfTraining { get; set; } = new();
    }
}
