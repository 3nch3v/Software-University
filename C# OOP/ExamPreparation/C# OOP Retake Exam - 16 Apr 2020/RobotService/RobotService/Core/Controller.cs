using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Chip chipProcedure;
        private TechCheck check;
        private Rest rest;
        private Work work;
        private Charge charge;
        private Polish polish;

        public Controller()
        {
            garage = new Garage();
            chipProcedure = new Chip();
            check = new TechCheck();
            rest = new Rest();
            work = new Work();
            charge = new Charge();
            polish = new Polish();
        }

        private void CheckIfRobotexist(string name)
        {
            if (!garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType != "HouseholdRobot" && robotType != "PetRobot" && robotType != "WalkerRobot")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }

            garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            chipProcedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            check.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;


            work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotexist(robotName);

            IRobot robot = garage.Robots.First(r => r.Key == robotName).Value;
            garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {
            if (procedureType == "Charge")
            {
                return charge.History();
            }
            else if (procedureType == "Chip")
            {
                return chipProcedure.History();
            }

            else if (procedureType == "Polish")
            {
                return polish.History();
            }

            else if (procedureType == "Rest")
            {
                return rest.History();
            }

            else if (procedureType == "TechCheck")
            {
                return check.History();
            }

            else if (procedureType == "Work")
            {
                return work.History();
            }

            else
            {
                throw new InvalidOperationException("Incorrect procedure type");
            }
        }
    }
}
