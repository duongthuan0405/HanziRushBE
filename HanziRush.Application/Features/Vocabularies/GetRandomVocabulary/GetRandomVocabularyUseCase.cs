using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Vocabularies.GetRandomVocabulary
{
    public class GetRandomVocabularyUseCase
    {
        private readonly IVocabularyRepository _repository;

        public GetRandomVocabularyUseCase(IVocabularyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<RandomVocabularyResponse>>> ExecuteAsync(GetRandomVocabularyRequest request)
        {
            if (request.TotalWords <= 0)
            {
                return Result<IEnumerable<RandomVocabularyResponse>>.Failure("Số lượng từ phải lớn hơn 0", "INVALID_TOTAL_WORDS");
            }

            var vocabularies = await _repository.GetRandomVocabulariesAsync(request);

            return Result<IEnumerable<RandomVocabularyResponse>>.Success(vocabularies);
        }
    }
}
