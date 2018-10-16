using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Model;

namespace TaskTracker.Contracts
{
    public interface IResponses
    {
        ServiceResult<bool> SuccessBoolResult { get; set; }

        ServiceResult<T> SuccessResult<T>( T result);

        ServiceResult<T> SuccessNullResult<T>(string message);
        ServiceResult<T> FailureResult<T>( T result, string errorMessage = "Unknown Error");
        ServiceResult<T> FailureNullResult<T>(string errorMessage = "Unknown Error");

        ServiceResult<bool> FailureBoolResult(string errorMessage = "Unknown Error");
    }
}
