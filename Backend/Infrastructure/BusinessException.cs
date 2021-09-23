using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BusinessException : Exception
    {
        public BusinessException() : base() { }

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, Exception innerException) : base(message, innerException) { }

        public BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BusinessException(string message, int? errorCode) : base(message) { ErrorCode = errorCode; }

        public BusinessException(string message, Exception innerException, int? errorCode) : base(message, innerException) { ErrorCode = errorCode; }

        public BusinessException(SerializationInfo info, StreamingContext context, int? errorCode) : base(info, context) { ErrorCode = errorCode; }

        public int? ErrorCode { get; set; }
    }
}
