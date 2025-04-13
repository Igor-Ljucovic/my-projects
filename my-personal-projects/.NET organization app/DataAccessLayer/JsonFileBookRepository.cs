using Domain05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JsonFileBookRepository : IBookRepository
    {
        private List<Book> books;
        public JsonFileBookRepository()
        {
            Console.WriteLine("ctor: JsonFileBookRepository()");
            string booksJson = File.ReadAllText("C:\\Users\\tanja\\Desktop\\booksCase.json");
            this.books = JsonSerializer.Deserialize<List<Book>>(booksJson);
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
            
        }
    }
}
