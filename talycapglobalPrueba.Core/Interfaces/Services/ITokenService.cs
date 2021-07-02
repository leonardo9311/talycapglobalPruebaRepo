using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.DTO;

namespace talycapglobalPrueba.Core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<bool> IsValidUser(string userName, string password);
        Task<string> Authenticate(TokenAuthDTO toeknCredential);
    }
}
