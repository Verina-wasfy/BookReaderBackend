using Bookstore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Globalization;
using BookStore.Model.Entities;
using Bookstore.Entity;
using BookStore.Model.CustomEntities;
using Bookstore.Models;

namespace Bookstore.Services
{
    public class Books:IBooks
    {
        private readonly ApiDbContext _db;
        public Books(ApiDbContext db)
        {
            _db = db;

        }

        public List<BooksEntity> GetAllBooks()
        {
            var AllData = (from Book in _db.Books
                           join Publisher in _db.Publishers
                           on Book.PublisherID equals Publisher.PublisherID
                           join Lang in _db.languages
                           on Book.LanguageID equals Lang.LangID
                           select new BooksEntity()
                           {
                               BookID=Book.BookID,
                                AvgRating=Book.AvgRating,
                                NumberPages=Book.NumberPages,
                                ISBN13=Book.ISBN13,
                                ISBN=Book.ISBN,
                                PublicationDate=Book.PublicationDate.ToString(),
                                PublisherID=Book.PublisherID,
                                PublisherName=Publisher.PublisherName,
                                RatingCount=Book.RatingCount,
                                Title=Book.Title,
                                TextRreviewsCount=Book.TextReviewsCount,
                                LangID=Lang.LangID,
                                LangName=Lang.LangName,
                                BookAuth=(from Bk in _db.Books
                                             join BkAuth in _db.BookAuthors
                                             on Bk.BookID equals BkAuth.BookID
                                             where Book.BookID == Bk.BookID
                                             select new BookAuthorsEntity() { 
                                                 AuthorID=BkAuth.AuthorID,
                                                AuthName=(BkAuth.Author.FirstName+" "+ BkAuth.Author.LastName),
                                             }).ToList()
                                             

                           }).ToList();

          
            return AllData;
        }


        public int DeleteBook(int Id)
        {
            try
            {
                var Data = (from Book in _db.Books
                              where Id == Book.BookID
                              select Book).FirstOrDefault();

                if (Data != null)
                {
                    var BookAuth = (from BkAuth in _db.BookAuthors
                                    
                                     where BkAuth.BookID == Id 
                                     select BkAuth
                                      ).ToList();

                    foreach (var BookData in BookAuth)
                    {
                        _db.BookAuthors.Remove(BookData);
                    }

                 
                    _db.SaveChanges();


                }
                _db.Books.Remove(Data);
                _db.SaveChanges();
                return 1;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveBook (BooksEntity BookData)
        {
            try
            {

                var DateConversion = Convert.ToDateTime(BookData.PublicationDate);
                //var RatingConversion = float.Parse(BookData.AvgRating);
              
                    //DateTime.ParseExact(BookData.PublicationDate, "dd/MM/yyyy",null);

                var NewBook = (from Bk in _db.Books
                                  where BookData.BookID == Bk.BookID
                                  select Bk).FirstOrDefault();


                if (NewBook == null)//new 
                {
                    NewBook = new Book()
                    {
                        Title = BookData.Title,
                        AvgRating = BookData.AvgRating,
                        ISBN = BookData.ISBN,
                        ISBN13 = BookData.ISBN13,
                        NumberPages = BookData.NumberPages,
                        PublicationDate = DateConversion,
                        RatingCount = BookData.RatingCount,
                        TextReviewsCount = BookData.TextRreviewsCount,
                        PublisherID = BookData.PublisherID,
                        LanguageID=BookData.LangID
                    };

                    _db.Books.Add(NewBook);
                    _db.SaveChanges();
                   

                    foreach (var Item in BookData.BookAuth)
                    {
                        _db.BookAuthors.Add(new BookAuthors()
                        {
                            AuthorID = Item.AuthorID,
                            BookID = NewBook.BookID
                        });
                    };

                   

                }
                else //edit
                {
                    NewBook.Title = BookData.Title;
                    NewBook.NumberPages = BookData.NumberPages;
                    NewBook.ISBN = BookData.ISBN;
                    NewBook.ISBN13 = BookData.ISBN13;
                    NewBook.PublicationDate = DateConversion;
                    NewBook.RatingCount = BookData.RatingCount;
                    NewBook.TextReviewsCount = BookData.TextRreviewsCount;
                    NewBook.PublisherID = BookData.PublisherID;
                    NewBook.AvgRating = BookData.AvgRating;
                    NewBook.LanguageID = BookData.LangID;
                    var BookAuth = (from Bk in _db.Books
                                    join BkAth in _db.BookAuthors
                                    on Bk.BookID equals BkAth.BookID
                                    where BookData.BookID == BkAth.BookID
                                    select new BookAuthors() { AuthorID = BkAth.AuthorID }).ToList();
                    foreach (var Item in BookData.BookAuth)
                    {
                        if (Item.DML == "add")
                        {
                            _db.BookAuthors.Add(new BookAuthors()
                            {
                                AuthorID = Item.AuthorID,
                                BookID = BookData.BookID
                            });
                        }
                        else if (Item.DML == "delete")
                        {
                            var Info = (from Authr in _db.BookAuthors
                                        where Authr.AuthorID == Item.AuthorID && Authr.BookID == BookData.BookID
                                        select Authr).ToList();

                            if (Info.Count > 0)
                            {
                                // failed delete
                                return 3;
                            }
                            else
                            {
                                var Detail = (from Auth in _db.BookAuthors
                                              where Auth.AuthorID == Item.AuthorID && Auth.BookID == BookData.BookID
                                              select Auth).FirstOrDefault();
                                _db.BookAuthors.Remove(Detail);
                            }
                        }


                       

                    }
                }
                _db.SaveChanges();

                return 1;
            }

            catch(Exception ex)
            {
                return 0;
            }
        }

    }
}
