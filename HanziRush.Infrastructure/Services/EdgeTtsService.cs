using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HanziRush.Infrastructure.Services
{
    public class EdgeTtsService : ITextToSpeechService
    {
        public async Task<byte[]> GenerateAudioAsync(string hanzi, CancellationToken cancellationToken = default)
        {
            var tempFilePath = Path.GetTempFileName() + ".mp3";

            try
            {
                string voice = "zh-CN-XiaoxiaoNeural";

                string textWithEmotion = $"{hanzi}...";

                var processInfo = new ProcessStartInfo
                {
                    FileName = "edge-tts",
                    Arguments = $"--voice {voice} --rate=-10% --pitch=+10Hz --text \"{textWithEmotion}\" --write-media \"{tempFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                if (process == null) throw new Exception("Không thể khởi động tiến trình edge-tts.");

                await process.WaitForExitAsync(cancellationToken);

                if (process.ExitCode != 0)
                {
                    var error = await process.StandardError.ReadToEndAsync(cancellationToken);
                    throw new Exception(error);
                }

                return await File.ReadAllBytesAsync(tempFilePath, cancellationToken);
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
    }
}
