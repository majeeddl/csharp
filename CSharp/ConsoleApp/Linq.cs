using System.Collections.Generic;
using System.Linq;

namespace Linq
{

    public class  Query{

        public static void Run(){


            var books = new BookRepository().GetBooks();


            //LINQ Extension Expression
            var getBook = books.SingleOrDefault(b => b.Title == "ADO");


            var getFirstBook = books.FirstOrDefault(b => b.Title == "C# advanced topic");


            var getLastBook = books.LastOrDefault(b => b.Title == "C# advanced topic");


            var getSkipTakeBook = books.Skip(2).Take(3);

            //WE also have a bunch of aggregate functions like we have in SQL
            var countBooks = books.Count();

            var max  = books.Max(b => b.Price);


        }
    }
    

    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book> {
                new Book(){ Title= "ADO" , Price = 5},
                new Book(){ Title= " ASP.net mvc" , Price = 9.99f},
                new Book(){ Title= "ASP.NET Web API" , Price = 12},
                new Book(){ Title= "C# advanced topic" , Price = 7},
                 new Book(){ Title= "C# advanced topic" , Price = 9},
            };
        }
    }


}