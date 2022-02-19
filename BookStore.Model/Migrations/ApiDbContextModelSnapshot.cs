﻿// <auto-generated />
using System;
using BookStore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Model.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorID", "BooksBookID");

                    b.HasIndex("BooksBookID");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookLanguage", b =>
                {
                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.Property<int>("LanguagesLangID")
                        .HasColumnType("int");

                    b.HasKey("BooksBookID", "LanguagesLangID");

                    b.HasIndex("LanguagesLangID");

                    b.ToTable("BookLanguage");
                });

            modelBuilder.Entity("Bookstore.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookstore.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AvgRating")
                        .HasColumnType("real");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NumberPages")
                        .HasColumnType("float");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<double>("RatingCount")
                        .HasColumnType("float");

                    b.Property<double>("TextReviewsCount")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookstore.Models.BookAuthors", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Bookstore.Models.BookLanguages", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("LangID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "LangID");

                    b.HasIndex("LangID");

                    b.ToTable("BookLanguages");
                });

            modelBuilder.Entity("Bookstore.Models.Language", b =>
                {
                    b.Property<int>("LangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LangName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LangID");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("Bookstore.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherID");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Bookstore.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookLanguage", b =>
                {
                    b.HasOne("Bookstore.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookstore.Models.Book", b =>
                {
                    b.HasOne("Bookstore.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Bookstore.Models.BookAuthors", b =>
                {
                    b.HasOne("Bookstore.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookstore.Models.BookLanguages", b =>
                {
                    b.HasOne("Bookstore.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Bookstore.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
