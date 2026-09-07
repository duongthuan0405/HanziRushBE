using HanziRush.Application.Common.Models;
using HanziRush.Application.Features.Books.CreateBook;
using HanziRush.Application.Features.Books.DeleteBook;
using HanziRush.Application.Features.Books.GetBooks;
using HanziRush.Application.Features.Books.UpdateBook;
using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly GetBooksUseCase _getBooksUseCase;
        private readonly CreateBookUseCase _createBookUseCase;
        private readonly UpdateBookUseCase _updateBookUseCase;
        private readonly DeleteBookUseCase _deleteBookUseCase;

        public BooksController
            (GetBooksUseCase getBooksUseCase, 
            CreateBookUseCase createBookUseCase, 
            UpdateBookUseCase updateBookUseCase, 
            DeleteBookUseCase deleteBookUseCase)
        {
            _getBooksUseCase = getBooksUseCase;
            _createBookUseCase = createBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _deleteBookUseCase = deleteBookUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _getBooksUseCase.ExecuteAsync();

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            var result = await _createBookUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(Result<bool>.Failure("ID trên URL không khớp với dữ liệu", "MISMATCH_ID"));
            }

            var result = await _updateBookUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var request = new DeleteBookRequest { Id = id };

            var result = await _deleteBookUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
