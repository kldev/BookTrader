using System;
using BookTrader.Data.Model;
using BookTrader.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace BookTrader.Data
{
    public class BookTraderContext : DbContext
    {
        public static string DEFAULT_CONNECTION_STRING = @"Host=localhost;Database=book;Username=postgres;Password=postgres";
        
        public virtual DbSet<Trader> Traders { get; set; }
        public virtual DbSet<Book> Books { get; set; }

                
#if DEBUG
        public static readonly LoggerFactory ConsoleLoggerFactory
            = new LoggerFactory(new[] { new DebugLoggerProvider() });
#endif
        
        private string _connectionString;

        public BookTraderContext()
        {
            
        }

        public BookTraderContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)                
        {
            if (!optionsBuilder.IsConfigured)
            {              
#if DEBUG    /// uncomment when needed
            /// optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);
#endif                
                if (string.IsNullOrEmpty(_connectionString))
                {

                    _connectionString = EnvironmentUtil.GetEnv("WEB_DB_CONN");
                    
                    if (string.IsNullOrEmpty(_connectionString))
                    {
#if DEBUG
                        _connectionString = DEFAULT_CONNECTION_STRING;
#else
                    throw new ArgumentException("Environment variable \"WEB_DB_CONN\" not set");
#endif
                    }

                  
                }
                
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trader>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id")
                    .IsRequired().HasMaxLength(100);
                
                entity.Property(e => e.Name)
                    .HasColumnName("name").HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .HasColumnName("last_name").HasMaxLength(100);

             
                entity.Property(e => e.EMail).HasColumnName("email").HasMaxLength(100);

                entity.Property(e => e.Password).HasColumnName("password").HasMaxLength(512);
                
                entity.HasMany(e => e.BookList).WithOne(s => s.Trader);
                
                entity.ToTable("bt_trader");

            });
            
            modelBuilder.Entity<Book>(entity =>
            {

                entity.Property(e => e.Id)
                    .HasColumnName("id").IsRequired().HasMaxLength(100);
                
                entity.Property(e => e.TraderId)
                    .HasColumnName("trader_id").IsRequired().HasMaxLength(100);
                
                
                entity.Property(e => e.Title)
                    .HasColumnName("title").IsRequired().HasMaxLength(200);
                
                entity.Property(e => e.Author)
                    .HasColumnName("author").IsRequired().HasMaxLength(200);

                entity.Property(e => e.SoldCount).HasColumnName("sold_count")
                    .HasDefaultValue(0);
                
                entity.Property(e => e.Price).HasColumnName("price")
                    .HasDefaultValue(0.0M);

                entity.Property(e => e.Added).HasColumnName("added");

                entity.HasOne(e => e.Trader).WithMany(s => s.BookList).HasForeignKey(e => e.TraderId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.ToTable("bt_book");
            });
        }
    }
}