using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model
{
    public class ServiceResult<T>
    {
        public bool IsConnectionSuccessful { get; set; }
        public bool IsSuccessful { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }

        public ServiceResult(bool isSuccessful = true, T result = default(T), string errorMessage = null)
        {
            this.IsConnectionSuccessful = true;
            this.IsSuccessful = isSuccessful;
            this.Result = result;
            this.ErrorMessage = errorMessage;
        }
    }
}
