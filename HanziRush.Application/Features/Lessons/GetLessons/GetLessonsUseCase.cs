using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.GetLessons
{
    public class GetLessonsUseCase
    {
        private readonly ILessonRepository _repository;

        public GetLessonsUseCase(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<GetLessonsResponse>>> ExecuteAsync(GetLessonsRequest request)
        {
            if (request.BookId.HasValue && request.BookId <= 0)
            {
                return Result<IEnumerable<GetLessonsResponse>>.Failure("ID của sách không hợp lệ", "INVALID_BOOK_ID");
            }

            var lessons = await _repository.GetLessonsAsync(request);

            return Result<IEnumerable<GetLessonsResponse>>.Success(lessons);
        }
    }
}
