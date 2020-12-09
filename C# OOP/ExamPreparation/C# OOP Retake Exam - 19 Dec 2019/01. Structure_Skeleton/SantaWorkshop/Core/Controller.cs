using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private const int READY_DWARF_ENERGY = 50;

        private DwarfRepository dwarfRepository;
        private PresentRepository presentRepository;

        public Controller()
        {
            dwarfRepository = new DwarfRepository();
            presentRepository = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            dwarfRepository.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = dwarfRepository.FindByName(dwarfName);

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
            presentRepository.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            List<IDwarf> dwarves = dwarfRepository.Models
                .Where(d => d.Energy >= READY_DWARF_ENERGY)
                .OrderByDescending(d => d.Energy)
                .ToList();

            if (dwarves.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            IPresent present = presentRepository.FindByName(presentName);

            Workshop workshop = new Workshop();

            while (true)
            {
                IDwarf dwarf = dwarves.FirstOrDefault(d => d.Energy > 0 && d.Instruments.Count > 0);

                if (dwarf == null)
                {
                    break;
                }

                workshop.Craft(present, dwarf);

                if (dwarf.Energy == 0)
                {
                    dwarfRepository.Remove(dwarf);
                }

                if (present.IsDone())
                {
                    return string.Format(OutputMessages.PresentIsDone, presentName);
                }
            }

            return string.Format(OutputMessages.PresentIsNotDone, presentName);
        }

        public string Report()
        {
            int countCraftedPresents = presentRepository.Models.Count(p => p.IsDone());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in dwarfRepository.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Count} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
