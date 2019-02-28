using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrader.Data.Model;
using BookTrader.Data.Predicates;
using Microsoft.EntityFrameworkCore;

namespace BookTrader.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository 
    {
        public BookRepository(BookTraderContext context) : 
            base(context)
        {
        }

        public async Task<string> AddAsync(Book book)
        {
            if (string.IsNullOrEmpty(book.Id)) book.Id = Guid.NewGuid().ToString("N");

            Context.Books.Add(book);

            await Context.SaveChangesAsync();
            return await Task.FromResult(book.Id);
        }

        public async Task<bool> UpdateSoldAsync(string id, int soldCount)
        {
            var book = Context.Books.FirstOrDefault(x => x.Id.Equals(id));

            if (book != null)
            {
                book.SoldCount = soldCount;
                Context.Update(book);
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found by Id", nameof(id));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {

            var book = Context.Books.FirstOrDefault(x => x.Id.Equals(id));

            if (book != null)
            {
                Context.Remove(book);
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found by Id", "Id");
            }


            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateBookAsync(string id, string author, string title)
        {

            var book = Context.Books.FirstOrDefault(x => x.Id.Equals(id));

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

                Context.Update(book);
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found by Id", "Id");
            }

            return await Task.FromResult(true);

        }

        public async Task<List<Book>> TraderBooksAsync(string traderId, string title = null, string author = null)
        {

            return await Context.Books.Where(x => x.TraderId.Equals(traderId))
                .FilterByTitleOrAuthor(title, author).ToListAsync();
        }

        public async Task<Book> GetAsync(string id)
        {
            return await Context.Books.FirstOrDefaultAsync(x => x.Id.Equals(id));
           
        }
    }
}