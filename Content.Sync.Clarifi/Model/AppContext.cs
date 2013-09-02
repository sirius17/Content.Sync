using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class AppContext
    {
        // TODO: Initialize this with the DI Container.
        public static AppContext Current = new AppContext();

        public string TenantId { get; set; }


    }
}
