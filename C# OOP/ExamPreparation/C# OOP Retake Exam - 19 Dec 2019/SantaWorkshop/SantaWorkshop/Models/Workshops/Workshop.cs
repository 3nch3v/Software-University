
using System;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Instruments.Any() 
                   && dwarf.Energy > 0)
            {
                IInstrument instrument = dwarf.Instruments.First();

                while (!present.IsDone() 
                       && dwarf.Energy > 0 
                       && !instrument.IsBroken())
                {
                    present.GetCrafted();
                    dwarf.Work();
                    instrument.Use();
                }

                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
