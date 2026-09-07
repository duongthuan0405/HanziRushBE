using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Domain.Entities
{
    /// <summary>
    /// Đại diện cho một phiên học.
    /// </summary>
    public class StudySession
    {
        /// <summary>
        /// Khởi tạo một phiên học.
        /// </summary>
        /// <param name="id">Id của phiên học</param>
        /// <param name="startTime">Thời điểm bắt đầu</param>
        /// <param name="endTime">Thời điểm kết thúc (có thể null nếu chưa kết thúc)</param>
        /// <param name="totalWords">Tổng số từ trong phiên</param>
        /// <param name="correctCount">Số câu trả lời đúng</param>
        public StudySession(int id, DateTime startTime, DateTime? endTime, int totalWords, int correctCount)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            TotalWords = totalWords;
            CorrectCount = correctCount;
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int TotalWords { get; set; }
        public int CorrectCount { get; set; }
    }
}
