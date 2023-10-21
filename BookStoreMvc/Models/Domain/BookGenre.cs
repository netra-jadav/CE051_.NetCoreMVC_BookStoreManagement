namespace BookStoreMvc.Models.Domain
{
    public class BookGenre
    {
        //We are mapping Genere and Book here with 1 to many relationship

        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
