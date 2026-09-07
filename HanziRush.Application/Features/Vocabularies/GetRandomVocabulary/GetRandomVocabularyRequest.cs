using HanziRush.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Vocabularies.GetRandomVocabulary
{
    public class GetRandomVocabularyRequest
    {
        public int TotalWords { get; set; } = 10;
        public int? BookId { get; set; }
        public int? LessonId { get; set; }
    }
}
