using BookStoreMvc.Models.Domain;
using BookStoreMvc.Models.DTO;

namespace BookStoreMvc.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        Book GetById(int id);
        bool Delete(int id);
        BookListVm List();

        List<int> GetGenreByBookId(int bookId);

    }
}
