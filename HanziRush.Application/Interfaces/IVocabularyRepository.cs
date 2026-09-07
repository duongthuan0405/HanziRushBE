using HanziRush.Application.Features.Vocabularies.GetRandomVocabulary;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Interfaces
{
    public interface IVocabularyRepository
    {
        Task<IEnumerable<RandomVocabularyResponse>> GetRandomVocabulariesAsync(GetRandomVocabularyRequest request);
    }
}
