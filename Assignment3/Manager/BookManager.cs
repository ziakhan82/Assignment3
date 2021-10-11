using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment3.Manager
{
    class BookManager
    {
        private static List<Book> _Books = new List<Book>() {
            new Book ("c# programming","Tom",200,"978-3-16-148410-0"),
            new Book ("Java","Zia",300,"977-3-16-158410-0"),
            new Book ("c++","khan",400,"976-3-16-168410-0")
            };
        public List<Book> GetAll()
        {
            return new List<Book>(_Books);


        }
        public Book Get(String ISBN13)
        {
            return _Books.Find(book => book.ISBN13 == ISBN13);
        }
        public Book Save(Book book)
        {
            var _book = _Books.Find(boook => boook.ISBN13 == book.ISBN13);
            if (_book == null)
            {

                _Books.Add(book);

                return book;
            }
            return null;
        }
    }
}
