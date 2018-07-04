using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIPv1.Models
{
    public class ResponseResult<T>
    {
        public T Result { get; set; }

        public ResponseResult(T result)
        {
            Result = result;
        }
    }
}