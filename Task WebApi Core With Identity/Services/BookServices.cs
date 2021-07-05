using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Models;

namespace Task_WebApi_Core_With_Identity.Services
{
    public class BookServices
    {
        private readonly MyDbContext _db;

        public BookServices(MyDbContext db)
        {
            _db = db;
        }
        //get All Books
        public List<Book> books()
        {
            return _db.Books.ToList();
        }
        //get book by id
        public Book getById(int id)
        {
           Book book= _db.Books.Where(a => a.BookId == id).FirstOrDefault();
            return book;
        }
        //Add Book
        public Book AddBook(Book b)
        {
            _db.Books.Add(b);
            _db.SaveChanges();
            return b;
        }
        //Edit Book
        public Book EditBook(int id,Book b)
        {
          Book book=  _db.Books.Where(a => a.BookId == id).FirstOrDefault();
            book.BookName = b.BookName;
            book.Description = b.Description;
            book.Discount = book.Discount;
            book.authorId = b.authorId;
            _db.SaveChanges();
            return book;
        }
        //delete Book
        public Book DeleteBook(int id)
        {
            Book book = _db.Books.Where(a => a.BookId == id).FirstOrDefault();
            _db.Books.Remove(book);
            _db.SaveChanges();
            return book;

        }
    }
}
