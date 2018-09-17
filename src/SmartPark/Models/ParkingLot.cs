using System.Collections.Generic;

namespace SmartPark.Models
{
    public class ParkingLot : IParkingLot
    {
        public IList<ICar> Cars { get; } = new List<ICar>();
    }
}