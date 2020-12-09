using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            dwarfs = new DwarfRepository();
            presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            IDwarf dwarf;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }

            else
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = dwarfs.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();
            IPresent present = presents.FindByName(presentName);

            ICollection<IDwarf> selectedDwarfs = this.dwarfs.Models
                .Where(d => d.Energy >= 50)
                .OrderByDescending(d => d.Energy)
                .ToList();

            if (!selectedDwarfs.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }


            while (selectedDwarfs.Any())
            {
                IDwarf currDwarf = selectedDwarfs.First();

                workshop.Craft(present, currDwarf);

                if (!currDwarf.Instruments.Any())
                {
                    selectedDwarfs.Remove(currDwarf);
                }

                if (currDwarf.Energy == 0)
                {
                    selectedDwarfs.Remove(currDwarf);
                    dwarfs.Remove(currDwarf);
                }

                if (present.IsDone())
                {
                    break;
                }
            }

            if (present.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }

            return string.Format(OutputMessages.PresentIsNotDone, presentName);
        }


        public string Report()
        {
            int countCraftedPresents = presents.Models.Count(p => p.IsDone());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Count(i => !i.IsBroken())} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
