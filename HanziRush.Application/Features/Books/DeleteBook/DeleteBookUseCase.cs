using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.DeleteBook
{
    public class DeleteBookUseCase
    {
        private readonly IBookRepository _repository;

        public DeleteBookUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(DeleteBookRequest request)
        {
            if (request.Id <= 0)
            {
                return Result<bool>.Failure("ID sách không hợp lệ", "INVALID_ID");
            }

            var isSuccess = await _repository.DeleteBookAsync(request.Id);

            if (!isSuccess)
            {
                return Result<bool>.Failure("Sách không tồn tại hoặc đã bị xóa", "DELETE_FAILED");
            }

            return Result<bool>.Success(true);
        }
    }
}
