using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Models;

namespace Task_WebApi_Core_With_Identity.Interfaces
{
    public interface IBook
    {
        public List<Book> GetAllbooks();
        public Book getById(int id);
        public Book AddBook(Book b);
        public Book EditBook(int id, Book b);
        public Book DeleteBook(int id);
    }
}
