using Dapper;
using HanziRush.Application.Features.Books.GetBooks;
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
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///Lấy danh sách tất cả quyển sách hiện có.
        /// </summary>
        public async Task<IEnumerable<GetBooksResponse>> GetBooksAsync()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var result = await db.QueryAsync<GetBooksResponse>(
                "spGetBooks",
                commandType: CommandType.StoredProcedure);

            return result;
        }

        ///<summary>
        ///Thêm mới một quyển sách
        ///</summary>
        public async Task<int> CreateBookAsync(Book book)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Title", book.Title);
            parameters.Add("@Description", book.Description);
            parameters.Add("@DisplayOrder", book.DisplayOrder);

            var newId = await db.ExecuteScalarAsync<int>(
                "spCreateBook",
                parameters,
                commandType: CommandType.StoredProcedure);

            return newId;
        }

        ///<summary>
        ///Cập nhật thông tin một quyển sách
        ///</summary>
        public async Task<bool> UpdateBookAsync(Book book)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", book.Id);
            parameters.Add("@Title", book.Title);
            parameters.Add("@Description", book.Description);
            parameters.Add("@DisplayOrder", book.DisplayOrder);

            var affectedRows = await db.ExecuteAsync(
                "spUpdateBook",
                parameters,
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }

        ///<sumary>
        ///Xóa một quyển sách
        ///</sumary>
        public async Task<bool> DeleteBookAsync(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using IDbConnection db = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var affectedRows = await db.ExecuteAsync(
                "spDeleteBook",
                parameters,
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }
    }
}
