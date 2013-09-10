using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.ErrorSpace
{
    [Serializable]
    public class InvalidParameterException : BaseApplicationException
    {
        public  InvalidParameterException()
            : base()
        {
        }

        public InvalidParameterException(string message)
            : base(message)
        {
        }

        public InvalidParameterException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public InvalidParameterException(SerializationInfo serializationInfo, StreamingContext context) :
            base(serializationInfo, context)
        {
        }
    }
}
