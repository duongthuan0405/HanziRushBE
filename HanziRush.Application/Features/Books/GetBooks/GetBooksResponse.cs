using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.GetBooks
{
    public class GetBooksResponse
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
    }
}
