using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.ErrorSpace
{
    [Serializable]
    public abstract class BaseApplicationException : Exception
    {
        protected BaseApplicationException()
            : base()
        {
        }

        protected BaseApplicationException(string message)
            : base(message)
        {
        }

        protected BaseApplicationException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        protected BaseApplicationException(SerializationInfo serializationInfo, StreamingContext context) :
            base(serializationInfo, context)
        {
        }
    }
}
