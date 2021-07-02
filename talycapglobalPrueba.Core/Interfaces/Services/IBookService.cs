using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;

namespace talycapglobalPrueba.Core.Interfaces.Services
{
    public interface IBookService
    {
        List<Book> GetAllBook();
        Book GetById(int id);
        List<Book> GetByIds(List<int> ids);
    }
}
