using HanziRush.Application.Common.Models;
using HanziRush.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Features.Books.GetBooks
{
    public class GetBooksUseCase
    {
        private readonly IBookRepository _repository;

        public GetBooksUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<GetBooksResponse>>> ExecuteAsync()
        {
            var books = await _repository.GetBooksAsync();

            return Result<IEnumerable<GetBooksResponse>>.Success(books);
        }
    }
}
