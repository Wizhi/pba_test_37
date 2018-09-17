using System.Collections.Generic;
using SmartPark.Models;

namespace SmartPark
{
    public interface IParkingLotService
    {
        /// <summary>
        ///     Kaldes når en bil forlader parkeringspladsen.
        /// </summary>
        /// <param name="car"></param>
        void Leave(ICar car);

        /// <summary>
        ///     Kaldes når en Car ankommer til parkeringspladsen.
        /// </summary>
        /// <param name="car"></param>
        void Arrive(ICar car);

        /// <summary>
        ///     Find Car med det angivne registreringsnummer.
        /// </summary>
        /// <param name="regNr">
        ///     regNr er optional. Hvis den ikke angives returneres en tilfældig Car.
        /// </param>
        /// <returns>Hvis Caren findes returneres denne. Ellers returneres null</returns>
        ICar FindCar(string regNr);

        /// <summary>
        ///     Hent alle Carer på parkeringspladsen.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<ICar> GetAllCars();
    }
}
