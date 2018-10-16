using TaskTracker.Model;
using TaskTracker.Contracts;

namespace TaskTracker.Utility
{
    public class Responses: IResponses
    {
        public ServiceResult<bool> SuccessBoolResult
        {
            get
            {
                return new ServiceResult<bool>(true, true);
            }
        }

        ServiceResult<bool> IResponses.SuccessBoolResult { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ServiceResult<T> SuccessResult<T>( T result)
        {
            return new ServiceResult<T>(true, result);
        }

        public ServiceResult<T> SuccessNullResult<T>(string message)
        {
            return new ServiceResult<T>(true, default(T), message);
        }

        public ServiceResult<T> FailureResult<T>( T result, string errorMessage = "Unknown Error")
        {
            return new ServiceResult<T>(false, result, errorMessage);
        }

        public ServiceResult<T> FailureNullResult<T>(string errorMessage = "Unknown Error")
        {
            return new ServiceResult<T>(false, default(T), errorMessage);
        }

        public ServiceResult<bool> FailureBoolResult(string errorMessage = "Unknown Error")
        {
            return new ServiceResult<bool>(false, false, errorMessage);
        }
        
    }
}
