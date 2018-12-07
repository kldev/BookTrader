using System;
using System.Collections.Generic;
using BookTrader.Data.Model;

namespace BookTrader.Data.Repository
{
    public interface IBookRepository
    {
        string Add(Book book);
        void UpdateSold(String id, int soldCount);
        void Delete(String id);
        void UpdateBook(String id, String author, String title);
        List<Book> traderBooks(String traderId, String title = null, String author = null);
        Book GetOne(String id);
    }
}