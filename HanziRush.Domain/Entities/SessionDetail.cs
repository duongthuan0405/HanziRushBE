using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Domain.Entities
{
    /// <summary>
    /// Đại diện cho chi tiết một lần làm bài (session).
    /// </summary>
    public class SessionDetail
    {
        /// <summary>
        /// Khởi tạo chi tiết session.
        /// </summary>
        /// <param name="id">Id của session detail</param>
        /// <param name="sessionId">Id của session</param>
        /// <param name="vocabularyId">Id của từ vựng</param>
        /// <param name="isCorrect">Kết quả trả lời đúng hay sai</param>
        /// <param name="userInput">Câu trả lời của người dùng (có thể null)</param>
        /// <param name="createdAt">Thời điểm tạo</param>
        public SessionDetail(int id, int sessionId, int vocabularyId, bool isCorrect, string? userInput, DateTime createdAt)
        {
            Id = id;
            SessionId = sessionId;
            VocabularyId = vocabularyId;
            IsCorrect = isCorrect;
            UserInput = userInput;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public int SessionId { get; set; }
        public int VocabularyId { get; set; }
        public bool IsCorrect { get; set; }
        public string? UserInput { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
