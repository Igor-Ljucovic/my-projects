using Domain05;

namespace DataAccessLayer
{
    public class InMemoryBookRepository : IBookRepository
    {
        private List<Book> books;
        public InMemoryBookRepository()
        {
            Console.WriteLine("ctor: InMemoryBookRepository()");
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Book1",
                PublicationYear = 1999,
                Author = new Author
                {
                    Id = 1,
                    FirstName = "Autor1",
                    LastName = "LastNameAuthor1"
                }
            });
            books.Add(new Book
            {
                Id = 2,
                Title = "Book1",
                PublicationYear = 2020,
                Author = new Author
                {
                    Id = 1,
                    FirstName = "Autor1",
                    LastName = "LastNameAuthor1"
                }
            });
            books.Add(new Book
            {
                Id = 3,
                Title = "Book3",
                PublicationYear = 1975,
                Author = new Author
                {
                    Id = 2,
                    FirstName = "Autor2",
                    LastName = "LastNameAuthor2"
                }
            });
        }

        public List<Book> GetAll()
        {
            return books;
        }
        public Book GetById(int id)
        {
            return books.SingleOrDefault(b => b.Id == id);
        }
        public List<Book> Search(Func<Book, bool> uslov)
        {
            return books.Where(uslov).ToList();
        }
        public void Add(Book b)
        {
            books.Add(b);
        }
    }
}