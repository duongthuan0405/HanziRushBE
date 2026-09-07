using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.UpdateBook
{
    public class UpdateBookUseCase
    {
        private readonly IBookRepository _repository;

        public UpdateBookUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(UpdateBookRequest request)
        {
            if (request.Id <= 0)
            {
                return Result<bool>.Failure("ID sách không hợp lệ", "INVALID_ID");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Result<bool>.Failure("Tiêu đề sách không được để trống", "INVALID_TITLE");
            }

            var bookToUpdate = Book.Update(request.Id, request.Title, request.Description, request.DisplayOrder);

            var isSuccess = await _repository.UpdateBookAsync(bookToUpdate);

            if (!isSuccess)
            {
                return Result<bool>.Failure("Cập nhật thất bại hoặc sách không tồn tại", "UPDATE_FAILED");
            }

            return Result<bool>.Success(true);
        }
    }
}
