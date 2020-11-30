using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MIN_NAME_LENGTH = 5;

        private string name;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_NAME_LENGTH));
                }

                name = value;
            }
        }
        
        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }


        public void WinRace()
        {
            NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            Car = car;
            CanParticipate = true;
        }
    }
}
