using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.CreateLesson
{
    public class CreateLessonRequest
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
