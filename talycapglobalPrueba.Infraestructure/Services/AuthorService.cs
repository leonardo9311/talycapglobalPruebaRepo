using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces.Repository;
using talycapglobalPrueba.Core.Interfaces.Services;

namespace talycapglobalPrueba.Infraestructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public   List<Author> GetAllAuthor()
        {
            return  _authorRepository.ListAsync().ToList();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public List<Author> GetByIds(List<int> ids)
        {
            return _authorRepository.ListAsync().Where(s=>ids.Any(i=>i==s.Id)).ToList();
        }
    }
}
