using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Model
{
    public static class WorkerState
    {
        public static readonly int Stopped = 0;
        public static readonly int Started = 1;
        public static readonly int Stopping = 2;
        public static readonly int Starting = 3;
    }
}
