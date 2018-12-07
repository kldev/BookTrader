using System;
using System.Linq;
using BookTrader.Data.Model;

namespace BookTrader.Data.Predicates
{
    public static class BookPredicate
    {
        public static IQueryable<Book> FilterByTitleOrAuthor(this IQueryable<Book> books, String title, String author)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                books = books.Where(s => s.Title.StartsWith(title));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                books = books.Where(s => s.Author.StartsWith(author));
            }

            return books;
        }
    }
}