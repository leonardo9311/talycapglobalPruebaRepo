using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Interfaces.Services;

namespace talycapglobalPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = JwtBearerDefaults.AuthenticationScheme)]
    public class SyncController : Controller
    {
        private readonly ISyncService _syncService;
        public SyncController(ISyncService syncService)
        {
            _syncService = syncService;
        }
        [HttpGet("SyncBooksAndAuthors")]
        public async Task<IActionResult> SyncBooksAndAuthors() {
            await _syncService.SyncBooksAndAuthors();
            return Ok();
        }
    }
}
