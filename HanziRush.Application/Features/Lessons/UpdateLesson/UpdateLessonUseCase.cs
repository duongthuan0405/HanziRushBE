using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.UpdateLesson
{
    public class UpdateLessonUseCase
    {
        private readonly ILessonRepository _repository;

        public UpdateLessonUseCase(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(UpdateLessonRequest request)
        {
            if (request.Id <= 0)
            {
                return Result<bool>.Failure("ID bài học không hợp lệ", "INVALID_ID");
            }

            if (request.BookId <= 0)
            {
                return Result<bool>.Failure("ID sách không hợp lệ", "INVALID_BOOK_ID");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Result<bool>.Failure("Tiêu đề bài học không được để trống", "INVALID_TITLE");
            }

            var lessonToUpdate = Lesson.Update(request.Id, request.BookId, request.Title, request.DisplayOrder);

            var isSuccess = await _repository.UpdateLessonAsync(lessonToUpdate);

            if (!isSuccess)
            {
                return Result<bool>.Failure("Cập nhật thất bại hoặc bài học không tồn tại", "UPDATE_FAILED");
            }

            return Result<bool>.Success(true);
        }
    }
}
