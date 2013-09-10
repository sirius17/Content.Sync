using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;
namespace Content.Sync.Data.Interfaces
{
    public interface IHotelChainProvider
    {
        void AddChain(HotelChain chain);
    }
}
