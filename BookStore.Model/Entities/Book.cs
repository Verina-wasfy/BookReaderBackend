using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { set; get; }

        [Required]
        public string Title { set; get; }

        public string ISBN { set; get; }

        public string ISBN13 { set; get; }
        public double NumberPages { set; get; }
        public float? AvgRating { set; get; }
        public double RatingCount { set; get; }
        public double TextReviewsCount { set; get; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { set; get; }

        [ForeignKey("Publisher")]
        public int PublisherID { set; get; }

        [ForeignKey("Language")]
        public int LanguageID { set; get; }

        public Publisher Publisher{ set; get; }

        public List<Author> Authors { set; get; }
        public Language Language { set; get; }
    }
}
