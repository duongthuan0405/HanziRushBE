using HanziRush.Application.Features.Vocabularies.GetRandomVocabulary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocabulariesController : ControllerBase
    {
        private readonly GetRandomVocabularyUseCase _getRandomVocabularyUseCase;

        public VocabulariesController(GetRandomVocabularyUseCase getRandomVocabularyUseCase)
        {
            _getRandomVocabularyUseCase = getRandomVocabularyUseCase;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomVocabularies([FromQuery] GetRandomVocabularyRequest request)
        {
            var result = await _getRandomVocabularyUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
