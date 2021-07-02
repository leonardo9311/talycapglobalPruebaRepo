using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Interfaces;
using talycapglobalPrueba.Core.Interfaces.Services;

namespace talycapglobalPrueba.Infraestructure.Services
{
    public class SyncService : ISyncService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SyncService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task SyncAuthors()
        {
           var authors = await _unitOfWork._ThirdApiRepository.GetAuthors();
           var IdExist = _unitOfWork._AuthorRepository.ListAsync().Select(a=>a.Id);
           var authorsToUpdate = authors.Distinct().Where(s => IdExist.Any(id => s.Id == id)).ToList();
           var authorsToCreate = authors.Distinct().Where(s => !IdExist.Any(id => s.Id == id)).ToList();

            await _unitOfWork._AuthorRepository.UpdateRange(authorsToUpdate);
            await _unitOfWork._AuthorRepository.AddRange(authorsToCreate);
        }

        public async Task SyncBooks()
        {
            var books = await _unitOfWork._ThirdApiRepository.GetBooks();
            var IdExist = _unitOfWork._bookRepository.ListAsync().Select(a => a.Id);
            var booksToUpdate = books.Distinct().Where(s => IdExist.Any(id => s.Id == id)).ToList();
            var BookToCreate = books.Distinct().Where(s => !IdExist.Any(id => s.Id == id)).ToList();

            await _unitOfWork._bookRepository.UpdateRange(booksToUpdate);
            await _unitOfWork._bookRepository.AddRange(BookToCreate);
        }

        public async Task SyncBooksAndAuthors()
        {
            await SyncBooks();
            await SyncAuthors();
        }
    }
}

