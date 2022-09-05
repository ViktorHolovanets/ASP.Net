using PaginationSortingFiltering.Models.DB;
using System.ComponentModel.DataAnnotations;

namespace PaginationSortingFiltering.Models
{
    public enum SortState
    {
        TitleAsc,
        TitleDesc,
        AuthorAsc,
        AuthorDesc,
    }
    public enum Categories
    {
        [Display(Name = "Mystery, Detective stories")]
        mystery_and_detective_stories,
        [Display(Name = "Romance")]
        romance,
        [Display(Name = "Poetry")]
        poetry,
        [Display(Name = "Fantasy")]
        fantasy
    }
    public class ViewSortPage
    {
        public IEnumerable<Book> Books { get; set; }
        public SortState? sortState { get; set; }
        public Categories? Categori { get; set; }
        public int Page { get; set; } = 0;
        public int TotalPages { get; set; }
        public bool IsSort { get; set; }
    }
}
