using System;

namespace Generics
{


    public class Book
    {

    }
    public class BookList
    {
        public void Add(Book book)
        {

        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericsList<T>
    {

        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}