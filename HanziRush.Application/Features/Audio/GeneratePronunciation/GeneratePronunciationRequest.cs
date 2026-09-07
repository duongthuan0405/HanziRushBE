using HanziRush.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Audio.GeneratePronunciation
{
    public class GeneratePronunciationRequest
    {
        public string Hanzi { get; set; } = string.Empty;
    }
}
