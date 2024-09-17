using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public static Result<T> SuccessResult(T data) =>
            new Result<T> { Success = true, Data = data };

        public static Result<T> FailureResult(string errorMessage) =>
            new Result<T> { Success = false, ErrorMessage = errorMessage };
    }

}
