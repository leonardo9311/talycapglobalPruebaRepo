using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces;
using talycapglobalPrueba.Core.Interfaces.Repository;

namespace talycapglobalPrueba.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Book> _bookRepository { get; }

        public IRepository<Author> _AuthorRepository { get; }

        public IThirdApiRepository _ThirdApiRepository { get; }

        public UnitOfWork(IRepository<Book> bookRepository,
                          IRepository<Author> authorRepository,
                          IThirdApiRepository thirdApiRepository)
        {
            _bookRepository = bookRepository;
            _AuthorRepository = authorRepository;
            _ThirdApiRepository = thirdApiRepository;
        }
    }
}
