using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SmartPark.Models;

namespace SmartPark
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLot _parkingLot;

        public ParkingLotService(IParkingLot parkingLot)
        {
            _parkingLot = parkingLot;
        }

        public void Leave(ICar car)
        {
            _parkingLot.Cars.Remove(car);
        }

        public void Arrive(ICar car)
        {
            _parkingLot.Cars.Add(car);
        }

        public ICar FindCar(string regNr)
        {
            return _parkingLot.Cars.FirstOrDefault(x => x.RegistrationNumber == regNr);
        }

        public IReadOnlyList<ICar> GetAllCars()
        {
            return _parkingLot.Cars.ToList();
        }
    }
}
