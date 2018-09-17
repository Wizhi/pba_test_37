using System.Collections.Generic;

namespace SmartPark.Models
{
    public interface IParkingLot
    {
        IList<ICar> Cars { get; }
    }
}