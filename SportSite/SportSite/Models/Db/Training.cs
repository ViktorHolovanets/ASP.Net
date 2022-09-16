using Microsoft.EntityFrameworkCore;
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
    public class Training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public List<DayofWeekTraining> dayofWeeks { get; set; } = new();
        public TypeTraining training { get; set; }
        [Required]
        public Coach? coach { get; set; }
    }
}
