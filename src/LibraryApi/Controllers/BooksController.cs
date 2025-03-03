using AutoMapper;
using LibraryApplication.Interfaces;
using LibraryDomain.DTOs;
using LibraryDomain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var createdBook = await _bookService.CreateBookAsync(book);
            return Ok(createdBook);
        }

        [HttpGet]
        public async  Task<IActionResult> Get()
        {
          var getBook = await _bookService.GetAllBooksAsync();
          return Ok(getBook);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var getBook = await _bookService.GetBookByIdAsync(id);
            return Ok(getBook);
        }
    }
}
