
using System.Collections.Generic;
using System.Linq;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces;
using talycapglobalPrueba.Core.Interfaces.Repository;
using talycapglobalPrueba.Core.Interfaces.Services;

namespace talycapglobalPrueba.Infraestructure.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBook()
        {
            return _bookRepository.ListAsync().ToList();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public List<Book> GetByIds(List<int> ids)
        {
            return _bookRepository.ListAsync().Where(s => ids.Any(i => i == s.Id)).ToList();
        }
    }
}
