using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DbContext _context;
        public BooksController(DbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var book = "Book created!";

            return Created("", book);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = new string[] { "Book 1", "Book 2" };
            return Ok(books);
        }
    }
}
