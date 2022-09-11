using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models.Db
{
    public enum TypeTraining
    {
        [Display(Name = "Group training")]
        group_training,
        [Display(Name = "Individual training")]
        individual_training
    }
    public class TimeOfWork
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public TypeTraining training { get; set; }
        public Trainer Trainer { get; set; }
    }
}
