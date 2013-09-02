using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class SampleCommand : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(HotelWorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
