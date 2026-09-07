using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Interfaces
{
    public interface ITextToSpeechService
    {
        Task<byte[]> GenerateAudioAsync(string text, CancellationToken cancellationToken = default);
    }
}
