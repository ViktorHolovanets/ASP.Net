﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models.Db
{
    
    public enum TypeTraining
    {
        [Display(Name = "Group training")]
        Group,
        [Display(Name = "Individual training")]
        Individual
    }
    public class Training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public List<DayOfWeekTraining> dayofWeeks { get; set; } = new();
        public TypeTraining training { get; set; }=TypeTraining.Group;
        [Required]
        public Coach? coach { get; set; }
        public Client? Client { get; set; }
    }
}
