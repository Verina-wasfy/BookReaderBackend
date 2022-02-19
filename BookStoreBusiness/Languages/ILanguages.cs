using BookStore.Model.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Languages
{
    public interface ILanguages
    {
        List<BookLanguagesEntity> GetAllLang();
    }
}
