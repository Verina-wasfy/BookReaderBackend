using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookAuthors
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
