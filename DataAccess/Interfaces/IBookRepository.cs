using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();

        Book GetBookByID(int Id);

        void AddBook(Book book);

        void DeleteBook(int bookId);

        void UpdateBook(Book book);

        void Save();
    }
}
