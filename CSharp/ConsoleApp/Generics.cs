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

   // T is a parameter
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

    // Generics dictionary
    public class GenericDictionary<TKey,TValue>{
        public void Add(TKey key, TValue value){

        }
    }
}