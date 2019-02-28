using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookTrader.Data.Model;

namespace BookTrader.Data.Repository
{
    public interface IBookRepository
    {
        Task<String> AddAsync(Book book);
        Task<bool> UpdateSoldAsync(string id, int soldCount);
        Task<bool> DeleteAsync(String id);
        Task<bool> UpdateBookAsync(String id, String author, String title);
        Task<List<Book>> TraderBooksAsync(String traderId, String title = null, String author = null);
        Task<Book> GetAsync(String id);
    }
}