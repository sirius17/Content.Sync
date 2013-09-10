using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using System.Threading;

namespace Content.Sync.UpdateCommands
{
    public class TagUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(HotelWorkItem workItem, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
