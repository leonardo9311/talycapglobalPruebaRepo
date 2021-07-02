using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;

namespace talycapglobalPrueba.Core.Interfaces.Services
{
   public  interface IAuthorService 
    {
        List<Author> GetAllAuthor();
        Author GetById(int id);
        List<Author> GetByIds(List<int> ids);
    }
}
