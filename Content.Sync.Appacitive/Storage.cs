using Appacitive.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    public class Storage
    {
        public static void Initialize()
        {
            App.Initialize(WindowsRT.Host, "JPVBkuDr/Wo7T78iatf8hUoY82gNi68JgKDKkDK+ySI=",
                global::Appacitive.Sdk.Environment.Sandbox);
        }
    }
}
