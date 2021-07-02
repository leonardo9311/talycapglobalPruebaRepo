using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talycapglobalPrueba.Core.Interfaces.Services
{
    public interface ISyncService
    {
        Task SyncAuthors();
        Task SyncBooks();
        Task SyncBooksAndAuthors();
    }
}
