using Bookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Services.Interface
{
    public interface IBooks
    {
         int DeleteBook(int Id);
        List<BooksEntity> GetAllBooks();
        int SaveBook(BooksEntity BookData);
    }
}
