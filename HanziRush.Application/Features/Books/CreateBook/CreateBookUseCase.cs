using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.CreateBook
{
    public class CreateBookUseCase
    {
        private readonly IBookRepository _repository;

        public CreateBookUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> ExecuteAsync(CreateBookRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Result<int>.Failure("Tiêu đề sách không được để trống", "INVALID_TITLE");
            }

            var newBook = Book.Create(request.Title, request.Description, request.DisplayOrder);

            var newBookId = await _repository.CreateBookAsync(newBook);

            return Result<int>.Success(newBookId);
        }
    }
}
