using System;
using System.Runtime.Serialization;

namespace LOCRetriever.Objects
{
    public class RetrieverException : SystemException
    {
        public RetrieverException()
        {
        }

        public RetrieverException(string message) : base(message)
        {
        }

        public RetrieverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetrieverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
