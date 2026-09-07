using Dapper;
using HanziRush.Application.Features.Vocabularies.GetRandomVocabulary;
using HanziRush.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HanziRush.Infrastructure.Repositories
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly IConfiguration _configuration;

        public VocabularyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<RandomVocabularyResponse>> GetRandomVocabulariesAsync(GetRandomVocabularyRequest request)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@TotalWords", request.TotalWords);
            parameters.Add("@BookId", request.BookId);
            parameters.Add("@LessonId", request.LessonId);

            var result = await db.QueryAsync<RandomVocabularyResponse>(
                "spGetRandomVocabularyForSession",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
