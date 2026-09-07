using HanziRush.Application.Features.Books.GetBooks;
using HanziRush.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Interfaces
{
    public interface IBookRepository
    {        
        Task<IEnumerable<GetBooksResponse>> GetBooksAsync();
        Task<int> CreateBookAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
