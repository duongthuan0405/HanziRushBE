using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.CreateLesson
{
    public class CreateLessonUseCase
    {
        private readonly ILessonRepository _repository;

        public CreateLessonUseCase(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> ExecuteAsync(CreateLessonRequest request)
        {
            if (request.BookId <= 0)
            {
                return Result<int>.Failure("ID của sách không hợp lệ", "INVALID_BOOK_ID");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Result<int>.Failure("Tiêu đề bài học không được để trống", "INVALID_TITLE");
            }

            var newLesson = Lesson.Create(request.BookId, request.Title, request.DisplayOrder);

            var newLessonId = await _repository.CreateLessonAsync(newLesson);

            return Result<int>.Success(newLessonId);
        }
    }
}
