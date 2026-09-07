using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Lessons.UpdateLesson
{
    public class UpdateLessonRequest
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
