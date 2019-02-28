using System;
using System.Collections.Generic;
using BookTrader.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookTrader.Data.Util
{
    public static class DatabaseSeedUtil
    {
        private static readonly Random _random = new Random();
        
        /// <summary>
        /// Delete all table data
        /// </summary>
        public static void DropData(String connectionString = null)
        {
            var tables = new string[] {"bt_book", "bt_trader"};

            using (var context = connectionString != null ? new BookTraderContext(connectionString) : new BookTraderContext())
            {
                foreach (var table in tables)
                {
                    try
                    {                        
                        context.Database.ExecuteSqlCommand($"DELETE FROM {table} CASCADE ");
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        ILogger logger = BookTraderContext.ConsoleLoggerFactory.CreateLogger(nameof(DatabaseSeedUtil));
                        logger.LogError($"Can not delete table {table}. Message {ex.Message}");
#endif                        
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        ///  create random books
        /// </summary>
        /// <param name="traderId"></param>
        /// <returns></returns>
        private static List<Book> CreateTraderBooks(string traderId){
        
            var authors = new String[] {"First Author", "Second Author", "Third Author" };
            var books = new List<Book>();
            var i = 0;
            
            while (i++ < 500)
            {
                var bookId = Guid.NewGuid().ToString("N");
                books.Add(new Book
                {
                    Id = bookId,
                    SoldCount = _random.Next(10, 100),        
                    Price = 0.25M*_random.Next(10,50),
                    Added = DateTime.Now.AddDays(-1 * _random.Next(1, 31)),
                    Title = "The book title: " + bookId,
                    Author = authors[_random.Next(0, authors.Length-1)], 
                    TraderId =  traderId,
                });
            }

            return books;
        }

        public static void SeedData()
        {
            using (var context = new BookTraderContext())
            {
                var traderGuid = Guid.NewGuid().ToString("N");
                var bookList = CreateTraderBooks(traderGuid);

                var trader = new Trader
                {
                    Id = traderGuid,
                    Name = "Test",
                    Lastname = "Trader",
                    BookList = bookList
                };


                context.Traders.Add(trader);
                context.SaveChanges();
            }
        }

    }
}