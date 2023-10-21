using BookStoreMvc.Models.Domain;
using BookStoreMvc.Models.DTO;
using BookStoreMvc.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookStoreMvc.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext ctx;
        public BookService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Book model)
        {
            try
            {

                ctx.Book.Add(model);
                ctx.SaveChanges();
                foreach (int genreId in model.Genres)
                {
                    var bookGenre = new BookGenre
                    {
                        BookId = model.Id,
                        GenreId = genreId
                    };
                    ctx.BookGenre.Add(bookGenre);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if(data == null)
                {
                    return false;
                }
                var bookGenres= ctx.BookGenre.Where(a => a.BookId == data.Id); 
                foreach(var bookGenre in bookGenres) 
                {
                    ctx.BookGenre.Remove(bookGenre);
                }
                ctx.Book.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book GetById(int id)
        {
            return ctx.Book.Find(id);
        }

       
        public BookListVm List()
        {
            var list = ctx.Book.ToList();
            foreach (var book in list)
            {
                var genres = (from genre in ctx.Genre
                              join bg in ctx.BookGenre
                              on genre.Id equals bg.GenreId
                              where bg.BookId == book.Id
                              select genre.GenreName
                              ).ToList();
                var genreNames = string.Join(",", genres);
                book.GenreNames = genreNames;
            }
            var data = new BookListVm
            {
                BookList = list.AsQueryable()
            };
            return data;
        }
        public bool Update(Book model)
        {
            try
            {
                //these genreIds are not selected by users and still present is bookGenre table corresponding 
                // to this bookId. So these ids should be removed.
                var genresToDeleted = ctx.BookGenre.Where(a => a.BookId == model.Id && !model.Genres.Contains(a.GenreId)).ToList();
                foreach(var bGenre in genresToDeleted)
                {
                    ctx.BookGenre.Remove(bGenre);
                }
                foreach(int genId in model.Genres)
                {
                    var bookGenre = ctx.BookGenre.FirstOrDefault(a => a.BookId == model.Id && a.GenreId == genId);
                    if(bookGenre == null)
                    {
                        bookGenre = new BookGenre { GenreId = genId, BookId = model.Id };
                        ctx.BookGenre.Add(bookGenre);
                    }
                }
                ctx.Book.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<int> GetGenreByBookId(int bookId)
        {
            var genreIds = ctx.BookGenre.Where(a => a.BookId == bookId).Select(a => a.GenreId).ToList();
            return genreIds;
        }
    }
}
