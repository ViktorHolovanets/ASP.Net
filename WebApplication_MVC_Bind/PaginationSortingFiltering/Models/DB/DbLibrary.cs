using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace PaginationSortingFiltering.Models.DB
{
    public class DbLibrary : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public DbLibrary(DbContextOptions<DbLibrary> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public ViewSortPage? GetBooksSort(ViewSortPage? viewSortPage)
        {
            var book = GetBooks(viewSortPage!.Categori);
            book = viewSortPage?.sortState switch
            {
                SortState.TitleAsc => book = book.OrderBy(b => b.Title),
                SortState.TitleDesc => book = book.OrderByDescending(b => b.Title),
                SortState.AuthorAsc => book.OrderBy(b => b.Authors),
                SortState.AuthorDesc => book.OrderByDescending(b => b.Authors),
            };
            if (viewSortPage.IsSort)
            {
                viewSortPage.sortState= viewSortPage?.sortState switch
                {
                    SortState.TitleAsc => SortState.TitleDesc,
                    SortState.TitleDesc => SortState.TitleAsc,
                    SortState.AuthorAsc => SortState.AuthorDesc,
                    SortState.AuthorDesc => SortState.AuthorAsc,

                };
            }
            int count = book.Count();
            viewSortPage.TotalPages = count % 6 == 0 ? count / 6 : count / 6 + 1;
            viewSortPage.Books = book.Skip((viewSortPage.Page * 6)).Take(6);
            return viewSortPage;
        }

        public IEnumerable<Book> GetBooks(Categories? categories)
        {
            IQueryable<Book> books = Books;
            if (categories != null)
                books = Books.Where(c => c.Categori == categories);
            if (books.Count() < 1)
            {
                AddBooks(categories);
                books = Books.Where(c => c.Categori == categories);
            }
            return books;
        }
        private async void AddBooks(Categories? categori)
        {
            if(categori == null) return;
            var res = await GetResponse($"https://openlibrary.org/subjects/{categori.ToString()}.json");
            JObject js = JObject.Parse(res);
            foreach (var item in js["works"])
            {
                var book = new Book()
                {
                    Title = item["title"].ToString(),
                    Authors = GetAuthors(item["authors"]),
                    Categori = categori,
                    Information = $"https://openlibrary.org{item["key"].ToString()}",
                    Image = $"https://covers.openlibrary.org/b/id/{item["cover_id"]}-M.jpg",
                };
                Books.Add(book);
                this.SaveChanges();
            }
        }

        private string GetAuthors(JToken? jToken)
        {
            string authors = "";
            foreach (var item in jToken)
            {
                authors = $" {authors} {item["name"]} ";
            }
            return authors;
        }

        public static async Task<string> GetResponse(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            string result = "";
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}
