using HanziRush.Application.Features.Audio.GeneratePronunciation;
using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly GeneratePronunciationUseCase _generatePronunciationUseCase;

        public AudioController(GeneratePronunciationUseCase generatePronunciationUseCase)
        {
            _generatePronunciationUseCase = generatePronunciationUseCase;
        }

        [HttpGet("pronounce")]
        public async Task<IActionResult> GetPronunciation([FromQuery] string hanzi)
        {
            var query = new GeneratePronunciationRequest { Hanzi = hanzi };

            var result = await _generatePronunciationUseCase.ExecuteAsync(query);

            if (result.IsSuccess && result.Data != null)
            {
                return File(result.Data, "audio/mpeg");
            }


            return BadRequest(result);
        }
    }
}
