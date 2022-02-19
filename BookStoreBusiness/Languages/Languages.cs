using BookStore.Model.CustomEntities;
using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Languages
{
    public class Languages:ILanguages
    {
        private readonly ApiDbContext _db;
        public Languages(ApiDbContext db)
        {
            _db = db;

        }

        public List<BookLanguagesEntity> GetAllLang()
        {

            var AllData = (from Lang in _db.languages

                           select new BookLanguagesEntity()
                           {
                               LangID = Lang.LangID,
                               LangName = Lang.LangName
                           }).ToList();

            return AllData;
        }
    }
}
