using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Abstraction
{

    public class Result
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

    }

    public class Result<T>: Result
    {        
        public T? Data { get; set; }        

        // For a single item
        public static Result<T> SuccessResult(T data) =>
            new Result<T> { Success = true, Data = data };

        // For a collection of items
        //public static Result<IEnumerable<T>> SuccessCollectionResult(IEnumerable<T> data) =>
        //    new Result<IEnumerable<T>> { Success = true, Data = data };

        public static Result<T> FailureResult(string errorMessage) =>
            new Result<T> { Success = false, ErrorMessage = errorMessage };

        //// For a collection of items
        //internal static IEnumerable<Result<Domain.Entities.UserProfile>> SuccessCollectionResult(IAsyncEnumerable<Domain.Entities.UserProfile> data)
        //{
        //    new Result<IEnumerable<T>> { Success = true, Data = data };
        //}
    }

}
