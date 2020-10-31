
using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Core.Contarcts;
using MilitaryElite.Exceptions;
using MilitaryElite.Exeptions;
using MilitaryElite.Interfaces;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> data;


        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            data = new List<ISoldier>();
        }


        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] currArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = currArgs[0];
                int id = int.Parse(currArgs[1]);
                string firstName = currArgs[2];
                string lastName = currArgs[3];

                ISoldier soldier = null;

                if (command == "Private")
                {
                    decimal salary = decimal.Parse(currArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }

                else if (command == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(currArgs[4]);
                    int[] ids = currArgs.Skip(5).Select(int.Parse).ToArray();

                    ILieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var currId in ids)
                    {
                        if (data.Any(p => p.Id == currId))
                        {
                            ISoldier currSoldier = data.First(p => p.Id == currId);
                            lieutenant.AddPrivate(currSoldier);
                        }
                    }

                    soldier = lieutenant;
                }

                else if (command == "Engineer")
                {
                    decimal salary = decimal.Parse(currArgs[4]);
                    string corp = currArgs[5];

                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                        string[] currRepairs = currArgs.Skip(6).ToArray();

                        for (int i = 0; i < currRepairs.Length; i += 2)
                        {
                            string name = currRepairs[i];
                            int hours = int.Parse(currRepairs[i + 1]);

                            IRepair repair = new Repair(name, hours);
                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException e)
                    {
                        continue;
                    }
                }

                else if (command == "Commando")
                {
                    decimal salary = decimal.Parse(currArgs[4]);
                    string corp = currArgs[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corp);

                        string[] currMissions = currArgs.Skip(6).ToArray();

                        for (int i = 0; i < currMissions.Length; i += 2)
                        {
                            try
                            {
                                string name = currMissions[i];
                                string state = currMissions[i + 1];

                                IMission mission = new Mission(name, state);

                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException e)
                            {
                                continue;
                            }
                        }

                        soldier = commando;
                    }

                    catch (InvalidCorpsException e)
                    {
                        continue;
                    }

                }

                else if (command == "Spy")
                {
                    int codeNumber = int.Parse(currArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                data.Add(soldier);
            }

            foreach (var soldier in data)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
