using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.DeleteLesson
{
    public class DeleteLessonUseCase
    {
        private readonly ILessonRepository _repository;

        public DeleteLessonUseCase(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(DeleteLessonRequest request)
        {
            if (request.Id <= 0)
            {
                return Result<bool>.Failure("ID bài học không hợp lệ", "INVALID_ID");
            }

            var isSuccess = await _repository.DeleteLessonAsync(request.Id);

            if (!isSuccess)
            {
                return Result<bool>.Failure("Bài học không tồn tại hoặc đã bị xóa", "DELETE_FAILED");
            }

            return Result<bool>.Success(true);
        }
    }
}
