using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> drivers;
        private IRepository<IRace> races;
        private IRepository<ICar> cars;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            races= new RaceRepository();
            cars = new CarRepository();
        }


        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }


        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            else if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }


        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }


        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }


        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }


        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            //IDriver[] topDrivers = drivers.GetAll()
            //    .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
            //    .Take(3)
            //    .ToArray();

            //races.Remove(races.GetByName(raceName));

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, topDrivers[0].Name, raceName));
            //sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, topDrivers[1].Name, raceName));
            //sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, topDrivers[2].Name, raceName));

            //return sb.ToString().TrimEnd();


            List<IDriver> winnersList = race
                .Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            races.Remove(races.GetByName(raceName));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winnersList[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winnersList[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winnersList[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
