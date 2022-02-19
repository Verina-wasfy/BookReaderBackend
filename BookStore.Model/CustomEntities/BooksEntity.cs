using BookStore.Model.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Entity
{
    public class BooksEntity
    {
        public int BookID { set; get; }
        public string Title { set; get; }
        public int PublisherID { set; get; }
        public string PublisherName { set; get; }
        public string PublicationDate{ set; get; }
        public string ISBN { set; get; }
        public string ISBN13 { set; get; }
        public double NumberPages { set; get; }
        public float? AvgRating { set; get; }
        public double RatingCount { set; get; }
        public double TextRreviewsCount { set; get; }
        public int LangID { set; get; }
        public string LangName { set; get; }

        public List<BookAuthorsEntity>BookAuth{ set; get; }

    }
}
