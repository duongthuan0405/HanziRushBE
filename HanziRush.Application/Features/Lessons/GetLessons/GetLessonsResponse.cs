using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.GetLessons
{
    public class GetLessonsResponse
    {
        public int LessonId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
