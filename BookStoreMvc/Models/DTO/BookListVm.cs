using BookStoreMvc.Models.Domain;

namespace BookStoreMvc.Models.DTO
{
    public class BookListVm
    {
        public IQueryable<Book> BookList { get; set; }

    }
}
