using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Poster { get; set; }
        public string? Released { get; set; }
        public string? Genre { get; set; }
        public string? Country { get; set; }
        public string? Director { get; set; }
        public string? Writer { get; set; }
        public string? Actors { get; set; }
        public string? Awards { get; set; }
    }
}
