namespace Domain05
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"Book: {Id} {Title} {PublicationYear} Author: {Author.Id} {Author.FirstName} {Author.LastName}";
        }
    }
}