using HanziRush.Application.Common.Models;
using HanziRush.Application.Features.Lessons.CreateLesson;
using HanziRush.Application.Features.Lessons.DeleteLesson;
using HanziRush.Application.Features.Lessons.GetLessons;
using HanziRush.Application.Features.Lessons.UpdateLesson;
using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly GetLessonsUseCase _getLessonsUseCase;
        private readonly CreateLessonUseCase _createLessonUseCase;
        private readonly UpdateLessonUseCase _updateLessonUseCase;
        private readonly DeleteLessonUseCase _deleteLessonUseCase;

        public LessonsController(
            GetLessonsUseCase getLessonsUseCase,
            CreateLessonUseCase createLessonUseCase,
            UpdateLessonUseCase updateLessonUseCase,
            DeleteLessonUseCase deleteLessonUseCase)
        {
            _getLessonsUseCase = getLessonsUseCase;
            _createLessonUseCase = createLessonUseCase;
            _updateLessonUseCase = updateLessonUseCase;
            _deleteLessonUseCase = deleteLessonUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetLessons([FromQuery] GetLessonsRequest request)
        {
            var result = await _getLessonsUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonRequest request)
        {
            var result = await _createLessonUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, [FromBody] UpdateLessonRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(Result<bool>.Failure("ID trên URL không khớp với dữ liệu", "MISMATCH_ID"));
            }

            var result = await _updateLessonUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var request = new DeleteLessonRequest { Id = id };

            var result = await _deleteLessonUseCase.ExecuteAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
