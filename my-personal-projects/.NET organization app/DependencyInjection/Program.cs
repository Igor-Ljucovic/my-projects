using DataAccessLayer;
using Domain05;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<IBookRepository, JsonFileBookRepository>();

var app = builder.Build();

using var scope1 = app.Services.CreateScope();
var bookrepo = scope1.ServiceProvider.GetService<IBookRepository>();

foreach (Book b in bookrepo.GetAll())
    Console.WriteLine(b);
var bookrepo1 = scope1.ServiceProvider.GetService<IBookRepository>();

Book b1 = bookrepo1.GetById(2);
Console.WriteLine(b1);
using var scope2 = app.Services.CreateScope();
var bookrepo2 = scope2.ServiceProvider.GetService<IBookRepository>();
List<Book> booksSearch = bookrepo2.Search(b => b.Author.Id == 101);
booksSearch.ForEach(b => Console.WriteLine(b));

