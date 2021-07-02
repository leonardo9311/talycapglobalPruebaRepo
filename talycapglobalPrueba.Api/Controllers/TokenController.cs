using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.DTO;
using talycapglobalPrueba.Core.Interfaces.Services;

namespace talycapglobalPrueba.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;

        }
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(TokenAuthDTO Auth)
        {
            return Ok(await _tokenService.Authenticate(Auth));
        }
    }
}
