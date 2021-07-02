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
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetBookById/{Id}")]
        public IActionResult GetAuthorById(int Id)
        {

            return Ok(_bookService.GetById(Id));
        }
        [HttpPost("GetBookByIds")]
        public IActionResult GetAuthorById(ListIdDto listIdDto)
        {

            return Ok(_bookService.GetByIds(listIdDto.Ids));
        }

    }
}
