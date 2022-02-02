using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRepository.GetByName(driverName) == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (carRepository.GetByName(carModel) == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driverRepository.GetByName(driverName).AddCar(carRepository.GetByName(carModel));
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (driverRepository.GetByName(driverName) == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (raceRepository.GetByName(raceName) == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            raceRepository.GetByName(raceName).AddDriver(driverRepository.GetByName(driverName));
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetByName(model) == default)
            {
                if (type == "Muscle")
                {
                    carRepository.Add(new MuscleCar(model, horsePower));
                    return string.Format(OutputMessages.CarCreated, "MuscleCar", model);
                }
                else if (type == "Sports")
                {
                    carRepository.Add(new SportsCar(model, horsePower));
                    return string.Format(OutputMessages.CarCreated, "SportsCar", model);
                }
            }
            throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetByName(driverName) == default)
            {
                IDriver driver = new Driver(driverName);
                driverRepository.Add(driver);
                return string.Format(OutputMessages.DriverCreated, driverName);
            }
            throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) == default)
            {
                IRace race = new Race(name, laps);
                raceRepository.Add(race);
                return string.Format(OutputMessages.RaceCreated, name);
            }
            throw new ArgumentException(string.Format(ExceptionMessages.RaceExists, name));
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            int laps = race.Laps;
            List<IDriver> drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(laps)).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {drivers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {drivers[1].Name} is second in {race.Name} race.");
            sb.Append($"Driver {drivers[2].Name} is third in {race.Name} race.");
            return sb.ToString();
        }
    }
}
