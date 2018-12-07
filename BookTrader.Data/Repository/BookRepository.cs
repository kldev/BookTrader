using System;
using System.Collections.Generic;
using System.Linq;
using BookTrader.Data.Model;
using BookTrader.Data.Predicates;

namespace BookTrader.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        public string Add(Book book)
        {
            using (var context = new BookTraderContext())
            {
                if (string.IsNullOrEmpty(book.Id)) book.Id = Guid.NewGuid().ToString("N");
                
                context.Books.Add(book);

                context.SaveChanges();
                return book.Id;
            }
        }

        public void UpdateSold(string id, int soldCount)
        {
            using (var context = new BookTraderContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id.Equals(id));

                if (book != null)
                {
                    book.SoldCount = soldCount;
                    context.Update(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Book not found by Id", "Id");
                }
            }
        }

        public void Delete(string id)
        {
            using (var context = new BookTraderContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id.Equals(id));

                if (book != null)
                {
                    context.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Book not found by Id", "Id");
                }
            }
        }

        public void UpdateBook(string id, string author, string title)
        {
            using (var context = new BookTraderContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id.Equals(id));

                if (book != null)
                {
                    if (!string.IsNullOrWhiteSpace(author))
                    {
                        book.Author = author;
                    }

                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        book.Title = title;
                    }

                    context.Update(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Book not found by Id", "Id");
                }
            }
        }

        public List<Book> traderBooks(string traderId, string title = null, string author = null)
        {
            using (var context = new BookTraderContext())
            {
                return context.Books.Where(x=>x.TraderId.Equals(traderId))
                    .FilterByTitleOrAuthor(title, author).ToList();
            }
        }

        public Book GetOne(string id)
        {
            using (var context = new BookTraderContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id.Equals(id));

                return book;
            }
        }
    }
}