using HanziRush.Application.Features.Lessons.GetLessons;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<GetLessonsResponse>> GetLessonsAsync(GetLessonsRequest request);
        Task<int> CreateLessonAsync(Lesson lesson);
        Task<bool> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(int id);
    }
}
