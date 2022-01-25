
// What is a Lambda Expression?

// An anonymous method : 
//      1. No access modifier
//      2. No name
//      3. No return statement


/*

Why do we use them?

For convenience



*/
using System;
using System.Collections.Generic;

namespace ConsoleApp
{

    public class Lambda
    {

        static void Main()
        {

            // Lmabda expression
            // () => ...
            // x => ...
            Func<int, int> square = number => number * number;

            System.Console.WriteLine(square(5));


            const int factor = 5;

            Func<int, int> multipler = n => n * factor;

            Console.WriteLine(multipler(10));


            var books = new BookRepository().GetBooks();

            var cheapBooks = books.FindAll(book => book.Price < 1500);

            foreach( var book in cheapBooks){
                System.Console.WriteLine(book.Title);
            }

        }

        // number => number*number
        static int Square(int number)
        {
            return number * number;
        }




    }


    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

    public class BookRepository
    {


        public List<Book> GetBooks()
        {
            return new List<Book>{
                new Book(){ Title ="title 1" , Price = 1200},
                new Book(){ Title = "title 2", Price = 2500}
            };
        }
    }
}