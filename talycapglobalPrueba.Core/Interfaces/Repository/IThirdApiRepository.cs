using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;

namespace talycapglobalPrueba.Core.Interfaces.Repository
{
   public  interface IThirdApiRepository
    {
        Task<List<Book>> GetBooks();
        Task<List<Author>> GetAuthors();
    }
}
