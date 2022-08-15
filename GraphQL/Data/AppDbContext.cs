using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Book>()
        //        .HasMany(book => book.Authors)
        //        .WithOne(book => book.Book!)
        //        .HasForeignKey(book => book.BookId);

        //    modelBuilder
        //        .Entity<Author>()
        //        .HasOne(author => author.Book)
        //        .WithMany(author => author.Authors)
        //        .HasForeignKey(author => author.BookId);
        //}


    }
}