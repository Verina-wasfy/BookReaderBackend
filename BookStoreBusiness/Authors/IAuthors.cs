using BookStore.Model.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Authors
{
    public interface IAuthors
    {
        List<BookAuthorsEntity> GetAllAuth();
    }
}
