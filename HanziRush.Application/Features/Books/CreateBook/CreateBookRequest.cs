using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.CreateBook
{
    public class CreateBookRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
    }
}
