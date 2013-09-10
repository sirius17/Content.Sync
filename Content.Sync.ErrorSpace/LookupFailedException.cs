using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.ErrorSpace
{
    [Serializable]
    public class LookupFailedException : BaseApplicationException
    {
        public  LookupFailedException()
            : base()
        {
        }

        public LookupFailedException(string message)
            : base(message)
        {
        }

        public LookupFailedException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public LookupFailedException(SerializationInfo serializationInfo, StreamingContext context) :
            base(serializationInfo, context)
        {
        }
    }
}
