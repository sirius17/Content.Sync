using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    internal class Unique
    {
        public static string NewString
        {
            get
            {
                return Guid.NewGuid().ToString().Replace("-", string.Empty);
            }
        }
    }
}
