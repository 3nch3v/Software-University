using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<IInstrument> instruments = dwarf.Instruments.ToList();

            if (dwarf.Energy > 0 && instruments.Count > 0)
            {
                

                while (true)
                {
                    if (present.IsDone() || instruments.Count == 0 || dwarf.Energy == 0)
                    {
                        break;
                    }

                    IInstrument instrument = instruments.First();

                    dwarf.Work();
                    instrument.Use();

                    if (instrument.IsBroken())
                    {
                        instruments.Remove(instrument);
                        dwarf.Instruments.Remove(instrument);
                    }

                    present.GetCrafted();
                }
            }
        }
    }
}
