using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.ErrorSpace
{
    [Serializable]
    public class IncorrectOperationException : BaseApplicationException
    {
        public  IncorrectOperationException()
            : base()
        {
        }

        public IncorrectOperationException(string message)
            : base(message)
        {
        }

        public IncorrectOperationException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public IncorrectOperationException(SerializationInfo serializationInfo, StreamingContext context) :
            base(serializationInfo, context)
        {
        }
    }
}
