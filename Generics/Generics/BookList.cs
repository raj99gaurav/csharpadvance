using System;

namespace Generics
{
    public class BookList
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericDictionary<TKey, TValue> //GenericDictionary
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    public class GenericList<T> //GenericList
    {
        public void Add(T value) // we dont know what T is yet
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}