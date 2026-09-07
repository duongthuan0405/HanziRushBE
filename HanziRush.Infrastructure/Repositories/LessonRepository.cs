using Dapper;
using HanziRush.Application.Features.Lessons.GetLessons;
using HanziRush.Application.Interfaces;
using HanziRush.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HanziRush.Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IConfiguration _configuration;

        public LessonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetLessonsResponse>> GetLessonsAsync(GetLessonsRequest request)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", request.BookId);

            var result = await db.QueryAsync<GetLessonsResponse>(
                "spGetLessons",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> CreateLessonAsync(Lesson lesson)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", lesson.BookId);
            parameters.Add("@Title", lesson.Title);
            parameters.Add("@DisplayOrder", lesson.DisplayOrder);

            var newId = await db.ExecuteScalarAsync<int>(
                "spCreateLesson",
                parameters,
                commandType: CommandType.StoredProcedure);

            return newId;
        }

        public async Task<bool> UpdateLessonAsync(Lesson lesson)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", lesson.Id);
            parameters.Add("@BookId", lesson.BookId);
            parameters.Add("@Title", lesson.Title);
            parameters.Add("@DisplayOrder", lesson.DisplayOrder);

            var affectedRows = await db.ExecuteAsync(
                "spUpdateLesson",
                parameters,
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var affectedRows = await db.ExecuteAsync(
                "spDeleteLesson",
                parameters,
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }
    }
}
