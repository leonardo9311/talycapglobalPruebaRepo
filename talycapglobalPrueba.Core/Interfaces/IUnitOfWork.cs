using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces.Repository;


namespace talycapglobalPrueba.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> _bookRepository { get; }
        IRepository<Author> _AuthorRepository { get; }
        IThirdApiRepository _ThirdApiRepository { get; }
    }
}
