using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Domain.Entities
{
    /// <summary>
    /// Đại diện cho thông tin một cuốn sách.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Khởi tạo một cuốn sách mới.
        /// </summary>
        /// <param name="id">Id của sách</param>
        /// <param name="title">Tiêu đề của sách</param>
        /// <param name="description">Mô tả nội dung (có thể null)</param>
        /// <param name="displayOrder">Thứ tự hiển thị</param>
        /// <param name="createdAt">Thời điểm tạo</param>
        public Book(int id, string title, string? description, int displayOrder, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            DisplayOrder = displayOrder;
            CreatedAt = createdAt;
        }

        public static Book Create(string title, string? description, int displayOrder)
        {
            return new Book(0, title, description, displayOrder, DateTime.Now);
        }

        public static Book Update(int id, string title, string? description, int displayOrder)
        {
            return new Book(id, title, description, displayOrder, DateTime.MinValue);
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int DisplayOrder { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
