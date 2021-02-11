using System.Collections.Immutable;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {   
        }

        public DbSet<Value> Values { get; set; } //values is the table name

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );

             builder.Entity<Author>()
                .HasData(
                    new Author{Id=1, FirstName="André", LastName="Lopes" },
                    new Author{Id=2, FirstName="Rui", LastName="Antunes" }
                );
            builder.Entity<Book>()
                .HasData(
                    new Book {Id=1, Title="Adventures of Mark", AuthorId = 1},
                    new Book {Id=2, Title="new Bible", AuthorId= 1},
                    new Book {Id=3, Title="Born to be alive", AuthorId = 2},
                    new Book {Id=4, Title="Being Portuguese", AuthorId = 2}
                );
           
        }
    }
}
