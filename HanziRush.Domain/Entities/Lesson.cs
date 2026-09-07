using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Domain.Entities
{
    /// <summary>
    /// Đại diện cho một bài học trong sách.
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// Khởi tạo một bài học mới.
        /// </summary>
        /// <param name="id">Id của bài học</param>
        /// <param name="bookId">Id của sách chứa bài học</param>
        /// <param name="title">Tiêu đề bài học</param>
        /// <param name="displayOrder">Thứ tự hiển thị</param>
        /// <param name="createdAt">Thời điểm tạo</param>
        public Lesson(int id, int bookId, string title, int displayOrder, DateTime createdAt)
        {
            Id = id;
            BookId = bookId;
            Title = title;
            DisplayOrder = displayOrder;
            CreatedAt = createdAt;
        }

        public static Lesson Create(int bookId, string title, int displayOrder)
        {
            return new Lesson(0, bookId, title, displayOrder, DateTime.UtcNow);
        }

        public static Lesson Update(int id, int bookId, string title, int displayOrder)
        {
            return new Lesson(id, bookId, title, displayOrder, DateTime.MinValue);
        }

        public int Id { get; private set; }
        public int BookId { get; private set; }
        public string Title { get; private set; }
        public int DisplayOrder { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
