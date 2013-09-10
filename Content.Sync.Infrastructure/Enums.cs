﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Infrastructure
{
    public enum WorkerState
    {
        Stopped = 0,
        Started = 1,
        Stopping = 2,
        Starting = 3,
        Faulted = 4
    }
}
