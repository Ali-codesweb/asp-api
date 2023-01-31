using bookstore.Models;
using bookstore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooksAsync();
            return Ok(books);   
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);
            return Ok(book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BooksModel bookModel)
        {
            var id = await bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new
            {
                id = id,
                controller = "books",


            },bookModel);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateBook([FromBody] BooksModel bookModel)
        {
            await bookRepository.UpdateBookAsync(bookModel.Id, bookModel);
            return Ok(bookModel);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok(bookModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await bookRepository.DeleteBookAsync(id);
            return Ok();
        }
                


    }
}
