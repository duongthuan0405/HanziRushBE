using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Audio.GeneratePronunciation
{
    public class GeneratePronunciationUseCase
    {
        private readonly ITextToSpeechService _ttsService;

        public GeneratePronunciationUseCase(ITextToSpeechService ttsService)
        {
            _ttsService = ttsService;
        }

        public async Task<Result<byte[]>> ExecuteAsync(GeneratePronunciationRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Hanzi))
            {
                return Result<byte[]>.Failure("Hán tự không được để trống.", "EMPTY_TEXT");
            }

            try
            {
                var audioBytes = await _ttsService.GenerateAudioAsync(request.Hanzi, cancellationToken);
                return Result<byte[]>.Success(audioBytes);
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failure($"Lỗi tạo âm thanh: {ex.Message}", "TTS_ERROR");
            }
        }
    }
}
