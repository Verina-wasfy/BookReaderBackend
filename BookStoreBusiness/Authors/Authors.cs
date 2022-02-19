using BookStore.Model.CustomEntities;
using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Authors
{
    public class Authors:IAuthors
    {
        private readonly ApiDbContext _db;
        public Authors(ApiDbContext db)
        {
            _db = db;

        }

        public List<BookAuthorsEntity> GetAllAuth()
        {

            var AllData = (from Auth in _db.Authors

                           select new BookAuthorsEntity()
                           {
                               AuthName=Auth.FirstName+" "+Auth.LastName,
                               
                               AuthorID=Auth.AuthorID
                           }).ToList();

            return AllData;
        }
    }
}
