﻿using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book>Books { get; set; }
        public DbSet<BookAuthors> BookAuthors{ get; set; }
        public DbSet<BookLanguages> BookLanguages { get; set; }
        public DbSet<Language> languages { set; get; }
        public DbSet<Publisher> Publishers { get; set; }


        public ApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookAuthors>().HasKey(vf => new { vf.BookID, vf.AuthorID});
            modelBuilder.Entity<BookLanguages>().HasKey(vf => new { vf.BookID, vf.LangID});


        }
    }
}