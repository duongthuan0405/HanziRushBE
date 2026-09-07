using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Vocabularies.GetRandomVocabulary
{
    public class RandomVocabularyResponse
    {
        public int VocabularyId { get; set; }
        public string Hanzi { get; set; } = string.Empty;
        public string Pinyin { get; set; } = string.Empty;
        public string Meaning { get; set; } = string.Empty;
        public string? Radical { get; set; }
        public string LessonTitle { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
    }
}
