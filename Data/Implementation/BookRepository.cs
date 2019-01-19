using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Implementation
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BooksEntities context;

        public BookRepository(BooksEntities context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Book.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            Book book = context.Book.Find(bookId);
            context.Book.Remove(book);
        }

        public Book GetBookByID(int bookId)
        {
            return context.Book.Include(b => b.Review)
                .FirstOrDefault(b => b.BookID == bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Book.ToList();
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

