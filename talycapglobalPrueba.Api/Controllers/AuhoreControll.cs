using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = JwtBearerDefaults.AuthenticationScheme)]
    public class AuhoreControll : Controller
    {
        private readonly IAuthorService _authorService;
        public AuhoreControll(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("GetAuthorById/{Id}")]
        public IActionResult GetAuthorById(int Id) {

            return Ok(_authorService.GetById(Id));
        }
        [HttpPost("GetAuthorByIds")]
        public IActionResult GetAuthorById(ListIdDto listIdDto)
        {

            return Ok(_authorService.GetByIds(listIdDto.Ids));
        }
    }
}
