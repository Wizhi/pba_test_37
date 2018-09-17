using System.Collections.Generic;
using FakeItEasy;
using SmartPark.Models;
using Xunit;

namespace SmartPark.Tests
{
    public class ParkeringspladsServiceSkal
    {
        [Fact]
        public void FjerneBilenFraParkeringspladsen_Ved_ForladPladsen()
        {
            var regNr = "12345678";
            var car = A.Fake<ICar>();
            var parkingLot = A.Fake<IParkingLot>();

            A.CallTo(() => car.RegistrationNumber).Returns(regNr);
            A.CallTo(() => parkingLot.Cars).Returns(new List<ICar>
            {
                car
            });


            var sut = new ParkingLotService(parkingLot);

            sut.Leave(car);

            Assert.DoesNotContain(parkingLot.Cars, a => a.RegistrationNumber == regNr);
        }

        [Fact]
        public void HenteAlleBilerPaaParkeringspladsen_Ved_AlleBiler()
        {
            var parkingLot = A.Fake<IParkingLot>();

            A.CallTo(() => parkingLot.Cars).Returns(A.CollectionOfDummy<ICar>(2));

            var sut = new ParkingLotService(parkingLot);

            var actual = sut.GetAllCars();

            Assert.Equal(2, actual.Count);
        }

        [Fact]
        public void TilfoejeEnBilTilParkeringspladsen_Ved_Ankomst()
        {
            var regNr = "12345678";
            var car = A.Fake<ICar>();
            var parkingLot = A.Fake<IParkingLot>();

            A.CallTo(() => car.RegistrationNumber).Returns(regNr);
            A.CallTo(() => parkingLot.Cars).Returns(new List<ICar>
            {
                car
            });

            var sut = new ParkingLotService(parkingLot);

            sut.Arrive(car);

            Assert.Contains(parkingLot.Cars, a => a.RegistrationNumber == regNr);
        }
    }
}
