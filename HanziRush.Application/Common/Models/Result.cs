using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Application.Common.Models
{
    /// <summary>
    /// Chuẩn hóa cách trả về kết quả của service.
    /// Thay vì trả dữ liệu trực tiếp hoặc ném exception, sử dụng Result<T>
    /// để chứa trạng thái, dữ liệu và thông điệp lỗi, giúp xử lý nhất quán.
    /// </summary>
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? ErrorMessage { get; }
        public string? ErrorCode { get; }

        private Result(bool isSuccess, T? data, string? errorMessage, string? errorCode)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null, null);
        }

        public static Result<T> Failure(string errorMessage, string? errorCode = null)
        {
            return new Result<T>(false, default, errorMessage, errorCode);
        }
    }
}
