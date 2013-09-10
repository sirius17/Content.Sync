using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IAmenityGroupDataProvider
    {
        void InsertAmenityGroup(AmenityGroup amenityGroup);
        void UpdateAmenityGroup(AmenityGroup amenityGroup);
        AmenityGroup GetAmenityGroupDetails(AmenityGroup appacitiveAmenityGroup);
    }
}
