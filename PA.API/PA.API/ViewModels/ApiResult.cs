using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA.API.ViewModels
{
    public class ApiResult<T>
    {
        public ApiResult() { }

        public ApiResult(bool status, T data = default(T), string message = null)
        {
            Status = status;
            Data = data;
            Message = message;
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ApiResult : ApiResult<object>
    {
        public ApiResult() : base()
        {
        }

        public ApiResult(bool status, object data = default(object), string message = null) : base(status, data, message)
        {
        }
    }
}
