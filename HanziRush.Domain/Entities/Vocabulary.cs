using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Domain.Entities
{
    /// <summary>
    /// Đại diện cho một từ vựng.
    /// </summary>
    public class Vocabulary
    {
        /// <summary>
        /// Khởi tạo một từ vựng mới.
        /// </summary>
        /// <param name="id">Id của từ vựng</param>
        /// <param name="lessonId">Id của bài học chứa từ vựng</param>
        /// <param name="hanzi">Chữ Hán</param>
        /// <param name="pinyin">Phiên âm Pinyin</param>
        /// <param name="meaning">Nghĩa tiếng Việt</param>
        /// <param name="radical">Bộ thủ (có thể null)</param>
        /// <param name="createdAt">Thời điểm tạo</param>
        public Vocabulary(int id, int lessonId, string hanzi, string pinyin, string meaning, string? radical, DateTime createdAt)
        {
            Id = id;
            LessonId = lessonId;
            Hanzi = hanzi;
            Pinyin = pinyin;
            Meaning = meaning;
            Radical = radical;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Hanzi { get; set; }
        public string Pinyin { get; set; }
        public string Meaning { get; set; }
        public string? Radical { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
