using BookStore.Model.CustomEntities;
using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Publishers
{
   public class Publishers:IPublishers
    {
        private readonly ApiDbContext _db;
        public Publishers(ApiDbContext db)
        {
            _db = db;

        }

        public List<PublishersEntity> GetAllPublish()
        {

            var AllData = (from Pub in _db.Publishers

                           select new PublishersEntity()
                           {
                               PublID= Pub.PublisherID,
                               PublisherName= Pub.PublisherName
                           }).ToList();

            return AllData;
        }
    }
}
