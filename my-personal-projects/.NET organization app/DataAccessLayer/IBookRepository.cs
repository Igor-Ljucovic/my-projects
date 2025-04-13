using Domain05;

namespace DataAccessLayer
{
    public interface IBookRepository
    {
        void Add(Book b);
        List<Book> GetAll();
        Book GetById(int id);
        List<Book> Search(Func<Book, bool> uslov);
    }
}